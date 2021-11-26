namespace Musicinstr
{
    partial class makeOrder
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.priceOT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.priceDO = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.addInBasket = new System.Windows.Forms.Button();
            this.deleteFromBasket = new System.Windows.Forms.Button();
            this.finish_ord = new System.Windows.Forms.Button();
            this.cbAmounce = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1415, 302);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(205, 33);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(329, 22);
            this.tbName.TabIndex = 1;
            // 
            // priceOT
            // 
            this.priceOT.Location = new System.Drawing.Point(912, 30);
            this.priceOT.Name = "priceOT";
            this.priceOT.Size = new System.Drawing.Size(218, 22);
            this.priceOT.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(840, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Цена от:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1136, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Цена до:";
            // 
            // priceDO
            // 
            this.priceDO.Location = new System.Drawing.Point(1209, 30);
            this.priceDO.Name = "priceDO";
            this.priceDO.Size = new System.Drawing.Size(218, 22);
            this.priceDO.TabIndex = 4;
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSearch.Location = new System.Drawing.Point(12, 12);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(181, 43);
            this.btSearch.TabIndex = 6;
            this.btSearch.Text = "Поиск:";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Название товара:";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(557, 32);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(277, 24);
            this.cbCategory.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Категория товара:";
            // 
            // dgvBasket
            // 
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(13, 401);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.RowHeadersWidth = 51;
            this.dgvBasket.RowTemplate.Height = 24;
            this.dgvBasket.Size = new System.Drawing.Size(521, 267);
            this.dgvBasket.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Моя корзина:";
            // 
            // addInBasket
            // 
            this.addInBasket.Location = new System.Drawing.Point(557, 401);
            this.addInBasket.Name = "addInBasket";
            this.addInBasket.Size = new System.Drawing.Size(226, 52);
            this.addInBasket.TabIndex = 12;
            this.addInBasket.Text = "Добавить в корзину (выберите строку в каталоге)";
            this.addInBasket.UseVisualStyleBackColor = true;
            this.addInBasket.Click += new System.EventHandler(this.addInBasket_Click);
            // 
            // deleteFromBasket
            // 
            this.deleteFromBasket.Location = new System.Drawing.Point(557, 524);
            this.deleteFromBasket.Name = "deleteFromBasket";
            this.deleteFromBasket.Size = new System.Drawing.Size(226, 52);
            this.deleteFromBasket.TabIndex = 13;
            this.deleteFromBasket.Text = "Убрать из корзины (выберите строку в корзине)";
            this.deleteFromBasket.UseVisualStyleBackColor = true;
            this.deleteFromBasket.Click += new System.EventHandler(this.deleteFromBasket_Click);
            // 
            // finish_ord
            // 
            this.finish_ord.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finish_ord.Location = new System.Drawing.Point(557, 600);
            this.finish_ord.Name = "finish_ord";
            this.finish_ord.Size = new System.Drawing.Size(226, 66);
            this.finish_ord.TabIndex = 22;
            this.finish_ord.Text = "Оформить заказ";
            this.finish_ord.UseVisualStyleBackColor = true;
            this.finish_ord.Click += new System.EventHandler(this.finish_ord_Click);
            // 
            // cbAmounce
            // 
            this.cbAmounce.FormattingEnabled = true;
            this.cbAmounce.Location = new System.Drawing.Point(557, 485);
            this.cbAmounce.Name = "cbAmounce";
            this.cbAmounce.Size = new System.Drawing.Size(226, 24);
            this.cbAmounce.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(554, 465);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Количество товара:";
            // 
            // makeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1458, 680);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbAmounce);
            this.Controls.Add(this.finish_ord);
            this.Controls.Add(this.deleteFromBasket);
            this.Controls.Add(this.addInBasket);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvBasket);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.priceDO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.priceOT);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "makeOrder";
            this.Text = "MakeOrder";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox priceOT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox priceDO;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addInBasket;
        private System.Windows.Forms.Button deleteFromBasket;
        private System.Windows.Forms.Button finish_ord;
        private System.Windows.Forms.ComboBox cbAmounce;
        private System.Windows.Forms.Label label9;
    }
}