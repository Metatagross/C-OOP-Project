namespace ClientImplementation
{
    partial class UserGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if(disposing && (components != null))
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
        private void InitializeComponent ( )
        {
            this.lblHead = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtbUser = new System.Windows.Forms.TextBox();
            this.txtbCipher = new System.Windows.Forms.TextBox();
            this.lblCipher = new System.Windows.Forms.Label();
            this.txtbGet = new System.Windows.Forms.TextBox();
            this.lblGet = new System.Windows.Forms.Label();
            this.txtbReturnCypher = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbReturnBank = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnCrypt = new System.Windows.Forms.Button();
            this.btnGetCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Location = new System.Drawing.Point(19, 9);
            this.lblHead.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(311, 39);
            this.lblHead.TabIndex = 0;
            this.lblHead.Text = "Bank Cipher Solver";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUser.Location = new System.Drawing.Point(26, 76);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(92, 17);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Потребител:";
            // 
            // txtbUser
            // 
            this.txtbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtbUser.Location = new System.Drawing.Point(158, 73);
            this.txtbUser.Name = "txtbUser";
            this.txtbUser.Size = new System.Drawing.Size(206, 23);
            this.txtbUser.TabIndex = 1;
            // 
            // txtbCipher
            // 
            this.txtbCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtbCipher.Location = new System.Drawing.Point(158, 172);
            this.txtbCipher.Name = "txtbCipher";
            this.txtbCipher.ReadOnly = true;
            this.txtbCipher.Size = new System.Drawing.Size(206, 23);
            this.txtbCipher.TabIndex = 3;
            // 
            // lblCipher
            // 
            this.lblCipher.AutoSize = true;
            this.lblCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCipher.Location = new System.Drawing.Point(26, 175);
            this.lblCipher.Name = "lblCipher";
            this.lblCipher.Size = new System.Drawing.Size(126, 17);
            this.lblCipher.TabIndex = 3;
            this.lblCipher.Text = "Криптирай карта:";
            // 
            // txtbGet
            // 
            this.txtbGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtbGet.Location = new System.Drawing.Point(158, 276);
            this.txtbGet.Name = "txtbGet";
            this.txtbGet.ReadOnly = true;
            this.txtbGet.Size = new System.Drawing.Size(206, 23);
            this.txtbGet.TabIndex = 4;
            // 
            // lblGet
            // 
            this.lblGet.AutoSize = true;
            this.lblGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblGet.Location = new System.Drawing.Point(26, 279);
            this.lblGet.Name = "lblGet";
            this.lblGet.Size = new System.Drawing.Size(113, 17);
            this.lblGet.TabIndex = 5;
            this.lblGet.Text = "Извлечи номер:";
            // 
            // txtbReturnCypher
            // 
            this.txtbReturnCypher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtbReturnCypher.Location = new System.Drawing.Point(158, 210);
            this.txtbReturnCypher.Name = "txtbReturnCypher";
            this.txtbReturnCypher.ReadOnly = true;
            this.txtbReturnCypher.Size = new System.Drawing.Size(206, 23);
            this.txtbReturnCypher.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(26, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Крипт:";
            // 
            // txtbReturnBank
            // 
            this.txtbReturnBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtbReturnBank.Location = new System.Drawing.Point(158, 315);
            this.txtbReturnBank.Name = "txtbReturnBank";
            this.txtbReturnBank.ReadOnly = true;
            this.txtbReturnBank.Size = new System.Drawing.Size(206, 23);
            this.txtbReturnBank.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(26, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Банков номер:";
            // 
            // txtbPass
            // 
            this.txtbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtbPass.Location = new System.Drawing.Point(158, 107);
            this.txtbPass.Name = "txtbPass";
            this.txtbPass.PasswordChar = '*';
            this.txtbPass.Size = new System.Drawing.Size(206, 23);
            this.txtbPass.TabIndex = 2;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPass.Location = new System.Drawing.Point(26, 110);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(62, 17);
            this.lblPass.TabIndex = 11;
            this.lblPass.Text = "Парола:";
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEnter.Location = new System.Drawing.Point(268, 137);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(96, 29);
            this.btnEnter.TabIndex = 12;
            this.btnEnter.Text = "Вход";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnCrypt
            // 
            this.btnCrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCrypt.Location = new System.Drawing.Point(268, 240);
            this.btnCrypt.Name = "btnCrypt";
            this.btnCrypt.Size = new System.Drawing.Size(96, 30);
            this.btnCrypt.TabIndex = 13;
            this.btnCrypt.Text = "Криптирай";
            this.btnCrypt.UseVisualStyleBackColor = true;
            this.btnCrypt.Click += new System.EventHandler(this.btnCrypt_Click);
            // 
            // btnGetCard
            // 
            this.btnGetCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGetCard.Location = new System.Drawing.Point(268, 345);
            this.btnGetCard.Name = "btnGetCard";
            this.btnGetCard.Size = new System.Drawing.Size(96, 45);
            this.btnGetCard.TabIndex = 14;
            this.btnGetCard.Text = "Извлечи номер";
            this.btnGetCard.UseVisualStyleBackColor = true;
            this.btnGetCard.Click += new System.EventHandler(this.btnGetCard_Click);
            // 
            // UserGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClientImplementation.Properties.Resources.banker;
            this.ClientSize = new System.Drawing.Size(721, 402);
            this.Controls.Add(this.btnGetCard);
            this.Controls.Add(this.btnCrypt);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtbPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtbReturnBank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbReturnCypher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbGet);
            this.Controls.Add(this.lblGet);
            this.Controls.Add(this.txtbCipher);
            this.Controls.Add(this.lblCipher);
            this.Controls.Add(this.txtbUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblHead);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "UserGUI";
            this.Text = "Bank Cipher Solver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserGUI_FormClosing);
            this.Load += new System.EventHandler(this.UserGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtbUser;
        private System.Windows.Forms.TextBox txtbCipher;
        private System.Windows.Forms.Label lblCipher;
        private System.Windows.Forms.TextBox txtbGet;
        private System.Windows.Forms.Label lblGet;
        private System.Windows.Forms.TextBox txtbReturnCypher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbReturnBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnCrypt;
        private System.Windows.Forms.Button btnGetCard;
    }
}

