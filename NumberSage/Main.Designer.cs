namespace NumberSage
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textUrl = new System.Windows.Forms.TextBox();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelPrediction = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hostCanvas = new System.Windows.Forms.Integration.ElementHost();
            this.textResponse = new System.Windows.Forms.RichTextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textUrl
            // 
            this.textUrl.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUrl.Location = new System.Drawing.Point(16, 14);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(500, 49);
            this.textUrl.TabIndex = 1;
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Location = new System.Drawing.Point(95, 575);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(105, 52);
            this.buttonRecognize.TabIndex = 3;
            this.buttonRecognize.Text = "Recognize";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(206, 575);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(105, 52);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelPrediction
            // 
            this.labelPrediction.Font = new System.Drawing.Font("Segoe UI Light", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrediction.ForeColor = System.Drawing.Color.Maroon;
            this.labelPrediction.Location = new System.Drawing.Point(13, 630);
            this.labelPrediction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrediction.Name = "labelPrediction";
            this.labelPrediction.Size = new System.Drawing.Size(503, 121);
            this.labelPrediction.TabIndex = 5;
            this.labelPrediction.Text = "0";
            this.labelPrediction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.hostCanvas);
            this.panel1.Location = new System.Drawing.Point(16, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 6;
            // 
            // hostCanvas
            // 
            this.hostCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostCanvas.Location = new System.Drawing.Point(0, 0);
            this.hostCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.hostCanvas.Name = "hostCanvas";
            this.hostCanvas.Size = new System.Drawing.Size(498, 498);
            this.hostCanvas.TabIndex = 0;
            this.hostCanvas.Child = null;
            // 
            // textResponse
            // 
            this.textResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textResponse.Font = new System.Drawing.Font("Segoe UI Light", 15.75F);
            this.textResponse.Location = new System.Drawing.Point(523, 14);
            this.textResponse.Name = "textResponse";
            this.textResponse.Size = new System.Drawing.Size(720, 737);
            this.textResponse.TabIndex = 7;
            this.textResponse.Text = "";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(317, 575);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(105, 52);
            this.buttonLoad.TabIndex = 8;
            this.buttonLoad.Text = "Load Model";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "model";
            this.openFile.Filter = "ONNX Files|*.onnx|All Files|*.*";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1255, 763);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textResponse);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPrediction);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRecognize);
            this.Controls.Add(this.textUrl);
            this.MinimumSize = new System.Drawing.Size(964, 547);
            this.Name = "Main";
            this.Text = "Number  Sage";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textUrl;
        private System.Windows.Forms.Button buttonRecognize;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelPrediction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox textResponse;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Integration.ElementHost hostCanvas;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}

