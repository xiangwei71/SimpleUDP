namespace SimpleServer
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.quit_btn = new System.Windows.Forms.Button();
            this.listen_btn = new System.Windows.Forms.Button();
            this.word_listbox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // quit_btn
            // 
            this.quit_btn.Enabled = false;
            this.quit_btn.Location = new System.Drawing.Point(43, 89);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(75, 23);
            this.quit_btn.TabIndex = 2;
            this.quit_btn.Text = "quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // listen_btn
            // 
            this.listen_btn.Location = new System.Drawing.Point(43, 43);
            this.listen_btn.Name = "listen_btn";
            this.listen_btn.Size = new System.Drawing.Size(75, 23);
            this.listen_btn.TabIndex = 0;
            this.listen_btn.Text = "listen";
            this.listen_btn.UseVisualStyleBackColor = true;
            this.listen_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // word_listbox
            // 
            this.word_listbox.FormattingEnabled = true;
            this.word_listbox.ItemHeight = 15;
            this.word_listbox.Location = new System.Drawing.Point(177, 43);
            this.word_listbox.Name = "word_listbox";
            this.word_listbox.Size = new System.Drawing.Size(564, 319);
            this.word_listbox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.word_listbox);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.listen_btn);
            this.Name = "Form1";
            this.Text = "UDPChatServer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button quit_btn;
        private System.Windows.Forms.Button listen_btn;
        private System.Windows.Forms.ListBox word_listbox;
    }
}

