﻿
namespace ShopAid
{
    partial class frmView
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
            this.lblWishlist = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOrderPriority = new System.Windows.Forms.Button();
            this.dgWishlist = new System.Windows.Forms.DataGridView();
            this.btnOrderPrice = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgWishlist)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWishlist
            // 
            this.lblWishlist.AutoSize = true;
            this.lblWishlist.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWishlist.Location = new System.Drawing.Point(227, 24);
            this.lblWishlist.Name = "lblWishlist";
            this.lblWishlist.Size = new System.Drawing.Size(97, 24);
            this.lblWishlist.TabIndex = 9;
            this.lblWishlist.Text = "WishList";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Location = new System.Drawing.Point(466, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "CLOSE FORM";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOrderPriority
            // 
            this.btnOrderPriority.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOrderPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderPriority.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOrderPriority.Location = new System.Drawing.Point(466, 83);
            this.btnOrderPriority.Name = "btnOrderPriority";
            this.btnOrderPriority.Size = new System.Drawing.Size(86, 49);
            this.btnOrderPriority.TabIndex = 24;
            this.btnOrderPriority.Text = "ORDER BY PRIORITY";
            this.btnOrderPriority.UseVisualStyleBackColor = false;
            this.btnOrderPriority.Click += new System.EventHandler(this.btnOrderPriority_Click);
            // 
            // dgWishlist
            // 
            this.dgWishlist.AllowUserToAddRows = false;
            this.dgWishlist.AllowUserToDeleteRows = false;
            this.dgWishlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWishlist.Location = new System.Drawing.Point(26, 64);
            this.dgWishlist.Name = "dgWishlist";
            this.dgWishlist.ReadOnly = true;
            this.dgWishlist.Size = new System.Drawing.Size(342, 150);
            this.dgWishlist.TabIndex = 25;
            // 
            // btnOrderPrice
            // 
            this.btnOrderPrice.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOrderPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderPrice.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOrderPrice.Location = new System.Drawing.Point(466, 24);
            this.btnOrderPrice.Name = "btnOrderPrice";
            this.btnOrderPrice.Size = new System.Drawing.Size(86, 49);
            this.btnOrderPrice.TabIndex = 26;
            this.btnOrderPrice.Text = "ORDER BY PRICE";
            this.btnOrderPrice.UseVisualStyleBackColor = false;
            this.btnOrderPrice.Click += new System.EventHandler(this.btnOrderPrice_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(26, 231);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOrderPrice);
            this.Controls.Add(this.dgWishlist);
            this.Controls.Add(this.btnOrderPriority);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblWishlist);
            this.Name = "frmView";
            this.Text = "frmView";
            this.Load += new System.EventHandler(this.frmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgWishlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWishlist;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOrderPriority;
        private System.Windows.Forms.DataGridView dgWishlist;
        private System.Windows.Forms.Button btnOrderPrice;
        private System.Windows.Forms.Button btnDelete;
    }
}