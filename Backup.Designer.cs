namespace Musicinstr
{
    partial class Backup
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btBackup = new System.Windows.Forms.Button();
            this.rbOrder = new System.Windows.Forms.RadioButton();
            this.rbOrdList = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(988, 639);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1006, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(666, 706);
            this.dataGridView2.TabIndex = 1;
            // 
            // btBackup
            // 
            this.btBackup.Location = new System.Drawing.Point(12, 12);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(479, 61);
            this.btBackup.TabIndex = 2;
            this.btBackup.Text = "Откатить запись (выберите строку в  таблице)";
            this.btBackup.UseVisualStyleBackColor = true;
            this.btBackup.Click += new System.EventHandler(this.btBackup_Click);
            // 
            // rbOrder
            // 
            this.rbOrder.AutoSize = true;
            this.rbOrder.Location = new System.Drawing.Point(508, 12);
            this.rbOrder.Name = "rbOrder";
            this.rbOrder.Size = new System.Drawing.Size(68, 21);
            this.rbOrder.TabIndex = 3;
            this.rbOrder.TabStop = true;
            this.rbOrder.Text = "Заказ";
            this.rbOrder.UseVisualStyleBackColor = true;
            this.rbOrder.CheckedChanged += new System.EventHandler(this.rbOrder_CheckedChanged);
            // 
            // rbOrdList
            // 
            this.rbOrdList.AutoSize = true;
            this.rbOrdList.Location = new System.Drawing.Point(508, 39);
            this.rbOrdList.Name = "rbOrdList";
            this.rbOrdList.Size = new System.Drawing.Size(124, 21);
            this.rbOrdList.TabIndex = 4;
            this.rbOrdList.TabStop = true;
            this.rbOrdList.Text = "Состав заказа";
            this.rbOrdList.UseVisualStyleBackColor = true;
            this.rbOrdList.CheckedChanged += new System.EventHandler(this.rbOrdList_CheckedChanged);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 730);
            this.Controls.Add(this.rbOrdList);
            this.Controls.Add(this.rbOrder);
            this.Controls.Add(this.btBackup);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Backup";
            this.Text = "Backup";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btBackup;
        private System.Windows.Forms.RadioButton rbOrder;
        private System.Windows.Forms.RadioButton rbOrdList;
    }
}