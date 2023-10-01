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
//      File name       : MapStructs_EditModule.cs
//
//      Author          : u7
//
//      Last update     : 2023/10/01
//
//      File version    : 2
//
//
/**************************************************************/

/* using namespace */
using MapEditor.src.main;
using static MapEditor.src.common.ConstBinaryData;



/* sources */
namespace MapEditor.src.app.models
{
    /// <summary>
    ///  Register methods related to the selection range.
    /// </summary>
    internal partial class MapStructs
    {
        /// <summary>
        ///  The coordinates held to determine the selected area of the map field.
        /// </summary>
        private struct RangeNavigator
        {
            internal Point startCell;
            internal Point endCell;
            internal float dashOffset;
            internal bool isSelecting;
            internal System.Windows.Forms.Timer selectionAnimationTimer;
        }

        /// <summary>
        ///  Constants for invalid values.
        /// </summary>
        private const int VOID = -1;

        /// <summary>
        ///  A shared member set for managing the selected range.
        /// </summary>
        private RangeNavigator _ranger = new()
        {
            startCell = new(VOID, VOID),
            endCell = new(VOID, VOID),
            dashOffset = 0.0f,
            isSelecting = false,
            selectionAnimationTimer = new()
        };


        /// <summary>
        ///  This is the setup method for the map table object.
        /// </summary>
        private void SetupMapStructure()
        {
            if (null != _mapTable)
            {
                _mapTable.Paint -= MapField_Paint;
                _mapTable.Paint += MapField_Paint;
                _ranger.selectionAnimationTimer.Interval = 50;      // 50 milliseconds.
                _ranger.selectionAnimationTimer.Tick -= SelectionAnimationTimer_Tick;
                _ranger.selectionAnimationTimer.Tick += SelectionAnimationTimer_Tick;
            }
        }

        /// <summary>
        ///  Handles the tick event for animating the selection boundary.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An EventArgs that contains the event data</param>
        private void SelectionAnimationTimer_Tick(object? sender, EventArgs e)
        {
            _ranger.dashOffset += 1.0f;
            if (_ranger.dashOffset > 10.0f)
                _ranger.dashOffset = 0;
            _mapTable?.Invalidate();
        }


        private void MapFieldChip_Click(object? sender, EventArgs e)
        {
            if (!_foldType && "" != _chipHolder.GetChipHolderNumberText())
            {
                if (sender is Control control && control.Parent is TableLayoutPanel table)
                {
                    TableLayoutPanelCellPosition position = table.GetCellPosition(control);
                    PictureBox picture = (PictureBox)sender!;
                    List<MementoParameter> parameters = new()
                    {
                        new MementoParameter
                        {
                            OldImageBinNum = byte.Parse(picture.Text),
                            NewImageBinNum = byte.Parse(_chipHolder.GetChipHolderNumberText()!),
                            MapAddress = (MapPages * MAP_PAGESIZE) + MAP_HEADERSIZE + (0x10 * position.Row) + position.Column,
                        }
                    };
                    MainForm.Recollection(parameters);
                    SetPanelFromMapFieldPosition(position.Column, position.Row, _chipHolder.GetSelectedChipTexture(), false);
                }
            }
        }

        /// <summary>
        ///  This is an indirect event handler that calls the parent control's MapField_MouseDown.
        /// </summary>
        /// <param name="sender"><see cref="PictureBox"/> object</param>
        /// <param name="e">Mouse event args</param>
        private void MapFieldChip_MouseDown(object? sender, MouseEventArgs e)
        {
            if (null != _mapTable && e.Button == MouseButtons.Left && _foldType)
            {
                Point screenPoint = ((Control)sender!).PointToScreen(e.Location);
                Point tablePoint = _mapTable.PointToClient(screenPoint);
                MapField_MouseDown(sender, new MouseEventArgs(e.Button, e.Clicks, tablePoint.X, tablePoint.Y, e.Delta));
            }
        }

        /// <summary>
        ///  The event when the mouse is pressed down on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapField_MouseDown(object? sender, MouseEventArgs e)
        {
            if (_ranger.selectionAnimationTimer.Enabled)
                RangeModeOff();

            Point mousepos = e.Location;
            int rowindex = VOID;
            int colindex = VOID;
            int rowheightsum = 0;
            for (int i = 0; i < _mapTable?.RowCount; i++)
            {
                rowheightsum += (int)_mapTable.RowStyles[i].Height;
                if (mousepos.Y < rowheightsum)
                {
                    rowindex = i;
                    break;
                }
            }
            int colwidthsum = 0;
            for (int j = 0; j < _mapTable?.ColumnCount; j++)
            {
                colwidthsum += (int)_mapTable.ColumnStyles[j].Width;
                if (mousepos.X < colwidthsum)
                {
                    colindex = j;
                    break;
                }
            }
            _ranger.startCell = new Point(colindex, rowindex);
            _ranger.isSelecting = true;
            _mapTable?.Invalidate(GetSelectionRectangle(_mapTable!, _ranger.startCell, _ranger.endCell));
        }

        /// <summary>
        ///  This is an indirect event handler that calls the parent control's MapField_MouseMove.
        /// </summary>
        /// <param name="sender"><see cref="PictureBox"/> object</param>
        /// <param name="e">Mouse event args</param>
        private void MapFieldChip_MouseMove(object? sender, MouseEventArgs e)
        {
            if (null != _mapTable && e.Button == MouseButtons.Left && _foldType)
            {
                Point screenPoint = ((Control)sender!).PointToScreen(e.Location);
                Point tablePoint = _mapTable.PointToClient(screenPoint);
                MapField_MouseMove(sender, new MouseEventArgs(e.Button, e.Clicks, tablePoint.X, tablePoint.Y, e.Delta));
            }
        }

        /// <summary>
        ///  The event when the mouse is moved over on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapField_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_ranger.isSelecting)
            {
                Point mousepos = e.Location;
                int rowindex = VOID;
                int colindex = VOID;
                int rowheightsum = 0;
                for (int i = 0; i < _mapTable?.RowCount; i++)
                {
                    if (mousepos.Y <= rowheightsum + (int)_mapTable.RowStyles[i].Height)
                    {
                        rowindex = i;
                        break;
                    }
                    rowheightsum += (int)_mapTable.RowStyles[i].Height;
                }
                int colwidthsum = 0;
                for (int j = 0; j < _mapTable?.ColumnCount; j++)
                {
                    if (mousepos.X <= colwidthsum + (int)_mapTable.ColumnStyles[j].Width)
                    {
                        colindex = j;
                        break;
                    }
                    colwidthsum += (int)_mapTable.ColumnStyles[j].Width;
                }
                _ranger.endCell = new Point(colindex, rowindex);
                _mapTable?.Invalidate();
                _mapTable?.Update();
            }
        }

        /// <summary>
        ///  Handles the MouseUp event for the MapFieldChip and translates the mouse coordinates to the _mapTable's coordinate system.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        private void MapFieldChip_MouseUp(object? sender, MouseEventArgs e)
        {
            if (null != _mapTable && e.Button == MouseButtons.Left && _foldType)
            {
                Point screenPoint = ((Control)sender!).PointToScreen(e.Location);
                Point tablePoint = _mapTable.PointToClient(screenPoint);
                MapField_MouseUp(sender, new MouseEventArgs(e.Button, e.Clicks, tablePoint.X, tablePoint.Y, e.Delta));
            }
        }

        /// <summary>
        ///  The event when the mouse is released on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Mouse event argument</param>
        private void MapField_MouseUp(object? sender, MouseEventArgs e)
        {
            _ranger.isSelecting = false;
            ClearSelectionAndRedraw();
            _ranger.selectionAnimationTimer.Start();
        }

        /// <summary>
        ///  The drawing event on the MapStruct.
        /// </summary>
        /// <param name="sender">The control of the map field</param>
        /// <param name="e">Paint event args</param>
        private void MapField_Paint(object? sender, PaintEventArgs e)
        {
            if (_ranger.startCell.X == VOID || _ranger.startCell.Y == VOID || _ranger.endCell.X == VOID || _ranger.endCell.Y == VOID)
                return;

            var tables = (TableLayoutPanel)sender!;
            Rectangle area = GetSelectionRectangle(tables, _ranger.startCell, _ranger.endCell);
            if (_ranger.isSelecting)
            {
                using Pen solidPen = new(Color.Red, 1.0f);
                area = new Rectangle(area.X, area.Y, area.Width - 1, area.Height - 1);              // Depends on the balance with the parents.
                e.Graphics.DrawRectangle(solidPen, area);
            }
            else
            {
                using Pen dashedPen = new(Color.Blue, 2.0f)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash,
                    DashOffset = _ranger.dashOffset
                };
                area = new Rectangle(area.X + 1, area.Y + 1, area.Width - 1, area.Height - 1);      // Depends on the balance with the parents.
                // Drawing a rectangle of the specified size. By changing the offset in the Timer.Tick event and invalidating the TableLayoutPanel itself,
                // the border is animated.
                e.Graphics.DrawRectangle(dashedPen, area);
            }
        }

        /// <summary>
        ///  Returns the rectangle representing the position and size of the specified cell in the given TableLayoutPanel.
        /// </summary>
        /// <param name="panel">The TableLayoutPanel in which the cell is located</param>
        /// <param name="cell">The cell's coordinates (column, row) within the TableLayoutPanel</param>
        /// <returns>A Rectangle representing the position and size of the specified cell. Returns an empty rectangle if the cell's coordinates are invalid.</returns>
        private static Rectangle GetCellRectangle(TableLayoutPanel panel, Point cell)
        {
            if (cell.X == VOID || cell.Y == VOID)
                return Rectangle.Empty;

            int col = cell.X;
            int row = cell.Y;
            int x = 0;
            int y = 0;
            // Retrieve the rectangle of the cell at the specified point.
            int[] columnWidths = panel.GetColumnWidths();
            int[] rowHeights = panel.GetRowHeights();
            for (int i = 0; i < col; i++)
            {
                x += columnWidths[i];
            }
            for (int j = 0; j < row; j++)
            {
                y += rowHeights[j];
            }
            int width = columnWidths[col];
            int height = rowHeights[row];

            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        ///  Returns the rectangle representing the area between the specified start and end cells in the given TableLayoutPanel.
        /// </summary>
        /// <param name="panel">The TableLayoutPanel in which the cells are located.</param>
        /// <param name="start">The starting cell's coordinates (column, row) within the TableLayoutPanel.</param>
        /// <param name="end">The ending cell's coordinates (column, row) within the TableLayoutPanel.</param>
        /// <returns>A Rectangle representing the combined area between the start and end cells. If the end cell's coordinates are invalid, the start cell's coordinates will be used for both the start and end.</returns>
        private static Rectangle GetSelectionRectangle(TableLayoutPanel panel, Point start, Point end)
        {
            if (end.X == VOID || end.Y == VOID)
                end = start;

            // Get the starting and ending cell rectangles.
            Rectangle startRect = GetCellRectangle(panel, start);
            Rectangle endRect = GetCellRectangle(panel, end);
            // Calculate the four sides of a rectangle and return it.
            int minX = Math.Min(startRect.Left, endRect.Left);
            int minY = Math.Min(startRect.Top, endRect.Top);
            int maxX = Math.Max(startRect.Right, endRect.Right);
            int maxY = Math.Max(startRect.Bottom, endRect.Bottom);

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }

        /// <summary>
        ///  Reset the rectangles cell info.
        /// </summary>
        private void ResetCellPosition()
        {
            _ranger.startCell = new Point(VOID, VOID);
            _ranger.endCell = new Point(VOID, VOID);
        }

        /// <summary>
        ///  Clearing and resetting the drawn Rectangle.
        /// </summary>
        internal void ClearSelectionAndRedraw()
        {
            if (null != _mapTable)
            {
                var prevSelectionRect = GetSelectionRectangle(_mapTable, _ranger.startCell, _ranger.endCell);
                prevSelectionRect.Inflate(2, 2);
                _mapTable?.Invalidate(prevSelectionRect);
            }
        }

        /// <summary>
        ///  This method performs the following three actions:
        /// <see cref="ClearSelectionAndRedraw">ClearSelectionAndRedraw</see>, <see cref="ResetCellPosition">ResetCellPosition</see>, <see cref="System.Windows.Forms.Timer.Stop">selectionAnimationTimer.Stop</see>
        /// </summary>
        private void RangeModeOff()
        {
            ClearSelectionAndRedraw();
            ResetCellPosition();
            _ranger.selectionAnimationTimer.Stop();
        }
    }
}
