
namespace Classification_kNN
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lern = new System.Windows.Forms.Button();
            this.getClass = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lern
            // 
            this.Lern.Location = new System.Drawing.Point(12, 12);
            this.Lern.Name = "Lern";
            this.Lern.Size = new System.Drawing.Size(75, 23);
            this.Lern.TabIndex = 0;
            this.Lern.Text = "Обучить";
            this.Lern.UseVisualStyleBackColor = true;
            this.Lern.Click += new System.EventHandler(this.Lern_Click);
            // 
            // getClass
            // 
            this.getClass.Location = new System.Drawing.Point(12, 67);
            this.getClass.Name = "getClass";
            this.getClass.Size = new System.Drawing.Size(75, 23);
            this.getClass.TabIndex = 1;
            this.getClass.Text = "Распознать";
            this.getClass.UseVisualStyleBackColor = true;
            this.getClass.Click += new System.EventHandler(this.getClass_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(690, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 98);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.getClass);
            this.Controls.Add(this.Lern);
            this.Name = "Form1";
            this.Text = "kNN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Lern;
        private System.Windows.Forms.Button getClass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}

