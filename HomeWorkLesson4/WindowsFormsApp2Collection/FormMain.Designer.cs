namespace WindowsFormsApp1Collection
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelHeader = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCalcNumbers = new System.Windows.Forms.Button();
            this.textBoxResultNumbers = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonCalcGenCollection = new System.Windows.Forms.Button();
            this.textBoxResultGenCollection = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCalcLINQ = new System.Windows.Forms.Button();
            this.textBoxResultLINQ = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.Color.LightGreen;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(619, 93);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCalcNumbers);
            this.groupBox1.Controls.Add(this.textBoxResultNumbers);
            this.groupBox1.Location = new System.Drawing.Point(4, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 172);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подсчет элементов для коллекции целых чисел";
            // 
            // buttonCalcNumbers
            // 
            this.buttonCalcNumbers.Location = new System.Drawing.Point(8, 19);
            this.buttonCalcNumbers.Name = "buttonCalcNumbers";
            this.buttonCalcNumbers.Size = new System.Drawing.Size(129, 55);
            this.buttonCalcNumbers.TabIndex = 5;
            this.buttonCalcNumbers.Text = "Сосчитать!";
            this.buttonCalcNumbers.UseVisualStyleBackColor = true;
            this.buttonCalcNumbers.Click += new System.EventHandler(this.buttonCalcNumbers_Click);
            // 
            // textBoxResultNumbers
            // 
            this.textBoxResultNumbers.Location = new System.Drawing.Point(143, 19);
            this.textBoxResultNumbers.Multiline = true;
            this.textBoxResultNumbers.Name = "textBoxResultNumbers";
            this.textBoxResultNumbers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResultNumbers.Size = new System.Drawing.Size(460, 145);
            this.textBoxResultNumbers.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCalcGenCollection);
            this.groupBox2.Controls.Add(this.textBoxResultGenCollection);
            this.groupBox2.Location = new System.Drawing.Point(4, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(609, 172);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Подсчет элементов для коллекции целых чисел";
            // 
            // buttonCalcGenCollection
            // 
            this.buttonCalcGenCollection.Location = new System.Drawing.Point(8, 19);
            this.buttonCalcGenCollection.Name = "buttonCalcGenCollection";
            this.buttonCalcGenCollection.Size = new System.Drawing.Size(129, 55);
            this.buttonCalcGenCollection.TabIndex = 5;
            this.buttonCalcGenCollection.Text = "Сосчитать!";
            this.buttonCalcGenCollection.UseVisualStyleBackColor = true;
            this.buttonCalcGenCollection.Click += new System.EventHandler(this.buttonCalcGenCollection_Click);
            // 
            // textBoxResultGenCollection
            // 
            this.textBoxResultGenCollection.Location = new System.Drawing.Point(143, 19);
            this.textBoxResultGenCollection.Multiline = true;
            this.textBoxResultGenCollection.Name = "textBoxResultGenCollection";
            this.textBoxResultGenCollection.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResultGenCollection.Size = new System.Drawing.Size(460, 145);
            this.textBoxResultGenCollection.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCalcLINQ);
            this.groupBox3.Controls.Add(this.textBoxResultLINQ);
            this.groupBox3.Location = new System.Drawing.Point(4, 452);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 172);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Подсчет элементов для коллекции целых чисел";
            // 
            // buttonCalcLINQ
            // 
            this.buttonCalcLINQ.Location = new System.Drawing.Point(8, 19);
            this.buttonCalcLINQ.Name = "buttonCalcLINQ";
            this.buttonCalcLINQ.Size = new System.Drawing.Size(129, 55);
            this.buttonCalcLINQ.TabIndex = 5;
            this.buttonCalcLINQ.Text = "Сосчитать!";
            this.buttonCalcLINQ.UseVisualStyleBackColor = true;
            this.buttonCalcLINQ.Click += new System.EventHandler(this.buttonCalcLINQ_Click);
            // 
            // textBoxResultLINQ
            // 
            this.textBoxResultLINQ.Location = new System.Drawing.Point(143, 19);
            this.textBoxResultLINQ.Multiline = true;
            this.textBoxResultLINQ.Name = "textBoxResultLINQ";
            this.textBoxResultLINQ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResultLINQ.Size = new System.Drawing.Size(460, 145);
            this.textBoxResultLINQ.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 629);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Методичка 4. Продвинутый курс C#. Задача № 2.  Количество элементов в коллекции.";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxResultNumbers;
        private System.Windows.Forms.Button buttonCalcNumbers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCalcGenCollection;
        private System.Windows.Forms.TextBox textBoxResultGenCollection;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCalcLINQ;
        private System.Windows.Forms.TextBox textBoxResultLINQ;
    }
}

