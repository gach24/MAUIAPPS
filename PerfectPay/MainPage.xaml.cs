namespace PerfectPay
{
    public partial class MainPage : ContentPage
    {
        private decimal bill;
        private int tip;
        private int numPeople = 1;
        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            // Total propina
            var totalTip = (bill * tip) / 100;
            var tipByPerson = totalTip / numPeople;
            lblTipByPerson.Text = $"{tipByPerson:C}";

            // Subtotal
            var subtotal = bill / numPeople;
            lblSubtotal.Text = $"{subtotal:C}";

            // Total
            var totalByPerson = (bill + tip) / numPeople;
            lblTotal.Text = $"{totalByPerson:C}";
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)e.NewValue;
            lblTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                var btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%", ""));
                sldTip.Value = percentage;
            }
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (numPeople > 1)
            {
                numPeople--;
            }
            lblNoPersons.Text = numPeople.ToString();
            CalculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            numPeople++;
            lblNoPersons.Text = numPeople.ToString();
            CalculateTotal();
        }
    }
}