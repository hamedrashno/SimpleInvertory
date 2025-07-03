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
        private int? _editItemId;
        public ProductListForm(ProductService productService, UnitService unitService, CategoryService categoryService)
        {
            _productService = productService;
            _unitService = unitService;
            _categoryService = categoryService;
            _editItemId = null;
            InitializeComponent();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadUnits();
            LoadCategories();
            EmptyCreateForm();
            _editItemId = null;
        }

        private void createProductBtn_Click(object sender, EventArgs e)
        {
            if (unitCombo.SelectedValue == null || categoryCombo.SelectedValue == null)
                return;

            if (_editItemId is null)
            {
                _productService.Add(new ProductEntity
                {
                    Name = nameTxt.Text,
                    MinStock = int.Parse(minStockTxt.Text),
                    CategoryId = (int)categoryCombo.SelectedValue,
                    UnitId = (int)unitCombo.SelectedValue
                });
            }
            else
            {
                var entity = _productService.GetByIdAsync(_editItemId.Value);
                if (entity == null) return;
                entity.MinStock = int.Parse(minStockTxt.Text);
                entity.Name = nameTxt.Text;
                entity.CategoryId = (int)categoryCombo.SelectedValue;
                entity.UnitId = (int)unitCombo.SelectedValue;

                _productService.Update(entity);
            }
            _editItemId = null;
            EmptyCreateForm();
            LoadProducts();
        }

        void LoadProducts()
        {
            var productList = _productService.SearchAsync(pageSize: 9999);
            productGridView.DataSource = productList;

        }

        void LoadUnits()
        {
            var data = _unitService.SearchAsync(pageSize: 999);
            if (data.Any())
            {
                unitCombo.DataSource = data;

                unitCombo.DisplayMember = "Name";
                unitCombo.SelectedIndex = 0;
                unitCombo.ValueMember = "Id";
            }
        }

        void LoadCategories()
        {
            var data = _categoryService.SearchAsync(pageSize: 999);
            if (data.Any())
            {
                categoryCombo.DataSource = data;
                categoryCombo.DisplayMember = "Name";
                categoryCombo.SelectedIndex = 0;
                categoryCombo.ValueMember = "Id";
            }
        }



        private void productGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var product = (ProductListModel)productGridView.Rows[e.RowIndex].DataBoundItem;
            var productEntity = _productService.GetByIdAsync(product.Id);
            if (productEntity == null) return;
            _editItemId = product.Id;
            nameTxt.Text = productEntity.Name;
            minStockTxt.Text = productEntity.MinStock.ToString();
            categoryCombo.SelectedValue = productEntity.CategoryId;
            unitCombo.SelectedValue = productEntity.UnitId;
        }

        void EmptyCreateForm()
        {
            nameTxt.Text = "";
            minStockTxt.Text = "";
            categoryCombo.SelectedIndex = 0;
            unitCombo.SelectedIndex = 0;
        }
    }
}
