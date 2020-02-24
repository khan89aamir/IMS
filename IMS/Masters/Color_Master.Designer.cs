﻿namespace IMS.Masters
{
    partial class Color_Master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Color_Master));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpColorDetails = new System.Windows.Forms.GroupBox();
            this.lblColorName = new System.Windows.Forms.Label();
            this.lblActiveStatus = new System.Windows.Forms.Label();
            this.txtColorName = new System.Windows.Forms.TextBox();
            this.cmbActiveStatus = new System.Windows.Forms.ComboBox();
            this.grpColorSearch = new System.Windows.Forms.GroupBox();
            this.rdShowAll = new System.Windows.Forms.RadioButton();
            this.rdSearchByColor = new System.Windows.Forms.RadioButton();
            this.txtSearchByColor = new System.Windows.Forms.TextBox();
            this.dgvColorMaster = new System.Windows.Forms.DataGridView();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grpColorDetails.SuspendLayout();
            this.grpColorSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 49);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(151, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Color Master";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(365, 69);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 31);
            this.btnUpdate.TabIndex = 204;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(583, 69);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 31);
            this.btnCancel.TabIndex = 206;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(474, 69);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 31);
            this.btnDelete.TabIndex = 205;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(256, 69);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 31);
            this.btnEdit.TabIndex = 203;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(145, 69);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 31);
            this.btnSave.TabIndex = 202;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(33, 69);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 31);
            this.btnAdd.TabIndex = 201;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.btnAdd_MouseLeave);
            // 
            // grpColorDetails
            // 
            this.grpColorDetails.BackColor = System.Drawing.Color.Transparent;
            this.grpColorDetails.Controls.Add(this.lblColorName);
            this.grpColorDetails.Controls.Add(this.lblActiveStatus);
            this.grpColorDetails.Controls.Add(this.txtColorName);
            this.grpColorDetails.Controls.Add(this.cmbActiveStatus);
            this.grpColorDetails.Enabled = false;
            this.grpColorDetails.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpColorDetails.Location = new System.Drawing.Point(33, 132);
            this.grpColorDetails.Margin = new System.Windows.Forms.Padding(4);
            this.grpColorDetails.Name = "grpColorDetails";
            this.grpColorDetails.Padding = new System.Windows.Forms.Padding(4);
            this.grpColorDetails.Size = new System.Drawing.Size(532, 145);
            this.grpColorDetails.TabIndex = 207;
            this.grpColorDetails.TabStop = false;
            this.grpColorDetails.Text = "Color Details";
            // 
            // lblColorName
            // 
            this.lblColorName.AutoSize = true;
            this.lblColorName.BackColor = System.Drawing.Color.Transparent;
            this.lblColorName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorName.Location = new System.Drawing.Point(24, 38);
            this.lblColorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColorName.Name = "lblColorName";
            this.lblColorName.Size = new System.Drawing.Size(110, 21);
            this.lblColorName.TabIndex = 187;
            this.lblColorName.Text = "Color Name :";
            // 
            // lblActiveStatus
            // 
            this.lblActiveStatus.AutoSize = true;
            this.lblActiveStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveStatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveStatus.Location = new System.Drawing.Point(24, 91);
            this.lblActiveStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActiveStatus.Name = "lblActiveStatus";
            this.lblActiveStatus.Size = new System.Drawing.Size(118, 21);
            this.lblActiveStatus.TabIndex = 189;
            this.lblActiveStatus.Text = "Active Status :";
            // 
            // txtColorName
            // 
            this.txtColorName.BackColor = System.Drawing.Color.White;
            this.txtColorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColorName.Location = new System.Drawing.Point(190, 34);
            this.txtColorName.Margin = new System.Windows.Forms.Padding(4);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Size = new System.Drawing.Size(273, 29);
            this.txtColorName.TabIndex = 0;
            this.txtColorName.Enter += new System.EventHandler(this.txtColorName_Enter);
            this.txtColorName.Leave += new System.EventHandler(this.txtColorName_Leave);
            // 
            // cmbActiveStatus
            // 
            this.cmbActiveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActiveStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActiveStatus.FormattingEnabled = true;
            this.cmbActiveStatus.Items.AddRange(new object[] {
            "Active",
            "InActive"});
            this.cmbActiveStatus.Location = new System.Drawing.Point(190, 87);
            this.cmbActiveStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbActiveStatus.Name = "cmbActiveStatus";
            this.cmbActiveStatus.Size = new System.Drawing.Size(273, 30);
            this.cmbActiveStatus.TabIndex = 2;
            // 
            // grpColorSearch
            // 
            this.grpColorSearch.BackColor = System.Drawing.Color.Transparent;
            this.grpColorSearch.Controls.Add(this.rdShowAll);
            this.grpColorSearch.Controls.Add(this.rdSearchByColor);
            this.grpColorSearch.Controls.Add(this.txtSearchByColor);
            this.grpColorSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpColorSearch.Location = new System.Drawing.Point(33, 293);
            this.grpColorSearch.Margin = new System.Windows.Forms.Padding(4);
            this.grpColorSearch.Name = "grpColorSearch";
            this.grpColorSearch.Padding = new System.Windows.Forms.Padding(4);
            this.grpColorSearch.Size = new System.Drawing.Size(675, 63);
            this.grpColorSearch.TabIndex = 208;
            this.grpColorSearch.TabStop = false;
            this.grpColorSearch.Text = "Search";
            // 
            // rdShowAll
            // 
            this.rdShowAll.AutoSize = true;
            this.rdShowAll.Checked = true;
            this.rdShowAll.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdShowAll.Location = new System.Drawing.Point(569, 22);
            this.rdShowAll.Margin = new System.Windows.Forms.Padding(4);
            this.rdShowAll.Name = "rdShowAll";
            this.rdShowAll.Size = new System.Drawing.Size(99, 25);
            this.rdShowAll.TabIndex = 1;
            this.rdShowAll.TabStop = true;
            this.rdShowAll.Text = "Show All";
            this.rdShowAll.UseVisualStyleBackColor = true;
            this.rdShowAll.CheckedChanged += new System.EventHandler(this.rdShowAll_CheckedChanged);
            // 
            // rdSearchByColor
            // 
            this.rdSearchByColor.AutoSize = true;
            this.rdSearchByColor.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdSearchByColor.Location = new System.Drawing.Point(24, 25);
            this.rdSearchByColor.Margin = new System.Windows.Forms.Padding(4);
            this.rdSearchByColor.Name = "rdSearchByColor";
            this.rdSearchByColor.Size = new System.Drawing.Size(157, 25);
            this.rdSearchByColor.TabIndex = 0;
            this.rdSearchByColor.Text = "By Color Name :";
            this.rdSearchByColor.UseVisualStyleBackColor = true;
            this.rdSearchByColor.CheckedChanged += new System.EventHandler(this.rdSearchByColor_CheckedChanged);
            // 
            // txtSearchByColor
            // 
            this.txtSearchByColor.BackColor = System.Drawing.Color.White;
            this.txtSearchByColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchByColor.Enabled = false;
            this.txtSearchByColor.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByColor.Location = new System.Drawing.Point(223, 22);
            this.txtSearchByColor.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchByColor.Name = "txtSearchByColor";
            this.txtSearchByColor.Size = new System.Drawing.Size(273, 29);
            this.txtSearchByColor.TabIndex = 5;
            this.txtSearchByColor.TextChanged += new System.EventHandler(this.txtSearchByColor_TextChanged);
            // 
            // dgvColorMaster
            // 
            this.dgvColorMaster.AllowUserToAddRows = false;
            this.dgvColorMaster.AllowUserToDeleteRows = false;
            this.dgvColorMaster.BackgroundColor = System.Drawing.Color.White;
            this.dgvColorMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColorMaster.Location = new System.Drawing.Point(30, 366);
            this.dgvColorMaster.Margin = new System.Windows.Forms.Padding(4);
            this.dgvColorMaster.Name = "dgvColorMaster";
            this.dgvColorMaster.ReadOnly = true;
            this.dgvColorMaster.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvColorMaster.Size = new System.Drawing.Size(678, 181);
            this.dgvColorMaster.TabIndex = 209;
            this.dgvColorMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColorMaster_CellDoubleClick);
            this.dgvColorMaster.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvColorMaster_DataBindingComplete);
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalRecords.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(29, 555);
            this.lblTotalRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(150, 22);
            this.lblTotalRecords.TabIndex = 210;
            this.lblTotalRecords.Text = "Total Records : 0";
            // 
            // Color_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(729, 584);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.dgvColorMaster);
            this.Controls.Add(this.grpColorSearch);
            this.Controls.Add(this.grpColorDetails);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Color_Master";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Master";
            this.Load += new System.EventHandler(this.Color_Master_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpColorDetails.ResumeLayout(false);
            this.grpColorDetails.PerformLayout();
            this.grpColorSearch.ResumeLayout(false);
            this.grpColorSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpColorDetails;
        private System.Windows.Forms.Label lblColorName;
        private System.Windows.Forms.Label lblActiveStatus;
        private System.Windows.Forms.TextBox txtColorName;
        private System.Windows.Forms.ComboBox cmbActiveStatus;
        private System.Windows.Forms.GroupBox grpColorSearch;
        private System.Windows.Forms.RadioButton rdShowAll;
        private System.Windows.Forms.RadioButton rdSearchByColor;
        private System.Windows.Forms.TextBox txtSearchByColor;
        private System.Windows.Forms.DataGridView dgvColorMaster;
        private System.Windows.Forms.Label lblTotalRecords;
    }
}