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
//      File name       : BinaryHeaderEditDialog.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/09
//
//      File version    : 2
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Modules;
using ClientForm.src.Configs;
using ClientForm.src.Exceptions;
using System.Media;



/* sources */
namespace ClientForm.src.Apps.Editor
{
    /// <summary>
    ///  A class that configures the binary header information editing dialog.
    /// </summary>
    public partial class BinaryHeaderEditDialog : Form
    {
        /// <summary>
        ///  Array of header information
        /// </summary>
        private readonly string[]? _headerInfo;
        internal string[] HeaderInfo => _headerInfo ?? ([]);

        private string? _originalValue;

        private const int HEADER_SIZE = CoreConstants.BINARY_HEADER_SIZE;


        public BinaryHeaderEditDialog(string pageIndexText, string[]? parameters)
        {
            InitializeComponent();
            _headerInfo = parameters;
            informationLabel.Text = informationLabel.Text.Replace("N", pageIndexText);  // Displays the page number part of the explanation.
        }

        private void BinaryHeaderEditDialog_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void HeaderTextBox_Enter(object? sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                _originalValue = textBox.Text;
            }
        }

        /// <summary>
        ///  <see cref="TryParseHexValueOfTextBox"/>
        /// </summary>
        private void HeaderTextBox_Leave(object? sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                TryParseHexValueOfTextBox(textBox);
            }
        }

        /// <summary>
        ///  When the update button is pressed.
        /// </summary>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Packing();
            Close();
        }

        /// <summary>
        ///  Initializes the form's controls.
        /// </summary>
        private void Initialize()
        {
            // Spread scroll type choices.
            AddComboBoxForScrollingTypeText(topScrollingComboBox);
            AddComboBoxForScrollingTypeText(bottomScrollingComboBox);
            AddComboBoxForScrollingTypeText(leftScrollingComboBox);
            AddComboBoxForScrollingTypeText(rightScrollingComboBox);

            if (null != _headerInfo && HEADER_SIZE == _headerInfo.Length)
            {
                headerTextBox0.Text = _headerInfo[0];
                ChangeReadOrWriteOfTextBox(headerTextBox0, false);
                headerTextBox1.Text = _headerInfo[1];
                ChangeReadOrWriteOfTextBox(headerTextBox1, false);
                headerLabel2.Text = "0x" + _headerInfo[2];
                headerTextBox3.Text = _headerInfo[3];
                ChangeReadOrWriteOfTextBox(headerTextBox3, false);
                headerTextBox4.Text = _headerInfo[4];
                ChangeReadOrWriteOfTextBox(headerTextBox4, true);
                headerTextBox5.Text = _headerInfo[5];
                ChangeReadOrWriteOfTextBox(headerTextBox5, true);
                headerTextBox6.Text = _headerInfo[6];
                ChangeReadOrWriteOfTextBox(headerTextBox6, true);
                headerTextBox7.Text = _headerInfo[7];
                ChangeReadOrWriteOfTextBox(headerTextBox7, true);
                headerTextBox8.Text = _headerInfo[8];
                ChangeReadOrWriteOfTextBox(headerTextBox8, true);
                StringManipulations.SplitHexBytes(_headerInfo[9], out string upper9, out string lower9);
                SelectedIndexForComboBox(topScrollingComboBox, upper9);
                SelectedIndexForComboBox(bottomScrollingComboBox, lower9);
                StringManipulations.SplitHexBytes(_headerInfo[10], out string upper10, out string lower10);
                SelectedIndexForComboBox(leftScrollingComboBox, upper10);
                SelectedIndexForComboBox(rightScrollingComboBox, lower10);
                headerTextBox11.Text = _headerInfo[11];
                ChangeReadOrWriteOfTextBox(headerTextBox11, true);
                headerTextBox12.Text = _headerInfo[12];
                ChangeReadOrWriteOfTextBox(headerTextBox12, true);
                headerTextBox13.Text = _headerInfo[13];
                ChangeReadOrWriteOfTextBox(headerTextBox13, true);
                headerTextBox14.Text = _headerInfo[14];
                ChangeReadOrWriteOfTextBox(headerTextBox14, true);
                headerLabel15.Text = "0x" + _headerInfo[15];
            }
        }

        /// <summary>
        ///  Finalizes the form's controls.
        /// </summary>
        private void Packing()
        {
            if (null != _headerInfo && HEADER_SIZE == _headerInfo.Length)
            {
                _headerInfo[0] = headerTextBox0.Text;
                _headerInfo[1] = headerTextBox1.Text;
                _headerInfo[2] = headerLabel2.Text[^2..];
                _headerInfo[3] = headerTextBox3.Text;
                _headerInfo[4] = headerTextBox4.Text;
                _headerInfo[5] = headerTextBox5.Text;
                _headerInfo[6] = headerTextBox6.Text;
                _headerInfo[7] = headerTextBox7.Text;
                _headerInfo[8] = headerTextBox8.Text;
                int value = (topScrollingComboBox.SelectedIndex * 0x10) + bottomScrollingComboBox.SelectedIndex;
                _headerInfo[9] = value.ToString("X2");
                value = (leftScrollingComboBox.SelectedIndex * 0x10) + rightScrollingComboBox.SelectedIndex;
                _headerInfo[10] = value.ToString("X2");
                _headerInfo[11] = headerTextBox11.Text;
                _headerInfo[12] = headerTextBox12.Text;
                _headerInfo[13] = headerTextBox13.Text;
                _headerInfo[14] = headerTextBox14.Text;
                _headerInfo[15] = headerLabel15.Text;
            }
        }

        /// <summary>
        ///  Set the scroll type to dropdown list.
        /// </summary>
        /// <param name="comboBox">Object to set</param>
        private static void AddComboBoxForScrollingTypeText(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.BeginUpdate();
            for (int i = 0; i < CoreConstants.SCROLLTYPELIST.Length; i++)
            {
                comboBox.Items.Add(CoreConstants.SCROLLTYPELIST[i]);
            }
            comboBox.EndUpdate();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        ///  Change the selected value of the <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="comboBox">Objects</param>
        /// <param name="strValue">Hexadecimal selection index</param>
        private static void SelectedIndexForComboBox(ComboBox comboBox, string strValue)
        {
            if (!ExceptionHandler.TryCatchWithLogging(() =>
            {
                comboBox.SelectedIndex = Convert.ToInt32(strValue, 16);
            }))
            {
                MessageBox.Show(comboBox.Name + "に無効な文字列がセットされようとしていました。\r\n文字列は「" + strValue + "」です。");
            }
        }

        /// <summary>
        ///  Toggles activation of <see cref="TextBox"/>.
        /// </summary>
        /// <param name="textBox">Objects</param>
        /// <param name="isWrite">True if writable</param>
        private void ChangeReadOrWriteOfTextBox(TextBox textBox, bool isWrite)
        {
            if (isWrite)
            {
                textBox.BackColor = SystemColors.Window;
                textBox.ForeColor = SystemColors.WindowText;
                textBox.ReadOnly = false;
                textBox.TabStop = true;
                textBox.Enter += HeaderTextBox_Enter;
                textBox.Leave += HeaderTextBox_Leave;
            }
            else
            {
                textBox.BackColor = SystemColors.GrayText;
                textBox.ForeColor = SystemColors.WindowText;
                textBox.ReadOnly = true;
                textBox.TabStop = false;
                textBox.Enter -= HeaderTextBox_Enter;
                textBox.Leave -= HeaderTextBox_Leave;
            }
        }

        /// <summary>
        ///  Check if input value is hexadecimal.
        /// </summary>
        /// <param name="sender">Objects</param>
        /// <returns>True if it can be converted to hexadecimal.</returns>
        private bool TryParseHexValueOfTextBox(TextBox sender)
        {
            // Parses as hexadecimal.
            if (int.TryParse(sender.Text, System.Globalization.NumberStyles.HexNumber, null, out int hexValue))
            {
                if (hexValue >= byte.MinValue && hexValue <= byte.MaxValue)
                {
                    sender.Text = hexValue.ToString("X2");
                    return true;
                }
            }

            // If it's not a number, change it back to the original value.
            sender.Text = _originalValue;
            return false;
        }

        /// <summary>
        ///  Processing when changing the force gate switch.
        /// </summary>
        private void RestrictToggleSwitch_Changed(object sender, EventArgs e)
        {
            if (restrictToggleSwitch.Toggled)
            {
                SystemSounds.Beep.Play();
                var dialogResult = MessageBox.Show("$00, $01などの値は変更するとバイナリマップ利用時に影響が出る恐れがあります。\r\nforceモードに切り替えますか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes != dialogResult)
                {
                    restrictToggleSwitch.Toggled = false;
                    return;
                }
                ChangeReadOrWriteOfTextBox(headerTextBox0, true);
                ChangeReadOrWriteOfTextBox(headerTextBox1, true);
                ChangeReadOrWriteOfTextBox(headerTextBox3, true);
            }
            else
            {
                ChangeReadOrWriteOfTextBox(headerTextBox0, false);
                ChangeReadOrWriteOfTextBox(headerTextBox1, false);
                ChangeReadOrWriteOfTextBox(headerTextBox3, false);
            }
        }

        private void BinaryHeaderEditDialogs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                ActiveControl = null;
            }
        }
    }
}
