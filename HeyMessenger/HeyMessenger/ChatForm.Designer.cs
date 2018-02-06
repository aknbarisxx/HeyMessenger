namespace HeyMessenger
{
    partial class formChat
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelChat = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelChatTitle = new System.Windows.Forms.Label();
            this.textBoxBenutzer = new System.Windows.Forms.TextBox();
            this.buttonBenutzer = new System.Windows.Forms.Button();
            this.labelBenutzer = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelChat
            // 
            this.labelChat.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelChat.Location = new System.Drawing.Point(12, 78);
            this.labelChat.Name = "labelChat";
            this.labelChat.Size = new System.Drawing.Size(501, 290);
            this.labelChat.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(351, 389);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(162, 20);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Senden";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelChatTitle
            // 
            this.labelChatTitle.AutoSize = true;
            this.labelChatTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChatTitle.Location = new System.Drawing.Point(12, 44);
            this.labelChatTitle.Name = "labelChatTitle";
            this.labelChatTitle.Size = new System.Drawing.Size(65, 25);
            this.labelChatTitle.TabIndex = 3;
            this.labelChatTitle.Text = "Chat:";
            // 
            // textBoxBenutzer
            // 
            this.textBoxBenutzer.Location = new System.Drawing.Point(17, 13);
            this.textBoxBenutzer.Name = "textBoxBenutzer";
            this.textBoxBenutzer.Size = new System.Drawing.Size(100, 20);
            this.textBoxBenutzer.TabIndex = 4;
            // 
            // buttonBenutzer
            // 
            this.buttonBenutzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBenutzer.Location = new System.Drawing.Point(124, 13);
            this.buttonBenutzer.Name = "buttonBenutzer";
            this.buttonBenutzer.Size = new System.Drawing.Size(75, 23);
            this.buttonBenutzer.TabIndex = 5;
            this.buttonBenutzer.Text = "Erstellen";
            this.buttonBenutzer.UseVisualStyleBackColor = true;
            this.buttonBenutzer.Click += new System.EventHandler(this.buttonBenutzer_Click);
            // 
            // labelBenutzer
            // 
            this.labelBenutzer.AutoSize = true;
            this.labelBenutzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBenutzer.Location = new System.Drawing.Point(17, 1);
            this.labelBenutzer.Name = "labelBenutzer";
            this.labelBenutzer.Size = new System.Drawing.Size(57, 13);
            this.labelBenutzer.TabIndex = 6;
            this.labelBenutzer.Text = "Benutzer";
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new System.Drawing.Point(12, 390);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new System.Drawing.Size(332, 20);
            textBoxMessage.TabIndex = 0;
            textBoxMessage.TextChanged += new System.EventHandler(this.textBoxMessage_TextChanged);
            // 
            // formChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(525, 422);
            this.Controls.Add(this.labelBenutzer);
            this.Controls.Add(this.buttonBenutzer);
            this.Controls.Add(this.textBoxBenutzer);
            this.Controls.Add(this.labelChatTitle);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelChat);
            this.Controls.Add(textBoxMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "formChat";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelChatTitle;
        private System.Windows.Forms.TextBox textBoxBenutzer;
        private System.Windows.Forms.Button buttonBenutzer;
        private System.Windows.Forms.Label labelBenutzer;
    }
}

