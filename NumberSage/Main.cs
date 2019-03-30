using System;
using System.IO;
using System.Windows.Ink;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Text;
using Microsoft.ML.OnnxRuntime;
using System.Numerics.Tensors;
using System.Collections.Generic;
using System.Linq;

namespace NumberSage
{
    public partial class Main : Form
    {
        private InkCanvas _inkCanvas;
        public Main()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void Predict(float[] digit)
        {
            var now = DateTime.Now;
            Tensor<float> x = new DenseTensor<float>(digit.Length);

            // normalize
            for (int i = 0; i < digit.Length; i++)
                x[i] = ((digit[i] / 255) - 0.1307f) / 0.3081f;

            var input = new List<NamedOnnxValue>() {
                NamedOnnxValue.CreateFromTensor("0", x)
            };

            var prediction = _session.Run(input)
                                     .First()
                                     .AsTensor<float>()
                                     .ToArray();

            var r = Array.IndexOf(prediction, prediction.Max());
            var time = (DateTime.Now - now).TotalSeconds;

            ShowResult(r, prediction, time, v => (float)System.Math.Exp(v));

        }

        private InferenceSession _session = null;
        
        private void LoadModel(string file)
        {
            _session = new InferenceSession(file);
            textUrl.Text = $"Model: {Path.GetFileName(file)}";            
        }


        /*
         * Boring bits....
         */
        private float[] GetWrittenDigit(int size = 28)
        {
            RenderTargetBitmap b = new RenderTargetBitmap(
                (int)_inkCanvas.ActualWidth, (int)_inkCanvas.ActualHeight,
                96d, 96d, PixelFormats.Default);

            b.Render(_inkCanvas);
            var bitmap = new WriteableBitmap(b)
                            .Resize(size, size, WriteableBitmapExtensions.Interpolation.NearestNeighbor);

            float[] data = new float[size * size];
            for (int x = 0; x < bitmap.PixelWidth; x++)
            {
                for (int y = 0; y < bitmap.PixelHeight; y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    data[y * bitmap.PixelWidth + x] = 255 - ((color.R + color.G + color.B) / 3);
                }
            }

            Console.WriteLine(Stringify(data));
            return data;
        }

        private string Stringify(float[] data)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 0) sb.Append("{\r\n\t");
                else if (i % 28 == 0)
                    sb.Append("\r\n\t");
                sb.Append($"{data[i],3:##0}, ");

            }
            sb.Append("\r\n}\r\n");
            return sb.ToString();
        }

        private void ShowResult(int prediction, float[] scores, double time, Func<float, float> conversion = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Scores:");

            for (int i = 0; i < scores.Length; i++)
            {
                double v = conversion == null ? scores[i] : conversion(scores[i]);
                sb.AppendLine($"\t{i}: {v}");
            }

            sb.AppendLine($"Prediction: {prediction}");
            sb.AppendLine($"Time: {time}");
            labelPrediction.Text = prediction.ToString();

            textResponse.Text = "";
            textResponse.Text = sb.ToString();
        }

        private void Clear()
        {
            _inkCanvas.Strokes.Clear();
            textResponse.Clear();
            labelPrediction.Text = "";
        }

        private void InitializeCanvas()
        {
            textUrl.HideSelection = true;
            _inkCanvas = new InkCanvas();
            _inkCanvas.DefaultDrawingAttributes = new DrawingAttributes()
            {
                FitToCurve = true,
                Height = 25,
                Width = 25
            };
            hostCanvas.Child = _inkCanvas;
            labelPrediction.Text = "";
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            Predict(GetWrittenDigit());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if(openFile.ShowDialog() == DialogResult.OK && File.Exists(openFile.FileName))
                LoadModel(openFile.FileName);
        }
    }
}
