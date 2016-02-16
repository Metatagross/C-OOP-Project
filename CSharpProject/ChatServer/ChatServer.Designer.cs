partial class ChatServerForm
{
   /// <summary>
   /// Required designer variable.
   /// </summary>
   private System.ComponentModel.IContainer components = null;

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   protected override void Dispose( bool disposing )
   {
      if (disposing && (components != null))
      {
         components.Dispose();
      }
      base.Dispose( disposing );
   }

   #region Windows Form Designer generated code

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   private void InitializeComponent()
   {
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // displayTextBox
            // 
            this.displayTextBox.Location = new System.Drawing.Point(13, 12);
            this.displayTextBox.Multiline = true;
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.Size = new System.Drawing.Size(267, 242);
            this.displayTextBox.TabIndex = 1;
            this.displayTextBox.TextChanged += new System.EventHandler(this.displayTextBox_TextChanged);
            // 
            // ChatServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.displayTextBox);
            this.Name = "ChatServerForm";
            this.Text = "Chat Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

   }

   #endregion
   private System.Windows.Forms.TextBox displayTextBox;
}

