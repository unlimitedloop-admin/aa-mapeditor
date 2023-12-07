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
//      File name       : HeaderInfoPanel.cs
//
//      Author          : u7
//
//      Last update     : 2023/12/07
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Apps.Core;
using ClientForm.src.Apps.Editor;
using ClientForm.src.Apps.EditsUI;
using ClientForm.src.Apps.Modules;
using ClientForm.src.Configs;
using ClientForm.src.Exceptions;
using ClientForm.src.Gems.Command;



/* sources */
namespace ClientForm.src.CustomControls.Map
{
    /// <summary>
    ///  A control panel that displays information attached to map data.
    /// </summary>
    public class HeaderInfoPanel : Panel
    {
        private RecordSupervision? _memento;
        private readonly List<Label> _labels = [];

        // Dependency injection of members for map field access.
        private IBinaryArrayData? _binaryArrayData;
        private IPageIndex? _pageIndex;

        private const int HEADER_SIZE = CoreConstants.BINARY_HEADER_SIZE;
        private const int PAGE_SIZE = CoreConstants.BINARY_DATA_1PAGE_SIZE;


        public HeaderInfoPanel()
        {
            DoubleBuffered = true;
            AutoScroll = true;
        }

        /// <summary>
        ///  Inserts an instance of a required class into a private member.
        /// </summary>
        /// <param name="memento">Class reference</param>
        /// <param name="binaryArray"><see cref="IBinaryArrayData"/> interface for DI container</param>
        /// <param name="pageIndex"><see cref="IPageIndex"/> interface for DI container</param>
        public void SetPrimaryInstance(ref RecordSupervision memento, IBinaryArrayData binaryArray, IPageIndex pageIndex)
        {
            _memento = memento;
            _binaryArrayData = binaryArray;
            _pageIndex = pageIndex;
        }

        /// <summary>
        ///  Draws basic information for the <see cref="Label"/>.
        /// </summary>
        internal void InitializeLabels()
        {
            for (int i = 0; i < 9; i++)
            {
                Label label = new()
                {
                    Location = new Point(2, 16 * i),
                    AutoSize = true
                };
                _labels.Add(label);
                Controls.Add(label);
            }
            Invalidate();
        }

        /// <summary>
        ///  Change the header of the specified page.
        /// </summary>
        /// <param name="hex">Specify the change value in hexadecimal</param>
        internal void SetBaseBinaryHeadBytes(string[] hex)
        {
            if (null != _binaryArrayData && 0 < _binaryArrayData.Length && null != _pageIndex)
            {
                byte[] bytes = new byte[hex.Length];
                
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(hex[i], 16);
                }

                _binaryArrayData.UpdateRangeData(bytes, _pageIndex.PageIndex * PAGE_SIZE);
            }
        }

        /// <summary>
        ///  Get the header information of the current <see cref="IPageIndex"/>.
        /// </summary>
        /// <returns>Character array of 16-byte header area bytes.</returns>
        internal string[]? GetBaseBinaryHeadBytes()
        {
            if (null != _binaryArrayData && 0 < _binaryArrayData.Length && null != _pageIndex)
            {
                byte[] bytes = _binaryArrayData.ExtractRangeData(_pageIndex.PageIndex * PAGE_SIZE, HEADER_SIZE);
                string[] stringArray = new string[bytes.Length];

                for (int i = 0; i < bytes.Length; i++)
                {
                    stringArray[i] = bytes[i].ToString("X2");
                }

                return stringArray;
            }
            return null;
        }

        /// <summary>
        ///  Replace the index that means the scroll type with a string.
        /// </summary>
        /// <param name="typeValue">scroll type index</param>
        /// <returns>Scroll type (name).</returns>
        private static string ReplaceScrollTypeName(string typeValue)
        {
            int convertedValue = 0;
            if (ExceptionHandler.TryCatchWithLogging(() =>
            {
                convertedValue = Convert.ToInt32(typeValue, 16);
            }) && CoreConstants.SCROLLTYPE.Length > convertedValue)
            {
                return CoreConstants.SCROLLTYPE[convertedValue];
            }
            return string.Empty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            UpdateHeaderInfo();
        }

        /// <summary>
        ///  Header information redrawing process.
        /// </summary>
        private void UpdateHeaderInfo()
        {
            string[]? headerInfo = GetBaseBinaryHeadBytes() ?? null;
            if (null == headerInfo)
            {
                return;
            }

            _labels[0].Text = "(Parity)$00～$01：" + headerInfo[0] + " " + headerInfo[1];
            _labels[1].Text = "(PageIndex)$02：" + headerInfo[2];
            _labels[2].Text = "(EdgePageSign)$03：" + headerInfo[3];
            _labels[3].Text = "(RoomNo.)$04：" + headerInfo[4];
            _labels[4].Text = "(NextRoomsNo.)$05～$08：[↑]" + headerInfo[5] + " [↓]" + headerInfo[6] + " [←]" + headerInfo[7] + " [→]" + headerInfo[8];
            StringManipulations.SplitHexBytes(headerInfo[9], out string upper9, out string lower9);
            StringManipulations.SplitHexBytes(headerInfo[10], out string upper10, out string lower10);
            _labels[5].Text = "(NextRoomsMotion)$09～$0A：[↑]" + ReplaceScrollTypeName(upper9) + " [↓]" + ReplaceScrollTypeName(lower9) + " [←]" + ReplaceScrollTypeName(upper10) + " [→]" + ReplaceScrollTypeName(lower10);
            _labels[6].Text = "(AttributesType)$0B：" + headerInfo[11];
            _labels[7].Text = "(AnimationsType)$0C：" + headerInfo[12];
            _labels[8].Text = "(Heaps)$0D～$0E：" + headerInfo[13] + " " + headerInfo[14];
        }

        /// <summary>
        ///  Launches the <see cref="BinaryHeaderEditDialog"/> form and edit the map header information.
        /// </summary>
        internal void ExecuteBinaryHeaderEditDialog(object sender, EventArgs e)
        {
            if (null != _binaryArrayData && 0 < _binaryArrayData.Length && null != _pageIndex)
            {
                using BinaryHeaderEditDialog headerEditDialog = new((_pageIndex!.PageIndex + 1).ToString("X2"), GetBaseBinaryHeadBytes());
                if (DialogResult.OK == headerEditDialog.ShowDialog())
                {
                    string[] headerInfo = headerEditDialog.HeaderInfo;
                    if (0 < headerInfo.Length)
                    {
                        var command = new BinaryHeaderChangeCommand(this, headerInfo);  // => SetBaseBinaryHeadBytes(headerInfo);
                        command.Execute();
                        _memento!.PushUndoStack(command);
                    }
                }
                headerEditDialog.Dispose();
            }
        }

        /// <summary>
        ///  Clears all elements of the control.
        /// </summary>
        internal void Clear()
        {
            _labels.Clear();
            Controls.Clear();
        }
    }
}
