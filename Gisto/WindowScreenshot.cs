using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Screenshot
{

    public enum ScreenshotType { AllWindow, ClientRegion }

    static public class WindowScreenshot
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_PRINT = 791;
        /// <summary>
        /// The WM_PRINT drawing options
        /// </summary>
        [Flags]
        private enum DrawingOptions
        {
            /// <summary>
            /// Draws the window only if it is visible.
            /// </summary>
            PRF_CHECKVISIBLE = 1,

            /// <summary>
            /// Draws the nonclient area of the window.
            /// </summary>
            PRF_NONCLIENT = 2,
            /// <summary>

            /// Draws the client area of the window.
            /// </summary>
            PRF_CLIENT = 4,

            /// <summary>
            /// Erases the background before drawing the window.
            /// </summary>
            PRF_ERASEBKGND = 8,

            /// <summary>
            /// Draws all visible children windows.
            /// </summary>
            PRF_CHILDREN = 16,

            /// <summary>
            /// Draws all owned windows.
            /// </summary>
            PRF_OWNED = 32
        }

        private static Bitmap GetWindowScreenshot(Form form, ScreenshotType screenshotType)
        {
            Bitmap screenshot = new Bitmap(form.Width, form.Height);
            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                try
                {
                    SendMessage(form.Handle, WM_PRINT, graphics.GetHdc().ToInt32(), (int)(DrawingOptions.PRF_CHILDREN | DrawingOptions.PRF_CLIENT | DrawingOptions.PRF_NONCLIENT | DrawingOptions.PRF_OWNED));
                }
                finally
                {
                    
                    graphics.ReleaseHdc();
                }
            }
            if (screenshotType == ScreenshotType.ClientRegion)
            {
                Rectangle rectAll = form.RectangleToClient(form.Bounds);
                Rectangle rectClient = form.ClientRectangle;
                rectClient.X = rectClient.Left - rectAll.Left;
                rectClient.Y = rectClient.Top - rectAll.Top;
                screenshot = screenshot.Clone(rectClient, screenshot.PixelFormat);
            }
            return screenshot;
        }

        private static Bitmap GetWindowScreenshot(Form form, Rectangle rectangle, ScreenshotType screenshotType)
        {
            Bitmap windowScreenshot = GetWindowScreenshot(form, screenshotType);
            return windowScreenshot.Clone(rectangle, windowScreenshot.PixelFormat);
        }

        private static void Save(Bitmap image, string fileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Введіть ім'я файлу",
                DefaultExt = ".jpeg",
                FileName = fileName,
                Filter = "JPEG Image (.jpeg)|*.jpeg|Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf",
                InitialDirectory = Application.StartupPath
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImageFormat imageFormat;
                string ext = Path.GetExtension(saveFileDialog.FileName);
                switch (ext)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".gif":
                        imageFormat = ImageFormat.Gif;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case ".tiff":
                        imageFormat = ImageFormat.Tiff;
                        break;
                    case ".wmf":
                        imageFormat = ImageFormat.Wmf;
                        break;
                    default:
                        imageFormat = ImageFormat.Jpeg;
                        break;
                }
                image.Save(saveFileDialog.FileName, imageFormat);
            }
        }

        public static void SaveInFile(Form form, string fileName, ScreenshotType screenshotType, Rectangle rectangle)
        {
            Save(GetWindowScreenshot(form, rectangle, screenshotType), fileName);
        }

        public static void SaveInFile(Form form, string fileName, ScreenshotType screenshotType)
        {
            Save(GetWindowScreenshot(form, screenshotType), fileName);
        }

        public static void CopyToClipboard(Form form, ScreenshotType screenshotType, Rectangle rectangle)
        {
            Clipboard.SetImage(GetWindowScreenshot(form, rectangle, screenshotType));
        }

        public static void CopyToClipboard(Form form, ScreenshotType screenshotType)
        {
            Clipboard.SetImage(GetWindowScreenshot(form, screenshotType));
        }
    }
}
