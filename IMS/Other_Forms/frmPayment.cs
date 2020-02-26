﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMS.Other_Forms
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }
        public static string strPaymentAutoID = "";
        private void button1_Click(object sender, EventArgs e)
        {
            strPaymentAutoID = txtPaymentAutoID.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPaymentAutoID.Clear(); strPaymentAutoID = "";
            this.Close();
        }
        Image B_Leave = IMS.Properties.Resources.B_click;
        Image B_Enter = IMS.Properties.Resources.B_on;
        private void frmPayment_Load(object sender, EventArgs e)
        {
            btnOK.BackgroundImage = B_Leave;
            btnCancel.BackgroundImage = B_Leave;

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
    }
}