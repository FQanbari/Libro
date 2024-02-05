namespace Domain.Entities.BookAggregate;

public class Author
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int? CityOfBirth { get; private set; }
    public string HomeTown { get; private set; }

    public Author(int id,string name, string homeTown, int? cityOfBirth)
    {
        Id = id;
        Name = name;
        HomeTown = homeTown;
        CityOfBirth = cityOfBirth;
    }
}