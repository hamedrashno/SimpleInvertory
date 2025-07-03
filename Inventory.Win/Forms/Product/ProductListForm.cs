using Inventory.Application.Db.Entities;
using Inventory.Application.Models;
using Inventory.Application.Services;

namespace Inventory.Win.Forms.Product
{
    public partial class ProductListForm : Form
    {
        private readonly ProductService _productService;
        private readonly UnitService _unitService;
        private readonly CategoryService _categoryService;
        public ProductListForm(ProductService productService, UnitService unitService, CategoryService categoryService)
        {
            _productService = productService;
            _unitService = unitService;
            _categoryService = categoryService;
            InitializeComponent();
        }

        private void createProductBtn_Click(object sender, EventArgs e)
        {
            if (unitCombo.SelectedValue == null || categoryCombo.SelectedValue == null)
                return;

            _productService.Add(new ProductEntity
            {
                Name = nameTxt.Text,
                MinStock = int.Parse(minStockTxt.Text),
                CategoryId = (int)categoryCombo.SelectedValue,
                UnitId = (int)unitCombo.SelectedValue
            });
            LoadProducts();
        }

        void LoadProducts()
        {
            var productList = _productService.SearchAsync(pageSize: 9999);
            productGridView.DataSource = productList;

        }

        void LoadUnits()
        {
            unitCombo.DataSource = _unitService.SearchAsync(pageSize: 999);
            unitCombo.DisplayMember = "Name";
            unitCombo.SelectedIndex = 0;
            unitCombo.ValueMember = "Id";

        }

        void LoadCategories()
        {
            categoryCombo.DataSource = _categoryService.SearchAsync(pageSize: 999);
            categoryCombo.DisplayMember = "Name";
            categoryCombo.SelectedIndex = 0;
            categoryCombo.ValueMember = "Id";

        }
        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadUnits();
            LoadCategories();
        }


        private void productGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;
            var product = (ProductListModel)productGridView.Rows[e.RowIndex].DataBoundItem;

        }
    }
}
