
namespace Lab6
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
            this.dgvIncome = new System.Windows.Forms.DataGridView();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnBayes = new System.Windows.Forms.Button();
            this.lblBayes = new System.Windows.Forms.Label();
            this.btnGurvits = new System.Windows.Forms.Button();
            this.lblSV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIncome
            // 
            this.dgvIncome.AllowUserToDeleteRows = false;
            this.dgvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncome.Location = new System.Drawing.Point(53, 79);
            this.dgvIncome.Name = "dgvIncome";
            this.dgvIncome.RowTemplate.Height = 25;
            this.dgvIncome.Size = new System.Drawing.Size(343, 291);
            this.dgvIncome.TabIndex = 0;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(550, 127);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 43);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "Read Incomes";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnBayes
            // 
            this.btnBayes.Enabled = false;
            this.btnBayes.Location = new System.Drawing.Point(440, 228);
            this.btnBayes.Name = "btnBayes";
            this.btnBayes.Size = new System.Drawing.Size(75, 47);
            this.btnBayes.TabIndex = 2;
            this.btnBayes.Text = "Bayes criteria";
            this.btnBayes.UseVisualStyleBackColor = true;
            this.btnBayes.Click += new System.EventHandler(this.btnBayes_Click);
            // 
            // lblBayes
            // 
            this.lblBayes.AutoSize = true;
            this.lblBayes.Location = new System.Drawing.Point(440, 302);
            this.lblBayes.Name = "lblBayes";
            this.lblBayes.Size = new System.Drawing.Size(38, 15);
            this.lblBayes.TabIndex = 3;
            this.lblBayes.Text = "label1";
            this.lblBayes.Visible = false;
            // 
            // btnGurvits
            // 
            this.btnGurvits.Enabled = false;
            this.btnGurvits.Location = new System.Drawing.Point(648, 228);
            this.btnGurvits.Name = "btnGurvits";
            this.btnGurvits.Size = new System.Drawing.Size(75, 47);
            this.btnGurvits.TabIndex = 4;
            this.btnGurvits.Text = "Gurvits criteria";
            this.btnGurvits.UseVisualStyleBackColor = true;
            this.btnGurvits.Click += new System.EventHandler(this.btnGurvits_Click);
            // 
            // lblSV
            // 
            this.lblSV.AutoSize = true;
            this.lblSV.Location = new System.Drawing.Point(648, 301);
            this.lblSV.Name = "lblSV";
            this.lblSV.Size = new System.Drawing.Size(38, 15);
            this.lblSV.TabIndex = 5;
            this.lblSV.Text = "label1";
            this.lblSV.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSV);
            this.Controls.Add(this.btnGurvits);
            this.Controls.Add(this.lblBayes);
            this.Controls.Add(this.btnBayes);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.dgvIncome);
            this.Name = "Form1";
            this.Text = "Lab6";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncome;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnBayes;
        private System.Windows.Forms.Label lblBayes;
        private System.Windows.Forms.Button btnGurvits;
        private System.Windows.Forms.Label lblSV;
    }
}

