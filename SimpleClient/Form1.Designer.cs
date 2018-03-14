namespace SimpleClient
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
            this.listenport_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connet_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.userid_text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.word_text = new System.Windows.Forms.TextBox();
            this.quit_btn = new System.Windows.Forms.Button();
            this.word_listbox = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.debug_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listenport_text
            // 
            this.listenport_text.Location = new System.Drawing.Point(122, 34);
            this.listenport_text.Name = "listenport_text";
            this.listenport_text.Size = new System.Drawing.Size(100, 25);
            this.listenport_text.TabIndex = 0;
            this.listenport_text.Text = "1234";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "listenPort";
            // 
            // connet_btn
            // 
            this.connet_btn.Location = new System.Drawing.Point(264, 93);
            this.connet_btn.Name = "connet_btn";
            this.connet_btn.Size = new System.Drawing.Size(75, 23);
            this.connet_btn.TabIndex = 2;
            this.connet_btn.Text = "connect";
            this.connet_btn.UseVisualStyleBackColor = true;
            this.connet_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "userId";
            // 
            // userid_text
            // 
            this.userid_text.Location = new System.Drawing.Point(122, 93);
            this.userid_text.Name = "userid_text";
            this.userid_text.Size = new System.Drawing.Size(100, 25);
            this.userid_text.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "word";
            // 
            // word_text
            // 
            this.word_text.Location = new System.Drawing.Point(122, 156);
            this.word_text.Name = "word_text";
            this.word_text.Size = new System.Drawing.Size(100, 25);
            this.word_text.TabIndex = 6;
            // 
            // quit_btn
            // 
            this.quit_btn.Enabled = false;
            this.quit_btn.Location = new System.Drawing.Point(382, 93);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(75, 23);
            this.quit_btn.TabIndex = 5;
            this.quit_btn.Text = "quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // word_listbox
            // 
            this.word_listbox.FormattingEnabled = true;
            this.word_listbox.ItemHeight = 15;
            this.word_listbox.Location = new System.Drawing.Point(42, 212);
            this.word_listbox.Name = "word_listbox";
            this.word_listbox.Size = new System.Drawing.Size(452, 199);
            this.word_listbox.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(264, 156);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // debug_label
            // 
            this.debug_label.AutoSize = true;
            this.debug_label.Location = new System.Drawing.Point(261, 34);
            this.debug_label.Name = "debug_label";
            this.debug_label.Size = new System.Drawing.Size(41, 15);
            this.debug_label.TabIndex = 11;
            this.debug_label.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.debug_label);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.word_listbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.word_text);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userid_text);
            this.Controls.Add(this.connet_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listenport_text);
            this.Name = "Form1";
            this.Text = "UDPChatClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox listenport_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connet_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userid_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox word_text;
        private System.Windows.Forms.Button quit_btn;
        private System.Windows.Forms.ListBox word_listbox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label debug_label;
    }
}

