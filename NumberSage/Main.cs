using System;
using System.IO;
using System.Windows.Ink;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace NumberSage
{
    public partial class Main : Form
    {
        private InkCanvas _inkCanvas;
        public Main()
        {
            InitializeComponent();
            textUrl.HideSelection = true;
            _inkCanvas = new InkCanvas();
            _inkCanvas.DefaultDrawingAttributes = new DrawingAttributes()
            {
                FitToCurve = true,
                Height = 20,
                Width = 20
            };
            hostCanvas.Child = _inkCanvas;
            labelPrediction.Text = "";
        }

        private void Predict(float[,] digit)
        {
            
        }

        private void LoadModel(string onnxfile)
        {

        }


        /*
         * Boring bits....
         */
        private float[,] GetWrittenDigit(int size = 28)
        {
            RenderTargetBitmap b = new RenderTargetBitmap(
                (int)_inkCanvas.ActualWidth, (int)_inkCanvas.ActualHeight,
                96d, 96d, PixelFormats.Default);

            b.Render(_inkCanvas);
            var bitmap = new WriteableBitmap(b)
                            .Resize(size, size, WriteableBitmapExtensions.Interpolation.NearestNeighbor);

            var data = new float[size, size];
            for (int x = 0; x < bitmap.PixelWidth; x++)
            {
                for (int y = 0; y < bitmap.PixelHeight; y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    data[x, y] = (255 - ((color.R + color.G + color.B) / 3)) / 255f;
                }
            }

            return data;
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            Predict(GetWrittenDigit());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _inkCanvas.Strokes.Clear();
            textResponse.Clear();
            labelPrediction.Text = "";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if(openFile.ShowDialog() == DialogResult.OK && File.Exists(openFile.FileName))
                LoadModel(openFile.FileName);
        }
    }
}
