using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLW.View;

internal class FullClear
{
    public static void ClearFullConsole()
    {
        // Clear the visible screen and move the cursor to the top-left corner.
        Console.Clear();

        // Send the ANSI escape code to clear the scrollback buffer.
        // \x1b is the escape character, [3J is the command to erase the scrollback.
        Console.Write("\x1b[3J");

        // Optional: Reset the cursor position just to be safe.
        Console.SetCursorPosition(0, 0);
    }
}
