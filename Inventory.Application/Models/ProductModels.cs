namespace Inventory.Application.Models;

public class ProductModels
{

}
public class ProductListModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string CategoryName { get; set; } = "";
    public string UnitName { get; set; } = "";
    public int MinStock { get; set; }
}

public class ProductInventoryModel : ProductListModel
{
    public int CurrentStock { get; set; }
}