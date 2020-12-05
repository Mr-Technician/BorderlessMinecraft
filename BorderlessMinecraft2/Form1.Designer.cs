
namespace BorderlessMinecraft2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProcessList = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.TitleButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.BorderlessButton = new System.Windows.Forms.Button();
            this.CustomXPosition = new System.Windows.Forms.TextBox();
            this.CustomYPosition = new System.Windows.Forms.TextBox();
            this.CustomXSize = new System.Windows.Forms.TextBox();
            this.CustomYSize = new System.Windows.Forms.TextBox();
            this.AdvancedModeCheckBox = new System.Windows.Forms.CheckBox();
            this.PreserveTaskbarCheckBox = new System.Windows.Forms.CheckBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.xSizeLabel = new System.Windows.Forms.Label();
            this.ySizeLabel = new System.Windows.Forms.Label();
            this.yPositionLabel = new System.Windows.Forms.Label();
            this.xPositionLabel = new System.Windows.Forms.Label();
            this.AdvancedModePanel = new System.Windows.Forms.Panel();
            this.AdvancedModePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessList
            // 
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.ItemHeight = 15;
            this.ProcessList.Location = new System.Drawing.Point(12, 25);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(299, 109);
            this.ProcessList.TabIndex = 0;
            this.ProcessList.SelectedIndexChanged += new System.EventHandler(this.ProcessList_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(317, 25);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(90, 25);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh List";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // TitleButton
            // 
            this.TitleButton.Location = new System.Drawing.Point(317, 54);
            this.TitleButton.Name = "TitleButton";
            this.TitleButton.Size = new System.Drawing.Size(90, 25);
            this.TitleButton.TabIndex = 2;
            this.TitleButton.Text = "Set Title";
            this.TitleButton.UseVisualStyleBackColor = true;
            this.TitleButton.Click += new System.EventHandler(this.TitleButton_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(317, 83);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(90, 25);
            this.RestoreButton.TabIndex = 3;
            this.RestoreButton.Text = "Restore Window";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // BorderlessButton
            // 
            this.BorderlessButton.Location = new System.Drawing.Point(317, 112);
            this.BorderlessButton.Name = "BorderlessButton";
            this.BorderlessButton.Size = new System.Drawing.Size(90, 25);
            this.BorderlessButton.TabIndex = 4;
            this.BorderlessButton.Text = "Go Borderless!";
            this.BorderlessButton.UseVisualStyleBackColor = true;
            this.BorderlessButton.Click += new System.EventHandler(this.BorderlessButton_Click);
            // 
            // CustomXPosition
            // 
            this.CustomXPosition.Location = new System.Drawing.Point(74, 0);
            this.CustomXPosition.Name = "CustomXPosition";
            this.CustomXPosition.Size = new System.Drawing.Size(100, 23);
            this.CustomXPosition.TabIndex = 5;
            // 
            // CustomYPosition
            // 
            this.CustomYPosition.Location = new System.Drawing.Point(74, 29);
            this.CustomYPosition.Name = "CustomYPosition";
            this.CustomYPosition.Size = new System.Drawing.Size(100, 23);
            this.CustomYPosition.TabIndex = 6;
            // 
            // CustomXSize
            // 
            this.CustomXSize.Location = new System.Drawing.Point(222, 0);
            this.CustomXSize.Name = "CustomXSize";
            this.CustomXSize.Size = new System.Drawing.Size(100, 23);
            this.CustomXSize.TabIndex = 7;
            // 
            // CustomYSize
            // 
            this.CustomYSize.Location = new System.Drawing.Point(222, 29);
            this.CustomYSize.Name = "CustomYSize";
            this.CustomYSize.Size = new System.Drawing.Size(100, 23);
            this.CustomYSize.TabIndex = 8;
            // 
            // AdvancedModeCheckBox
            // 
            this.AdvancedModeCheckBox.AutoSize = true;
            this.AdvancedModeCheckBox.Location = new System.Drawing.Point(317, 163);
            this.AdvancedModeCheckBox.Name = "AdvancedModeCheckBox";
            this.AdvancedModeCheckBox.Size = new System.Drawing.Size(151, 19);
            this.AdvancedModeCheckBox.TabIndex = 9;
            this.AdvancedModeCheckBox.Text = "Enable Advanced Mode";
            this.AdvancedModeCheckBox.UseVisualStyleBackColor = true;
            this.AdvancedModeCheckBox.CheckedChanged += new System.EventHandler(this.AdvancedModeCheckBox_CheckedChanged);
            // 
            // PreserveTaskbarCheckBox
            // 
            this.PreserveTaskbarCheckBox.AutoSize = true;
            this.PreserveTaskbarCheckBox.Location = new System.Drawing.Point(317, 141);
            this.PreserveTaskbarCheckBox.Name = "PreserveTaskbarCheckBox";
            this.PreserveTaskbarCheckBox.Size = new System.Drawing.Size(112, 19);
            this.PreserveTaskbarCheckBox.TabIndex = 10;
            this.PreserveTaskbarCheckBox.Text = "Preserve Taskbar";
            this.PreserveTaskbarCheckBox.UseVisualStyleBackColor = true;
            this.PreserveTaskbarCheckBox.CheckedChanged += new System.EventHandler(this.PreserveTaskbarCheckBox_CheckedChanged);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(134, 139);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(177, 23);
            this.TitleTextBox.TabIndex = 11;
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Location = new System.Drawing.Point(12, 7);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(253, 15);
            this.MainLabel.TabIndex = 12;
            this.MainLabel.Text = "Select a window below to modify its properties";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(12, 141);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(116, 15);
            this.TitleLabel.TabIndex = 13;
            this.TitleLabel.Text = "New Title (Optional):";
            // 
            // xSizeLabel
            // 
            this.xSizeLabel.AutoSize = true;
            this.xSizeLabel.Location = new System.Drawing.Point(180, 3);
            this.xSizeLabel.Name = "xSizeLabel";
            this.xSizeLabel.Size = new System.Drawing.Size(36, 15);
            this.xSizeLabel.TabIndex = 14;
            this.xSizeLabel.Text = "x Size";
            // 
            // ySizeLabel
            // 
            this.ySizeLabel.AutoSize = true;
            this.ySizeLabel.Location = new System.Drawing.Point(180, 32);
            this.ySizeLabel.Name = "ySizeLabel";
            this.ySizeLabel.Size = new System.Drawing.Size(36, 15);
            this.ySizeLabel.TabIndex = 15;
            this.ySizeLabel.Text = "y Size";
            // 
            // yPositionLabel
            // 
            this.yPositionLabel.AutoSize = true;
            this.yPositionLabel.Location = new System.Drawing.Point(9, 29);
            this.yPositionLabel.Name = "yPositionLabel";
            this.yPositionLabel.Size = new System.Drawing.Size(59, 15);
            this.yPositionLabel.TabIndex = 16;
            this.yPositionLabel.Text = "y Position";
            // 
            // xPositionLabel
            // 
            this.xPositionLabel.AutoSize = true;
            this.xPositionLabel.Location = new System.Drawing.Point(9, 3);
            this.xPositionLabel.Name = "xPositionLabel";
            this.xPositionLabel.Size = new System.Drawing.Size(59, 15);
            this.xPositionLabel.TabIndex = 17;
            this.xPositionLabel.Text = "x Position";
            // 
            // AdvancedModePanel
            // 
            this.AdvancedModePanel.Controls.Add(this.CustomXPosition);
            this.AdvancedModePanel.Controls.Add(this.xPositionLabel);
            this.AdvancedModePanel.Controls.Add(this.CustomYPosition);
            this.AdvancedModePanel.Controls.Add(this.yPositionLabel);
            this.AdvancedModePanel.Controls.Add(this.CustomXSize);
            this.AdvancedModePanel.Controls.Add(this.ySizeLabel);
            this.AdvancedModePanel.Controls.Add(this.CustomYSize);
            this.AdvancedModePanel.Controls.Add(this.xSizeLabel);
            this.AdvancedModePanel.Location = new System.Drawing.Point(12, 188);
            this.AdvancedModePanel.Name = "AdvancedModePanel";
            this.AdvancedModePanel.Size = new System.Drawing.Size(332, 62);
            this.AdvancedModePanel.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 253);
            this.Controls.Add(this.AdvancedModePanel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.PreserveTaskbarCheckBox);
            this.Controls.Add(this.AdvancedModeCheckBox);
            this.Controls.Add(this.BorderlessButton);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.TitleButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.ProcessList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.AdvancedModePanel.ResumeLayout(false);
            this.AdvancedModePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ProcessList;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button TitleButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.Button BorderlessButton;
        private System.Windows.Forms.TextBox CustomXPosition;
        private System.Windows.Forms.TextBox CustomYPosition;
        private System.Windows.Forms.TextBox CustomXSize;
        private System.Windows.Forms.TextBox CustomYSize;
        private System.Windows.Forms.CheckBox AdvancedModeCheckBox;
        private System.Windows.Forms.CheckBox PreserveTaskbarCheckBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label xSizeLabel;
        private System.Windows.Forms.Label ySizeLabel;
        private System.Windows.Forms.Label yPositionLabel;
        private System.Windows.Forms.Label xPositionLabel;
        private System.Windows.Forms.Panel AdvancedModePanel;
    }
}

