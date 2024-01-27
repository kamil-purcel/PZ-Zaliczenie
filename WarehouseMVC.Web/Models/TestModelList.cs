namespace WarehouseMVC.Web.Models;

public class TestModelList
{
    private readonly List<TestModel> _models;

    public TestModelList()
    {
        _models = new List<TestModel>();
        _models.Add(new TestModel { Id = 1, Name = "Whopper", Type = "G 1", Price = 19.99M });
        _models.Add(new TestModel { Id = 2, Name = "Double Whopper", Type = "G 1", Price = 25.99M });
        _models.Add(new TestModel { Id = 3, Name = "Hamburger", Type = "G 1", Price = 6.50M });
        _models.Add(new TestModel { Id = 4, Name = "Cheeseburger", Type = "G 2", Price = 7.00M });
        _models.Add(new TestModel { Id = 5, Name = "Test Burger", Type = "G 2", Price = 39.99M });
    }

    public List<TestModel> GetAll()
    {
        return _models;
    }

    public TestModel GetModelById(int id)
    {
        return _models.Find(i => i.Id == id);
    }
}