namespace WinFormsApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValor1 = new System.Windows.Forms.TextBox();
            this.tbValor2 = new System.Windows.Forms.TextBox();
            this.btnMover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor2:";
            // 
            // tbValor1
            // 
            this.tbValor1.Location = new System.Drawing.Point(60, 17);
            this.tbValor1.Name = "tbValor1";
            this.tbValor1.Size = new System.Drawing.Size(100, 23);
            this.tbValor1.TabIndex = 2;
            // 
            // tbValor2
            // 
            this.tbValor2.Enabled = false;
            this.tbValor2.Location = new System.Drawing.Point(60, 46);
            this.tbValor2.Name = "tbValor2";
            this.tbValor2.Size = new System.Drawing.Size(100, 23);
            this.tbValor2.TabIndex = 3;
            // 
            // btnMover
            // 
            this.btnMover.Location = new System.Drawing.Point(179, 17);
            this.btnMover.Name = "btnMover";
            this.btnMover.Size = new System.Drawing.Size(75, 23);
            this.btnMover.TabIndex = 4;
            this.btnMover.Text = "Mover";
            this.btnMover.UseVisualStyleBackColor = true;
            this.btnMover.Click += new System.EventHandler(this.buttonMover_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 94);
            this.Controls.Add(this.btnMover);
            this.Controls.Add(this.tbValor2);
            this.Controls.Add(this.tbValor1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Aula 02";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbValor1;
        private TextBox tbValor2;
        private Button btnMover;
    }
}