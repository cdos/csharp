using ConsignmentClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {

        private Store store = new Store();
        private List<Item> shoppingCartData = new List<Item>();
        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorBinding = new BindingSource();
        private decimal storeProfit = 0;

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();

            //Links store item to the binding source.  The expression looks whether item has been sold.
            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();
            ItemsListBox.DataSource = itemsBinding;

            //Looking for properties it wants to diplsy from items
            ItemsListBox.DisplayMember = "Display";
            ItemsListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartData;
            shoppingcartlistbox.DataSource = cartBinding;

            shoppingcartlistbox.ValueMember = "Display";
            shoppingcartlistbox.DisplayMember = "Display";

            vendorBinding.DataSource = store.Vendors;
            vendorlistbox.DataSource = vendorBinding;

            vendorlistbox.DisplayMember = "Display";
            vendorlistbox.ValueMember = "Display";
        }

        
        //Methods Fills in the dummy data
        private void SetupData()
        {
            //Two ways to add Vendor
            //First way
            //Vendor demoVendor = new Vendor();

            //demoVendor.FirstName = "Bill";
            //demoVendor.lastName = "Smith";
            //demoVendor.Commission = .5;

            //store.Vendors.Add(demoVendor);

            //demoVendor = new Vendor();

            //demoVendor.FirstName = "Sue";
            //demoVendor.lastName = "Jones";
            //demoVendor.Commission = .5;

            //store.Vendors.Add(demoVendor);

            //Second Way
            store.Vendors.Add(new Vendor { FirstName = "Bill", lastName = "Smith", Commission = .75 });
            store.Vendors.Add(new Vendor { FirstName = "Sue", lastName = "Jones" });

            store.Items.Add(new Item
            {
                Title = "Moby Dick",
                Description = "A Book about a Whale",
                Price = 4.50M,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                Title = "A Tale of two Cities",
                Description = "A Book about a revolution",
                Price = 3.80M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Harry Potter Book1",
                Description = "A Book about a boy",
                Price = 4.50M,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                Title = "Jane Eyre",
                Description = "A book about a girl",
                Price = 5.10M,
                Owner = store.Vendors[0]
            });

            store.Name = "Seconds are Better";
        }

        private void addtocart_Click(object sender, EventArgs e)
        {
            //Figure out what is selected from items list
            Item selectedItem = (Item)ItemsListBox.SelectedItem; 

            //Copy that item to the shopping cart
            shoppingCartData.Add(selectedItem);
            //Refresh bindings.  (Refresh List)
            cartBinding.ResetBindings(false);
            
            //Do we remove the item from the items list?
            
            //Verify
            //MessageBox.Show(selectedItem.Title);
        }

        private void makepurchasebutton_Click(object sender, EventArgs e)
        {
            //mark each item in the cart as sold.
            //Clear the cart

            foreach (Item item in shoppingCartData)
            {
                item.Sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.Commission * item.Price;
                storeProfit += (1 - (decimal)item.Owner.Commission) * item.Price;
            }

            shoppingCartData.Clear();

            //Reestablish our list

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();

            storeprofitvalue.Text = string.Format("${0}", storeProfit);

            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
            vendorBinding.ResetBindings(false);
        }
    }
}
