namespace KompleksneChysloApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxNumbers;
        private System.Windows.Forms.Button btnDemo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxNumbers = new System.Windows.Forms.ListBox();
            this.btnDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxNumbers
            // 
            this.listBoxNumbers.FormattingEnabled = true;
            this.listBoxNumbers.ItemHeight = 16;
            this.listBoxNumbers.Location = new System.Drawing.Point(12, 12);
            this.listBoxNumbers.Name = "listBoxNumbers";
            this.listBoxNumbers.Size = new System.Drawing.Size(482, 132);
            this.listBoxNumbers.TabIndex = 0;
            // 
            // btnDemo
            // 
            this.btnDemo.Location = new System.Drawing.Point(12, 150);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(520, 35);
            this.btnDemo.TabIndex = 1;
            this.btnDemo.Text = "Показати комплексні числа";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(550, 360);
            this.Controls.Add(this.btnDemo);
            this.Controls.Add(this.listBoxNumbers);
            this.Name = "Form1";
            this.Text = "Демонстрація комплексних чисел";
            this.ResumeLayout(false);

        }
    }
}


