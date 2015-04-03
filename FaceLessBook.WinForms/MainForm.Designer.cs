namespace FaceLessBook.WinForms
{
    partial class MainForm
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
            this.sortButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(184, 7);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 23);
            this.sortButton.TabIndex = 6;
            this.sortButton.Text = "sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(26, 11);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 13);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "label1";
            // 
            // friendsListBox
            // 
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.Location = new System.Drawing.Point(25, 36);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(235, 329);
            this.friendsListBox.TabIndex = 4;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(25, 387);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 478);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.friendsListBox);
            this.Name = "MainForm";
            this.Text = "FaceLessBook :)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListBox friendsListBox;
        private System.Windows.Forms.Label lblError;
    }
}

