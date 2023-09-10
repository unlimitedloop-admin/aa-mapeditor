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
//      File name       : Expandings.cs
//
//      Author          : u7
//
//      Last update     : 2023/09/10
//
//      File version    : 1
//
//
/**************************************************************/

/* sources */
namespace MapEditor.src.common
{
    /// <summary>
    ///  This is an indirect command class provided to link event handlers for the map field.
    /// </summary>
    internal class CustomMapStructEventArgs
    {
        internal event MouseEventHandler? MouseDownEvent;
        internal event MouseEventHandler? MouseUpEvent;
        internal event MouseEventHandler? MouseMoveEvent;

        internal void OnMouseDown(object? sender, MouseEventArgs e)
        {
            MouseDownEvent?.Invoke(sender, e);
        }

        internal void OnMouseUp(object? sender, MouseEventArgs e)
        {
            MouseUpEvent?.Invoke(sender, e);
        }

        internal void OnMouseMove(object? sender, MouseEventArgs e)
        {
            MouseMoveEvent?.Invoke(sender, e);
        }
    }
}
