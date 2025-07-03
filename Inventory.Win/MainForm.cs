using Inventory.Win.Forms;
using Inventory.Win.Forms.Product;

namespace Inventory.Win
{
    public partial class MainForm : BaseForm
    {
        ProductListForm productListForm;
        public MainForm(ProductListForm productListForm)
        {
            this.productListForm = productListForm;
            InitializeComponent();
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
        }

        private void لیستمحصولاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productListForm.ShowDialog();
        }
    }
}
