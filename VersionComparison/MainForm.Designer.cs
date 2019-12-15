namespace VersionComparison
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeDirectory1 = new System.Windows.Forms.TreeView();
            this.treeDirectory2 = new System.Windows.Forms.TreeView();
            this.butSelectDirectory1 = new System.Windows.Forms.Button();
            this.fldDirectoryPath1 = new System.Windows.Forms.TextBox();
            this.butOpenDirectory1 = new System.Windows.Forms.Button();
            this.FileComparison = new System.Windows.Forms.Button();
            this.butSelectDirectory2 = new System.Windows.Forms.Button();
            this.butCompare = new System.Windows.Forms.Button();
            this.fldDirectoryPath2 = new System.Windows.Forms.TextBox();
            this.butOpenDirectory2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblGreen = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 108);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeDirectory1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeDirectory2);
            this.splitContainer1.Size = new System.Drawing.Size(794, 637);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeDirectory1
            // 
            this.treeDirectory1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeDirectory1.Location = new System.Drawing.Point(12, 0);
            this.treeDirectory1.Name = "treeDirectory1";
            this.treeDirectory1.Size = new System.Drawing.Size(381, 634);
            this.treeDirectory1.TabIndex = 3;
            this.treeDirectory1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDirectory1_AfterSelect);
            // 
            // treeDirectory2
            // 
            this.treeDirectory2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeDirectory2.Location = new System.Drawing.Point(3, 0);
            this.treeDirectory2.Name = "treeDirectory2";
            this.treeDirectory2.Size = new System.Drawing.Size(376, 634);
            this.treeDirectory2.TabIndex = 7;
            this.treeDirectory2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDirectory2_AfterSelect);
            // 
            // butSelectDirectory1
            // 
            this.butSelectDirectory1.Location = new System.Drawing.Point(12, 12);
            this.butSelectDirectory1.Name = "butSelectDirectory1";
            this.butSelectDirectory1.Size = new System.Drawing.Size(95, 23);
            this.butSelectDirectory1.TabIndex = 4;
            this.butSelectDirectory1.Text = "Выберите файл";
            this.butSelectDirectory1.UseVisualStyleBackColor = true;
            this.butSelectDirectory1.Click += new System.EventHandler(this.butSelectDirectory1_Click);
            // 
            // fldDirectoryPath1
            // 
            this.fldDirectoryPath1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fldDirectoryPath1.Location = new System.Drawing.Point(113, 14);
            this.fldDirectoryPath1.Name = "fldDirectoryPath1";
            this.fldDirectoryPath1.Size = new System.Drawing.Size(587, 20);
            this.fldDirectoryPath1.TabIndex = 1;
            this.fldDirectoryPath1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fldDirectoryPath1_KeyPress);
            // 
            // butOpenDirectory1
            // 
            this.butOpenDirectory1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpenDirectory1.Location = new System.Drawing.Point(706, 12);
            this.butOpenDirectory1.Name = "butOpenDirectory1";
            this.butOpenDirectory1.Size = new System.Drawing.Size(75, 23);
            this.butOpenDirectory1.TabIndex = 0;
            this.butOpenDirectory1.Text = "Открыть";
            this.butOpenDirectory1.UseVisualStyleBackColor = true;
            this.butOpenDirectory1.Click += new System.EventHandler(this.butOpenDirectory1_Click);
            // 
            // FileComparison
            // 
            this.FileComparison.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.FileComparison.Location = new System.Drawing.Point(291, 751);
            this.FileComparison.Name = "FileComparison";
            this.FileComparison.Size = new System.Drawing.Size(209, 27);
            this.FileComparison.TabIndex = 9;
            this.FileComparison.Text = "Сравнить содержимое файлов";
            this.FileComparison.UseVisualStyleBackColor = true;
            this.FileComparison.Click += new System.EventHandler(this.FileComparison_Click);
            // 
            // butSelectDirectory2
            // 
            this.butSelectDirectory2.Location = new System.Drawing.Point(12, 41);
            this.butSelectDirectory2.Name = "butSelectDirectory2";
            this.butSelectDirectory2.Size = new System.Drawing.Size(95, 23);
            this.butSelectDirectory2.TabIndex = 8;
            this.butSelectDirectory2.Text = "Выберите файл";
            this.butSelectDirectory2.UseVisualStyleBackColor = true;
            this.butSelectDirectory2.Click += new System.EventHandler(this.butSelectDirectory2_Click);
            // 
            // butCompare
            // 
            this.butCompare.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butCompare.Location = new System.Drawing.Point(326, 69);
            this.butCompare.Name = "butCompare";
            this.butCompare.Size = new System.Drawing.Size(139, 32);
            this.butCompare.TabIndex = 6;
            this.butCompare.Text = "Сравнить каталоги";
            this.butCompare.UseVisualStyleBackColor = true;
            this.butCompare.Click += new System.EventHandler(this.butCompare_Click);
            // 
            // fldDirectoryPath2
            // 
            this.fldDirectoryPath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fldDirectoryPath2.Location = new System.Drawing.Point(113, 43);
            this.fldDirectoryPath2.Name = "fldDirectoryPath2";
            this.fldDirectoryPath2.Size = new System.Drawing.Size(587, 20);
            this.fldDirectoryPath2.TabIndex = 4;
            this.fldDirectoryPath2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fldDirectoryPath2_KeyPress);
            // 
            // butOpenDirectory2
            // 
            this.butOpenDirectory2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpenDirectory2.Location = new System.Drawing.Point(706, 41);
            this.butOpenDirectory2.Name = "butOpenDirectory2";
            this.butOpenDirectory2.Size = new System.Drawing.Size(75, 23);
            this.butOpenDirectory2.TabIndex = 3;
            this.butOpenDirectory2.Text = "Открыть";
            this.butOpenDirectory2.UseVisualStyleBackColor = true;
            this.butOpenDirectory2.Click += new System.EventHandler(this.butOpenDirectory2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblGreen});
            this.statusStrip1.Location = new System.Drawing.Point(0, 781);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(793, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(190, 17);
            this.toolStripStatusLabel1.Text = "Количество совпадающих файлов: ";
            // 
            // lblGreen
            // 
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 803);
            this.Controls.Add(this.FileComparison);
            this.Controls.Add(this.butCompare);
            this.Controls.Add(this.butSelectDirectory1);
            this.Controls.Add(this.butSelectDirectory2);
            this.Controls.Add(this.butOpenDirectory1);
            this.Controls.Add(this.butOpenDirectory2);
            this.Controls.Add(this.fldDirectoryPath2);
            this.Controls.Add(this.fldDirectoryPath1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сравнение файлов";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button butOpenDirectory1;
        private System.Windows.Forms.Button butOpenDirectory2;
        private System.Windows.Forms.Button butCompare;
        private System.Windows.Forms.Button butSelectDirectory1;
        private System.Windows.Forms.Button butSelectDirectory2;
        public System.Windows.Forms.TextBox fldDirectoryPath1;
        public System.Windows.Forms.TextBox fldDirectoryPath2;
        public System.Windows.Forms.TreeView treeDirectory1;
        public System.Windows.Forms.TreeView treeDirectory2;
        private System.Windows.Forms.Button FileComparison;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblGreen;

    }
}

