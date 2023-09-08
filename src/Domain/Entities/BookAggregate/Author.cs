namespace Domain.Entities.BookAggregate;

public class Author
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int CityOfBirth { get; private set; }

    public Author(int id,string name, int cityOfBirth)
    {
        Id = id;
        Name = name;
        CityOfBirth = cityOfBirth;
    }
}