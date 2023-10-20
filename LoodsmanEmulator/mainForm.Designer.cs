namespace LoodsmanEmulator
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bpListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.initiator = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.attributesListView = new System.Windows.Forms.ListView();
            this.Attribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(603, 15);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(536, 13);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "Атрибуты и свойства";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(603, 564);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(536, 13);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Бизнес процессы";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(13, 15);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(584, 13);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "Дерево";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(13, 564);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(584, 13);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Прикрепленные файлы";
            // 
            // bpListView
            // 
            this.bpListView.AutoArrange = false;
            this.bpListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.status,
            this.initiator});
            this.bpListView.HideSelection = false;
            this.bpListView.Location = new System.Drawing.Point(603, 583);
            this.bpListView.Name = "bpListView";
            this.bpListView.Size = new System.Drawing.Size(535, 178);
            this.bpListView.TabIndex = 3;
            this.bpListView.UseCompatibleStateImageBehavior = false;
            this.bpListView.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Название";
            this.name.Width = 326;
            // 
            // status
            // 
            this.status.Text = "Статус";
            this.status.Width = 86;
            // 
            // initiator
            // 
            this.initiator.Text = "Инициатор";
            this.initiator.Width = 116;
            // 
            // filesListView
            // 
            this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.filesListView.HideSelection = false;
            this.filesListView.Location = new System.Drawing.Point(13, 583);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(584, 178);
            this.filesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.filesListView.TabIndex = 4;
            this.filesListView.TileSize = new System.Drawing.Size(100, 100);
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Название";
            this.columnHeader1.Width = 575;
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(12, 767);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(1126, 20);
            this.infoTextBox.TabIndex = 10;
            // 
            // attributesListView
            // 
            this.attributesListView.AutoArrange = false;
            this.attributesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Attribute,
            this.Value});
            this.attributesListView.HideSelection = false;
            this.attributesListView.Location = new System.Drawing.Point(603, 35);
            this.attributesListView.Name = "attributesListView";
            this.attributesListView.Size = new System.Drawing.Size(536, 515);
            this.attributesListView.TabIndex = 9;
            this.attributesListView.UseCompatibleStateImageBehavior = false;
            this.attributesListView.View = System.Windows.Forms.View.Details;
            // 
            // Attribute
            // 
            this.Attribute.Name = "Attribute";
            this.Attribute.Text = "Атрибут";
            this.Attribute.Width = 216;
            // 
            // Value
            // 
            this.Value.Name = "Value";
            this.Value.Text = "Значение";
            this.Value.Width = 312;
            // 
            // mainTreeView
            // 
            this.mainTreeView.Location = new System.Drawing.Point(13, 69);
            this.mainTreeView.Name = "mainTreeView";
            this.mainTreeView.Size = new System.Drawing.Size(584, 481);
            this.mainTreeView.TabIndex = 11;
            this.mainTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.mainTreeView_AfterExpand);
            this.mainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mainTreeView_AfterSelect);
            // 
            // findTextBox
            // 
            this.findTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findTextBox.Location = new System.Drawing.Point(13, 37);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(543, 22);
            this.findTextBox.TabIndex = 12;
            // 
            // findButton
            // 
            this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
            this.findButton.Location = new System.Drawing.Point(562, 34);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(35, 29);
            this.findButton.TabIndex = 13;
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 792);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.findTextBox);
            this.Controls.Add(this.mainTreeView);
            this.Controls.Add(this.attributesListView);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bpListView);
            this.Controls.Add(this.filesListView);
            this.Name = "mainForm";
            this.Text = "Лоцман эмулятор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView bpListView;
        private System.Windows.Forms.ListView filesListView;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.ListView attributesListView;
        public System.Windows.Forms.ColumnHeader Attribute;
        public System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader name;
        public System.Windows.Forms.ColumnHeader status;
        public System.Windows.Forms.ColumnHeader initiator;
        private System.Windows.Forms.TreeView mainTreeView;
        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.Button findButton;
    }
}