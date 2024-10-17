namespace Private_Chat___Filesharing
{
    partial class Server
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
            this.LsvMessages = new System.Windows.Forms.ListView();
            this.columnHeaderMessages = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LsvMessages
            // 
            this.LsvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMessages});
            this.LsvMessages.FullRowSelect = true;
            this.LsvMessages.GridLines = true;
            this.LsvMessages.HideSelection = false;
            this.LsvMessages.Location = new System.Drawing.Point(12, 40);
            this.LsvMessages.Name = "LsvMessages";
            this.LsvMessages.Size = new System.Drawing.Size(776, 370);
            this.LsvMessages.TabIndex = 0;
            this.LsvMessages.UseCompatibleStateImageBehavior = false;
            this.LsvMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderMessages
            // 
            this.columnHeaderMessages.Text = "Messages";
            this.columnHeaderMessages.Width = 740;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server Messages";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LsvMessages);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Server_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView LsvMessages;
        private System.Windows.Forms.ColumnHeader columnHeaderMessages;
        private System.Windows.Forms.Label label1;
    }
}
