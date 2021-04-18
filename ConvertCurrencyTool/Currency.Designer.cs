namespace ConvertCurrencyTool
{
    partial class Currency
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TaglistBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ID = new System.Windows.Forms.NumericUpDown();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RSSLINK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TITLE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NAME = new System.Windows.Forms.TextBox();
            this.InsertButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TaglistBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2MinSize = 288;
            this.splitContainer1.Size = new System.Drawing.Size(794, 229);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 6;
            // 
            // TaglistBox
            // 
            this.TaglistBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaglistBox.FormattingEnabled = true;
            this.TaglistBox.Location = new System.Drawing.Point(0, 0);
            this.TaglistBox.Name = "TaglistBox";
            this.TaglistBox.Size = new System.Drawing.Size(233, 229);
            this.TaglistBox.TabIndex = 5;
            this.TaglistBox.SelectedIndexChanged += new System.EventHandler(this.TaglistBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ID);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.RSSLINK);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TITLE);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NAME);
            this.panel1.Controls.Add(this.InsertButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 229);
            this.panel1.TabIndex = 6;
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(115, 35);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(120, 20);
            this.ID.TabIndex = 17;
            this.ID.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(297, 177);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(126, 23);
            this.DeleteButton.TabIndex = 16;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(155, 177);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(126, 23);
            this.UpdateButton.TabIndex = 15;
            this.UpdateButton.Text = "Save";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "RSS Link";
            // 
            // RSSLINK
            // 
            this.RSSLINK.Location = new System.Drawing.Point(13, 135);
            this.RSSLINK.Name = "RSSLINK";
            this.RSSLINK.Size = new System.Drawing.Size(532, 20);
            this.RSSLINK.TabIndex = 9;
            this.RSSLINK.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Title";
            // 
            // TITLE
            // 
            this.TITLE.Location = new System.Drawing.Point(13, 87);
            this.TITLE.Name = "TITLE";
            this.TITLE.Size = new System.Drawing.Size(532, 20);
            this.TITLE.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ID";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // NAME
            // 
            this.NAME.Location = new System.Drawing.Point(14, 34);
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(64, 20);
            this.NAME.TabIndex = 5;
            this.NAME.Text = "EUR";
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(13, 177);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(126, 23);
            this.InsertButton.TabIndex = 4;
            this.InsertButton.Text = "New record";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Currency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 229);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Currency";
            this.Text = "Parameters";
            this.Load += new System.EventHandler(this.Tags_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox TaglistBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RSSLINK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TITLE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NAME;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ID;
    }
}