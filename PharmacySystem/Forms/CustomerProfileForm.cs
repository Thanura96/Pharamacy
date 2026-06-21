using System.Windows.Forms;
using PharmacySystem.Core;
using PharmacySystem.Models;

namespace PharmacySystem.Forms
{
    public partial class CustomerProfileForm : BaseForm
    {
        private readonly Customer _customer;

        public CustomerProfileForm(PharmacyAppContext appContext, Customer customer) : base(appContext)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void CustomerProfileForm_Load(object sender, EventArgs e)
        {
            lblFullNameValue.Text = _customer.FullName ?? "—";
            lblEmailValue.Text = _customer.Email ?? "—";
            lblPhoneValue.Text = _customer.Phone ?? "—";
            lblAddressValue.Text = _customer.Address ?? "—";
            lblUsernameValue.Text = _customer.Username ?? "—";
        }
    }
}
