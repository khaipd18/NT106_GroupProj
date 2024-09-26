namespace Windows_Explorer
{
    partial class WindowExplorer
    {
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            BwBtn = new Button();
            FwBtn = new Button();
            OpenBtn = new Button();
            label1 = new Label();
            PathtxtBox = new TextBox();
            listView = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            copyToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            newFolderToolStripMenuItem = new ToolStripMenuItem();

            SuspendLayout();
            // 
            // BwBtn
            // 
            BwBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            BwBtn.Location = new Point(9, 12);
            BwBtn.Name = "BwBtn";
            BwBtn.Size = new Size(50, 29);
            BwBtn.TabIndex = 0;
            BwBtn.Text = "<<";
            BwBtn.UseVisualStyleBackColor = true;
            BwBtn.Click += BackBtn_Click; // Thêm sự kiện Click cho nút Back
            // 
            // FwBtn
            // 
            FwBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FwBtn.Location = new Point(65, 12);
            FwBtn.Name = "FwBtn";
            FwBtn.Size = new Size(50, 29);
            FwBtn.TabIndex = 1;
            FwBtn.Text = ">>";
            FwBtn.UseVisualStyleBackColor = true;
            FwBtn.Click += ForwardBtn_Click; // Thêm sự kiện Click cho nút Forward
            // 
            // OpenBtn
            // 
            OpenBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            OpenBtn.Location = new Point(694, 12);
            OpenBtn.Name = "OpenBtn";
            OpenBtn.Size = new Size(94, 29);
            OpenBtn.TabIndex = 2;
            OpenBtn.Text = "Open...";
            OpenBtn.UseVisualStyleBackColor = true;
            OpenBtn.Click += OpenBtn_Click; // Thêm sự kiện Click cho nút Open
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 17);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 3;
            label1.Text = "Path:";
            // 
            // PathtxtBox
            // 
            PathtxtBox.Location = new Point(162, 12);
            PathtxtBox.Name = "PathtxtBox";
            PathtxtBox.Size = new Size(526, 27);
            PathtxtBox.TabIndex = 4;
            // 
            // listView
            // 
            listView.ContextMenuStrip = contextMenuStrip1;
            listView.Location = new Point(11, 55);
            listView.Name = "listView";
            listView.Size = new Size(781, 343);
            listView.TabIndex = 5;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.MouseDoubleClick += ListView_MouseDoubleClick; // Thêm sự kiện MouseDoubleClick cho ListView
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
            copyToolStripMenuItem,
            cutToolStripMenuItem,
            pasteToolStripMenuItem,
            deleteToolStripMenuItem,
            newFolderToolStripMenuItem});
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(156, 124);

            // Thêm các mục vào contextMenuStrip1
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(155, 24);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += CopyToolStripMenuItem_Click; // Thêm sự kiện Click cho mục Copy
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(155, 24);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += CutToolStripMenuItem_Click; // Thêm sự kiện Click cho mục Cut
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(155, 24);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += PasteToolStripMenuItem_Click; // Thêm sự kiện Click cho mục Paste
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(155, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click; // Thêm sự kiện Click cho mục Delete
            // 
            // newFolderToolStripMenuItem
            // 
            newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            newFolderToolStripMenuItem.Size = new Size(155, 24);
            newFolderToolStripMenuItem.Text = "New Folder";
            newFolderToolStripMenuItem.Click += NewFolderToolStripMenuItem_Click; // Thêm sự kiện Click cho mục New Folder
            // 
            // WindowExplorer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView);
            Controls.Add(PathtxtBox);
            Controls.Add(label1);
            Controls.Add(OpenBtn);
            Controls.Add(FwBtn);
            Controls.Add(BwBtn);
            Name = "WindowExplorer";
            Text = "Window Explorer";
            Load += WindowExplorer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BwBtn;
        private Button FwBtn;
        private Button OpenBtn;
        private Label label1;
        private TextBox PathtxtBox;
        private ListView listView;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem newFolderToolStripMenuItem;
    }
}
