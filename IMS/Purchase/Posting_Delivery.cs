﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CoreApp;

namespace IMS.Purchase
{
    public partial class Posting_Delivery : Form
    {
        public Posting_Delivery()
        {
            InitializeComponent();
        }

        clsUtility ObjUtil = new clsUtility();
        clsConnection_DAL ObjDAL = new clsConnection_DAL(true);

        int ID = 0;
        //int ProductID = 0;

        Image B_Leave = IMS.Properties.Resources.B_click;
        Image B_Enter = IMS.Properties.Resources.B_on;

        private bool validateform()
        {
            if (ObjUtil.IsControlTextEmpty(cmbEntryType))
            {
                clsUtility.ShowInfoMessage("Please Select Entry Type for Post..", clsUtility.strProjectTitle);
                cmbEntryType.Focus();
                return false;
            }
            else if (ObjUtil.IsControlTextEmpty(txtSupplierBillNo))
            {
                clsUtility.ShowInfoMessage("Please Enter Supplier Bill Number for Post..", clsUtility.strProjectTitle);
                txtSupplierBillNo.Focus();
                return false;
            }
            else if (ObjUtil.IsControlTextEmpty(txtTotalQTY))
            {
                clsUtility.ShowInfoMessage("QTY is not available for Post..", clsUtility.strProjectTitle);
                txtTotalQTY.Focus();
                return false;
            }
            return true;
        }

        private void ClearAll()
        {
            txtPurchaseInvoiceID.Clear();
            cmbEntryType.SelectedIndex = -1;
            cmbStore.SelectedIndex = -1;
            txtSupplierBillNo.Clear();
            txtTotalQTY.Clear();
            cmbEntryType.Focus();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (clsFormRights.HasFormRight(clsFormRights.Forms.Posting_Delivery, clsFormRights.Operation.Save) || clsUtility.IsAdmin)
            {
                if (validateform())
                {
                    bool b = clsUtility.ShowQuestionMessage("Are you sure want to post for " + txtSupplierBillNo.Text + " ?", clsUtility.strProjectTitle);
                    if (b)
                    {
                        string para = txtPurchaseInvoiceID.Text + "," + cmbStore.SelectedValue + "," + txtTotalQTY.Text + "," + cmbEntryType.SelectedIndex + "," + txtSupplierBillNo.Text + "," + clsUtility.LoginID;

                        DataTable dt = ObjDAL.ExecuteSelectStatement("EXEC " + clsUtility.DBName + ".dbo.Insert_PurchaseInvoice_BulkPrint_Color_Size " + para);
                        if (ObjUtil.ValidateTable(dt))
                        {
                            int flag = Convert.ToInt32(dt.Rows[0]["Flag"]);
                            string Msg = dt.Rows[0]["Msg"].ToString();

                            clsUtility.ShowInfoMessage(Msg, clsUtility.strProjectTitle);
                            ClearAll();
                        }
                        else
                        {
                            clsUtility.ShowInfoMessage("Posting Delivery Entry for '" + txtSupplierBillNo.Text + "' is not Saved Successfully..", clsUtility.strProjectTitle);
                        }
                    }
                }
            }
            else
            {
                clsUtility.ShowInfoMessage("You have no rights to perform this task", clsUtility.strProjectTitle);
            }
        }

        private void FillStoreData()
        {
            DataTable dt = ObjDAL.GetDataCol(clsUtility.DBName + ".dbo.StoreMaster", "StoreID,StoreName", "ISNULL(ActiveStatus,1)=1", "StoreName ASC");
            cmbStore.DataSource = dt;
            cmbStore.DisplayMember = "StoreName";
            cmbStore.ValueMember = "StoreID";

            cmbStore.SelectedIndex = -1;
        }

        private void txtSupplierBillNo_Enter(object sender, EventArgs e)
        {
            ObjUtil.SetTextHighlightColor(sender);
        }

        private void txtSupplierBillNo_Leave(object sender, EventArgs e)
        {
            ObjUtil.SetTextHighlightColor(sender, Color.White);
        }

        private void btnPost_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = B_Enter;
        }

        private void btnPost_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackgroundImage = B_Leave;
        }

        private void Posting_Delivery_Load(object sender, EventArgs e)
        {
            btnPost.BackgroundImage = B_Leave;
            btnCancel.BackgroundImage = B_Leave;

            FillStoreData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtSupplierBillNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierBillNo.Text.Length > 0)
                {
                    DataTable dt = ObjDAL.ExecuteSelectStatement("EXEC " + clsUtility.DBName + ".dbo.Get_PurchaseInvoice_Popup '" + txtSupplierBillNo.Text + "'");
                    if (ObjUtil.ValidateTable(dt))
                    {
                        ObjUtil.SetControlData(txtSupplierBillNo, "SupplierBillNo");
                        ObjUtil.SetControlData(txtPurchaseInvoiceID, "PurchaseInvoiceID");

                        ObjUtil.ShowDataPopup(dt, txtSupplierBillNo, this, this);

                        if (ObjUtil.GetDataPopup() != null && ObjUtil.GetDataPopup().DataSource != null)
                        {
                            // if there is only one column                
                            ObjUtil.GetDataPopup().AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            if (ObjUtil.GetDataPopup().ColumnCount > 0)
                            {
                                ObjUtil.GetDataPopup().Columns["PurchaseInvoiceID"].Visible = false;
                                ObjUtil.GetDataPopup().Columns["SupplierID"].Visible = false;
                                ObjUtil.SetDataPopupSize(300, 0);
                            }
                        }
                        ObjUtil.GetDataPopup().CellClick += Posting_Delivery_CellClick;
                        ObjUtil.GetDataPopup().KeyDown += Posting_Delivery_KeyDown;
                    }
                    else
                    {
                        ObjUtil.CloseAutoExtender();
                    }
                }
                else
                {
                    txtPurchaseInvoiceID.Clear();
                    txtTotalQTY.Clear();
                    ObjUtil.CloseAutoExtender();
                }
            }
            catch (Exception ex)
            {
                clsUtility.ShowErrorMessage(ex.ToString(), clsUtility.strProjectTitle);
            }
        }

        private void Posting_Delivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.DataSource != null)
            {
                txtSupplierBillNo.SelectionStart = txtSupplierBillNo.MaxLength;
                txtSupplierBillNo.Focus();

                DataTable dt = ObjDAL.ExecuteSelectStatement("EXEC " + clsUtility.DBName + ".dbo.Get_Posting_Delivery_QTY " + txtPurchaseInvoiceID.Text);
                if (ObjUtil.ValidateTable(dt))
                {
                    cmbStore.SelectedValue = dt.Rows[0]["StoreID"].ToString();
                    txtTotalQTY.Text = dt.Rows[0]["Total"].ToString();
                }
            }
        }

        private void Posting_Delivery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtSupplierBillNo.SelectionStart = txtSupplierBillNo.MaxLength;
                txtSupplierBillNo.Focus();

                DataTable dt = ObjDAL.ExecuteSelectStatement("EXEC " + clsUtility.DBName + ".dbo.Get_Posting_Delivery_QTY " + txtPurchaseInvoiceID.Text);
                if (ObjUtil.ValidateTable(dt))
                {
                    //ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                    cmbStore.SelectedValue = dt.Rows[0]["StoreID"].ToString();
                    txtTotalQTY.Text = dt.Rows[0]["Total"].ToString();
                }
            }
        }
    }
}
