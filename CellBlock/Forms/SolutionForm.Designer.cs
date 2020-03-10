namespace CellBlock
{
    partial class SolutionForm
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
            this.SaveToSQLDBButton = new System.Windows.Forms.Button();
            this.SolutionsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SaveToSQLDBButton
            // 
            this.SaveToSQLDBButton.Location = new System.Drawing.Point(544, 455);
            this.SaveToSQLDBButton.Name = "SaveToSQLDBButton";
            this.SaveToSQLDBButton.Size = new System.Drawing.Size(139, 23);
            this.SaveToSQLDBButton.TabIndex = 0;
            this.SaveToSQLDBButton.Text = "Save To SQL DB";
            this.SaveToSQLDBButton.UseVisualStyleBackColor = true;
            this.SaveToSQLDBButton.Click += new System.EventHandler(this.SaveToSQLDBButton_Click);
            // 
            // SolutionsListBox
            // 
            this.SolutionsListBox.FormattingEnabled = true;
            this.SolutionsListBox.Location = new System.Drawing.Point(506, 27);
            this.SolutionsListBox.Name = "SolutionsListBox";
            this.SolutionsListBox.Size = new System.Drawing.Size(223, 420);
            this.SolutionsListBox.TabIndex = 1;
            this.SolutionsListBox.SelectedIndexChanged += new System.EventHandler(this.SolutionsListBox_SelectedIndexChanged);
            // 
            // SolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 490);
            this.Controls.Add(this.SolutionsListBox);
            this.Controls.Add(this.SaveToSQLDBButton);
            this.Name = "SolutionForm";
            this.Text = "Solution";
            this.Load += new System.EventHandler(this.SolutionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveToSQLDBButton;
        private System.Windows.Forms.ListBox SolutionsListBox;
    }
}