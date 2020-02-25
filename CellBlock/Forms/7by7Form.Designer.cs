namespace _7by7
{
    partial class _7by7Form
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
            this.solveButton = new System.Windows.Forms.Button();
            this.ViewSavedSolutions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(43, 382);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(124, 23);
            this.solveButton.TabIndex = 0;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // ViewSavedSolutions
            // 
            this.ViewSavedSolutions.Location = new System.Drawing.Point(173, 382);
            this.ViewSavedSolutions.Name = "ViewSavedSolutions";
            this.ViewSavedSolutions.Size = new System.Drawing.Size(124, 23);
            this.ViewSavedSolutions.TabIndex = 1;
            this.ViewSavedSolutions.Text = "View Saved Solutions";
            this.ViewSavedSolutions.UseVisualStyleBackColor = true;
            this.ViewSavedSolutions.Click += new System.EventHandler(this.ViewSavedSolutions_Click);
            // 
            // _7by7Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 421);
            this.Controls.Add(this.ViewSavedSolutions);
            this.Controls.Add(this.solveButton);
            this.Name = "_7by7Form";
            this.Text = "_7by7Form";
            this.Load += new System.EventHandler(this._7by7Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button ViewSavedSolutions;
    }
}