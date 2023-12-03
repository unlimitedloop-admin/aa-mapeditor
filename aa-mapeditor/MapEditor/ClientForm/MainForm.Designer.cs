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
            開くFToolStripMenuItem = new ToolStripMenuItem();
            マップデータToolStripMenuItem = new ToolStripMenuItem();
            グラフィックチップToolStripMenuItem = new ToolStripMenuItem();
            閉じるCToolStripMenuItem = new ToolStripMenuItem();
            マップデータMToolStripMenuItem = new ToolStripMenuItem();
            グラフィックチップLToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            保存SToolStripMenuItem = new ToolStripMenuItem();
            マップデータをバイナリへ書き出しToolStripMenuItem = new ToolStripMenuItem();
            バイナリデータを開き直すRToolStripMenuItem = new ToolStripMenuItem();
            アプリケーションの終了XToolStripMenuItem = new ToolStripMenuItem();
            編集EToolStripMenuItem = new ToolStripMenuItem();
            元に戻すUToolStripMenuItem = new ToolStripMenuItem();
            やり直しRToolStripMenuItem = new ToolStripMenuItem();
            choiceChipPanel = new src.CustomControls.Chip.ChipManagedPanel();
            statusStrip = new StatusStrip();
            openGraphChipButton = new Button();
            openBinaryMapButton = new Button();
            nextPagesButton = new Button();
            showPagesTextBox = new TextBox();
            maxPagesLabel = new Label();
            prevPagesButton = new Button();
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
            mainContainer.SplitterDistance = 516;
            mainContainer.TabIndex = 0;
            mainContainer.TabStop = false;
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
            mapFieldContainer.Size = new Size(516, 605);
            mapFieldContainer.SplitterDistance = 484;
            mapFieldContainer.TabIndex = 0;
            mapFieldContainer.TabStop = false;
            // 
            // mapFieldPanel
            // 
            mapFieldPanel.BackColor = SystemColors.AppWorkspace;
            mapFieldPanel.BorderStyle = BorderStyle.Fixed3D;
            mapFieldPanel.Dock = DockStyle.Fill;
            mapFieldPanel.Location = new Point(0, 0);
            mapFieldPanel.Name = "mapFieldPanel";
            mapFieldPanel.Size = new Size(516, 484);
            mapFieldPanel.TabIndex = 0;
            mapFieldPanel.DoubleClick += MapFieldPanel_DoubleClick;
            // 
            // mapFieldInfoPanel
            // 
            mapFieldInfoPanel.BackColor = SystemColors.ButtonFace;
            mapFieldInfoPanel.BorderStyle = BorderStyle.Fixed3D;
            mapFieldInfoPanel.Dock = DockStyle.Fill;
            mapFieldInfoPanel.Location = new Point(0, 0);
            mapFieldInfoPanel.Name = "mapFieldInfoPanel";
            mapFieldInfoPanel.Size = new Size(516, 117);
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
            graphicChipPanel.Size = new Size(630, 605);
            graphicChipPanel.TabIndex = 0;
            graphicChipPanel.DoubleClick += GraphicChipPanel_DoubleClick;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { ファイルFToolStripMenuItem, 編集EToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1174, 24);
            mainMenuStrip.TabIndex = 1;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            ファイルFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 開くFToolStripMenuItem, 閉じるCToolStripMenuItem, toolStripMenuItem1, 保存SToolStripMenuItem, バイナリデータを開き直すRToolStripMenuItem, アプリケーションの終了XToolStripMenuItem });
            ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            ファイルFToolStripMenuItem.Size = new Size(70, 20);
            ファイルFToolStripMenuItem.Text = "ファイル (&F)";
            // 
            // 開くFToolStripMenuItem
            // 
            開くFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { マップデータToolStripMenuItem, グラフィックチップToolStripMenuItem });
            開くFToolStripMenuItem.Name = "開くFToolStripMenuItem";
            開くFToolStripMenuItem.Size = new Size(206, 22);
            開くFToolStripMenuItem.Text = "開く (&F)";
            // 
            // マップデータToolStripMenuItem
            // 
            マップデータToolStripMenuItem.Name = "マップデータToolStripMenuItem";
            マップデータToolStripMenuItem.Size = new Size(180, 22);
            マップデータToolStripMenuItem.Text = "マップデータ... (&M)";
            マップデータToolStripMenuItem.Click += 開く_マップデータ_Click;
            // 
            // グラフィックチップToolStripMenuItem
            // 
            グラフィックチップToolStripMenuItem.Name = "グラフィックチップToolStripMenuItem";
            グラフィックチップToolStripMenuItem.Size = new Size(180, 22);
            グラフィックチップToolStripMenuItem.Text = "グラフィックチップ... (&R)";
            グラフィックチップToolStripMenuItem.Click += 開く_グラフィックチップ_Click;
            // 
            // 閉じるCToolStripMenuItem
            // 
            閉じるCToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { マップデータMToolStripMenuItem, グラフィックチップLToolStripMenuItem });
            閉じるCToolStripMenuItem.Name = "閉じるCToolStripMenuItem";
            閉じるCToolStripMenuItem.Size = new Size(206, 22);
            閉じるCToolStripMenuItem.Text = "閉じる (&C)";
            // 
            // マップデータMToolStripMenuItem
            // 
            マップデータMToolStripMenuItem.Name = "マップデータMToolStripMenuItem";
            マップデータMToolStripMenuItem.Size = new Size(167, 22);
            マップデータMToolStripMenuItem.Text = "マップデータ (&M)";
            マップデータMToolStripMenuItem.Click += 閉じる_マップデータ_Click;
            // 
            // グラフィックチップLToolStripMenuItem
            // 
            グラフィックチップLToolStripMenuItem.Name = "グラフィックチップLToolStripMenuItem";
            グラフィックチップLToolStripMenuItem.Size = new Size(167, 22);
            グラフィックチップLToolStripMenuItem.Text = "グラフィックチップ (&R)";
            グラフィックチップLToolStripMenuItem.Click += 閉じる_グラフィックチップ_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(203, 6);
            // 
            // 保存SToolStripMenuItem
            // 
            保存SToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { マップデータをバイナリへ書き出しToolStripMenuItem });
            保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            保存SToolStripMenuItem.Size = new Size(206, 22);
            保存SToolStripMenuItem.Text = "保存 (&S)";
            // 
            // マップデータをバイナリへ書き出しToolStripMenuItem
            // 
            マップデータをバイナリへ書き出しToolStripMenuItem.Enabled = false;
            マップデータをバイナリへ書き出しToolStripMenuItem.Name = "マップデータをバイナリへ書き出しToolStripMenuItem";
            マップデータをバイナリへ書き出しToolStripMenuItem.Size = new Size(249, 22);
            マップデータをバイナリへ書き出しToolStripMenuItem.Text = "マップデータをバイナリへ書き出し... (&B)";
            マップデータをバイナリへ書き出しToolStripMenuItem.Click += マップデータをバイナリへ書き出しMenuItem_Click;
            // 
            // バイナリデータを開き直すRToolStripMenuItem
            // 
            バイナリデータを開き直すRToolStripMenuItem.Enabled = false;
            バイナリデータを開き直すRToolStripMenuItem.Name = "バイナリデータを開き直すRToolStripMenuItem";
            バイナリデータを開き直すRToolStripMenuItem.Size = new Size(206, 22);
            バイナリデータを開き直すRToolStripMenuItem.Text = "バイナリデータを開き直す (&R)";
            バイナリデータを開き直すRToolStripMenuItem.Click += バイナリデータを開き直す_Click;
            // 
            // アプリケーションの終了XToolStripMenuItem
            // 
            アプリケーションの終了XToolStripMenuItem.Name = "アプリケーションの終了XToolStripMenuItem";
            アプリケーションの終了XToolStripMenuItem.Size = new Size(206, 22);
            アプリケーションの終了XToolStripMenuItem.Text = "アプリケーションの終了 (&X)";
            アプリケーションの終了XToolStripMenuItem.Click += アプリケーションの終了XToolStripMenuItem_Click;
            // 
            // 編集EToolStripMenuItem
            // 
            編集EToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 元に戻すUToolStripMenuItem, やり直しRToolStripMenuItem });
            編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            編集EToolStripMenuItem.Size = new Size(60, 20);
            編集EToolStripMenuItem.Text = "編集 (&E)";
            // 
            // 元に戻すUToolStripMenuItem
            // 
            元に戻すUToolStripMenuItem.Name = "元に戻すUToolStripMenuItem";
            元に戻すUToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            元に戻すUToolStripMenuItem.Size = new Size(176, 22);
            元に戻すUToolStripMenuItem.Text = "元に戻す (&U)";
            元に戻すUToolStripMenuItem.Click += 元に戻す_Click;
            // 
            // やり直しRToolStripMenuItem
            // 
            やり直しRToolStripMenuItem.Name = "やり直しRToolStripMenuItem";
            やり直しRToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            やり直しRToolStripMenuItem.Size = new Size(176, 22);
            やり直しRToolStripMenuItem.Text = "やり直し (&R)";
            やり直しRToolStripMenuItem.Click += やり直し_Click;
            // 
            // choiceChipPanel
            // 
            choiceChipPanel.BackColor = SystemColors.ControlLight;
            choiceChipPanel.BorderStyle = BorderStyle.Fixed3D;
            choiceChipPanel.ChoiceChip = null;
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
            // nextPagesButton
            // 
            nextPagesButton.BackColor = SystemColors.ButtonHighlight;
            nextPagesButton.BackgroundImage = Properties.Resources.icons8_次_30;
            nextPagesButton.FlatAppearance.BorderSize = 0;
            nextPagesButton.FlatStyle = FlatStyle.Flat;
            nextPagesButton.ForeColor = SystemColors.ButtonFace;
            nextPagesButton.Location = new Point(464, 112);
            nextPagesButton.Name = "nextPagesButton";
            nextPagesButton.Size = new Size(30, 30);
            nextPagesButton.TabIndex = 6;
            nextPagesButton.UseVisualStyleBackColor = false;
            nextPagesButton.Click += NextPagesButton_Click;
            // 
            // showPagesTextBox
            // 
            showPagesTextBox.Enabled = false;
            showPagesTextBox.Font = new Font("Yu Gothic UI", 9.75F);
            showPagesTextBox.Location = new Point(396, 115);
            showPagesTextBox.MaxLength = 3;
            showPagesTextBox.Name = "showPagesTextBox";
            showPagesTextBox.Size = new Size(32, 25);
            showPagesTextBox.TabIndex = 7;
            showPagesTextBox.TextAlign = HorizontalAlignment.Center;
            showPagesTextBox.KeyDown += ShowPagesTextBox_KeyDown;
            showPagesTextBox.Leave += ShowPagesTextBox_Leave;
            // 
            // maxPagesLabel
            // 
            maxPagesLabel.AutoSize = true;
            maxPagesLabel.BackColor = Color.Transparent;
            maxPagesLabel.Font = new Font("Yu Gothic UI", 9F);
            maxPagesLabel.Location = new Point(430, 120);
            maxPagesLabel.Name = "maxPagesLabel";
            maxPagesLabel.Size = new Size(24, 15);
            maxPagesLabel.TabIndex = 8;
            maxPagesLabel.Text = "/ N";
            // 
            // prevPagesButton
            // 
            prevPagesButton.BackColor = SystemColors.ButtonHighlight;
            prevPagesButton.BackgroundImage = Properties.Resources.icons8_前_30;
            prevPagesButton.FlatAppearance.BorderSize = 0;
            prevPagesButton.FlatStyle = FlatStyle.Flat;
            prevPagesButton.ForeColor = SystemColors.ButtonFace;
            prevPagesButton.Location = new Point(356, 112);
            prevPagesButton.Name = "prevPagesButton";
            prevPagesButton.Size = new Size(30, 30);
            prevPagesButton.TabIndex = 9;
            prevPagesButton.UseVisualStyleBackColor = false;
            prevPagesButton.Click += PrevPagesButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 785);
            Controls.Add(prevPagesButton);
            Controls.Add(maxPagesLabel);
            Controls.Add(showPagesTextBox);
            Controls.Add(nextPagesButton);
            Controls.Add(openBinaryMapButton);
            Controls.Add(openGraphChipButton);
            Controls.Add(statusStrip);
            Controls.Add(choiceChipPanel);
            Controls.Add(mainContainer);
            Controls.Add(mainMenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = mainMenuStrip;
            Name = "MainForm";
            KeyDown += MainForm_KeyDown;
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
        private ToolStripMenuItem 開くFToolStripMenuItem;
        private ToolStripMenuItem マップデータToolStripMenuItem;
        private ToolStripMenuItem グラフィックチップToolStripMenuItem;
        private ToolStripMenuItem 閉じるCToolStripMenuItem;
        private ToolStripMenuItem マップデータMToolStripMenuItem;
        private ToolStripMenuItem グラフィックチップLToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem 編集EToolStripMenuItem;
        private ToolStripMenuItem 元に戻すUToolStripMenuItem;
        private ToolStripMenuItem やり直しRToolStripMenuItem;
        private Button nextPagesButton;
        private TextBox showPagesTextBox;
        private Label maxPagesLabel;
        private Button prevPagesButton;
        private ToolStripMenuItem バイナリデータを開き直すRToolStripMenuItem;
        private ToolStripMenuItem 保存SToolStripMenuItem;
        private ToolStripMenuItem マップデータをバイナリへ書き出しToolStripMenuItem;
    }
}