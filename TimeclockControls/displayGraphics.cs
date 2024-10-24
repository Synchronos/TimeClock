using System.Drawing;
using System.Reflection;

namespace TimeclockControls
{
    internal sealed class displayGraphics
    {
        // Graphics
        internal static readonly Bitmap[] numericDigitBitmaps = new Bitmap[10];
        internal static readonly Bitmap blankDigitBitmap;
        internal static readonly Bitmap colonBitmap;
        internal static readonly Bitmap dashBitmap;
        internal static readonly Bitmap timeAMBitmap;
        internal static readonly Bitmap timePMBitmap;
        internal static readonly Bitmap time24HourBitmap;

        static displayGraphics()
        {
            // Load the image array with the digits stored in the assembly.
            for (int i = 0; i != 10; i++)
            {
                numericDigitBitmaps[i] = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("TimeclockControls.Digit_Graphics." + i + ".gif"));
            }

            // Load the special characters.
            blankDigitBitmap = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("TimeclockControls.Digit_Graphics.blank.gif"));
            colonBitmap = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("TimeclockControls.Digit_Graphics.colon.gif"));
            dashBitmap = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("TimeclockControls.Digit_Graphics.dash.gif"));
            timeAMBitmap = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("TimeclockControls.Digit_Graphics.timeAM.gif"));
            timePMBitmap = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("TimeclockControls.Digit_Graphics.timePM.gif"));
            time24HourBitmap = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("TimeclockControls.Digit_Graphics.time24hr.gif"));
        }
    }
}
