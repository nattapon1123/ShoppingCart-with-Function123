namespace New1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           namespace ShoppingCart
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            // Function to get the total price from selected items
            double getPriceFromSelectedItems()
            {
                string strCoffeePrice = CoffeePrice.Text;
                string strCoffeeQuantity = CoffeeQuantity.Text;

                int iCoffeePrice = 0;
                int iCoffeeQuantity = 0;
                try
                {
                    if (Coffee.Checked)
                    {
                        iCoffeePrice = int.Parse(strCoffeePrice);
                        iCoffeeQuantity = int.Parse(strCoffeeQuantity);
                    }
                }
                catch (Exception ex)
                {
                    iCoffeePrice = 0;
                    iCoffeeQuantity = 0;
                }

                int iPrice = iCoffeePrice * iCoffeeQuantity;
                double dTotal = getDiscountPrice(iPrice, "BEV");

                // Check for other items: Green Tea, Noodles, Pizza
                string strGreenTeaPrice = GreenTeaPrice.Text;
                string strGreenTeaQuantity = GreenTeaQuantity.Text;
                int iGreenTeaPrice = 0;
                int iGreenTeaQuantity = 0;

                if (GreenTea.Checked)
                {
                    try
                    {
                        iGreenTeaPrice = int.Parse(strGreenTeaPrice);
                        iGreenTeaQuantity = int.Parse(strGreenTeaQuantity);
                    }
                    catch (Exception ex) { }
                    iPrice = iGreenTeaPrice * iGreenTeaQuantity;
                    dTotal += getDiscountPrice(iPrice, "BEV");
                }

                // Adding other items similarly (Noodles, Pizza)
                string strNoodlePrice = NoodlePrice.Text;
                string strNoodleQuantity = NoodleQuantity.Text;
                int iNoodlePrice = 0;
                int iNoodleQuantity = 0;

                if (Noodle.Checked)
                {
                    try
                    {
                        iNoodlePrice = int.Parse(strNoodlePrice);
                        iNoodleQuantity = int.Parse(strNoodleQuantity);
                    }
                    catch (Exception ex) { }
                    iPrice = iNoodlePrice * iNoodleQuantity;
                    dTotal += getDiscountPrice(iPrice, "FOOD");
                }

                // Similar for Pizza
                string strPizzaPrice = PizzaPrice.Text;
                string strPizzaQuantity = PizzaQuantity.Text;
                int iPizzaPrice = 0;
                int iPizzaQuantity = 0;

                if (Pizza.Checked)
                {
                    try
                    {
                        iPizzaPrice = int.Parse(strPizzaPrice);
                        iPizzaQuantity = int.Parse(strPizzaQuantity);
                    }
                    catch (Exception ex) { }
                    iPrice = iPizzaPrice * iPizzaQuantity;
                    dTotal += getDiscountPrice(iPrice, "FOOD");
                }

                return dTotal;
            }

            /// <summary>
            /// Function to calculate item price with discount
            /// </summary>
            /// <param name="pTotal">total price of item</param>
            /// <param name="pType">type of item: ALL, BEV, FOOD</param>
            /// <returns></returns>
            double getDiscountPrice(int pTotal, string pType = "ALL")
            {
                double dDiscount = 0;

                // Apply discount for beverages if selected
                if (pType == "BEV" && DiscountBev.Checked)
                    dDiscount = int.Parse(DiscountBev.Text);

                // Apply discount for all items
                if (pType == "ALL" && DiscountAll.Checked)
                    dDiscount = int.Parse(DiscountAll.Text);

                // Apply discount for food items
                if (pType == "FOOD" && DiscountFood.Checked)
                    dDiscount = int.Parse(DiscountFood.Text);

                return pTotal - (pTotal * dDiscount / 100);
            }

            // Event handler for calculating total when button is clicked
            private void button1_Click(object sender, EventArgs e)
            {
                double total = getPriceFromSelectedItems();
                Total.Text = total.ToString("F2");
            }

            // Function to calculate change and display breakdown of bills
            private void calculateChange()
            {
                if (!string.IsNullOrEmpty(Cash.Text))
                {
                    double cashReceived = 0;
                    bool isValidCash = double.TryParse(Cash.Text, out cashReceived);

                    if (isValidCash)
                    {
                        double total = double.Parse(Total.Text);
                        if (cashReceived >= total)
                        {
                            double change = cashReceived - total;
                            Change.Text = change.ToString("F2");

                            // Calculate the breakdown of the change in denominations
                            int[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1 };
                            double remainingChange = change;

                            // Set default text for the breakdown fields
                            txt1000.Text = txt500.Text = txt100.Text = txt50.Text =
                                txt20.Text = txt10.Text = txt5.Text = txt1.Text = "";

                            for (int i = 0; i < denominations.Length; i++)
                            {
                                int count = (int)(remainingChange / denominations[i]);
                                remainingChange %= denominations[i];

                                switch (denominations[i])
                                {
                                    case 1000: txt1000.Text = count.ToString(); break;
                                    case 500: txt500.Text = count.ToString(); break;
                                    case 100: txt100.Text = count.ToString(); break;
                                    case 50: txt50.Text = count.ToString(); break;
                                    case 20: txt20.Text = count.ToString(); break;
                                    case 10: txt10.Text = count.ToString(); break;
                                    case 5: txt5.Text = count.ToString(); break;
                                    case 1: txt1.Text = count.ToString(); break;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("เงินที่ได้รับน้อยกว่าราคาสินค้า!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอกจำนวนเงินสดที่ถูกต้อง!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}







