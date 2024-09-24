namespace Windows_Explorer
{
    partial class WindowExplorer

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
            BwBtn = new Button();
            FwBtn = new Button();
            OpenBtn = new Button();
            label1 = new Label();
            PathtxtBox = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

            listView = new ListView();

            SuspendLayout();
            // 
            // BwBtn
            // 
            BwBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BwBtn.Location = new Point(9, 12);
            BwBtn.Name = "BwBtn";
            BwBtn.Size = new Size(50, 29);
            BwBtn.TabIndex = 0;
            BwBtn.Text = "<<";
            BwBtn.UseVisualStyleBackColor = true;

            // 
            // FwBtn
            // 

            FwBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FwBtn.Location = new Point(65, 12);
            FwBtn.Name = "FwBtn";
            FwBtn.Size = new Size(50, 29);
            FwBtn.TabIndex = 1;
            FwBtn.Text = ">>";
            FwBtn.UseVisualStyleBackColor = true;
            // OpenBtn
            // 
            OpenBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OpenBtn.Location = new Point(694, 12);
            OpenBtn.Name = "OpenBtn";
            OpenBtn.Size = new Size(94, 29);
            OpenBtn.TabIndex = 2;
            OpenBtn.Text = "Open...";
            OpenBtn.UseVisualStyleBackColor = true;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 17);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 3;
            label1.Text = "Path :";
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
            listView.Location = new Point(11, 55);
            listView.Name = "listView";
            listView.Size = new Size(781, 343);
            listView.TabIndex = 5;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 

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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
      private ListView listView;

    }
}
