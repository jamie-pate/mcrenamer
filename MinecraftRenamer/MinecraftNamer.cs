using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Management;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace MCRenamer {
    public partial class MinecraftNamer : Form {

        class ProfileHolder: INotifyPropertyChanged {
            public ProfileHolder(dynamic profile) {
                this.profile = profile;
                PropertyChanged = null;
            }
            public ProfileHolder(String name) {
                this.profile = new JProperty(Guid.NewGuid().ToString().Replace("-", ""), new JObject(new JProperty("displayName", name)));
                PropertyChanged = null;
            }
            public dynamic profile;

            public event PropertyChangedEventHandler PropertyChanged;

            public String name {
                get { return profile.Value.displayName.Value; }
                set {
                    profile.Value.displayName.Value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("name"));
                }
            }
        }

        class LauncherProfiles {
            public dynamic jsonObj;
            public dynamic profiles;
            private String jsonPath;
            public LauncherProfiles() {
                String path = Environment.ExpandEnvironmentVariables("%APPDATA%\\.minecraft");
                jsonPath = $"{path}\\launcher_profiles_namer.json";
                profiles = new Newtonsoft.Json.Linq.JObject();
                jsonObj = JsonConvert.DeserializeObject(File.ReadAllText(jsonPath)) as Newtonsoft.Json.Linq.JObject;
                foreach (var p in jsonObj) {
                    profiles[p.Name] = p.Value;
                }
            }

            public void Save() {
                jsonObj = profiles;
                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(jsonObj, Formatting.Indented));
            }
        }


        BindingList<ProfileHolder> profiles = new BindingList<ProfileHolder>();

        public MinecraftNamer() {
            InitializeComponent();
            LoadProfiles();
        }

        public void LoadProfiles() {
            var lp = new LauncherProfiles();
            namesBox.BeginUpdate();
            profiles.Clear();
            foreach(var p in lp.profiles) {
                profiles.Add(new ProfileHolder(p));
            }
            namesBox.DisplayMember = "Name";
            EnableDisable();
            namesBox.DataSource = profiles;
            namesBox.EndUpdate();
        }

        public void SaveProfiles() {
            var lp = new LauncherProfiles();
            (lp.profiles as JObject).RemoveAll();
            foreach (ProfileHolder p in profiles) {
                (lp.profiles as JObject).Add(p.profile);
            }
            lp.Save();
        }

        private void EnableDisable() {
            var item = (ProfileHolder)namesBox.SelectedItem;
            renameButton.Enabled = item != null && nameBox.Text.Length > 0 && nameBox.Text != item.name;
            removeButton.Enabled = item != null && nameBox.Text.Length > 0;
            bool dup = profiles.Any(p => p.name == nameBox.Text);
            addButton.Enabled = nameBox.Text.Length > 0 && !dup;
        }

        private void namesBox_SelectedValueChanged(object sender, EventArgs e) {
            if (namesBox.SelectedItem != null) {
                nameBox.Text = ((ProfileHolder)namesBox.SelectedItem).name;
            } else {
                nameBox.Text = "";
            }
            EnableDisable();
        }

        private void addButton_Click(object sender, EventArgs e) {
            dynamic item = new ProfileHolder(nameBox.Text);
            profiles.Add(item);
            namesBox.SelectedItem = item;
            EnableDisable();
        }

        private void nameBox_TextChanged(object sender, EventArgs e) {
            EnableDisable();
        }

        private void loadButton_Click(object sender, EventArgs e) {
            LoadProfiles();
        }

        private void saveButton_Click(object sender, EventArgs e) {
            SaveProfiles();
        }

        private void removeButton_Click(object sender, EventArgs e) {
            profiles.Remove((ProfileHolder)namesBox.SelectedItem);
        }

        private void renameButton_Click(object sender, EventArgs e) {
            ProfileHolder ph = (ProfileHolder)namesBox.SelectedItem;
            ph.name = nameBox.Text;

            EnableDisable();
        }

        private List<String> jlpDirs = new List<String>();

        private void reLaunchButton_Click(object sender, EventArgs e) {
            var procs = Process.GetProcesses();
            var mclProcs = procs.Where((p) => p.ProcessName == "MinecraftLauncher");

            foreach (var process in procs) {
                if (process.ProcessName == "javaw") {
                    try {
                        var cl = GetCommandLine(process);
                        var usernameExpr = new Regex(@"--username [^ ]+");
                        var gameDirExpr = new Regex("--gameDir (?:\"([^\"]+)\" +|([^ ]+) )");
                        var jlpExpr = new Regex("(?:-Djava.library.path=\"([^\"]+)\"|-Djava.library.path=([^ ]+))");
                        
                        var firstArgExpr = new Regex("^(?:\"([^\"]+)\" +|([^ ]+) )");
                        if (cl != null) {
                            var username = ((ProfileHolder)namesBox.SelectedItem).name;
                            var newCl = firstArgExpr.Replace(usernameExpr.Replace(cl, "--username " + username), "");
                            var gameDir = gameDirExpr.Match(cl);
                            var jlp = jlpExpr.Match(cl);
                            var si = process.StartInfo;
                            si.Arguments = newCl;
                            var m = firstArgExpr.Match(cl);
                            si.FileName = m.Groups[1].Value;
                            if (si.FileName == "") {
                                si.FileName = m.Groups[2].Value;
                            }
                            si.WorkingDirectory = gameDir.Groups[1].Value;
                            if (si.WorkingDirectory == "") {
                                si.WorkingDirectory = gameDir.Groups[2].Value;
                            }
                            var jlpDir = jlp.Groups[1].Value;
                            if (jlpDir == "") {
                                jlpDir = jlp.Groups[2].Value;
                            }
                            if (jlpDir != "") {
                                jlpDirs.Add(jlpDir);
                            }
                            try {
                                var proc = Process.Start(si);
                                proc.EnableRaisingEvents = true;
                                proc.Exited += Proc_Exited;
                                proc.WaitForInputIdle(120000);
                                if (proc.WaitForExit(1000)) {
                                    System.Diagnostics.Debug.WriteLine(proc.ExitCode);
                                } else {
                                    process.Kill();
                                    foreach (var mclp in mclProcs) {
                                        mclp.Kill();
                                    }
                                }
                            } catch (Exception ex) {
                                 System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                            System.Diagnostics.Debug.WriteLine(newCl);
                        }
                    } catch (Win32Exception ex) when ((uint)ex.ErrorCode == 0x80004005) {
                        // Intentionally empty - no security access to the process.
                    } catch (InvalidOperationException) {
                        // Intentionally empty - the process exited before getting details.
                    }
                }

            }
        }

        private void Proc_Exited(object sender, EventArgs e) {
            var proc = sender as Process;
            proc.Exited -= Proc_Exited;
            var remaining = new List<String>();
            foreach(var d in jlpDirs) {
                try {
                    Directory.Delete(d, true);
                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    remaining.Add(d);
                }
            }
            jlpDirs = remaining;
        }

        private static string GetCommandLine(Process process) {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id)) {
                using (ManagementObjectCollection objects = searcher.Get()) {
                    return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
                }
            }
        }
    }
}
