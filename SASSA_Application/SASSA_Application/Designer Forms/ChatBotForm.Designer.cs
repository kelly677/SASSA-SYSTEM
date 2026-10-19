namespace SASSA_Application.Designer_Forms
{
    partial class ChatBotForm
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
            rtbChat = new RichTextBox();
            txtInput = new SASSA_Application.Classes.RoundedTextBox();
            btnSend = new SASSA_Application.Classes.RoundedButton();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // rtbChat
            // 
            rtbChat.Location = new Point(0, 54);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.Size = new Size(643, 371);
            rtbChat.TabIndex = 0;
            rtbChat.Text = "";
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BackColor = Color.White;
            txtInput.Font = new Font("Segoe UI", 10F);
            txtInput.Location = new Point(30, 435);
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "Type Your Question";
            txtInput.Size = new Size(403, 46);
            txtInput.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(0, 84, 166);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.HoverColor = Color.Empty;
            btnSend.Location = new Point(453, 431);
            btnSend.Name = "btnSend";
            btnSend.PressedColor = Color.Empty;
            btnSend.Size = new Size(178, 50);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(26, 70, 130);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(643, 57);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(30, 19);
            label1.Name = "label1";
            label1.Size = new Size(198, 29);
            label1.TabIndex = 0;
            label1.Text = "Virtual Assistant";
            // 
            // ChatBotForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 520);
            Controls.Add(panel1);
            Controls.Add(btnSend);
            Controls.Add(txtInput);
            Controls.Add(rtbChat);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChatBotForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatBotForm";
            Load += ChatBotForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Classes.RoundedTextBox txtInput;
        private Classes.RoundedButton btnSend;
        private Panel panel1;
        private Label label1;
        internal RichTextBox rtbChat;
    }
}