namespace MapEditor.src.dialog
{
    partial class LoadGraphDialog
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
            flatTextLabel1 = new Label();
            filePathTextBox = new TextBox();
            openFileDialogButton = new Button();
            flatTextLabel2 = new Label();
            confRowTextBox = new TextBox();
            flatTextLabel3 = new Label();
            flatTextLabel4 = new Label();
            confColumnTextBox = new TextBox();
            OKButton = new Button();
            flatTextLabel5 = new Label();
            SuspendLayout();
            // 
            // flatTextLabel1
            // 
            flatTextLabel1.AutoSize = true;
            flatTextLabel1.Location = new Point(12, 9);
            flatTextLabel1.Name = "flatTextLabel1";
            flatTextLabel1.Size = new Size(41, 15);
            flatTextLabel1.TabIndex = 9;
            flatTextLabel1.Text = "ファイル";
            // 
            // filePathTextBox
            // 
            filePathTextBox.BorderStyle = BorderStyle.FixedSingle;
            filePathTextBox.Location = new Point(12, 27);
            filePathTextBox.Name = "filePathTextBox";
            filePathTextBox.Size = new Size(375, 23);
            filePathTextBox.TabIndex = 1;
            // 
            // openFileDialogButton
            // 
            openFileDialogButton.FlatStyle = FlatStyle.System;
            openFileDialogButton.Location = new Point(393, 27);
            openFileDialogButton.Name = "openFileDialogButton";
            openFileDialogButton.Size = new Size(100, 23);
            openFileDialogButton.TabIndex = 2;
            openFileDialogButton.Text = "ファイルを選択...";
            openFileDialogButton.UseVisualStyleBackColor = true;
            openFileDialogButton.Click += OpenFileDialogButton_Click;
            // 
            // flatTextLabel2
            // 
            flatTextLabel2.AutoSize = true;
            flatTextLabel2.Location = new Point(12, 68);
            flatTextLabel2.Name = "flatTextLabel2";
            flatTextLabel2.Size = new Size(94, 15);
            flatTextLabel2.TabIndex = 9;
            flatTextLabel2.Text = "取り込みオプション";
            // 
            // confRowTextBox
            // 
            confRowTextBox.Location = new Point(44, 86);
            confRowTextBox.Name = "confRowTextBox";
            confRowTextBox.Size = new Size(50, 23);
            confRowTextBox.TabIndex = 3;
            confRowTextBox.KeyPress += TextBox_KeyPress;
            confRowTextBox.TextChanged += RowColNumber_TextChanged;
            // 
            // flatTextLabel3
            // 
            flatTextLabel3.AutoSize = true;
            flatTextLabel3.Location = new Point(19, 89);
            flatTextLabel3.Name = "flatTextLabel3";
            flatTextLabel3.Size = new Size(19, 15);
            flatTextLabel3.TabIndex = 9;
            flatTextLabel3.Text = "行";
            // 
            // flatTextLabel4
            // 
            flatTextLabel4.AutoSize = true;
            flatTextLabel4.Location = new Point(123, 89);
            flatTextLabel4.Name = "flatTextLabel4";
            flatTextLabel4.Size = new Size(19, 15);
            flatTextLabel4.TabIndex = 9;
            flatTextLabel4.Text = "列";
            // 
            // confColumnTextBox
            // 
            confColumnTextBox.Location = new Point(148, 86);
            confColumnTextBox.Name = "confColumnTextBox";
            confColumnTextBox.Size = new Size(50, 23);
            confColumnTextBox.TabIndex = 4;
            confColumnTextBox.KeyPress += TextBox_KeyPress;
            confColumnTextBox.TextChanged += RowColNumber_TextChanged;
            // 
            // OKButton
            // 
            OKButton.Location = new Point(393, 86);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(100, 28);
            OKButton.TabIndex = 5;
            OKButton.Text = "取り込み開始";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // flatTextLabel5
            // 
            flatTextLabel5.AutoSize = true;
            flatTextLabel5.Location = new Point(227, 89);
            flatTextLabel5.Name = "flatTextLabel5";
            flatTextLabel5.Size = new Size(51, 15);
            flatTextLabel5.TabIndex = 9;
            flatTextLabel5.Text = "セル数：";
            flatTextLabel5.Visible = false;
            // 
            // LoadGraphDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 125);
            Controls.Add(flatTextLabel5);
            Controls.Add(OKButton);
            Controls.Add(flatTextLabel4);
            Controls.Add(confColumnTextBox);
            Controls.Add(flatTextLabel3);
            Controls.Add(confRowTextBox);
            Controls.Add(flatTextLabel2);
            Controls.Add(openFileDialogButton);
            Controls.Add(filePathTextBox);
            Controls.Add(flatTextLabel1);
            KeyPreview = true;
            Name = "LoadGraphDialog";
            Text = "グラフィックチップリストの読み込み";
            KeyPress += LoadGraphDialog_KeyPress;
            Click += LoadGraphDialog_FocusOut;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label flatTextLabel1;
        private TextBox filePathTextBox;
        private Button openFileDialogButton;
        private Label flatTextLabel2;
        private TextBox confRowTextBox;
        private Label flatTextLabel3;
        private Label flatTextLabel4;
        private TextBox confColumnTextBox;
        private Button OKButton;
        private Label flatTextLabel5;
    }
}