namespace WindowsFormsApp3Dictionary
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
            this.textBoxLambda = new System.Windows.Forms.TextBox();
            this.buttonLambda = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDelegate = new System.Windows.Forms.Button();
            this.textBoxDelegate = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.BackColor = System.Drawing.Color.LightGreen;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(630, 73);
            this.labelHeader.TabIndex = 3;
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonLambda);
            this.groupBox1.Controls.Add(this.textBoxLambda);
            this.groupBox1.Location = new System.Drawing.Point(4, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 160);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обращение с использованием лямбда оператора =>";
            // 
            // textBoxLambda
            // 
            this.textBoxLambda.Location = new System.Drawing.Point(143, 19);
            this.textBoxLambda.Multiline = true;
            this.textBoxLambda.Name = "textBoxLambda";
            this.textBoxLambda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLambda.Size = new System.Drawing.Size(460, 126);
            this.textBoxLambda.TabIndex = 5;
            // 
            // buttonLambda
            // 
            this.buttonLambda.Location = new System.Drawing.Point(8, 19);
            this.buttonLambda.Name = "buttonLambda";
            this.buttonLambda.Size = new System.Drawing.Size(129, 55);
            this.buttonLambda.TabIndex = 6;
            this.buttonLambda.Text = "Использование =>";
            this.buttonLambda.UseVisualStyleBackColor = true;
            this.buttonLambda.Click += new System.EventHandler(this.buttonLambda_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDelegate);
            this.groupBox2.Controls.Add(this.textBoxDelegate);
            this.groupBox2.Location = new System.Drawing.Point(4, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 160);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обращение с использованием лямбда оператора =>";
            // 
            // buttonDelegate
            // 
            this.buttonDelegate.Location = new System.Drawing.Point(8, 19);
            this.buttonDelegate.Name = "buttonDelegate";
            this.buttonDelegate.Size = new System.Drawing.Size(129, 55);
            this.buttonDelegate.TabIndex = 6;
            this.buttonDelegate.Text = "Использование =>";
            this.buttonDelegate.UseVisualStyleBackColor = true;
            this.buttonDelegate.Click += new System.EventHandler(this.buttonDelegate_Click);
            // 
            // textBoxDelegate
            // 
            this.textBoxDelegate.Location = new System.Drawing.Point(143, 19);
            this.textBoxDelegate.Multiline = true;
            this.textBoxDelegate.Name = "textBoxDelegate";
            this.textBoxDelegate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDelegate.Size = new System.Drawing.Size(460, 126);
            this.textBoxDelegate.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 415);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Методичка 4. Продвинутый курс C#. Задача № 3.  Работа со словарем.";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxLambda;
        private System.Windows.Forms.Button buttonLambda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDelegate;
        private System.Windows.Forms.TextBox textBoxDelegate;
    }
}

