namespace CellBlock
{
    partial class ViewSavedSolutionsForm
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
            this.SavedSolutionsListBox = new System.Windows.Forms.ListBox();
            this.ViewSolutionButton = new System.Windows.Forms.Button();
            this.ViewSolutionsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SavedSolutionsListBox
            // 
            this.SavedSolutionsListBox.FormattingEnabled = true;
            this.SavedSolutionsListBox.Location = new System.Drawing.Point(428, 61);
            this.SavedSolutionsListBox.Name = "SavedSolutionsListBox";
            this.SavedSolutionsListBox.Size = new System.Drawing.Size(303, 303);
            this.SavedSolutionsListBox.TabIndex = 0;
           // this.SavedSolutionsListBox.SelectedIndexChanged += new System.EventHandler(this.SavedSolutionsListBox_SelectedIndexChanged_1);
            // 
            // ViewSolutionButton
            // 
            this.ViewSolutionButton.Location = new System.Drawing.Point(505, 370);
            this.ViewSolutionButton.Name = "ViewSolutionButton";
            this.ViewSolutionButton.Size = new System.Drawing.Size(131, 23);
            this.ViewSolutionButton.TabIndex = 1;
            this.ViewSolutionButton.Text = "View Solution";
            this.ViewSolutionButton.UseVisualStyleBackColor = true;
            this.ViewSolutionButton.Click += new System.EventHandler(this.ViewSolutionButton_Click);
            // 
            // ViewSolutionsLabel
            // 
            this.ViewSolutionsLabel.AutoSize = true;
            this.ViewSolutionsLabel.Location = new System.Drawing.Point(428, 37);
            this.ViewSolutionsLabel.Name = "ViewSolutionsLabel";
            this.ViewSolutionsLabel.Size = new System.Drawing.Size(79, 13);
            this.ViewSolutionsLabel.TabIndex = 2;
            this.ViewSolutionsLabel.Text = "View Solutions:";
            // 
            // ViewSavedSolutionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.ViewSolutionsLabel);
            this.Controls.Add(this.ViewSolutionButton);
            this.Controls.Add(this.SavedSolutionsListBox);
            this.Name = "ViewSavedSolutionsForm";
            this.Text = "View Saved Solutions";
            this.Load += new System.EventHandler(this.ViewSavedSolutionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox SavedSolutionsListBox;
        private System.Windows.Forms.Button ViewSolutionButton;
        private System.Windows.Forms.Label ViewSolutionsLabel;
    }
}