namespace Archiver
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_AddToArchive = new System.Windows.Forms.Button();
            this.button_ExtractFromArchive = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_SelectFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_AddToArchive
            // 
            this.button_AddToArchive.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_AddToArchive.Enabled = false;
            this.button_AddToArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AddToArchive.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AddToArchive.Location = new System.Drawing.Point(20, 100);
            this.button_AddToArchive.Margin = new System.Windows.Forms.Padding(4);
            this.button_AddToArchive.Name = "button_AddToArchive";
            this.button_AddToArchive.Size = new System.Drawing.Size(196, 46);
            this.button_AddToArchive.TabIndex = 0;
            this.button_AddToArchive.Text = "ДОБАВИТЬ В АРХИВ";
            this.button_AddToArchive.UseVisualStyleBackColor = false;
            this.button_AddToArchive.Click += new System.EventHandler(this.button_AddToArchive_Click);
            // 
            // button_ExtractFromArchive
            // 
            this.button_ExtractFromArchive.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_ExtractFromArchive.Enabled = false;
            this.button_ExtractFromArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ExtractFromArchive.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ExtractFromArchive.Location = new System.Drawing.Point(20, 153);
            this.button_ExtractFromArchive.Margin = new System.Windows.Forms.Padding(4);
            this.button_ExtractFromArchive.Name = "button_ExtractFromArchive";
            this.button_ExtractFromArchive.Size = new System.Drawing.Size(196, 46);
            this.button_ExtractFromArchive.TabIndex = 1;
            this.button_ExtractFromArchive.Text = "ИЗВЛЕЧЬ ИЗ АРХИВА";
            this.button_ExtractFromArchive.UseVisualStyleBackColor = false;
            this.button_ExtractFromArchive.Click += new System.EventHandler(this.button_ExtractFromArchive_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Exit.Location = new System.Drawing.Point(495, 197);
            this.button_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(196, 46);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "ВЫХОД";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_SelectFile
            // 
            this.button_SelectFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_SelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SelectFile.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_SelectFile.Location = new System.Drawing.Point(20, 37);
            this.button_SelectFile.Margin = new System.Windows.Forms.Padding(4);
            this.button_SelectFile.Name = "button_SelectFile";
            this.button_SelectFile.Size = new System.Drawing.Size(196, 46);
            this.button_SelectFile.TabIndex = 5;
            this.button_SelectFile.Text = "ВЫБРАТЬ ФАЙЛ";
            this.button_SelectFile.UseVisualStyleBackColor = false;
            this.button_SelectFile.Click += new System.EventHandler(this.button_SelectFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(225, 48);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(465, 22);
            this.textBox1.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog_Select_File";
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Status.ForeColor = System.Drawing.Color.Teal;
            this.label_Status.Location = new System.Drawing.Point(520, 161);
            this.label_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(0, 22);
            this.label_Status.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(707, 262);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_SelectFile);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_ExtractFromArchive);
            this.Controls.Add(this.button_AddToArchive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_AddToArchive;
        private System.Windows.Forms.Button button_ExtractFromArchive;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_SelectFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label_Status;
    }
}

