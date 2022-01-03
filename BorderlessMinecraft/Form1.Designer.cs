//Copyright (C) 2019 Riley Nielsen

//This file is part of Borderless Minecraft.

//   Borderless Minecraft is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    Borderless Minecraft is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with Borderless Minecraft.  If not, see<https://www.gnu.org/licenses/>.

namespace BorderlessMinecraft
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.debugInstructionsLabel = new System.Windows.Forms.Label();
            this.goBorderlessButton = new System.Windows.Forms.Button();
            this.processesListBox = new System.Windows.Forms.ListBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.setTitleButton = new System.Windows.Forms.Button();
            this.mainTitlePictureBox = new System.Windows.Forms.PictureBox();
            this.advancedCheckBox = new System.Windows.Forms.CheckBox();
            this.xPosTextBox = new System.Windows.Forms.TextBox();
            this.xPosLabel = new System.Windows.Forms.Label();
            this.yPosLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.yPosTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.newTitleLabel = new System.Windows.Forms.Label();
            this.newTitleTextBox = new System.Windows.Forms.TextBox();
            this.helpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.restoreWindowButton = new System.Windows.Forms.Button();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ToolTipContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenu = new System.Windows.Forms.MenuStrip();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.startOnBootMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMinimizedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticBorderlessMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preserveTaskbarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllClientsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainTitlePictureBox)).BeginInit();
            this.ToolTipContextMenu.SuspendLayout();
            this.SettingsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // debugInstructionsLabel
            // 
            this.debugInstructionsLabel.AutoSize = true;
            this.debugInstructionsLabel.Location = new System.Drawing.Point(66, 83);
            this.debugInstructionsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.debugInstructionsLabel.Name = "debugInstructionsLabel";
            this.debugInstructionsLabel.Size = new System.Drawing.Size(409, 13);
            this.debugInstructionsLabel.TabIndex = 1;
            this.debugInstructionsLabel.Text = "Select the session of Minecraft you want to make borderless and click \'Go Borderl" +
    "ess\'";
            // 
            // goBorderlessButton
            // 
            this.goBorderlessButton.Location = new System.Drawing.Point(378, 209);
            this.goBorderlessButton.Margin = new System.Windows.Forms.Padding(2);
            this.goBorderlessButton.Name = "goBorderlessButton";
            this.goBorderlessButton.Size = new System.Drawing.Size(97, 28);
            this.goBorderlessButton.TabIndex = 2;
            this.goBorderlessButton.Text = "Go Borderless!";
            this.goBorderlessButton.UseVisualStyleBackColor = true;
            this.goBorderlessButton.Click += new System.EventHandler(this.goBorderlessButton_Click);
            // 
            // processesListBox
            // 
            this.processesListBox.FormattingEnabled = true;
            this.processesListBox.Location = new System.Drawing.Point(69, 117);
            this.processesListBox.Name = "processesListBox";
            this.processesListBox.Size = new System.Drawing.Size(304, 121);
            this.processesListBox.TabIndex = 4;
            this.processesListBox.SelectedIndexChanged += new System.EventHandler(this.processesListBox_SelectedIndexChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(378, 117);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(97, 28);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.Text = "Refresh List";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // setTitleButton
            // 
            this.setTitleButton.Location = new System.Drawing.Point(378, 147);
            this.setTitleButton.Name = "setTitleButton";
            this.setTitleButton.Size = new System.Drawing.Size(97, 29);
            this.setTitleButton.TabIndex = 6;
            this.setTitleButton.Text = "Set Title";
            this.setTitleButton.UseVisualStyleBackColor = true;
            this.setTitleButton.Click += new System.EventHandler(this.setTitleButton_Click);
            // 
            // mainTitlePictureBox
            // 
            this.mainTitlePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mainTitlePictureBox.Image")));
            this.mainTitlePictureBox.Location = new System.Drawing.Point(23, 27);
            this.mainTitlePictureBox.Name = "mainTitlePictureBox";
            this.mainTitlePictureBox.Size = new System.Drawing.Size(496, 50);
            this.mainTitlePictureBox.TabIndex = 7;
            this.mainTitlePictureBox.TabStop = false;
            // 
            // advancedCheckBox
            // 
            this.advancedCheckBox.AutoSize = true;
            this.advancedCheckBox.Location = new System.Drawing.Point(19, 278);
            this.advancedCheckBox.Name = "advancedCheckBox";
            this.advancedCheckBox.Size = new System.Drawing.Size(75, 17);
            this.advancedCheckBox.TabIndex = 8;
            this.advancedCheckBox.Text = "Advanced";
            this.advancedCheckBox.UseVisualStyleBackColor = true;
            this.advancedCheckBox.CheckedChanged += new System.EventHandler(this.advancedCheckBox_CheckedChanged);
            // 
            // xPosTextBox
            // 
            this.xPosTextBox.Location = new System.Drawing.Point(130, 295);
            this.xPosTextBox.Name = "xPosTextBox";
            this.xPosTextBox.Size = new System.Drawing.Size(70, 20);
            this.xPosTextBox.TabIndex = 9;
            this.xPosTextBox.Visible = false;
            this.xPosTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AdvancedParamsTextBox_Validating);
            this.xPosTextBox.Validated += new System.EventHandler(this.AdvancedParamsTextBox_Validated);
            // 
            // xPosLabel
            // 
            this.xPosLabel.AutoSize = true;
            this.xPosLabel.Location = new System.Drawing.Point(130, 279);
            this.xPosLabel.Name = "xPosLabel";
            this.xPosLabel.Size = new System.Drawing.Size(54, 13);
            this.xPosLabel.TabIndex = 10;
            this.xPosLabel.Text = "X Position";
            this.xPosLabel.Visible = false;
            // 
            // yPosLabel
            // 
            this.yPosLabel.AutoSize = true;
            this.yPosLabel.Location = new System.Drawing.Point(203, 279);
            this.yPosLabel.Name = "yPosLabel";
            this.yPosLabel.Size = new System.Drawing.Size(54, 13);
            this.yPosLabel.TabIndex = 11;
            this.yPosLabel.Text = "Y Position";
            this.yPosLabel.Visible = false;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(279, 279);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(37, 13);
            this.widthLabel.TabIndex = 12;
            this.widthLabel.Text = "X Size";
            this.widthLabel.Visible = false;
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(355, 279);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(37, 13);
            this.heightLabel.TabIndex = 13;
            this.heightLabel.Text = "Y Size";
            this.heightLabel.Visible = false;
            // 
            // yPosTextBox
            // 
            this.yPosTextBox.Location = new System.Drawing.Point(206, 295);
            this.yPosTextBox.Name = "yPosTextBox";
            this.yPosTextBox.Size = new System.Drawing.Size(70, 20);
            this.yPosTextBox.TabIndex = 14;
            this.yPosTextBox.Visible = false;
            this.yPosTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AdvancedParamsTextBox_Validating);
            this.yPosTextBox.Validated += new System.EventHandler(this.AdvancedParamsTextBox_Validated);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(282, 295);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(70, 20);
            this.widthTextBox.TabIndex = 15;
            this.widthTextBox.Visible = false;
            this.widthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AdvancedParamsTextBox_Validating);
            this.widthTextBox.Validated += new System.EventHandler(this.AdvancedParamsTextBox_Validated);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(358, 295);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(70, 20);
            this.heightTextBox.TabIndex = 16;
            this.heightTextBox.Visible = false;
            this.heightTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.AdvancedParamsTextBox_Validating);
            this.heightTextBox.Validated += new System.EventHandler(this.AdvancedParamsTextBox_Validated);
            // 
            // newTitleLabel
            // 
            this.newTitleLabel.AutoSize = true;
            this.newTitleLabel.Location = new System.Drawing.Point(69, 245);
            this.newTitleLabel.Name = "newTitleLabel";
            this.newTitleLabel.Size = new System.Drawing.Size(103, 13);
            this.newTitleLabel.TabIndex = 17;
            this.newTitleLabel.Text = "New Title (Optional):";
            // 
            // newTitleTextBox
            // 
            this.newTitleTextBox.Location = new System.Drawing.Point(178, 242);
            this.newTitleTextBox.Name = "newTitleTextBox";
            this.newTitleTextBox.Size = new System.Drawing.Size(195, 20);
            this.newTitleTextBox.TabIndex = 18;
            // 
            // helpLinkLabel
            // 
            this.helpLinkLabel.AutoSize = true;
            this.helpLinkLabel.Location = new System.Drawing.Point(490, 282);
            this.helpLinkLabel.Name = "helpLinkLabel";
            this.helpLinkLabel.Size = new System.Drawing.Size(29, 13);
            this.helpLinkLabel.TabIndex = 19;
            this.helpLinkLabel.TabStop = true;
            this.helpLinkLabel.Text = "Help";
            this.helpLinkLabel.Visible = false;
            // 
            // restoreWindowButton
            // 
            this.restoreWindowButton.Location = new System.Drawing.Point(378, 178);
            this.restoreWindowButton.Name = "restoreWindowButton";
            this.restoreWindowButton.Size = new System.Drawing.Size(97, 29);
            this.restoreWindowButton.TabIndex = 20;
            this.restoreWindowButton.Text = "Restore Window";
            this.restoreWindowButton.UseVisualStyleBackColor = true;
            this.restoreWindowButton.Click += new System.EventHandler(this.restoreWindowButton_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.ToolTipContextMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Borderless Minecraft";
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_Click);
            // 
            // ToolTipContextMenu
            // 
            this.ToolTipContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit,
            this.ContextMenuSettings});
            this.ToolTipContextMenu.Name = "ToolTipContextMenu";
            this.ToolTipContextMenu.Size = new System.Drawing.Size(117, 48);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(116, 22);
            this.Exit.Text = "Exit";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // ContextMenuSettings
            // 
            this.ContextMenuSettings.Name = "ContextMenuSettings";
            this.ContextMenuSettings.Size = new System.Drawing.Size(116, 22);
            this.ContextMenuSettings.Text = "Settings";
            this.ContextMenuSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsMenu
            // 
            this.SettingsMenu.BackColor = System.Drawing.Color.White;
            this.SettingsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings});
            this.SettingsMenu.Location = new System.Drawing.Point(0, 0);
            this.SettingsMenu.Name = "SettingsMenu";
            this.SettingsMenu.Size = new System.Drawing.Size(543, 24);
            this.SettingsMenu.TabIndex = 23;
            this.SettingsMenu.Text = "menuStrip1";
            // 
            // Settings
            // 
            this.Settings.Checked = true;
            this.Settings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startOnBootMenuItem,
            this.startMinimizedMenuItem,
            this.minimizeToTrayMenuItem,
            this.automaticBorderlessMenuItem,
            this.preserveTaskbarMenuItem,
            this.showAllClientsMenuItem});
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(61, 20);
            this.Settings.Text = "Settings";
            // 
            // startOnBootMenuItem
            // 
            this.startOnBootMenuItem.CheckOnClick = true;
            this.startOnBootMenuItem.Name = "startOnBootMenuItem";
            this.startOnBootMenuItem.Size = new System.Drawing.Size(187, 22);
            this.startOnBootMenuItem.Text = "Start on Boot";
            this.startOnBootMenuItem.CheckedChanged += new System.EventHandler(this.StartOnBootItem_CheckedChanged);
            // 
            // startMinimizedMenuItem
            // 
            this.startMinimizedMenuItem.CheckOnClick = true;
            this.startMinimizedMenuItem.Name = "startMinimizedMenuItem";
            this.startMinimizedMenuItem.Size = new System.Drawing.Size(187, 22);
            this.startMinimizedMenuItem.Text = "Start Minimized";
            this.startMinimizedMenuItem.CheckedChanged += new System.EventHandler(this.StartMinimizedItem_CheckedChanged);
            // 
            // minimizeToTrayMenuItem
            // 
            this.minimizeToTrayMenuItem.CheckOnClick = true;
            this.minimizeToTrayMenuItem.Name = "minimizeToTrayMenuItem";
            this.minimizeToTrayMenuItem.Size = new System.Drawing.Size(187, 22);
            this.minimizeToTrayMenuItem.Text = "Minimize to Tray";
            this.minimizeToTrayMenuItem.CheckedChanged += new System.EventHandler(this.MinimizeToTrayItem_CheckedChanged);
            // 
            // automaticBorderlessMenuItem
            // 
            this.automaticBorderlessMenuItem.CheckOnClick = true;
            this.automaticBorderlessMenuItem.Name = "automaticBorderlessMenuItem";
            this.automaticBorderlessMenuItem.Size = new System.Drawing.Size(187, 22);
            this.automaticBorderlessMenuItem.Text = "Automatic Borderless";
            this.automaticBorderlessMenuItem.ToolTipText = "Requires administrator privleges";
            this.automaticBorderlessMenuItem.CheckedChanged += new System.EventHandler(this.AutoBorderlessItem_CheckedChanged);
            // 
            // preserveTaskbarMenuItem
            // 
            this.preserveTaskbarMenuItem.CheckOnClick = true;
            this.preserveTaskbarMenuItem.Name = "preserveTaskbarMenuItem";
            this.preserveTaskbarMenuItem.Size = new System.Drawing.Size(187, 22);
            this.preserveTaskbarMenuItem.Text = "Preserve Taskbar";
            this.preserveTaskbarMenuItem.ToolTipText = "The taskbar will be visible below Minecraft";
            this.preserveTaskbarMenuItem.CheckedChanged += new System.EventHandler(this.PreserveTaskBarItem_CheckedChanged);
            // 
            // showAllClientsMenuItem
            // 
            this.showAllClientsMenuItem.CheckOnClick = true;
            this.showAllClientsMenuItem.Name = "showAllClientsMenuItem";
            this.showAllClientsMenuItem.Size = new System.Drawing.Size(187, 22);
            this.showAllClientsMenuItem.Text = "Show All Clients";
            this.showAllClientsMenuItem.ToolTipText = "Shows non-vanilla MC clients, but may show other Java applications as well";
            this.showAllClientsMenuItem.CheckedChanged += new System.EventHandler(this.ShowAllClientsItem_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(543, 322);
            this.Controls.Add(this.SettingsMenu);
            this.Controls.Add(this.restoreWindowButton);
            this.Controls.Add(this.helpLinkLabel);
            this.Controls.Add(this.newTitleTextBox);
            this.Controls.Add(this.newTitleLabel);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.yPosTextBox);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.yPosLabel);
            this.Controls.Add(this.xPosLabel);
            this.Controls.Add(this.xPosTextBox);
            this.Controls.Add(this.advancedCheckBox);
            this.Controls.Add(this.mainTitlePictureBox);
            this.Controls.Add(this.setTitleButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.processesListBox);
            this.Controls.Add(this.goBorderlessButton);
            this.Controls.Add(this.debugInstructionsLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.SettingsMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Borderless Minecraft <version>";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mainTitlePictureBox)).EndInit();
            this.ToolTipContextMenu.ResumeLayout(false);
            this.SettingsMenu.ResumeLayout(false);
            this.SettingsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label debugInstructionsLabel;
        private System.Windows.Forms.Button goBorderlessButton;
        private System.Windows.Forms.ListBox processesListBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button setTitleButton;
        private System.Windows.Forms.PictureBox mainTitlePictureBox;
        private System.Windows.Forms.CheckBox advancedCheckBox;
        private System.Windows.Forms.TextBox xPosTextBox;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox yPosTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label newTitleLabel;
        private System.Windows.Forms.TextBox newTitleTextBox;
        private System.Windows.Forms.LinkLabel helpLinkLabel;
        private System.Windows.Forms.Button restoreWindowButton;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip ToolTipContextMenu;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.MenuStrip SettingsMenu;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ToolStripMenuItem startOnBootMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMinimizedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticBorderlessMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuSettings;
        private System.Windows.Forms.ToolStripMenuItem preserveTaskbarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllClientsMenuItem;
    }
}

