namespace MCRenamer {
    partial class MinecraftNamer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinecraftNamer));
            this.namesBox = new System.Windows.Forms.ListBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.removeButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.reLaunchButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // namesBox
            // 
            this.namesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.namesBox.FormattingEnabled = true;
            this.namesBox.ItemHeight = 31;
            this.namesBox.Location = new System.Drawing.Point(0, 70);
            this.namesBox.Margin = new System.Windows.Forms.Padding(8);
            this.namesBox.Name = "namesBox";
            this.namesBox.Size = new System.Drawing.Size(1037, 357);
            this.namesBox.TabIndex = 0;
            this.namesBox.SelectedValueChanged += new System.EventHandler(this.namesBox_SelectedValueChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(8, 8);
            this.nameBox.Margin = new System.Windows.Forms.Padding(8);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(373, 38);
            this.nameBox.TabIndex = 1;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.nameBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.removeButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.renameButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 70);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(613, 8);
            this.removeButton.Margin = new System.Windows.Forms.Padding(8);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(200, 54);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Enabled = false;
            this.renameButton.Location = new System.Drawing.Point(829, 8);
            this.renameButton.Margin = new System.Windows.Forms.Padding(8);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(200, 54);
            this.renameButton.TabIndex = 4;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(397, 8);
            this.addButton.Margin = new System.Windows.Forms.Padding(8);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(200, 54);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.reLaunchButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Controls.Add(this.loadButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 427);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1037, 70);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // reLaunchButton
            // 
            this.reLaunchButton.Location = new System.Drawing.Point(829, 8);
            this.reLaunchButton.Margin = new System.Windows.Forms.Padding(8);
            this.reLaunchButton.Name = "reLaunchButton";
            this.reLaunchButton.Size = new System.Drawing.Size(200, 54);
            this.reLaunchButton.TabIndex = 2;
            this.reLaunchButton.Text = "ReLaunch";
            this.reLaunchButton.UseVisualStyleBackColor = true;
            this.reLaunchButton.Click += new System.EventHandler(this.reLaunchButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(613, 8);
            this.saveButton.Margin = new System.Windows.Forms.Padding(8);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 54);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(397, 8);
            this.loadButton.Margin = new System.Windows.Forms.Padding(8);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(200, 54);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Visible = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // MinecraftNamer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 497);
            this.Controls.Add(this.namesBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "MinecraftNamer";
            this.Text = "Minecraft namer 2.1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox namesBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button reLaunchButton;
    }
}

