namespace ParkingUI
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBrowseClients = new System.Windows.Forms.Button();
            this.buttonBrowseCars = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBrowseClients
            // 
            this.buttonBrowseClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseClients.Location = new System.Drawing.Point(13, 13);
            this.buttonBrowseClients.Name = "buttonBrowseClients";
            this.buttonBrowseClients.Size = new System.Drawing.Size(190, 26);
            this.buttonBrowseClients.TabIndex = 0;
            this.buttonBrowseClients.Text = "Список клиентов";
            this.buttonBrowseClients.UseVisualStyleBackColor = true;
            this.buttonBrowseClients.Click += new System.EventHandler(this.buttonBrowseClients_Click);
            // 
            // buttonBrowseCars
            // 
            this.buttonBrowseCars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseCars.Location = new System.Drawing.Point(13, 43);
            this.buttonBrowseCars.Name = "buttonBrowseCars";
            this.buttonBrowseCars.Size = new System.Drawing.Size(190, 26);
            this.buttonBrowseCars.TabIndex = 1;
            this.buttonBrowseCars.Text = "Список машин";
            this.buttonBrowseCars.UseVisualStyleBackColor = true;
            this.buttonBrowseCars.Click += new System.EventHandler(this.buttonBrowseCars_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(13, 73);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(190, 26);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 108);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonBrowseCars);
            this.Controls.Add(this.buttonBrowseClients);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowseClients;
        private System.Windows.Forms.Button buttonBrowseCars;
        private System.Windows.Forms.Button buttonExit;
    }
}

