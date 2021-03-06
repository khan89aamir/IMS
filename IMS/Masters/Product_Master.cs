﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CoreApp;

namespace IMS.Masters
{
    public partial class Product_Master : Form
    {
        public Product_Master()
        {
            InitializeComponent();
        }
        clsUtility ObjUtil = new clsUtility();
        clsConnection_DAL ObjDAL = new clsConnection_DAL(true);

        int ID = 0;

        Image B_Leave = IMS.Properties.Resources.B_click;
        Image B_Enter = IMS.Properties.Resources.B_on;
        private void ClearAll()
        {
            txtProductName.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbActiveStatus.SelectedIndex = -1;
            txtProductName.Focus();
            PicProductMaster.Image = null;
        }

        private bool Validateform()
        {
            if (ObjUtil.IsControlTextEmpty(txtProductName))
            {
                clsUtility.ShowInfoMessage("Enter Product Name           ", clsUtility.strProjectTitle);
                txtProductName.Focus();
                return false;
            }
            else if (ObjUtil.IsControlTextEmpty(cmbCategory))
            {
                clsUtility.ShowInfoMessage("Select Department for " + txtProductName.Text, clsUtility.strProjectTitle);
                cmbCategory.Focus();
                return false;
            }
            else if (ObjUtil.IsControlTextEmpty(cmbActiveStatus))
            {
                clsUtility.ShowInfoMessage("Select Active Status.", clsUtility.strProjectTitle);
                cmbActiveStatus.Focus();
                return false;
            }
            return true;
        }

        private bool DuplicateUser(int i)
        {
            int a = 0;
            if (i == 0)
            {
                a = ObjDAL.CountRecords(clsUtility.DBName + ".dbo.ProductMaster", "ProductName='" + txtProductName.Text.Trim() + "'");
            }
            else
            {
                a = ObjDAL.CountRecords(clsUtility.DBName + ".dbo.ProductMaster", "ProductName='" + txtProductName.Text + "' AND ProductID !=" + i);
            }
            if (a > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LoadData()
        {
            ObjUtil.SetDataGridProperty(dataGridView1, DataGridViewAutoSizeColumnsMode.Fill);
            DataTable dt = null;
            dt = ObjDAL.ExecuteSelectStatement("EXEC " + clsUtility.DBName + ".dbo.Get_Product_Master '0'");

            if (ObjUtil.ValidateTable(dt))
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void FillDepartmentData()
        {
            DataTable dt = null;
            dt = ObjDAL.GetDataCol(clsUtility.DBName + ".dbo.CategoryMaster", "CategoryID,CategoryName", "ISNULL(ActiveStatus,1)=1", "CategoryName ASC");
            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";

            cmbCategory.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearAll();
            //ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterNew, clsUtility.IsAdmin);
            ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterNew);
            grpProduct.Enabled = true;
            grpPhoto.Enabled = true;
            txtProductName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validateform())
            {
                if (DuplicateUser(0))
                {
                    ObjDAL.SetColumnData("ProductName", SqlDbType.NVarChar, txtProductName.Text.Trim());
                    ObjDAL.SetColumnData("CategoryID", SqlDbType.Int, cmbCategory.SelectedValue);
                    ObjDAL.SetColumnData("ActiveStatus", SqlDbType.Bit, cmbActiveStatus.SelectedItem.ToString() == "Active" ? 1 : 0);
                    ObjDAL.SetColumnData("CreatedBy", SqlDbType.Int, clsUtility.LoginID); //if LoginID=0 then Test Admin else user
                    if (PicProductMaster.Image != null)
                    {
                        ObjDAL.SetColumnData("Photo", SqlDbType.VarBinary, ObjUtil.GetImageBytes(PicProductMaster.Image));
                    }
                    if (ObjDAL.InsertData(clsUtility.DBName + ".dbo.ProductMaster", true) > 0)
                    {
                        //ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterSave, clsUtility.IsAdmin);
                        ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterSave);
                        clsUtility.ShowInfoMessage("Product Name : '" + txtProductName.Text + "' is Saved Successfully..", clsUtility.strProjectTitle);
                        ClearAll();
                        LoadData();
                        grpProduct.Enabled = false;
                    }
                    else
                    {
                        clsUtility.ShowInfoMessage("Product Name : '" + txtProductName.Text + "' is not Saved Successfully..", clsUtility.strProjectTitle);
                        ObjDAL.ResetData();
                    }
                }
                else
                {
                    clsUtility.ShowErrorMessage("'" + txtProductName.Text + "' Product is already exist..", clsUtility.strProjectTitle);
                    ObjDAL.ResetData();
                    txtProductName.Focus();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterEdit, clsUtility.IsAdmin);
            ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterEdit);
            grpProduct.Enabled = true;
            txtProductName.Focus();
            txtProductName.SelectionStart = txtProductName.MaxLength;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validateform())
            {
                if (DuplicateUser(ID))
                {
                    ObjDAL.UpdateColumnData("ProductName", SqlDbType.NVarChar, txtProductName.Text.Trim());
                    ObjDAL.UpdateColumnData("CategoryID", SqlDbType.Int, cmbCategory.SelectedValue);
                    ObjDAL.UpdateColumnData("ActiveStatus", SqlDbType.Bit, cmbActiveStatus.SelectedItem.ToString() == "Active" ? 1 : 0);
                    ObjDAL.UpdateColumnData("UpdatedBy", SqlDbType.Int, clsUtility.LoginID); //if LoginID=0 then Test
                    ObjDAL.UpdateColumnData("UpdatedOn", SqlDbType.DateTime, DateTime.Now);
                    if (PicProductMaster.Image != null)
                    {
                        ObjDAL.UpdateColumnData("Photo", SqlDbType.VarBinary, ObjUtil.GetImageBytes(PicProductMaster.Image));
                    }
                    if (ObjDAL.UpdateData(clsUtility.DBName + ".dbo.ProductMaster", "ProductID = " + ID + "") > 0)
                    {
                        //ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterUpdate, clsUtility.IsAdmin);
                        ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterUpdate);

                        clsUtility.ShowInfoMessage("'" + txtProductName.Text + "' Product is Updated", clsUtility.strProjectTitle);
                        LoadData();
                        ClearAll();
                        grpProduct.Enabled = false;
                        ObjDAL.ResetData();
                    }
                    else
                    {
                        clsUtility.ShowErrorMessage("'" + txtProductName.Text + "' Product is not Updated", clsUtility.strProjectTitle);
                        ObjDAL.ResetData();
                    }
                }
                else
                {
                    clsUtility.ShowErrorMessage("'" + txtProductName.Text + "' Product is already exist..", clsUtility.strProjectTitle);
                    txtProductName.Focus();
                    ObjDAL.ResetData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure want to delete '" + txtProductName.Text + "' Product ", clsUtility.strProjectTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                if (ObjDAL.DeleteData(clsUtility.DBName + ".dbo.ProductMaster", "ProductName='" + txtProductName.Text.Trim() + "'") > 0)
                {
                    clsUtility.ShowInfoMessage("'" + txtProductName.Text + "' Product is deleted  ", clsUtility.strProjectTitle);
                    ClearAll();
                    LoadData();
                    grpProduct.Enabled = false;
                    //ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterDelete, clsUtility.IsAdmin);
                    ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterDelete);
                }
                else
                {
                    clsUtility.ShowErrorMessage("'" + txtProductName.Text + "' Product is not deleted  ", clsUtility.strProjectTitle);
                    ObjDAL.ResetData();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bool b = clsUtility.ShowQuestionMessage(clsUtility.MsgActionCancel, clsUtility.strProjectTitle);
            if (b)
            {
                ClearAll();
                LoadData();
                //ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterCancel, clsUtility.IsAdmin);
                ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterCancel);
                grpProduct.Enabled = false;
            }
        }

        private void txtProductName_Enter(object sender, EventArgs e)
        {
            ObjUtil.SetTextHighlightColor(sender);
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            ObjUtil.SetTextHighlightColor(sender, Color.White);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                try
                {
                    //ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterGridClick, clsUtility.IsAdmin);
                    ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.AfterGridClick);
                    ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProductID"].Value);
                    txtProductName.Text = dataGridView1.SelectedRows[0].Cells["ItemName"].Value.ToString();
                    cmbCategory.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CategoryID"].Value);
                    cmbActiveStatus.SelectedItem = dataGridView1.SelectedRows[0].Cells["ActiveStatus"].Value.ToString();
                    if (dataGridView1.SelectedRows[0].Cells["Photo"].Value != DBNull.Value)
                    {
                        PicProductMaster.Image = ObjUtil.GetImage((byte[])dataGridView1.SelectedRows[0].Cells["Photo"].Value);
                    }
                    grpProduct.Enabled = false;
                    txtProductName.Focus();
                }
                catch (Exception ex)
                {
                    clsUtility.ShowErrorMessage(ex.ToString(), clsUtility.strProjectTitle);
                }
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                cmbActiveStatus.Focus();
                return;
            }
        }

        private void Product_Master_Load(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = B_Leave;
            btnSave.BackgroundImage = B_Leave;
            btnEdit.BackgroundImage = B_Leave;
            btnUpdate.BackgroundImage = B_Leave;
            btnDelete.BackgroundImage = B_Leave;
            btnCancel.BackgroundImage = B_Leave;

            //clsUtility.IsAdmin = true;//removed

            ObjUtil.RegisterCommandButtons(btnAdd, btnSave, btnEdit, btnUpdate, btnDelete, btnCancel);
            //ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.Beginning, clsUtility.IsAdmin);
            ObjUtil.SetCommandButtonStatus(clsCommon.ButtonStatus.Beginning);

            LoadData();
            FillDepartmentData();
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = B_Enter;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = B_Leave;
        }

        private void rdSearchByProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSearchByProduct.Checked)
            {
                txtSearchByProduct.Enabled = true;
                txtSearchByProduct.Focus();
            }
            else
            {
                txtSearchByProduct.Enabled = false;
                txtSearchByProduct.Clear();
                rdShowAll.Checked = true;
            }
        }

        private void rdShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdShowAll.Checked)
            {
                txtSearchByProduct.Enabled = false;
                txtSearchByProduct.Clear();
                LoadData();
            }
        }

        private void txtSearchByProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByProduct.Text.Trim().Length == 0)
            {
                LoadData();
                return;
            }
            DataTable dt = ObjDAL.ExecuteSelectStatement("EXEC " + clsUtility.DBName + ".dbo.Get_Product_Master '" + txtSearchByProduct.Text.Trim() + "'");
            if (ObjUtil.ValidateTable(dt))
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ObjUtil.SetRowNumber(dataGridView1);
            ObjUtil.SetDataGridProperty(dataGridView1, DataGridViewAutoSizeColumnsMode.Fill);
            dataGridView1.Columns["ProductID"].Visible = false;
            dataGridView1.Columns["CategoryID"].Visible = false;
            dataGridView1.Columns["Photo"].Visible = false;
            lblTotalRecords.Text = "Total Records : " + dataGridView1.Rows.Count;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PicProductMaster.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PicProductMaster.Image = null;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //Other_Forms.Import_Data Obj = new Other_Forms.Import_Data();
            //Obj.Show();
        }

        private void btnCategoryPopup_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (cmbCategory.SelectedIndex >= 0)
            {
                a = Convert.ToInt32(cmbCategory.SelectedValue);
            }
            Masters.Category_Master Obj = new Category_Master();
            Obj.ShowDialog();
            FillDepartmentData();
            if (a > 0)
            {
                cmbCategory.SelectedValue = a;
            }
        }

        private void txtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ObjUtil.IsString(e);
            if (e.Handled == true)
            {
                clsUtility.ShowInfoMessage("Enter Only Charactors...", clsUtility.strProjectTitle);
                txtProductName.Focus();
            }
        }
    }
}