using Core.Persistence.Repositories;

namespace Domain.Models;

public class MockAPIModel:Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }

    public MockAPIModel()
    {
        
    }
    public MockAPIModel(int id,string name,string author)
    {
        Id=id;
        Name=name;
        Author=author;
    }

}
