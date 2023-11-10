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
//      File name       : TilingPanel2.cs
//
//      Author          : u7
//
//      Last update     : 2023/11/10
//
//      File version    : 1
//
//
/**************************************************************/

/* using namespace */
using ClientForm.src.Configs;



/* sources */
namespace ClientForm.src.CustomControls.Map
{
    public partial class TilingPanel
    {
        private const int VOID = -1;

        /// <summary>
        ///  Selection control tool.
        /// </summary>
        private MapSelectionTool? _rangeTool;


        /// <summary>
        ///  OnMouseDown of TilingPanel event handler.
        ///  <para>Override <see cref="Control.OnMouseDown"/> for Panel controls.</para>
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            _rangeTool?.SetDraggingBeginPoint(e);
        }

        /// <summary>
        ///  OnMouseMove of TilingPanel event handler.
        ///  <para>Override <see cref="Control.OnMouseMove"/> for Panel controls.</para>
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            _rangeTool?.SetDraggingEndPoint(e);
        }

        /// <summary>
        ///  OnMouseUp of TilingPanel event handler.
        ///  <para>Override <see cref="Control.OnMouseUp"/> for Panel controls.</para>
        /// </summary>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            ProcessMouseClickOrDrag(e);
        }

        /// <summary>
        ///  The behavior branches depending on the mouse movement.
        /// </summary>
        /// <param name="e"><see cref="MouseEventArgs"/></param>
        private void ProcessMouseClickOrDrag(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _rangeTool is MapSelectionTool selectionTool)
            {
                if (!selectionTool.IsDragging)
                {
                    MapTileChange(selectionTool.GetStartPoint());
                }
                else
                {
                    selectionTool.BeginSelectedRangeAnimation();
                }
            }
        }

        /// <summary>
        ///  Switch actions with key presses.
        /// </summary>
        /// <param name="e"><see cref="KeyEventArgs"/></param>
        internal void PressAnyKey(KeyEventArgs e)
        {
            if (_rangeTool is MapSelectionTool tool && tool.SelectedRangeAnimation)
            {
                switch (e.KeyData)
                {
                    case Keys.Insert:
                        MapTileChange(tool.GetStartPoint(), tool.GetEndPoint());
                        Invalidate();
                        break;
                    case Keys.Enter:
                        MapTileChange(tool.GetStartPoint(), tool.GetEndPoint());
                        tool.SelectedRangeAnimation = false;
                        Invalidate();
                        break;
                    case Keys.Escape:
                        tool.SelectedRangeAnimation = false;
                        Invalidate();
                        break;
                    default:
                        // Empty.
                        break;
                }
            }
        }

        // HACK : このメソッドもMapSelectionToolへ隠ぺいしていいと思う。
        /// <summary>
        ///  Draws a rectangle of the provided <see cref="MapSelectionTool"/>.
        /// </summary>
        /// <param name="e"><see cref="PaintEventArgs"/></param>
        private void DrawRangeTool(PaintEventArgs e)
        {
            if (_rangeTool is MapSelectionTool tool)
            {
                if (tool.IsDragging)
                {
                    // Draw the selection rectangle
                    Rectangle selectionRect = tool.GetSelectionRectangle(0, 1, 0);
                    e.Graphics.DrawRectangle(tool.GetPen(Color.Red, 1.0f, false), selectionRect);
                }
                else if (tool.SelectedRangeAnimation)
                {
                    // Draw the static selection animation rectangle
                    Rectangle selectionRect = tool.GetSelectionRectangle(1, 2, 0);
                    e.Graphics.DrawRectangle(tool.GetPen(Color.Blue, 2.0f, true), selectionRect);
                }
            }
        }



        /// <summary>
        ///  Selection control tool.
        /// </summary>
        private class MapSelectionTool : IDisposable
        {
            private const int MAPTILE_SIZE = CoreConstants.MAPFIELD_CELLSIZE;
            private readonly TilingPanel _parentPanel;

            private Point _selectionStart;  // Starting point of selection rectangle
            private Point _selectionEnd;    // End point of rectangle
            private bool _isDragging;   // State indicating that dragging is in progress
            private System.Windows.Forms.Timer? _selectedRangeAnimation;    // Selection rectangle animation counter
            private float _dashOffset;  // Dotted selection animation director

            public bool IsDragging
            {
                get => _isDragging;
                set
                {
                    if (value != _isDragging)
                    {
                        _isDragging = value;
                        OnIsSelectedChanged();
                    }
                }
            }

            public bool SelectedRangeAnimation
            {
                get => _selectedRangeAnimation!.Enabled;
                set => _selectedRangeAnimation!.Enabled = value;
            }


            /// <summary>
            ///  Event handler for selection rectangle animation.
            /// </summary>
            private void SelectionAnimationTimer_Tick(object? sender, EventArgs e)
            {
                _dashOffset += 1.0f;
                if (_dashOffset > 10.0f)
                {
                    _dashOffset = 0.0f;
                }

                _parentPanel.Invalidate();
            }

            /// <summary>
            ///  Event listener for the _isDragging property.
            /// </summary>
            private void OnIsSelectedChanged()
            {
                _parentPanel.Invalidate();
            }

            internal MapSelectionTool(TilingPanel parentPanel)
            {
                _selectionStart = new Point(VOID, VOID);
                _selectionEnd = new Point(VOID, VOID);
                _isDragging = false;
                _selectedRangeAnimation = new();
                _dashOffset = 0.0f;
                _selectedRangeAnimation.Interval = 50;
                _selectedRangeAnimation.Tick += SelectionAnimationTimer_Tick;
                _parentPanel = parentPanel;
            }

            /// <summary>
            ///  Is there no rectangular selection?
            /// </summary>
            /// <returns>Returns true if either is empty.</returns>
            private bool IsEmpty()
            {
                return VOID == _selectionStart.X || VOID == _selectionStart.Y || VOID == _selectionEnd.X || VOID == _selectionEnd.Y;
            }

            /// <summary>
            ///  Get selection start point.
            /// </summary>
            /// <returns><see cref="Point"/> object.</returns>
            internal Point GetStartPoint() { return _selectionStart; }
            /// <summary>
            ///  Get selection end point.
            /// </summary>
            /// <returns><see cref="Point"/> object.</returns>
            internal Point GetEndPoint() { return _selectionEnd; }

            /// <summary>
            /// Set selection entry point.
            /// </summary>
            internal void SetDraggingBeginPoint(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (_selectedRangeAnimation!.Enabled)
                    {
                        StopSelectedRangeAnimation();
                    }

                    // Start the drag operation
                    _selectionStart = e.Location;
                    _parentPanel.Invalidate();
                }
            }

            /// <summary>
            ///  Set the dragged point as the end point.
            /// </summary>
            internal void SetDraggingEndPoint(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Continuous dragging operation
                    _isDragging = true;
                    _selectionEnd = e.Location;
                    _parentPanel.Invalidate();
                }
            }

            /// <summary>
            ///  A <seealso cref="GetSelectionRectangle(int, int, int)"/> that indirectly calls a method.
            /// </summary>
            /// <param name="inflates">Specify offset to expand</param>
            /// <returns>A <see cref="Rectangle"/> object between set points.</returns>
            internal Rectangle GetSelectionRectangle(int inflates) => GetSelectionRectangle(0, 0, inflates);
            /// <summary>
            ///  Generates and obtains a <see cref="Rectangle"/> that weaves between the set base point and end point.
            /// </summary>
            /// <param name="fromOffset">Offset value to adjust the starting point</param>
            /// <param name="toOffset">Offset value to adjust the end point</param>
            /// <param name="inflates">Specify offset to expand</param>
            /// <returns>A <see cref="Rectangle"/> object between set points.</returns>
            internal Rectangle GetSelectionRectangle(int fromOffset, int toOffset, int inflates)
            {
                const int PANEL_WIDTH = CoreConstants.MAPFIELD_PANEL_WIDTH;
                const int PANEL_HEIGHT = CoreConstants.MAPFIELD_PANEL_HEIGHT;

                if (IsEmpty())
                {
                    return Rectangle.Empty;
                }

                static int Clamp(int value, int min, int max) => Math.Min(Math.Max(value, min), max);

                // Calculate the selection rectangle, Snap to the nearest "MapTile size" grid
                int minX = Clamp(Math.Min(_selectionStart.X, _selectionEnd.X), 0, PANEL_WIDTH);
                int minY = Clamp(Math.Min(_selectionStart.Y, _selectionEnd.Y), 0, PANEL_HEIGHT);
                int maxX = Clamp(Math.Max(_selectionStart.X, _selectionEnd.X), 0, PANEL_WIDTH);
                int maxY = Clamp(Math.Max(_selectionStart.Y, _selectionEnd.Y), 0, PANEL_HEIGHT);
                minX = minX / MAPTILE_SIZE * MAPTILE_SIZE;
                minY = minY / MAPTILE_SIZE * MAPTILE_SIZE;
                maxX = (maxX + MAPTILE_SIZE - 1) / MAPTILE_SIZE * MAPTILE_SIZE;
                maxY = (maxY + MAPTILE_SIZE - 1) / MAPTILE_SIZE * MAPTILE_SIZE;

                // Create the rectangle with fromOffset
                int width = maxX - minX;
                int height = maxY - minY;
                Rectangle selectionRect = new(minX + fromOffset, minY + fromOffset, width - toOffset, height - toOffset);
                if (0 >= selectionRect.Width || 0 >= selectionRect.Height)
                {
                    return Rectangle.Empty;
                }

                // Inflate if needed
                if (inflates != 0)
                {
                    selectionRect.Inflate(inflates, inflates);
                }

                return selectionRect;
            }

            /// <summary>
            ///  Get customize <see cref="Pen"/> object.
            /// </summary>
            /// <param name="color">Specify pen color</param>
            /// <param name="bold">Specify pen thickness</param>
            /// <param name="mode">Drag line: <c>false</c>, for selection: <c>true</c></param>
            /// <returns>Custom made <see cref="Pen"/> object.</returns>
            internal Pen GetPen(Color color, float bold, bool mode)
            {
                if (!mode)
                {
                    return new Pen(color, bold);    // Solid line.
                }
                else
                {
                    return new Pen(color, bold)
                    {
                        DashStyle = System.Drawing.Drawing2D.DashStyle.Dash,
                        DashOffset = _dashOffset
                    };                              // Dashed line [+ Scrolling animation].
                }
            }

            /// <summary>
            ///  What happens when starting the selection animation.
            /// </summary>
            internal void BeginSelectedRangeAnimation()
            {
                _isDragging = false;
                _parentPanel.Invalidate(GetSelectionRectangle(2));
                _selectedRangeAnimation!.Enabled = true;
            }

            /// <summary>
            ///  Constant process when stopping animation of selection range.
            /// </summary>
            private void StopSelectedRangeAnimation()
            {
                _selectionStart = new Point(VOID, VOID);
                _selectionEnd = new Point(VOID, VOID);
                _isDragging = false;
                _parentPanel.Invalidate(GetSelectionRectangle(2));
                _selectedRangeAnimation!.Enabled = false;
            }

            /// <summary>
            ///  Disposing class object.
            /// </summary>
            public void Dispose()
            {
                _selectedRangeAnimation!.Tick -= SelectionAnimationTimer_Tick;
                _selectedRangeAnimation.Dispose();
                _selectedRangeAnimation = null;
            }
        }
    }
}
