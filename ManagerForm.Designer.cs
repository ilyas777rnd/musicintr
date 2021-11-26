namespace Musicinstr
{
    partial class ManagerForm
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
            this.ShowOrders = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbDelivery = new System.Windows.Forms.ListBox();
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.btAdmin = new System.Windows.Forms.Button();
            this.npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            this.npgsqlCommandBuilder2 = new Npgsql.NpgsqlCommandBuilder();
            this.btMakeOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowOrders
            // 
            this.ShowOrders.BackColor = System.Drawing.Color.LightGreen;
            this.ShowOrders.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowOrders.Location = new System.Drawing.Point(12, 70);
            this.ShowOrders.Name = "ShowOrders";
            this.ShowOrders.Size = new System.Drawing.Size(303, 54);
            this.ShowOrders.TabIndex = 2;
            this.ShowOrders.Text = "Показать продажи";
            this.ShowOrders.UseVisualStyleBackColor = false;
            this.ShowOrders.Click += new System.EventHandler(this.ShowOrders_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(618, 397);
            this.dataGridView1.TabIndex = 3;
            // 
            // lbDelivery
            // 
            this.lbDelivery.FormattingEnabled = true;
            this.lbDelivery.ItemHeight = 16;
            this.lbDelivery.Location = new System.Drawing.Point(12, 544);
            this.lbDelivery.Name = "lbDelivery";
            this.lbDelivery.Size = new System.Drawing.Size(1255, 84);
            this.lbDelivery.TabIndex = 4;
            // 
            // dgvBasket
            // 
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(637, 141);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.RowHeadersWidth = 51;
            this.dgvBasket.RowTemplate.Height = 24;
            this.dgvBasket.Size = new System.Drawing.Size(630, 397);
            this.dgvBasket.TabIndex = 8;
            // 
            // btAdmin
            // 
            this.btAdmin.BackColor = System.Drawing.Color.LightGreen;
            this.btAdmin.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAdmin.Location = new System.Drawing.Point(992, 70);
            this.btAdmin.Name = "btAdmin";
            this.btAdmin.Size = new System.Drawing.Size(275, 54);
            this.btAdmin.TabIndex = 9;
            this.btAdmin.Text = "Админ панель";
            this.btAdmin.UseVisualStyleBackColor = false;
            this.btAdmin.Click += new System.EventHandler(this.btAdmin_Click);
            // 
            // npgsqlCommandBuilder1
            // 
            this.npgsqlCommandBuilder1.QuotePrefix = "\"";
            this.npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // npgsqlCommandBuilder2
            // 
            this.npgsqlCommandBuilder2.QuotePrefix = "\"";
            this.npgsqlCommandBuilder2.QuoteSuffix = "\"";
            // 
            // btMakeOrder
            // 
            this.btMakeOrder.BackColor = System.Drawing.Color.LightGreen;
            this.btMakeOrder.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btMakeOrder.Location = new System.Drawing.Point(12, 12);
            this.btMakeOrder.Name = "btMakeOrder";
            this.btMakeOrder.Size = new System.Drawing.Size(303, 54);
            this.btMakeOrder.TabIndex = 10;
            this.btMakeOrder.Text = "Оформить продажу";
            this.btMakeOrder.UseVisualStyleBackColor = false;
            this.btMakeOrder.Click += new System.EventHandler(this.btMakeOrder_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 639);
            this.Controls.Add(this.btMakeOrder);
            this.Controls.Add(this.btAdmin);
            this.Controls.Add(this.dgvBasket);
            this.Controls.Add(this.lbDelivery);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ShowOrders);
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ShowOrders;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lbDelivery;
        private System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Button btAdmin;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder2;
        private System.Windows.Forms.Button btMakeOrder;
    }
}