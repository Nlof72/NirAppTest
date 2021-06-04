
namespace TestApp
{
    partial class MarkType
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Plot = new System.Windows.Forms.Button();
            this.InputX = new System.Windows.Forms.RichTextBox();
            this.InputY = new System.Windows.Forms.RichTextBox();
            this.TypeLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Plot
            // 
            this.Plot.Location = new System.Drawing.Point(617, 366);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(94, 29);
            this.Plot.TabIndex = 0;
            this.Plot.Text = "Plot";
            this.Plot.UseVisualStyleBackColor = true;
            this.Plot.Click += new System.EventHandler(this.Plot_Click);
            // 
            // InputX
            // 
            this.InputX.Location = new System.Drawing.Point(12, 56);
            this.InputX.Name = "InputX";
            this.InputX.Size = new System.Drawing.Size(125, 120);
            this.InputX.TabIndex = 1;
            this.InputX.Text = "";
            // 
            // InputY
            // 
            this.InputY.Location = new System.Drawing.Point(209, 56);
            this.InputY.Name = "InputY";
            this.InputY.Size = new System.Drawing.Size(125, 120);
            this.InputY.TabIndex = 2;
            this.InputY.Text = "";
            // 
            // TypeLine
            // 
            this.TypeLine.Location = new System.Drawing.Point(493, 23);
            this.TypeLine.Name = "TypeLine";
            this.TypeLine.Size = new System.Drawing.Size(53, 27);
            this.TypeLine.TabIndex = 3;
            this.TypeLine.Text = "-o";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // MarkType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypeLine);
            this.Controls.Add(this.InputY);
            this.Controls.Add(this.InputX);
            this.Controls.Add(this.Plot);
            this.Name = "MarkType";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Plot;
        private System.Windows.Forms.RichTextBox InputX;
        private System.Windows.Forms.RichTextBox InputY;
        private System.Windows.Forms.TextBox TypeLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

