// Developer Express Code Central Example:
// How to display and edit XPO in the ASPxGridView
// 
// This is a simple example of how to bind the grid to an XpoDataSource (eXpress
// Persistent Objects) for data displaying and editing. It's implemented according
// to the http://www.devexpress.com/scid=K18061 article.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E320

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using PersistentObjects;
using System.Globalization;

namespace DatabaseUpdater {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            string connString = textBox1.Text;
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
        }

        private void button1_Click(object sender, EventArgs e) {
            XpoDefault.Session.UpdateSchema(typeof(PersistentObjects.Order).Assembly);
            XpoDefault.Session.CreateObjectTypeRecords();
            MessageBox.Show("Done!");
        }

        private void button2_Click(object sender, EventArgs e) {
            using(UnitOfWork uow = new UnitOfWork()) {
                if(uow.FindObject<Customer>(null) == null) {
                    Customer cust = new Customer(uow);
                    cust.CompanyName = "Königlich Essen";
                    cust.ContactName = "Königlich Essen";
                    cust.Country = "Germany";
                    cust.Phone = "030-0074321";
                    

                    Order order = new Order(uow);
                    order.OrderDate = DateTime.Parse("7/4/1996", CultureInfo.InvariantCulture);
                    order.PaidTotal = 34.34m;
                    cust.Orders.Add(order);

                    order = new Order(uow);
                    order.OrderDate = DateTime.Parse("7/10/1996", CultureInfo.InvariantCulture);
                    order.PaidTotal = 11.64m;
                    cust.Orders.Add(order);
                    cust.Save();

                    cust = new Customer(uow);
                    cust.CompanyName = "Ana Trujillo Emparedados y helados";
                    cust.ContactName = "Ana Trujillo";
                    cust.Country = "México D.F.";
                    cust.Phone = "(5) 555-4729";
                    cust.Save();

                    order = new Order(uow);
                    order.OrderDate = DateTime.Parse("7/12/1996", CultureInfo.InvariantCulture);
                    order.PaidTotal = 65.81m;
                    cust.Orders.Add(order);

                    order = new Order(uow);
                    order.OrderDate = DateTime.Parse("7/15/1996", CultureInfo.InvariantCulture);
                    order.PaidTotal = 41.34m;
                    cust.Orders.Add(order);

                    order = new Order(uow);
                    order.OrderDate = DateTime.Parse("7/11/1996", CultureInfo.InvariantCulture);
                    order.PaidTotal = 51.50m;
                    cust.Orders.Add(order);
                    cust.Save();

                    cust = new Customer(uow);
                    cust.CompanyName = "Antonio Moreno Taquería";
                    cust.ContactName = "Antonio Moreno";
                    cust.Country = "Mexico D.F.";
                    cust.Phone = "(5) 555-4729";
                    cust.Save();

                    order = new Order(uow);
                    order.OrderDate = DateTime.Parse("7/16/1996", CultureInfo.InvariantCulture);
                    order.PaidTotal = 58.17m;
                    cust.Orders.Add(order);
                    cust.Save();
                }
                uow.CommitChanges();
            }
            MessageBox.Show("Done!");
        }
    }
}