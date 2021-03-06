﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CoreApp;

namespace IMS.Settings
{
    public partial class frmOtherSetting : Form
    {
        public frmOtherSetting()
        {
            InitializeComponent();
        }
        
        clsConnection_DAL ObjCon = new clsConnection_DAL(true);
        clsUtility ObjUtil = new clsUtility();

        Image B_Leave = IMS.Properties.Resources.B_click;
        Image B_Enter = IMS.Properties.Resources.B_on;
        
        private void frmOtherSetting_Load(object sender, EventArgs e)
        {
            btnAdd.BackgroundImage = B_Leave;
            btnSave.BackgroundImage = B_Leave;
            btnFooterCancel.BackgroundImage= B_Leave;
            btnFooterSave.BackgroundImage = B_Leave;

            txtPCName.Text = Environment.MachineName;
            LoadStore();
            BindStoreSettingData();
        }
      
        private void LoadStore()
        {
            DataTable dt = ObjCon.ExecuteSelectStatement("SELECT StoreID, StoreName FROM " + clsUtility.DBName + ".[dbo].[StoreMaster] WITH(NOLOCK) ");
            if (ObjUtil.ValidateTable(dt))
            {
                cmbStoreName.DataSource = dt;
                cmbStoreName.DisplayMember = "StoreName";
                cmbStoreName.ValueMember = "StoreID";
                cmbStoreName.SelectedIndex = -1;
            }
        }
        private void BindStoreSettingData()
        {
            DataTable dt = ObjCon.ExecuteSelectStatement("SELECT * FROM " + clsUtility.DBName + ".[dbo].[DefaultStoreSetting] WITH(NOLOCK) where MachineName='" + Environment.MachineName + "'");
            if (ObjUtil.ValidateTable(dt))
            {
                lblmsg.Visible = false;
                cmbStoreName.SelectedValue = dt.Rows[0]["StoreID"].ToString();

                //we are binding store category by index value.
                cmbStoreCategory.SelectedIndex = Convert.ToInt32(dt.Rows[0]["StoreCategory"]);

                if (dt.Rows[0]["InvoiceFooterNote"]!=DBNull.Value)
                {
                    txtFooterNote.Text = dt.Rows[0]["InvoiceFooterNote"].ToString();
                }
                else
                {
                    txtFooterNote.Text = "";
                }
             
            }
            else
            {
                lblmsg.Visible = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPCName.Text.Trim().Length == 0)
            {
                clsUtility.ShowInfoMessage("Please enter PC name.", clsUtility.strProjectTitle);
                txtPCName.Focus();
                return;

            }
            else if (cmbStoreCategory.SelectedIndex == -1)
            {
                clsUtility.ShowInfoMessage("Please Select Store Category.", clsUtility.strProjectTitle);
                cmbStoreCategory.Focus();
                return;

            }
            else if (cmbStoreName.SelectedIndex == -1)
            {
                clsUtility.ShowInfoMessage("Please Select Store Name.", clsUtility.strProjectTitle);
                cmbStoreName.Focus();
                return;
            }

            int result = ObjCon.ExecuteScalarInt("SELECT count(1) FROM " + clsUtility.DBName + ".[dbo].[DefaultStoreSetting] WITH(NOLOCK) WHERE MachineName='" + txtPCName.Text + "'");
            if (result > 0) // if data found for the PC thenupdate
            {

                ObjCon.UpdateColumnData("StoreID", SqlDbType.Int, cmbStoreName.SelectedValue);
                ObjCon.UpdateColumnData("MachineName", SqlDbType.NVarChar, txtPCName.Text);
                ObjCon.UpdateColumnData("StoreCategory", SqlDbType.Int, cmbStoreCategory.SelectedIndex);

                int r = ObjCon.UpdateData(clsUtility.DBName + ".[dbo].[DefaultStoreSetting]", "MachineName='" + txtPCName.Text + "'");
                if (r > 0)
                {
                    clsUtility.ShowInfoMessage("Default store settings has been updated.", clsUtility.strProjectTitle);
                }
            }
            else
            {
                // else insert.
                ObjCon.SetColumnData("StoreID", SqlDbType.Int, cmbStoreName.SelectedValue);
                ObjCon.SetColumnData("MachineName", SqlDbType.NVarChar, txtPCName.Text);
                ObjCon.SetColumnData("StoreCategory", SqlDbType.Int, cmbStoreCategory.SelectedIndex);

                int r = ObjCon.InsertData(clsUtility.DBName + ".[dbo].[DefaultStoreSetting]", false);
                if (r > 0)
                {
                    clsUtility.ShowInfoMessage("Default store settings has been saved.", clsUtility.strProjectTitle);
                }
                lblmsg.Visible = false;
            }
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

        private void cmbStoreCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbStoreCategory.SelectedIndex == 0) // Normal store
            {
                DataTable dt = ObjCon.ExecuteSelectStatement("SELECT StoreID, StoreName FROM " + clsUtility.DBName + ".[dbo].[StoreMaster] WITH(NOLOCK) WHERE ISNULL(StoreCategory,0) = 0");
                if (ObjUtil.ValidateTable(dt))
                {
                    cmbStoreName.DataSource = dt;
                    cmbStoreName.DisplayMember = "StoreName";
                    cmbStoreName.ValueMember = "StoreID";
                    cmbStoreName.SelectedIndex = -1;

                }
            }
            else if (cmbStoreCategory.SelectedIndex == 1) // Wearhouse
            {
                DataTable dt = ObjCon.ExecuteSelectStatement("select StoreID, StoreName FROM " + clsUtility.DBName + ".[dbo].[StoreMaster] WITH(NOLOCK) WHERE StoreCategory = 1");
                if (ObjUtil.ValidateTable(dt))
                {
                    cmbStoreName.DataSource = dt;
                    cmbStoreName.DisplayMember = "StoreName";
                    cmbStoreName.ValueMember = "StoreID";
                    cmbStoreName.SelectedIndex = -1;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadStore();
            BindStoreSettingData();
        }

        private void txtPCName_Enter(object sender, EventArgs e)
        {
            ObjUtil.SetTextHighlightColor(sender);
        }

        private void txtPCName_Leave(object sender, EventArgs e)
        {
            ObjUtil.SetTextHighlightColor(sender, Color.White);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dtFooterNote = ObjCon.ExecuteSelectStatement("select * FROM " + clsUtility.DBName + ".[dbo].[DefaultStoreSetting]");
            if (dtFooterNote!=null && dtFooterNote.Rows.Count > 0) // if data found for the PC thenupdate
            {
                ObjCon.ExecuteNonQuery("update " + clsUtility.DBName + ".dbo.DefaultStoreSetting set InvoiceFooterNote ='" + txtFooterNote.Text + "'");
                clsUtility.ShowInfoMessage("Footer note has been updated.", clsUtility.strProjectTitle);

            }
            else
            {
                // else insert.
               
                ObjCon.SetColumnData("InvoiceFooterNote", SqlDbType.NVarChar, txtFooterNote.Text);
              

                int r = ObjCon.InsertData(clsUtility.DBName + ".[dbo].[DefaultStoreSetting]", false);
                if (r > 0)
                {
                    clsUtility.ShowInfoMessage("Foorter note settings has been saved.", clsUtility.strProjectTitle);
                }
                lblmsg.Visible = false;

            }
        }

        private void btnFooterCancel_Click(object sender, EventArgs e)
        {
            LoadStore();
            BindStoreSettingData();
        }

        private void btnStorePopup_Click(object sender, EventArgs e)
        {
            Masters.Store_Master Obj = new Masters.Store_Master();
            Obj.ShowDialog();
            LoadStore();
        }
    }
}
