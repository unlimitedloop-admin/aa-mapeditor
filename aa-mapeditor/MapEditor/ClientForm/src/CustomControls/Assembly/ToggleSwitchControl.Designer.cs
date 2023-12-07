namespace ClientForm.src.CustomControls
{
    partial class ToggleSwitchControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            toggleSwitchObject = new PictureBox();
            stateLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)toggleSwitchObject).BeginInit();
            SuspendLayout();
            // 
            // toggleSwitchObject
            // 
            toggleSwitchObject.BackColor = Color.Transparent;
            toggleSwitchObject.Image = Properties.Resources.icons8_toggle_32_off;
            toggleSwitchObject.InitialImage = null;
            toggleSwitchObject.Location = new Point(0, 0);
            toggleSwitchObject.Name = "toggleSwitchObject";
            toggleSwitchObject.Size = new Size(30, 30);
            toggleSwitchObject.SizeMode = PictureBoxSizeMode.StretchImage;
            toggleSwitchObject.TabIndex = 0;
            toggleSwitchObject.TabStop = false;
            toggleSwitchObject.Click += ToggleSwitchObject_Click;
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            stateLabel.Location = new Point(33, 5);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(27, 17);
            stateLabel.TabIndex = 1;
            stateLabel.Text = "Off";
            // 
            // ToggleSwitchControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            Controls.Add(stateLabel);
            Controls.Add(toggleSwitchObject);
            Name = "ToggleSwitchControl";
            Size = new Size(65, 30);
            ((System.ComponentModel.ISupportInitialize)toggleSwitchObject).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox toggleSwitchObject;
        private Label stateLabel;
    }
}
