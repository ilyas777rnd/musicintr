namespace Musicinstr
{
    partial class AdminForm
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
            this.btEmployee = new System.Windows.Forms.Button();
            this.btSupply = new System.Windows.Forms.Button();
            this.btMusicinstr = new System.Windows.Forms.Button();
            this.createCopy = new System.Windows.Forms.Button();
            this.loadCopy = new System.Windows.Forms.Button();
            this.Backup = new System.Windows.Forms.Button();
            this.tableType = new System.Windows.Forms.Button();
            this.btShop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btEmployee
            // 
            this.btEmployee.Location = new System.Drawing.Point(24, 32);
            this.btEmployee.Name = "btEmployee";
            this.btEmployee.Size = new System.Drawing.Size(240, 56);
            this.btEmployee.TabIndex = 0;
            this.btEmployee.Text = "Добавить/Изменить/Удалить сотрудников";
            this.btEmployee.UseVisualStyleBackColor = true;
            this.btEmployee.Click += new System.EventHandler(this.btEmployee_Click);
            // 
            // btSupply
            // 
            this.btSupply.Location = new System.Drawing.Point(299, 32);
            this.btSupply.Name = "btSupply";
            this.btSupply.Size = new System.Drawing.Size(184, 56);
            this.btSupply.TabIndex = 1;
            this.btSupply.Text = "Поставщики и поставки";
            this.btSupply.UseVisualStyleBackColor = true;
            this.btSupply.Click += new System.EventHandler(this.btSupply_Click);
            // 
            // btMusicinstr
            // 
            this.btMusicinstr.Location = new System.Drawing.Point(523, 32);
            this.btMusicinstr.Name = "btMusicinstr";
            this.btMusicinstr.Size = new System.Drawing.Size(232, 56);
            this.btMusicinstr.TabIndex = 2;
            this.btMusicinstr.Text = "Добавить/Изменить/Удалить инструменты";
            this.btMusicinstr.UseVisualStyleBackColor = true;
            this.btMusicinstr.Click += new System.EventHandler(this.btTech_Click);
            // 
            // createCopy
            // 
            this.createCopy.BackColor = System.Drawing.Color.PaleGreen;
            this.createCopy.Location = new System.Drawing.Point(24, 218);
            this.createCopy.Name = "createCopy";
            this.createCopy.Size = new System.Drawing.Size(240, 69);
            this.createCopy.TabIndex = 3;
            this.createCopy.Text = "Создать резервную копию БД";
            this.createCopy.UseVisualStyleBackColor = false;
            this.createCopy.Click += new System.EventHandler(this.createCopy_Click);
            // 
            // loadCopy
            // 
            this.loadCopy.BackColor = System.Drawing.Color.PaleGreen;
            this.loadCopy.Location = new System.Drawing.Point(24, 293);
            this.loadCopy.Name = "loadCopy";
            this.loadCopy.Size = new System.Drawing.Size(240, 69);
            this.loadCopy.TabIndex = 4;
            this.loadCopy.Text = "Загрузить резервную копию БД";
            this.loadCopy.UseVisualStyleBackColor = false;
            this.loadCopy.Click += new System.EventHandler(this.loadCopy_Click);
            // 
            // Backup
            // 
            this.Backup.BackColor = System.Drawing.Color.LightCoral;
            this.Backup.Location = new System.Drawing.Point(523, 293);
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(220, 69);
            this.Backup.TabIndex = 5;
            this.Backup.Text = "Система отката и темпоральные таблицы";
            this.Backup.UseVisualStyleBackColor = false;
            this.Backup.Click += new System.EventHandler(this.Backup_Click);
            // 
            // tableType
            // 
            this.tableType.Location = new System.Drawing.Point(24, 123);
            this.tableType.Name = "tableType";
            this.tableType.Size = new System.Drawing.Size(240, 66);
            this.tableType.TabIndex = 6;
            this.tableType.Text = "Категории(Типы) инструментов";
            this.tableType.UseVisualStyleBackColor = true;
            this.tableType.Click += new System.EventHandler(this.tableType_Click);
            // 
            // btShop
            // 
            this.btShop.Location = new System.Drawing.Point(523, 123);
            this.btShop.Name = "btShop";
            this.btShop.Size = new System.Drawing.Size(232, 66);
            this.btShop.TabIndex = 7;
            this.btShop.Text = "Данные о магазине";
            this.btShop.UseVisualStyleBackColor = true;
            this.btShop.Click += new System.EventHandler(this.btShop_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btShop);
            this.Controls.Add(this.tableType);
            this.Controls.Add(this.Backup);
            this.Controls.Add(this.loadCopy);
            this.Controls.Add(this.createCopy);
            this.Controls.Add(this.btMusicinstr);
            this.Controls.Add(this.btSupply);
            this.Controls.Add(this.btEmployee);
            this.Name = "AdminForm";
            this.Text = "Админ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btEmployee;
        private System.Windows.Forms.Button btSupply;
        private System.Windows.Forms.Button btMusicinstr;
        private System.Windows.Forms.Button createCopy;
        private System.Windows.Forms.Button loadCopy;
        private System.Windows.Forms.Button Backup;
        private System.Windows.Forms.Button tableType;
        private System.Windows.Forms.Button btShop;
    }
}