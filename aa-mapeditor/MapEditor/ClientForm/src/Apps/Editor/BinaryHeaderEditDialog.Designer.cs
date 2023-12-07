namespace ClientForm.src.Apps.Editor
{
    partial class BinaryHeaderEditDialog
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
            components = new System.ComponentModel.Container();
            informationLabel = new Label();
            restrictToggleSwitch = new CustomControls.ToggleSwitchControl();
            addressLabel0 = new Label();
            headerTextBox0 = new TextBox();
            headerTextBox1 = new TextBox();
            addressLabel1 = new Label();
            addressLabel2 = new Label();
            headerLabel2 = new Label();
            descriptionToolTip = new ToolTip(components);
            headerLabel15 = new Label();
            headerTextBox3 = new TextBox();
            addressLabel3 = new Label();
            headerTextBox4 = new TextBox();
            addressLabel4 = new Label();
            adminModeGroupBox = new GroupBox();
            nextRoomGroupBox = new GroupBox();
            headerTextBox8 = new TextBox();
            addressLabel8 = new Label();
            headerTextBox7 = new TextBox();
            addressLabel7 = new Label();
            headerTextBox6 = new TextBox();
            addressLabel6 = new Label();
            headerTextBox5 = new TextBox();
            addressLabel5 = new Label();
            scrollingTypeGroupBox = new GroupBox();
            rightScrollingComboBox = new ComboBox();
            addressLabel10lower = new Label();
            leftScrollingComboBox = new ComboBox();
            addressLabel10upper = new Label();
            bottomScrollingComboBox = new ComboBox();
            addressLabel9lower = new Label();
            topScrollingComboBox = new ComboBox();
            adressLabel9upper = new Label();
            headerTextBox11 = new TextBox();
            addressLabel11 = new Label();
            headerTextBox13 = new TextBox();
            addressLabel13 = new Label();
            headerTextBox14 = new TextBox();
            addressLabel14 = new Label();
            headerTextBox12 = new TextBox();
            addressLabel12 = new Label();
            addressLabel15 = new Label();
            submitButton = new Button();
            adminModeGroupBox.SuspendLayout();
            nextRoomGroupBox.SuspendLayout();
            scrollingTypeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // informationLabel
            // 
            informationLabel.AutoSize = true;
            informationLabel.Location = new Point(12, 12);
            informationLabel.Name = "informationLabel";
            informationLabel.Size = new Size(188, 15);
            informationLabel.TabIndex = 99;
            informationLabel.Text = "N ぺージ目のヘッダ情報を編集します。";
            // 
            // restrictToggleSwitch
            // 
            restrictToggleSwitch.AutoValidate = AutoValidate.EnablePreventFocusChange;
            restrictToggleSwitch.Location = new Point(15, 19);
            restrictToggleSwitch.Name = "restrictToggleSwitch";
            restrictToggleSwitch.Size = new Size(65, 33);
            restrictToggleSwitch.TabIndex = 1;
            restrictToggleSwitch.Toggled = false;
            restrictToggleSwitch.ToggleSwitchChanged += RestrictToggleSwitch_Changed;
            // 
            // addressLabel0
            // 
            addressLabel0.AutoSize = true;
            addressLabel0.Location = new Point(12, 54);
            addressLabel0.Name = "addressLabel0";
            addressLabel0.Size = new Size(31, 15);
            addressLabel0.TabIndex = 99;
            addressLabel0.Text = "$00 :";
            // 
            // headerTextBox0
            // 
            headerTextBox0.BackColor = SystemColors.GrayText;
            headerTextBox0.Location = new Point(43, 51);
            headerTextBox0.MaxLength = 3;
            headerTextBox0.Name = "headerTextBox0";
            headerTextBox0.ReadOnly = true;
            headerTextBox0.Size = new Size(38, 23);
            headerTextBox0.TabIndex = 1;
            headerTextBox0.TextAlign = HorizontalAlignment.Center;
            // 
            // headerTextBox1
            // 
            headerTextBox1.BackColor = SystemColors.GrayText;
            headerTextBox1.Location = new Point(126, 51);
            headerTextBox1.MaxLength = 3;
            headerTextBox1.Name = "headerTextBox1";
            headerTextBox1.ReadOnly = true;
            headerTextBox1.Size = new Size(38, 23);
            headerTextBox1.TabIndex = 2;
            headerTextBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel1
            // 
            addressLabel1.AutoSize = true;
            addressLabel1.Location = new Point(95, 54);
            addressLabel1.Name = "addressLabel1";
            addressLabel1.Size = new Size(31, 15);
            addressLabel1.TabIndex = 99;
            addressLabel1.Text = "$01 :";
            // 
            // addressLabel2
            // 
            addressLabel2.AutoSize = true;
            addressLabel2.Location = new Point(12, 82);
            addressLabel2.Name = "addressLabel2";
            addressLabel2.Size = new Size(31, 15);
            addressLabel2.TabIndex = 99;
            addressLabel2.Text = "$02 :";
            // 
            // headerLabel2
            // 
            headerLabel2.AutoSize = true;
            headerLabel2.Location = new Point(46, 82);
            headerLabel2.Name = "headerLabel2";
            headerLabel2.Size = new Size(31, 15);
            headerLabel2.TabIndex = 99;
            headerLabel2.Text = "0x00";
            descriptionToolTip.SetToolTip(headerLabel2, "ぺージインデックス (自動的に付与)");
            // 
            // headerLabel15
            // 
            headerLabel15.AutoSize = true;
            headerLabel15.Location = new Point(42, 437);
            headerLabel15.Name = "headerLabel15";
            headerLabel15.Size = new Size(31, 15);
            headerLabel15.TabIndex = 99;
            headerLabel15.Text = "0xFF";
            descriptionToolTip.SetToolTip(headerLabel15, "ぺージインデックス (自動的に付与)");
            // 
            // headerTextBox3
            // 
            headerTextBox3.BackColor = SystemColors.GrayText;
            headerTextBox3.Location = new Point(126, 79);
            headerTextBox3.MaxLength = 3;
            headerTextBox3.Name = "headerTextBox3";
            headerTextBox3.ReadOnly = true;
            headerTextBox3.Size = new Size(38, 23);
            headerTextBox3.TabIndex = 3;
            headerTextBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel3
            // 
            addressLabel3.AutoSize = true;
            addressLabel3.Location = new Point(95, 82);
            addressLabel3.Name = "addressLabel3";
            addressLabel3.Size = new Size(31, 15);
            addressLabel3.TabIndex = 99;
            addressLabel3.Text = "$03 :";
            // 
            // headerTextBox4
            // 
            headerTextBox4.BackColor = SystemColors.GrayText;
            headerTextBox4.ImeMode = ImeMode.NoControl;
            headerTextBox4.Location = new Point(126, 115);
            headerTextBox4.MaxLength = 3;
            headerTextBox4.Name = "headerTextBox4";
            headerTextBox4.ReadOnly = true;
            headerTextBox4.Size = new Size(38, 23);
            headerTextBox4.TabIndex = 4;
            headerTextBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel4
            // 
            addressLabel4.AutoSize = true;
            addressLabel4.Location = new Point(12, 118);
            addressLabel4.Name = "addressLabel4";
            addressLabel4.Size = new Size(99, 15);
            addressLabel4.TabIndex = 99;
            addressLabel4.Text = "$04 : 部屋番号・ID";
            // 
            // adminModeGroupBox
            // 
            adminModeGroupBox.Controls.Add(restrictToggleSwitch);
            adminModeGroupBox.ForeColor = Color.Firebrick;
            adminModeGroupBox.Location = new Point(180, 43);
            adminModeGroupBox.Name = "adminModeGroupBox";
            adminModeGroupBox.Size = new Size(88, 60);
            adminModeGroupBox.TabIndex = 13;
            adminModeGroupBox.TabStop = false;
            adminModeGroupBox.Text = "force gate";
            // 
            // nextRoomGroupBox
            // 
            nextRoomGroupBox.Controls.Add(headerTextBox8);
            nextRoomGroupBox.Controls.Add(addressLabel8);
            nextRoomGroupBox.Controls.Add(headerTextBox7);
            nextRoomGroupBox.Controls.Add(addressLabel7);
            nextRoomGroupBox.Controls.Add(headerTextBox6);
            nextRoomGroupBox.Controls.Add(addressLabel6);
            nextRoomGroupBox.Controls.Add(headerTextBox5);
            nextRoomGroupBox.Controls.Add(addressLabel5);
            nextRoomGroupBox.Location = new Point(12, 144);
            nextRoomGroupBox.Name = "nextRoomGroupBox";
            nextRoomGroupBox.Size = new Size(258, 85);
            nextRoomGroupBox.TabIndex = 5;
            nextRoomGroupBox.TabStop = false;
            nextRoomGroupBox.Text = "隣接する部屋番号・ID";
            // 
            // headerTextBox8
            // 
            headerTextBox8.BackColor = SystemColors.GrayText;
            headerTextBox8.Location = new Point(196, 49);
            headerTextBox8.MaxLength = 3;
            headerTextBox8.Name = "headerTextBox8";
            headerTextBox8.ReadOnly = true;
            headerTextBox8.Size = new Size(38, 23);
            headerTextBox8.TabIndex = 4;
            headerTextBox8.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel8
            // 
            addressLabel8.AutoSize = true;
            addressLabel8.Location = new Point(123, 52);
            addressLabel8.Name = "addressLabel8";
            addressLabel8.Size = new Size(70, 15);
            addressLabel8.TabIndex = 99;
            addressLabel8.Text = "$08 : 右方向";
            // 
            // headerTextBox7
            // 
            headerTextBox7.BackColor = SystemColors.GrayText;
            headerTextBox7.Location = new Point(79, 49);
            headerTextBox7.MaxLength = 3;
            headerTextBox7.Name = "headerTextBox7";
            headerTextBox7.ReadOnly = true;
            headerTextBox7.Size = new Size(38, 23);
            headerTextBox7.TabIndex = 3;
            headerTextBox7.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel7
            // 
            addressLabel7.AutoSize = true;
            addressLabel7.Location = new Point(6, 52);
            addressLabel7.Name = "addressLabel7";
            addressLabel7.Size = new Size(70, 15);
            addressLabel7.TabIndex = 99;
            addressLabel7.Text = "$07 : 左方向";
            // 
            // headerTextBox6
            // 
            headerTextBox6.BackColor = SystemColors.GrayText;
            headerTextBox6.Location = new Point(196, 20);
            headerTextBox6.MaxLength = 3;
            headerTextBox6.Name = "headerTextBox6";
            headerTextBox6.ReadOnly = true;
            headerTextBox6.Size = new Size(38, 23);
            headerTextBox6.TabIndex = 2;
            headerTextBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel6
            // 
            addressLabel6.AutoSize = true;
            addressLabel6.Location = new Point(123, 23);
            addressLabel6.Name = "addressLabel6";
            addressLabel6.Size = new Size(70, 15);
            addressLabel6.TabIndex = 99;
            addressLabel6.Text = "$06 : 下方向";
            // 
            // headerTextBox5
            // 
            headerTextBox5.BackColor = SystemColors.GrayText;
            headerTextBox5.Location = new Point(79, 20);
            headerTextBox5.MaxLength = 3;
            headerTextBox5.Name = "headerTextBox5";
            headerTextBox5.ReadOnly = true;
            headerTextBox5.Size = new Size(38, 23);
            headerTextBox5.TabIndex = 1;
            headerTextBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel5
            // 
            addressLabel5.AutoSize = true;
            addressLabel5.Location = new Point(6, 23);
            addressLabel5.Name = "addressLabel5";
            addressLabel5.Size = new Size(70, 15);
            addressLabel5.TabIndex = 99;
            addressLabel5.Text = "$05 : 上方向";
            // 
            // scrollingTypeGroupBox
            // 
            scrollingTypeGroupBox.Controls.Add(rightScrollingComboBox);
            scrollingTypeGroupBox.Controls.Add(addressLabel10lower);
            scrollingTypeGroupBox.Controls.Add(leftScrollingComboBox);
            scrollingTypeGroupBox.Controls.Add(addressLabel10upper);
            scrollingTypeGroupBox.Controls.Add(bottomScrollingComboBox);
            scrollingTypeGroupBox.Controls.Add(addressLabel9lower);
            scrollingTypeGroupBox.Controls.Add(topScrollingComboBox);
            scrollingTypeGroupBox.Controls.Add(adressLabel9upper);
            scrollingTypeGroupBox.Location = new Point(12, 235);
            scrollingTypeGroupBox.Name = "scrollingTypeGroupBox";
            scrollingTypeGroupBox.Size = new Size(258, 134);
            scrollingTypeGroupBox.TabIndex = 6;
            scrollingTypeGroupBox.TabStop = false;
            scrollingTypeGroupBox.Text = "画面スクロール情報";
            // 
            // rightScrollingComboBox
            // 
            rightScrollingComboBox.FormattingEnabled = true;
            rightScrollingComboBox.Location = new Point(83, 103);
            rightScrollingComboBox.Name = "rightScrollingComboBox";
            rightScrollingComboBox.Size = new Size(165, 23);
            rightScrollingComboBox.TabIndex = 4;
            // 
            // addressLabel10lower
            // 
            addressLabel10lower.AutoSize = true;
            addressLabel10lower.Location = new Point(6, 106);
            addressLabel10lower.Name = "addressLabel10lower";
            addressLabel10lower.Size = new Size(72, 15);
            addressLabel10lower.TabIndex = 99;
            addressLabel10lower.Text = "$0A : 右方向";
            // 
            // leftScrollingComboBox
            // 
            leftScrollingComboBox.FormattingEnabled = true;
            leftScrollingComboBox.Location = new Point(83, 74);
            leftScrollingComboBox.Name = "leftScrollingComboBox";
            leftScrollingComboBox.Size = new Size(165, 23);
            leftScrollingComboBox.TabIndex = 3;
            // 
            // addressLabel10upper
            // 
            addressLabel10upper.AutoSize = true;
            addressLabel10upper.Location = new Point(6, 77);
            addressLabel10upper.Name = "addressLabel10upper";
            addressLabel10upper.Size = new Size(72, 15);
            addressLabel10upper.TabIndex = 99;
            addressLabel10upper.Text = "$0A : 左方向";
            // 
            // bottomScrollingComboBox
            // 
            bottomScrollingComboBox.FormattingEnabled = true;
            bottomScrollingComboBox.Location = new Point(83, 45);
            bottomScrollingComboBox.Name = "bottomScrollingComboBox";
            bottomScrollingComboBox.Size = new Size(165, 23);
            bottomScrollingComboBox.TabIndex = 2;
            // 
            // addressLabel9lower
            // 
            addressLabel9lower.AutoSize = true;
            addressLabel9lower.Location = new Point(6, 48);
            addressLabel9lower.Name = "addressLabel9lower";
            addressLabel9lower.Size = new Size(70, 15);
            addressLabel9lower.TabIndex = 99;
            addressLabel9lower.Text = "$09 : 下方向";
            // 
            // topScrollingComboBox
            // 
            topScrollingComboBox.FormattingEnabled = true;
            topScrollingComboBox.Location = new Point(83, 16);
            topScrollingComboBox.Name = "topScrollingComboBox";
            topScrollingComboBox.Size = new Size(165, 23);
            topScrollingComboBox.TabIndex = 1;
            // 
            // adressLabel9upper
            // 
            adressLabel9upper.AutoSize = true;
            adressLabel9upper.Location = new Point(6, 19);
            adressLabel9upper.Name = "adressLabel9upper";
            adressLabel9upper.Size = new Size(70, 15);
            adressLabel9upper.TabIndex = 99;
            adressLabel9upper.Text = "$09 : 上方向";
            // 
            // headerTextBox11
            // 
            headerTextBox11.BackColor = SystemColors.GrayText;
            headerTextBox11.Location = new Point(93, 375);
            headerTextBox11.MaxLength = 3;
            headerTextBox11.Name = "headerTextBox11";
            headerTextBox11.ReadOnly = true;
            headerTextBox11.Size = new Size(38, 23);
            headerTextBox11.TabIndex = 7;
            headerTextBox11.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel11
            // 
            addressLabel11.AutoSize = true;
            addressLabel11.Location = new Point(7, 378);
            addressLabel11.Name = "addressLabel11";
            addressLabel11.Size = new Size(86, 15);
            addressLabel11.TabIndex = 99;
            addressLabel11.Text = "$0B : 背景タイプ";
            // 
            // headerTextBox13
            // 
            headerTextBox13.BackColor = SystemColors.GrayText;
            headerTextBox13.Location = new Point(93, 403);
            headerTextBox13.MaxLength = 3;
            headerTextBox13.Name = "headerTextBox13";
            headerTextBox13.ReadOnly = true;
            headerTextBox13.Size = new Size(38, 23);
            headerTextBox13.TabIndex = 9;
            headerTextBox13.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel13
            // 
            addressLabel13.AutoSize = true;
            addressLabel13.Location = new Point(7, 406);
            addressLabel13.Name = "addressLabel13";
            addressLabel13.Size = new Size(66, 15);
            addressLabel13.TabIndex = 99;
            addressLabel13.Text = "$0D : 汎用1";
            // 
            // headerTextBox14
            // 
            headerTextBox14.BackColor = SystemColors.GrayText;
            headerTextBox14.Location = new Point(228, 403);
            headerTextBox14.MaxLength = 3;
            headerTextBox14.Name = "headerTextBox14";
            headerTextBox14.ReadOnly = true;
            headerTextBox14.Size = new Size(38, 23);
            headerTextBox14.TabIndex = 10;
            headerTextBox14.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel14
            // 
            addressLabel14.AutoSize = true;
            addressLabel14.Location = new Point(140, 406);
            addressLabel14.Name = "addressLabel14";
            addressLabel14.Size = new Size(64, 15);
            addressLabel14.TabIndex = 99;
            addressLabel14.Text = "$0E : 汎用2";
            // 
            // headerTextBox12
            // 
            headerTextBox12.BackColor = SystemColors.GrayText;
            headerTextBox12.Location = new Point(228, 375);
            headerTextBox12.MaxLength = 3;
            headerTextBox12.Name = "headerTextBox12";
            headerTextBox12.ReadOnly = true;
            headerTextBox12.Size = new Size(38, 23);
            headerTextBox12.TabIndex = 8;
            headerTextBox12.TextAlign = HorizontalAlignment.Center;
            // 
            // addressLabel12
            // 
            addressLabel12.AutoSize = true;
            addressLabel12.Location = new Point(140, 378);
            addressLabel12.Name = "addressLabel12";
            addressLabel12.Size = new Size(88, 15);
            addressLabel12.TabIndex = 99;
            addressLabel12.Text = "$0C : アニメタイプ";
            // 
            // addressLabel15
            // 
            addressLabel15.AutoSize = true;
            addressLabel15.Location = new Point(7, 437);
            addressLabel15.Name = "addressLabel15";
            addressLabel15.Size = new Size(31, 15);
            addressLabel15.TabIndex = 99;
            addressLabel15.Text = "$0F :";
            // 
            // submitButton
            // 
            submitButton.DialogResult = DialogResult.OK;
            submitButton.Location = new Point(191, 440);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 28);
            submitButton.TabIndex = 20;
            submitButton.Text = "Update";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += SubmitButton_Click;
            // 
            // BinaryHeaderEditDialog
            // 
            AcceptButton = submitButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(282, 480);
            Controls.Add(submitButton);
            Controls.Add(headerLabel15);
            Controls.Add(addressLabel15);
            Controls.Add(headerTextBox12);
            Controls.Add(addressLabel12);
            Controls.Add(headerTextBox14);
            Controls.Add(addressLabel14);
            Controls.Add(headerTextBox13);
            Controls.Add(addressLabel13);
            Controls.Add(headerTextBox11);
            Controls.Add(addressLabel11);
            Controls.Add(scrollingTypeGroupBox);
            Controls.Add(nextRoomGroupBox);
            Controls.Add(adminModeGroupBox);
            Controls.Add(headerTextBox4);
            Controls.Add(addressLabel4);
            Controls.Add(headerTextBox3);
            Controls.Add(addressLabel3);
            Controls.Add(headerLabel2);
            Controls.Add(addressLabel2);
            Controls.Add(headerTextBox1);
            Controls.Add(addressLabel1);
            Controls.Add(headerTextBox0);
            Controls.Add(addressLabel0);
            Controls.Add(informationLabel);
            KeyPreview = true;
            Name = "BinaryHeaderEditDialog";
            Text = "ヘッダー情報の編集";
            Load += BinaryHeaderEditDialog_Load;
            KeyDown += BinaryHeaderEditDialogs_KeyDown;
            adminModeGroupBox.ResumeLayout(false);
            nextRoomGroupBox.ResumeLayout(false);
            nextRoomGroupBox.PerformLayout();
            scrollingTypeGroupBox.ResumeLayout(false);
            scrollingTypeGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label informationLabel;
        private CustomControls.ToggleSwitchControl restrictToggleSwitch;
        private Label addressLabel0;
        private TextBox headerTextBox0;
        private TextBox headerTextBox1;
        private Label addressLabel1;
        private Label addressLabel2;
        private Label headerLabel2;
        private ToolTip descriptionToolTip;
        private TextBox headerTextBox3;
        private Label addressLabel3;
        private TextBox headerTextBox4;
        private Label addressLabel4;
        private GroupBox adminModeGroupBox;
        private GroupBox nextRoomGroupBox;
        private TextBox headerTextBox5;
        private Label addressLabel5;
        private TextBox headerTextBox7;
        private Label addressLabel7;
        private TextBox headerTextBox6;
        private Label addressLabel6;
        private TextBox headerTextBox8;
        private Label addressLabel8;
        private GroupBox scrollingTypeGroupBox;
        private ComboBox bottomScrollingComboBox;
        private Label addressLabel9lower;
        private ComboBox topScrollingComboBox;
        private Label adressLabel9upper;
        private ComboBox leftScrollingComboBox;
        private Label addressLabel10upper;
        private ComboBox rightScrollingComboBox;
        private Label addressLabel10lower;
        private TextBox headerTextBox11;
        private Label addressLabel11;
        private TextBox headerTextBox13;
        private Label addressLabel13;
        private TextBox headerTextBox14;
        private Label addressLabel14;
        private TextBox headerTextBox12;
        private Label addressLabel12;
        private Label headerLabel15;
        private Label addressLabel15;
        private Button submitButton;
    }
}