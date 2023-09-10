/**************************************************************/
//
//
//      Copyright (c) 20XX UNLIMITED LOOP ROOT-ONE
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
//      File name       : MainForm_MapEditing.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/10
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.common;



/* sources */
namespace MapEditor.src.main
{
    /// <summary>
    ///  Implementing events and more to control the main functionality of the map editor.
    /// </summary>
    public partial class MainForm
    {
        private readonly CustomMapStructEventArgs _customMapStructEventArgs = new();

        // The coordinates held to determine the selected area of the map field.
        private Point _mouseDownPoint;
        private Point _mouseUpPoint;


        // ★Work in progress
        /// <summary>
        ///  The event when the mouse is pressed down on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapStruct_FieldMouseDown(object? sender, MouseEventArgs e)
        {
            Point mousepos = mapFieldTable.PointToClient(MousePosition);
            int clickedcol = mousepos.X / (mapFieldTable.Width / mapFieldTable.ColumnCount);
            int clickedrow = mousepos.Y / (mapFieldTable.Height / mapFieldTable.RowCount);
            _mouseDownPoint = new(clickedcol, clickedrow);

        }

        // ★Work in progress
        /// <summary>
        ///  The event when the mouse is moved over on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapStruct_FieldMouseMove(object? sender, MouseEventArgs e)
        {

        }

        // ★Work in progress
        /// <summary>
        ///  The event when the mouse is released on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapStruct_FieldMouseUp(object? sender, MouseEventArgs e)
        {
            if (mapFieldTable.GetControlFromPosition(_mouseDownPoint.X, _mouseDownPoint.Y) is PictureBox target && "" != selectedChipTexture.Text)
            {
                target.Text = selectedChipTexture.Text;
                target.Image = selectedChipTexture.Image;
            }
        }

        /// <summary>
        ///  Physical button click event handler for graphics chip list.
        /// </summary>
        /// <param name="sender">Image data set in <see cref="PictureBox"/></param>
        /// <param name="e">Unused event argument</param>
        /// <param name="tooltip_text">The text on the tooltip</param>
        private void ChipLists_GraphicChipClick(Button sender, EventArgs e, string tooltip_text)
        {
            Button button = sender!;
            List<MementoParameter> parameters = new()
            {
                new MementoParameter
                {
                    OldImageBinNum = "" != selectedChipTexture.Text ? byte.Parse(selectedChipTexture.Text) : null,
                    NewImageBinNum = "" != tooltip_text ? byte.Parse(tooltip_text) : null,
                    Holder = true
                }
            };
            Recollection(parameters);
            SetSelectedChipTexture(tooltip_text, button.BackgroundImage);
        }
    }


    /// <summary>
    ///  A dedicated event handler for retrieving information about the graphic chip.
    /// </summary>
    /// <param name="sender">Button object</param>
    /// <param name="e">Event args</param>
    /// <param name="tooltip_text">The chip sequence number set in the tooltip</param>
    public delegate void GetChipHandler(Button sender, EventArgs e, string tooltip_text);
}
