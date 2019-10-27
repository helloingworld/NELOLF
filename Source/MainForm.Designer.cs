namespace NELOLF
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            // 
            // filesListView
            // 
            this.filesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.filesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesListView.FullRowSelect = true;
            this.filesListView.HideSelection = false;
            this.filesListView.HoverSelection = true;
            this.filesListView.Location = new System.Drawing.Point(16, 16);
            this.filesListView.MultiSelect = false;
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(1162, 587);
            this.filesListView.TabIndex = 0;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.View = System.Windows.Forms.View.Details;
            this.filesListView.VirtualMode = true;
            this.filesListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.FilesListView_RetrieveVirtualItem);
            this.filesListView.DoubleClick += new System.EventHandler(this.FilesListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item path";
            this.columnHeader1.Width = 1100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1178, 619);
            this.Controls.Add(this.filesListView);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(16, 16, 0, 16);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NELOLF";

        }

        #endregion

        private System.Windows.Forms.ListView filesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

