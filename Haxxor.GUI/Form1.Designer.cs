namespace Haxxor.GUI
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.MethodLst = new System.Windows.Forms.ComboBox();
            this.EncryptionTypeLst = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TextEntryBox = new System.Windows.Forms.RichTextBox();
            this.ResultBox = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MethodLst);
            this.panel1.Controls.Add(this.EncryptionTypeLst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 32);
            this.panel1.TabIndex = 98;
            // 
            // MethodLst
            // 
            this.MethodLst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodLst.FormattingEnabled = true;
            this.MethodLst.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.MethodLst.Location = new System.Drawing.Point(526, 5);
            this.MethodLst.Name = "MethodLst";
            this.MethodLst.Size = new System.Drawing.Size(121, 21);
            this.MethodLst.TabIndex = 99;
            // 
            // EncryptionTypeLst
            // 
            this.EncryptionTypeLst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncryptionTypeLst.FormattingEnabled = true;
            this.EncryptionTypeLst.Location = new System.Drawing.Point(653, 5);
            this.EncryptionTypeLst.Name = "EncryptionTypeLst";
            this.EncryptionTypeLst.Size = new System.Drawing.Size(121, 21);
            this.EncryptionTypeLst.TabIndex = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TextEntryBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ResultBox);
            this.splitContainer1.Size = new System.Drawing.Size(786, 410);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 1;
            // 
            // TextEntryBox
            // 
            this.TextEntryBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TextEntryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextEntryBox.Location = new System.Drawing.Point(0, 0);
            this.TextEntryBox.Name = "TextEntryBox";
            this.TextEntryBox.Size = new System.Drawing.Size(786, 192);
            this.TextEntryBox.TabIndex = 0;
            this.TextEntryBox.Text = "";
            // 
            // ResultBox
            // 
            this.ResultBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ResultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultBox.Location = new System.Drawing.Point(0, 0);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.Size = new System.Drawing.Size(786, 214);
            this.ResultBox.TabIndex = 2;
            this.ResultBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(786, 442);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Haxxor";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox MethodLst;
        private System.Windows.Forms.ComboBox EncryptionTypeLst;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox TextEntryBox;
        private System.Windows.Forms.RichTextBox ResultBox;
    }
}

