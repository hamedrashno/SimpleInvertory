using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Win.Forms
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            //this.Font = new Font("B Nazanin", 12F);
        }
    }
}
