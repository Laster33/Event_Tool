namespace Event_Tool {
    partial class Trigger {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.eventCombo = new System.Windows.Forms.ComboBox();
            this.minNum = new System.Windows.Forms.NumericUpDown();
            this.maxNum = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNum)).BeginInit();
            this.SuspendLayout();
            // 
            // eventCombo
            // 
            this.eventCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.eventCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eventCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.eventCombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.eventCombo.FormattingEnabled = true;
            this.eventCombo.Location = new System.Drawing.Point(57, 71);
            this.eventCombo.Name = "eventCombo";
            this.eventCombo.Size = new System.Drawing.Size(338, 34);
            this.eventCombo.TabIndex = 76;
            // 
            // minNum
            // 
            this.minNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.minNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.minNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.minNum.Location = new System.Drawing.Point(420, 71);
            this.minNum.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.minNum.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.minNum.Name = "minNum";
            this.minNum.Size = new System.Drawing.Size(70, 37);
            this.minNum.TabIndex = 78;
            this.minNum.Tag = "";
            this.minNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maxNum
            // 
            this.maxNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.maxNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maxNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.maxNum.Location = new System.Drawing.Point(510, 71);
            this.maxNum.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.maxNum.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.maxNum.Name = "maxNum";
            this.maxNum.Size = new System.Drawing.Size(70, 37);
            this.maxNum.TabIndex = 79;
            this.maxNum.Tag = "";
            this.maxNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = true;
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(201)))), ((int)(((byte)(255)))));
            this.saveButton.Location = new System.Drawing.Point(445, 128);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(135, 43);
            this.saveButton.TabIndex = 88;
            this.saveButton.Text = "KAYDET";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.buttonDelete.Location = new System.Drawing.Point(260, 128);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(135, 43);
            this.buttonDelete.TabIndex = 89;
            this.buttonDelete.Text = "SİL";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Trigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(654, 214);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.maxNum);
            this.Controls.Add(this.minNum);
            this.Controls.Add(this.eventCombo);
            this.Name = "Trigger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trigger";
            ((System.ComponentModel.ISupportInitialize)(this.minNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox eventCombo;
        private System.Windows.Forms.NumericUpDown minNum;
        private System.Windows.Forms.NumericUpDown maxNum;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button buttonDelete;
    }
}