namespace EP
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            pbMain = new PictureBox();
            txtLog = new RichTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            txtBonus = new Label();
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            SuspendLayout();
            // 
            // pbMain
            // 
            pbMain.Location = new Point(30, 42);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(566, 366);
            pbMain.TabIndex = 0;
            pbMain.TabStop = false;
            pbMain.Paint += pbMain_Paint;
            pbMain.MouseClick += pbMain_MouseClick;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(602, 42);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(162, 366);
            txtLog.TabIndex = 1;
            txtLog.Text = "";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // txtBonus
            // 
            txtBonus.AutoSize = true;
            txtBonus.Location = new Point(509, 62);
            txtBonus.Name = "txtBonus";
            txtBonus.Size = new Size(59, 25);
            txtBonus.TabIndex = 2;
            txtBonus.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBonus);
            Controls.Add(txtLog);
            Controls.Add(pbMain);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbMain;
        private RichTextBox txtLog;
        private System.Windows.Forms.Timer timer1;
        private Label txtBonus;
    }
}
