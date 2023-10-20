namespace LoodsmanEmulator
{
    partial class finderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(finderForm));
            this.finderTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.finderListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // finderTextBox
            // 
            this.finderTextBox.Location = new System.Drawing.Point(12, 13);
            this.finderTextBox.Name = "finderTextBox";
            this.finderTextBox.Size = new System.Drawing.Size(412, 20);
            this.finderTextBox.TabIndex = 0;
            // 
            // findButton
            // 
            this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
            this.findButton.Location = new System.Drawing.Point(431, 8);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(35, 29);
            this.findButton.TabIndex = 14;
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // finderListBox
            // 
            this.finderListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.finderListBox.HideSelection = false;
            this.finderListBox.Location = new System.Drawing.Point(13, 65);
            this.finderListBox.Name = "finderListBox";
            this.finderListBox.Size = new System.Drawing.Size(453, 373);
            this.finderListBox.TabIndex = 15;
            this.finderListBox.UseCompatibleStateImageBehavior = false;
            this.finderListBox.View = System.Windows.Forms.View.Details;
            this.finderListBox.ItemActivate += new System.EventHandler(this.finderListBox_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Название";
            this.columnHeader1.Width = 211;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ключевой атрибут";
            this.columnHeader2.Width = 177;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата создания";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(13, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(453, 13);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Найденные объекты";
            // 
            // finderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 450);
            this.Controls.Add(this.finderListBox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.finderTextBox);
            this.Name = "finderForm";
            this.Text = "Поиск";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox finderTextBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.ListView finderListBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}