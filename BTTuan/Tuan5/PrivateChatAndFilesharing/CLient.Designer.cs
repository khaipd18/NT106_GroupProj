namespace PrivateChatAndFilesharing
{
    partial class Client
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.LsvMessage = new System.Windows.Forms.ListView();
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnShareFile = new System.Windows.Forms.Button();
            this.messageColumn = new System.Windows.Forms.ColumnHeader(); // Thêm cột hiển thị nội dung tin nhắn
            this.SuspendLayout();
            // 
            // LsvMessage
            // 
            this.LsvMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.messageColumn});
            this.LsvMessage.FullRowSelect = true;
            this.LsvMessage.GridLines = true;
            this.LsvMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LsvMessage.Location = new System.Drawing.Point(12, 12);
            this.LsvMessage.Name = "LsvMessage";
            this.LsvMessage.Size = new System.Drawing.Size(776, 372);
            this.LsvMessage.TabIndex = 0;
            this.LsvMessage.UseCompatibleStateImageBehavior = false;
            this.LsvMessage.View = System.Windows.Forms.View.Details; // Đặt chế độ xem là 'Details'
            this.messageColumn.Text = "Nội dung tin nhắn"; // Đặt tiêu đề cho cột
            this.messageColumn.Width = 750; // Điều chỉnh độ rộng cột
            // 
            // txbMessage
            // 
            this.txbMessage.Location = new System.Drawing.Point(12, 390);
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(676, 22);
            this.txbMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(694, 390);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 29);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Gửi"; // Đổi văn bản sang tiếng Việt
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnShareFile
            // 
            this.btnShareFile.Location = new System.Drawing.Point(694, 425);
            this.btnShareFile.Name = "btnShareFile";
            this.btnShareFile.Size = new System.Drawing.Size(94, 29);
            this.btnShareFile.TabIndex = 3;
            this.btnShareFile.Text = "Chia sẻ file"; // Đổi văn bản sang tiếng Việt
            this.btnShareFile.UseVisualStyleBackColor = true;
            this.btnShareFile.Click += new System.EventHandler(this.btnShareFile_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.btnShareFile);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txbMessage);
            this.Controls.Add(this.LsvMessage);
            this.Name = "Client";
            this.Text = "Máy Khách"; // Đổi văn bản sang tiếng Việt
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListView LsvMessage;
        private System.Windows.Forms.TextBox txbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnShareFile;
        private System.Windows.Forms.ColumnHeader messageColumn; // Khai báo cột tin nhắn
    }
}
