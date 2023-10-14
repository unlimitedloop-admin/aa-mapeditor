/**************************************************************/
//
//
//      Copyright (c) 2023 UNLIMITED LOOP ROOT-ONE
//
//
//      This software(and source code) is completely Unlicense.
//      see "LICENSE".
//
//
/**************************************************************/
//
//
//      Arthentic Action Map Editor (Csharp Edition)
//
//      File name       : LoadGraphDialog.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/14
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using System.Media;
using static ClientForm.src.Configs.CoreConstants;



/* sources */
namespace ClientForm.src.Apps.Loader
{
    /// <summary>
    ///  This is a dialog class that inherits the form for selecting the original file of the graphic chip list.
    /// </summary>
    public partial class LoadGraphDialog : Form
    {
        /// <summary>
        ///  Stores a valid file path set in the File Path text box.
        /// </summary>
        public string FileName { private set; get; } = string.Empty;

        /// <summary>
        ///  Image size determined from image data in FilePath.
        /// </summary>
        public int GraphicHeight { private set; get; }

        /// <summary>
        ///  Image size determined from image data in FilePath.
        /// </summary>
        public int GraphicWidth { private set; get; }


        public LoadGraphDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  Validate graphics files.
        /// </summary>
        /// <param name="graphfile">Subjects of graphic data</param>
        /// <returns>True if the image data is valid.</returns>
        /// <exception cref="OutOfMemoryException"></exception>
        private bool CheckOfGraphicFile(string graphfile)
        {
            try
            {
                // Investigate the extension to prove that it is an image file.
                string extension = Path.GetExtension(graphfile).ToLower();
                if (File.Exists(graphfile) && (extension == ".jpeg" || extension == ".jpg" || extension == ".png" || extension == ".bmp"))
                {
                    using Image image = Image.FromFile(graphfile);
                    // Determine whether the size of the image to be read is within the specified size.
                    if (null != image && 0xFFFF >= (image.Height * image.Width))
                    {
                        GraphicHeight = image.Height / CHIP_SIZE;
                        GraphicWidth = image.Width / CHIP_SIZE;
                        FileName = graphfile;
                        return true;
                    }
                }
                return false;
            }
            catch (OutOfMemoryException ex)
            {
                _ = MessageBox.Show(ex.Message, "OutOfMemoryException Info");
                //MessageBox.Show("Empty or invalid file. Please select valid image data.", "UNEXPECTED EXCEPTION INFO");
                //DefaultLogger.LogError(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///  Validates values entered in row/column cells.
        /// </summary>
        /// <returns>True if normal, false otherwise.</returns>
        private bool ValidateOfRowColNumberTextBox()
        {
            // [Row] and [Column] text boxes are disabled unless they are empty and have a number greater than 0.
            if (!string.IsNullOrEmpty(confRowTextBox.Text) && !string.IsNullOrEmpty(confColumnTextBox.Text))
            {
                if (0 < int.Parse(confRowTextBox.Text) && 0 < int.Parse(confColumnTextBox.Text))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  Change the display/hide of "セル数：***".
        /// </summary>
        private void ShowTileCellNumber()
        {
            if (ValidateOfRowColNumberTextBox())
            {
                flatTextLabel5.Text = "セル数：" + (int.Parse(confRowTextBox.Text) * int.Parse(confColumnTextBox.Text)).ToString();
                flatTextLabel5.Visible = true;
            }
            else
            {
                flatTextLabel5.Visible = false;
            }
        }

        /// <summary>
        ///  Update the parameters passed to MainForm.
        /// </summary>
        private void SetParamters()
        {
            if (null != FileName && int.TryParse(confRowTextBox.Text, out int row_num) && int.TryParse(confColumnTextBox.Text, out int col_num))
            {
                GraphicHeight = row_num;
                GraphicWidth = col_num;
                DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
        }


        /// <summary>
        ///  Focus out event handler.
        /// </summary>
        private void LoadGraphDialog_FocusOut(object sender, EventArgs e)
        {
            if (null != ActiveControl)
            {
                this.ActiveControl = null;
            }
        }

        /// <summary>
        ///  Key press event handler.
        /// </summary>
        private void LoadGraphDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape && ActiveControl != null)
            {
                e.Handled = true;
                this.ActiveControl = null;
                return;
            }
            else if (e.KeyChar == (char)Keys.Escape && ActiveControl == null)
            {
                e.Handled = true;
                Close();
                return;
            }
        }

        /// <summary>
        ///  Key press of <see cref="TextBox"/> event handler.
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Restrict non-numeric key input and special key input.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        ///  Text changed event handler, confRowTextBox and confColumnTextBox.
        /// </summary>
        private void RowColNumber_TextChanged(object sender, EventArgs e)
        {
            // Calculates the number of cells and outputs it to the screen when a number is entered in a row/column cell.
            ShowTileCellNumber();
        }

        /// <summary>
        ///  Click of file open <see cref="Button"/> event handler.
        /// </summary>
        private void OpenFileDialogButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofDialog = new()
            {
                Filter = "画像ファイル(*jpg;*png;*bmp)|*jpg;*jpeg;*png;*bmp|すべてのファイル(*.*)|*.*",
                Title = "開くファイルを選択",
            };
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = ofDialog.FileName;
                if (CheckOfGraphicFile(ofDialog.FileName))
                {
                    confRowTextBox.Text = GraphicHeight.ToString();
                    confColumnTextBox.Text = GraphicWidth.ToString();
                    ShowTileCellNumber();
                    OKButton.Focus();
                }
                else
                {
                    SystemSounds.Beep.Play();
                    MessageBox.Show("指定の画像ファイルは取り込みできませんでした。\n画像ファイルは縦横合計65535ピクセルのjpg,png,bmp形式のみ取り込めます。");
                }
            }
        }

        /// <summary>
        ///  Click of submit <see cref="Button"/> event handler.
        /// </summary>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (filePathTextBox.Text.Length == 0)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("画像ファイルを選択して下さい。");
                return;
            }
            else if (ValidateOfRowColNumberTextBox() && CheckOfGraphicFile(filePathTextBox.Text))
            {
                SetParamters();
                Close();
            }
            else
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("指定の画像ファイルは取り込みできませんでした。\n画像ファイルは65535ピクセルのjpg,png,bmp形式のみ取り込めます。");
            }
        }
    }
}
