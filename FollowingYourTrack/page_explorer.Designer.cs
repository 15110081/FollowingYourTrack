namespace FollowingYourTrack
{
    partial class page_explorer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.shellTreeView1 = new GongSolutions.Shell.ShellTreeView();
            this.shellView1 = new GongSolutions.Shell.ShellView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.shellTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.shellView1);
            this.splitContainer1.Size = new System.Drawing.Size(1017, 638);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 0;
            // 
            // shellTreeView1
            // 
            this.shellTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellTreeView1.Location = new System.Drawing.Point(0, 0);
            this.shellTreeView1.Name = "shellTreeView1";
            this.shellTreeView1.ShellView = this.shellView1;
            this.shellTreeView1.Size = new System.Drawing.Size(339, 638);
            this.shellTreeView1.TabIndex = 0;
            // 
            // shellView1
            // 
            this.shellView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellView1.Location = new System.Drawing.Point(0, 0);
            this.shellView1.Name = "shellView1";
            this.shellView1.Size = new System.Drawing.Size(674, 638);
            this.shellView1.StatusBar = null;
            this.shellView1.TabIndex = 0;
            this.shellView1.Text = "explorer";
            // 
            // page_explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "page_explorer";
            this.Size = new System.Drawing.Size(1017, 638);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private GongSolutions.Shell.ShellTreeView shellTreeView1;
        private GongSolutions.Shell.ShellView shellView1;
    }
}
