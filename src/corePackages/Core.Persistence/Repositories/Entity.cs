namespace Core.Persistence.Repositories;

public class Entity
{
    public string Id { get; set; }

    public Entity()
    {
    }

    public Entity(string id) : this()
    {
        Id = id;
    }
}