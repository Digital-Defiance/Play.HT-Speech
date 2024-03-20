namespace TTSPlay.HT
{
    partial class Settings
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
            lblUserId = new Label();
            txtUserId = new TextBox();
            txtUserSecret = new TextBox();
            lblUserSecret = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            lblAudioDevices = new Label();
            listAudioDevices = new ComboBox();
            SuspendLayout();
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(41, 22);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(181, 32);
            lblUserId.TabIndex = 0;
            lblUserId.Text = "Play.HT User ID:";
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(228, 19);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(709, 39);
            txtUserId.TabIndex = 1;
            // 
            // txtUserSecret
            // 
            txtUserSecret.Location = new Point(228, 64);
            txtUserSecret.Name = "txtUserSecret";
            txtUserSecret.Size = new Size(709, 39);
            txtUserSecret.TabIndex = 3;
            // 
            // lblUserSecret
            // 
            lblUserSecret.AutoSize = true;
            lblUserSecret.Location = new Point(6, 67);
            lblUserSecret.Name = "lblUserSecret";
            lblUserSecret.Size = new Size(216, 32);
            lblUserSecret.TabIndex = 2;
            lblUserSecret.Text = "Play.HT Secret Key:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(791, 164);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 45);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button1_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(639, 163);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(146, 45);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += button2_Click;
            // 
            // lblAudioDevices
            // 
            lblAudioDevices.AutoSize = true;
            lblAudioDevices.Location = new Point(51, 115);
            lblAudioDevices.Name = "lblAudioDevices";
            lblAudioDevices.Size = new Size(171, 32);
            lblAudioDevices.TabIndex = 6;
            lblAudioDevices.Text = "Audio Devices:";
            // 
            // listAudioDevices
            // 
            listAudioDevices.FormattingEnabled = true;
            listAudioDevices.Location = new Point(228, 112);
            listAudioDevices.Name = "listAudioDevices";
            listAudioDevices.Size = new Size(709, 40);
            listAudioDevices.TabIndex = 7;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 222);
            Controls.Add(listAudioDevices);
            Controls.Add(lblAudioDevices);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtUserSecret);
            Controls.Add(lblUserSecret);
            Controls.Add(txtUserId);
            Controls.Add(lblUserId);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserId;
        private TextBox txtUserId;
        private TextBox txtUserSecret;
        private Label lblUserSecret;
        private Button btnSave;
        private Button btnCancel;
        private Label lblAudioDevices;
        private ComboBox listAudioDevices;
    }
}