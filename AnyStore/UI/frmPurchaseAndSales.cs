using AnyStore.BLL;
using AnyStore.DAL;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace AnyStore.UI
{
    public partial class frmPurchaseAndSales : Form
    {
        public frmPurchaseAndSales()
        {
            InitializeComponent();
        }
        DeaCustDAL dcDAL = new DeaCustDAL();
        productsDAL pDAL = new productsDAL();
        userDAL uDal = new userDAL();
        transactionDAL tDAL =new transactionDAL();
        transaction_detailDAL tdDAL = new transaction_detailDAL();
       
        
        DataTable transactionDT = new DataTable();

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
         

        }

        private void FrmPurchaseAndSales_Load(object sender, EventArgs e)
        {
            //zzzget the transactionType value from frmUserDashboard
            string type = frmUserDashboard.transactionType;

            lblTop.Text = type;

            //Spesify Coulumns for our Transaction Data atable
            transactionDT.Columns.Add("Product Name");
            transactionDT.Columns.Add("Rate");
            transactionDT.Columns.Add("Qty");
            transactionDT.Columns.Add("Total");

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keyword from the text box
            string keyword = txtSearch.Text;

            if (keyword=="")
            {
                //cleas the textbox
                txtName.Text="";
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                return;
            }

            //Write the code to get the details and set the value on text boxes
            DeaCustBLL dc = dcDAL.SearchDealerCustomerForTransaction(keyword);

            // NOw transfer or set the value from 
            txtName.Text = dc.name;
            txtEmail.Text = dc.email;
            txtContact.Text = dc.contact;
            txtAddress.Text = dc.address;
        }

        private void TxtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            //Get the keyword from productsearch textBox 
            string keyword = txtSearchProduct.Text;

            //Chech ifwe have value to txtSearch or not
            if (keyword=="")
            {
                txtProductName.Text = "";
                txtInventory.Text = "";
                txtRate.Text = "";
                txtRate.Text = "";
                return;
            }

            //Search the product and display on respective texbox
            productsBLL p = pDAL.GetProductForTransaction(keyword);

            //Set  the value on textboxes based on p object 
            txtProductName.Text = p.name;
            txtInventory.Text = p.qty.ToString();
            txtRate.Text = p.rate.ToString();

            



        }

        private void BtnADD_Click(object sender, EventArgs e)
        {
            // Get Product name,rate,qty customer wants to buy 
            string productName = txtProductName.Text;
            decimal Rate = decimal.Parse(txtRate.Text);
            decimal Qty = decimal.Parse(txtQty.Text);
            decimal Total = Rate * Qty; //Total Ratex Qty

            //Display the Subttal 

            //Get the total vlue from texbox
            decimal subTotal = decimal.Parse(txtSubTotal.Text);
            subTotal = subTotal + Total;

            //Check Wheater the product is selected or not 
            if (productName == "")
            {
                //Display error message
                MessageBox.Show("Select the Product first. Try Again");
            }
            else
            {
                //add product the data grid view
                transactionDT.Rows.Add(productName, Rate,Qty, Total);

                //Show in DatagrdView
                dgvAddedProducts.DataSource = transactionDT;
                //Display the subtotal in text box
                txtSubTotal.Text = subTotal.ToString();

                //Clear the textbox
                txtSearchProduct.Text = "";
                txtProductName.Text = "";
                txtInventory .Text= "0.00";
                txtRate.Text = "0.00";
                txtQty .Text= "";
            }
        }

        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            //Get the value for discount textbox
            string value = txtDiscount.Text;
            if (value=="")
            {
                //Display erroe message
                MessageBox.Show("Please Discount First");

            }
            else
            {
                //Get the discount
                decimal subTotal = decimal.Parse(txtSubTotal.Text);
                decimal discount = decimal.Parse(txtDiscount.Text);
                //Calculate the grand total based on dscount 
                decimal grandTotal=((100-discount)/100)* subTotal;

                //Display the grand total in textbox
                txtGrandTotal.Text = grandTotal.ToString();
            }
        }

        private void TxtVAT_TextChanged(object sender, EventArgs e)
        {
            //Check if the grand total has value or nor if it has not value then calculate the discount first
            string check = txtGrandTotal.Text;
            if (check=="")
            {
                //Message error
                MessageBox.Show("Calculate the Dicount adn set the Grand total first");
            }
            else
            {
                //Calculate the vat percent first 
                decimal previousGT = decimal.Parse(txtGrandTotal.Text);
                decimal vat = decimal.Parse(txtVAT.Text);
                decimal grandTotalwithVAT=((100+vat)/100)*previousGT;

                //Displaying new grand total with vat 
                txtGrandTotal.Text = grandTotalwithVAT.ToString();
            }
        }

        private void TxtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            //get  the paid ammount and grand total 
            decimal grandTotal = decimal.Parse(txtGrandTotal.Text);
            decimal paidAmount = decimal.Parse(txtPaidAmount.Text);
            decimal returnAmount = paidAmount - grandTotal;

            //Dsiplay the return amount as well
            txtReturnAmount.Text = returnAmount.ToString();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Get the values from Purchase from frst
            transactionBLL transaction = new transactionBLL();
            transaction.type = lblTop.Text;

            //Get the ID of dealer or customer her
            //lets get name of the dealer or customer first
            string deaCustName = txtName.Text;
            DeaCustBLL dc = dcDAL.GetDeaCustIDFromName(deaCustName);

            transaction.dea_cust_id = dc.id;
            transaction.grandTotal = decimal.Parse(txtGrandTotal.Text);
            transaction.transaction_date = DateTime.Now;
            transaction.tax = decimal.Parse(txtVAT.Text);
            transaction.discount = decimal.Parse(txtDiscount.Text);

            //Get the username logged in user

            string username = frmLogin.loggedIn;
            userBLL u = uDal.GetIDFromUsername(username);
            transaction.added_by = u.id;
            transaction.transactionDetails = transactionDT;

            bool success = false;

            //Actual code to insert transaction and transaction details
            using (TransactionScope scope = new TransactionScope())
            {

                int transactionID = -1;
                ///create boolean value and insert transaction
                bool w = tDAL.Insert_Transaction(transaction, out transactionID);

                //User for  lopping transaction detaio 
                for (int i = 0; i < transactionDT.Rows.Count; i++)
                {
                    //Get all the details of the product 
                    transaction_detailBLL transactionDetail = new transaction_detailBLL();

                    //Get the Product name and convert it to id
                    string Productname = txtProductName.Text;
                    productsBLL p = pDAL.GetProductIDFromName(ProductName);

                    transactionDetail.product_id = p.id;
                    transactionDetail.rate = decimal.Parse(transactionDT.Rows[i][1].ToString());
                    transactionDetail.qty = decimal.Parse(transactionDT.Rows[i][2].ToString());
                    transactionDetail.total = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()),3);
                    transactionDetail.dea_cust_id = dc.id;
                    transactionDetail.added_date = DateTime.Now;
                    transactionDetail.added_by = u.id;

                    //Here increase or Decrease Product Quantitiy based on Purchase or sales
                    string transactionType = lblTop.Text;

                    //Lets check wheather we are on purchase or sales
                    bool x=false;
                    if (transactionType=="Purchase")
                    {
                       x = pDAL.IncreaseProduct(transactionDetail.product_id , transactionDetail.qty);
                    }
                    else if (transactionType=="Sales")
                    {
                        //Decrease the Product Quantitiy
                         x = pDAL.DecreaseProduct(transactionDetail.product_id, transactionDetail.qty);
                    }
                    //Insert Transaction Detail inside the Databsae 
                    
                    bool y = tdDAL.InsertTransactionDetail(transactionDetail);
                    success = w &&  y;
                }
                    
                    if (success == true)
                    {
                    //Transaction Completed
                    scope.Complete();

                    //Code to print bill
                    DGVPrinter printer = new DGVPrinter();

                    printer.Title = "\r\n\r\n ANYSTORE PVT. LTD.";
                    printer.SubTitle = "Jepara, Suwawal \r\n  Phone: 0895386989706";
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = false;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Discount :" +txtDiscount.Text+"% \r\n " +  "VAT:" +txtVAT.Text +"% \r\n" +"Grand Total:" +"r\n" +"Thank you for doing buisness with us   " ;
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(dgvAddedProducts);





                        MessageBox.Show("Transaction Completed Successfully");
                        dgvAddedProducts.DataSource = null;
                        dgvAddedProducts.Rows.Clear();

                        txtSearch.Text = "";
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtContact.Text = "";
                        txtAddress.Text = "";
                        txtSearchProduct.Text = "";
                        txtProductName.Text = "";
                        txtInventory.Text = "";
                        txtRate.Text = "";
                        txtQty.Text = "0";
                        txtSubTotal.Text = "0";
                        txtDiscount.Text="0";
                        txtVAT.Text = "0";
                        txtGrandTotal.Text = "0";
                    txtPaidAmount.Text = "0";
                        txtReturnAmount.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show("Transaction Failed ");
                    
                }
            }
        }

        private void LblTop_Click(object sender, EventArgs e)
        {

        }
    }
}
