namespace ConsignmentShopUI
{
    partial class ConsignmentShop
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
            this.HeaderText = new System.Windows.Forms.Label();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.itemslistboxlabel = new System.Windows.Forms.Label();
            this.addtocart = new System.Windows.Forms.Button();
            this.shoppingcartlistboxlabel = new System.Windows.Forms.Label();
            this.shoppingcartlistbox = new System.Windows.Forms.ListBox();
            this.makepurchasebutton = new System.Windows.Forms.Button();
            this.vendorlistboxlabel = new System.Windows.Forms.Label();
            this.vendorlistbox = new System.Windows.Forms.ListBox();
            this.storeprofitlabel = new System.Windows.Forms.Label();
            this.storeprofitvalue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HeaderText
            // 
            this.HeaderText.AutoSize = true;
            this.HeaderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderText.Location = new System.Drawing.Point(21, 23);
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.Size = new System.Drawing.Size(405, 37);
            this.HeaderText.TabIndex = 0;
            this.HeaderText.Text = "Consignment Shop Demo";
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.ItemHeight = 20;
            this.ItemsListBox.Location = new System.Drawing.Point(28, 106);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(365, 204);
            this.ItemsListBox.TabIndex = 1;
            // 
            // itemslistboxlabel
            // 
            this.itemslistboxlabel.AutoSize = true;
            this.itemslistboxlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemslistboxlabel.Location = new System.Drawing.Point(24, 83);
            this.itemslistboxlabel.Name = "itemslistboxlabel";
            this.itemslistboxlabel.Size = new System.Drawing.Size(103, 20);
            this.itemslistboxlabel.TabIndex = 2;
            this.itemslistboxlabel.Text = "Store Items";
            // 
            // addtocart
            // 
            this.addtocart.Location = new System.Drawing.Point(452, 183);
            this.addtocart.Name = "addtocart";
            this.addtocart.Size = new System.Drawing.Size(126, 37);
            this.addtocart.TabIndex = 3;
            this.addtocart.Text = "Add to Cart ->";
            this.addtocart.UseVisualStyleBackColor = true;
            this.addtocart.Click += new System.EventHandler(this.addtocart_Click);
            // 
            // shoppingcartlistboxlabel
            // 
            this.shoppingcartlistboxlabel.AutoSize = true;
            this.shoppingcartlistboxlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shoppingcartlistboxlabel.Location = new System.Drawing.Point(635, 83);
            this.shoppingcartlistboxlabel.Name = "shoppingcartlistboxlabel";
            this.shoppingcartlistboxlabel.Size = new System.Drawing.Size(124, 20);
            this.shoppingcartlistboxlabel.TabIndex = 5;
            this.shoppingcartlistboxlabel.Text = "Shopping Cart";
            // 
            // shoppingcartlistbox
            // 
            this.shoppingcartlistbox.FormattingEnabled = true;
            this.shoppingcartlistbox.ItemHeight = 20;
            this.shoppingcartlistbox.Location = new System.Drawing.Point(639, 106);
            this.shoppingcartlistbox.Name = "shoppingcartlistbox";
            this.shoppingcartlistbox.Size = new System.Drawing.Size(365, 204);
            this.shoppingcartlistbox.TabIndex = 4;
            // 
            // makepurchasebutton
            // 
            this.makepurchasebutton.Location = new System.Drawing.Point(878, 316);
            this.makepurchasebutton.Name = "makepurchasebutton";
            this.makepurchasebutton.Size = new System.Drawing.Size(126, 37);
            this.makepurchasebutton.TabIndex = 6;
            this.makepurchasebutton.Text = "Purchase";
            this.makepurchasebutton.UseVisualStyleBackColor = true;
            this.makepurchasebutton.Click += new System.EventHandler(this.makepurchasebutton_Click);
            // 
            // vendorlistboxlabel
            // 
            this.vendorlistboxlabel.AutoSize = true;
            this.vendorlistboxlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendorlistboxlabel.Location = new System.Drawing.Point(24, 381);
            this.vendorlistboxlabel.Name = "vendorlistboxlabel";
            this.vendorlistboxlabel.Size = new System.Drawing.Size(76, 20);
            this.vendorlistboxlabel.TabIndex = 8;
            this.vendorlistboxlabel.Text = "Vendors";
            // 
            // vendorlistbox
            // 
            this.vendorlistbox.FormattingEnabled = true;
            this.vendorlistbox.ItemHeight = 20;
            this.vendorlistbox.Location = new System.Drawing.Point(28, 404);
            this.vendorlistbox.Name = "vendorlistbox";
            this.vendorlistbox.Size = new System.Drawing.Size(365, 204);
            this.vendorlistbox.TabIndex = 7;
            // 
            // storeprofitlabel
            // 
            this.storeprofitlabel.AutoSize = true;
            this.storeprofitlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeprofitlabel.Location = new System.Drawing.Point(635, 381);
            this.storeprofitlabel.Name = "storeprofitlabel";
            this.storeprofitlabel.Size = new System.Drawing.Size(106, 20);
            this.storeprofitlabel.TabIndex = 9;
            this.storeprofitlabel.Text = "Store Profit:";
            // 
            // storeprofitvalue
            // 
            this.storeprofitvalue.AutoSize = true;
            this.storeprofitvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeprofitvalue.Location = new System.Drawing.Point(791, 381);
            this.storeprofitvalue.Name = "storeprofitvalue";
            this.storeprofitvalue.Size = new System.Drawing.Size(54, 20);
            this.storeprofitvalue.TabIndex = 10;
            this.storeprofitvalue.Text = "$0.00";
            // 
            // ConsignmentShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 717);
            this.Controls.Add(this.storeprofitvalue);
            this.Controls.Add(this.storeprofitlabel);
            this.Controls.Add(this.vendorlistboxlabel);
            this.Controls.Add(this.vendorlistbox);
            this.Controls.Add(this.makepurchasebutton);
            this.Controls.Add(this.shoppingcartlistboxlabel);
            this.Controls.Add(this.shoppingcartlistbox);
            this.Controls.Add(this.addtocart);
            this.Controls.Add(this.itemslistboxlabel);
            this.Controls.Add(this.ItemsListBox);
            this.Controls.Add(this.HeaderText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConsignmentShop";
            this.Text = "Consignment Shop Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderText;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Label itemslistboxlabel;
        private System.Windows.Forms.Button addtocart;
        private System.Windows.Forms.Label shoppingcartlistboxlabel;
        private System.Windows.Forms.ListBox shoppingcartlistbox;
        private System.Windows.Forms.Button makepurchasebutton;
        private System.Windows.Forms.Label vendorlistboxlabel;
        private System.Windows.Forms.ListBox vendorlistbox;
        private System.Windows.Forms.Label storeprofitlabel;
        private System.Windows.Forms.Label storeprofitvalue;
    }
}

