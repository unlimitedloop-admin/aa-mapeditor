namespace ClientForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainContainer = new SplitContainer();
            mapFieldContainer = new SplitContainer();
            mapFieldPanel = new src.CustomControls.Map.TilingPanel();
            mapFieldInfoPanel = new Panel();
            graphicChipPanel = new src.CustomControls.Chip.ShowcasePanel();
            mainMenuStrip = new MenuStrip();
            ファイルFToolStripMenuItem = new ToolStripMenuItem();
            アプリケーションの終了XToolStripMenuItem = new ToolStripMenuItem();
            choiceChipPanel = new src.CustomControls.Chip.ChipManagedPanel();
            statusStrip = new StatusStrip();
            openGraphChipButton = new Button();
            openBinaryMapButton = new Button();
            ((System.ComponentModel.ISupportInitialize)mainContainer).BeginInit();
            mainContainer.Panel1.SuspendLayout();
            mainContainer.Panel2.SuspendLayout();
            mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mapFieldContainer).BeginInit();
            mapFieldContainer.Panel1.SuspendLayout();
            mapFieldContainer.Panel2.SuspendLayout();
            mapFieldContainer.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainContainer
            // 
            mainContainer.IsSplitterFixed = true;
            mainContainer.Location = new Point(12, 148);
            mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            mainContainer.Panel1.Controls.Add(mapFieldContainer);
            // 
            // mainContainer.Panel2
            // 
            mainContainer.Panel2.Controls.Add(graphicChipPanel);
            mainContainer.Size = new Size(1150, 605);
            mainContainer.SplitterDistance = 517;
            mainContainer.TabIndex = 0;
            // 
            // mapFieldContainer
            // 
            mapFieldContainer.Dock = DockStyle.Fill;
            mapFieldContainer.IsSplitterFixed = true;
            mapFieldContainer.Location = new Point(0, 0);
            mapFieldContainer.Name = "mapFieldContainer";
            mapFieldContainer.Orientation = Orientation.Horizontal;
            // 
            // mapFieldContainer.Panel1
            // 
            mapFieldContainer.Panel1.Controls.Add(mapFieldPanel);
            // 
            // mapFieldContainer.Panel2
            // 
            mapFieldContainer.Panel2.Controls.Add(mapFieldInfoPanel);
            mapFieldContainer.Size = new Size(517, 605);
            mapFieldContainer.SplitterDistance = 485;
            mapFieldContainer.TabIndex = 0;
            // 
            // mapFieldPanel
            // 
            mapFieldPanel.BackColor = SystemColors.AppWorkspace;
            mapFieldPanel.BorderStyle = BorderStyle.Fixed3D;
            mapFieldPanel.Dock = DockStyle.Fill;
            mapFieldPanel.Location = new Point(0, 0);
            mapFieldPanel.Name = "mapFieldPanel";
            mapFieldPanel.Size = new Size(517, 485);
            mapFieldPanel.TabIndex = 0;
            // 
            // mapFieldInfoPanel
            // 
            mapFieldInfoPanel.BackColor = SystemColors.ButtonFace;
            mapFieldInfoPanel.BorderStyle = BorderStyle.Fixed3D;
            mapFieldInfoPanel.Dock = DockStyle.Fill;
            mapFieldInfoPanel.Location = new Point(0, 0);
            mapFieldInfoPanel.Name = "mapFieldInfoPanel";
            mapFieldInfoPanel.Size = new Size(517, 116);
            mapFieldInfoPanel.TabIndex = 0;
            // 
            // graphicChipPanel
            // 
            graphicChipPanel.AutoScroll = true;
            graphicChipPanel.BackColor = SystemColors.AppWorkspace;
            graphicChipPanel.BaseImage = null;
            graphicChipPanel.BorderStyle = BorderStyle.Fixed3D;
            graphicChipPanel.Dock = DockStyle.Fill;
            graphicChipPanel.Location = new Point(0, 0);
            graphicChipPanel.Name = "graphicChipPanel";
            graphicChipPanel.Size = new Size(629, 605);
            graphicChipPanel.TabIndex = 0;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { ファイルFToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1174, 24);
            mainMenuStrip.TabIndex = 1;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            ファイルFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { アプリケーションの終了XToolStripMenuItem });
            ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            ファイルFToolStripMenuItem.Size = new Size(70, 20);
            ファイルFToolStripMenuItem.Text = "ファイル (&F)";
            // 
            // アプリケーションの終了XToolStripMenuItem
            // 
            アプリケーションの終了XToolStripMenuItem.Name = "アプリケーションの終了XToolStripMenuItem";
            アプリケーションの終了XToolStripMenuItem.Size = new Size(195, 22);
            アプリケーションの終了XToolStripMenuItem.Text = "アプリケーションの終了 (&X)";
            アプリケーションの終了XToolStripMenuItem.Click += アプリケーションの終了XToolStripMenuItem_Click;
            // 
            // choiceChipPanel
            // 
            choiceChipPanel.BackColor = SystemColors.ControlLight;
            choiceChipPanel.BorderStyle = BorderStyle.Fixed3D;
            choiceChipPanel.ChoiceChipNumber = -1;
            choiceChipPanel.Location = new Point(1120, 100);
            choiceChipPanel.Name = "choiceChipPanel";
            choiceChipPanel.Size = new Size(42, 42);
            choiceChipPanel.TabIndex = 2;
            // 
            // statusStrip
            // 
            statusStrip.Location = new Point(0, 763);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1174, 22);
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip1";
            // 
            // openGraphChipButton
            // 
            openGraphChipButton.BackColor = SystemColors.ButtonHighlight;
            openGraphChipButton.BackgroundImage = Properties.Resources.icons8_フォルダーを開く_30_blue;
            openGraphChipButton.BackgroundImageLayout = ImageLayout.None;
            openGraphChipButton.FlatStyle = FlatStyle.Flat;
            openGraphChipButton.ForeColor = SystemColors.ButtonFace;
            openGraphChipButton.Location = new Point(533, 110);
            openGraphChipButton.Margin = new Padding(0);
            openGraphChipButton.Name = "openGraphChipButton";
            openGraphChipButton.Size = new Size(32, 32);
            openGraphChipButton.TabIndex = 4;
            openGraphChipButton.UseVisualStyleBackColor = false;
            openGraphChipButton.Click += OpenGraphChipButton_Click;
            // 
            // openBinaryMapButton
            // 
            openBinaryMapButton.BackColor = SystemColors.ButtonHighlight;
            openBinaryMapButton.BackgroundImage = Properties.Resources.icons8_フォルダーを開く_30;
            openBinaryMapButton.FlatStyle = FlatStyle.Flat;
            openBinaryMapButton.ForeColor = SystemColors.ButtonFace;
            openBinaryMapButton.Location = new Point(12, 110);
            openBinaryMapButton.Name = "openBinaryMapButton";
            openBinaryMapButton.Size = new Size(32, 32);
            openBinaryMapButton.TabIndex = 5;
            openBinaryMapButton.UseVisualStyleBackColor = false;
            openBinaryMapButton.Click += OpenBinaryMapButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 785);
            Controls.Add(openBinaryMapButton);
            Controls.Add(openGraphChipButton);
            Controls.Add(statusStrip);
            Controls.Add(choiceChipPanel);
            Controls.Add(mainContainer);
            Controls.Add(mainMenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenuStrip;
            Name = "MainForm";
            mainContainer.Panel1.ResumeLayout(false);
            mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainContainer).EndInit();
            mainContainer.ResumeLayout(false);
            mapFieldContainer.Panel1.ResumeLayout(false);
            mapFieldContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mapFieldContainer).EndInit();
            mapFieldContainer.ResumeLayout(false);
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer mainContainer;
        private SplitContainer mapFieldContainer;
        private Panel mapFieldInfoPanel;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem ファイルFToolStripMenuItem;
        private ToolStripMenuItem アプリケーションの終了XToolStripMenuItem;
        private src.CustomControls.Chip.ChipManagedPanel choiceChipPanel;
        private StatusStrip statusStrip;
        private Button openGraphChipButton;
        private src.CustomControls.Map.TilingPanel mapFieldPanel;
        private src.CustomControls.Chip.ShowcasePanel graphicChipPanel;
        private Button openBinaryMapButton;
    }
}