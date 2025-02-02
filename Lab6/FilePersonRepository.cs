using System.Text.Json;


namespace Lab6
{
  public record Person
  {
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
  }

  public interface IPersonRepository
  {
    IEnumerable<Person> GetAll();
    Person? GetById(Guid id);
    void Add(Person person);
    void Update(Person person);
    void Delete(Guid id);
  }

  public class FilePersonRepository : IPersonRepository
  {
    private readonly string _filePath;
    private readonly object _fileLock = new();

    public FilePersonRepository(string filePath)
    {
      _filePath = filePath;

      if (!File.Exists(_filePath))
      {
        File.Create(_filePath).Dispose();
      }
    }

    public IEnumerable<Person> GetAll()
    {
      lock (_fileLock)
      {
        var persons = new List<Person>();

        foreach (var line in File.ReadLines(_filePath))
        {
          if (string.IsNullOrWhiteSpace(line))
            continue;

          try
          {
            var person = JsonSerializer.Deserialize<Person>(line);
            if (person != null)
            {
              persons.Add(person);
            }
          }
          catch (JsonException)
          {
            Console.WriteLine("Wystąpił błąd podczas pobierania osób");
          }
        }

        return persons;
      }
    }

    public Person? GetById(Guid id)
    {
      return GetAll().FirstOrDefault(p => p.Id == id);
    }

    public void Add(Person person)
    {
      lock (_fileLock)
      {
        if (GetAll().Any(p => p.Id == person.Id))
          throw new Exception("Osoba o podanym identyfikatorze już istnieje.");

        string json = JsonSerializer.Serialize(person);
        File.AppendAllText(_filePath, json + Environment.NewLine);
      }
    }

    public void Update(Person person)
    {
      lock (_fileLock)
      {
        var persons = GetAll().ToList();
        int index = persons.FindIndex(p => p.Id == person.Id);

        if (index == -1)
          throw new Exception("Nie znaleziono osoby o podanym identyfikatorze.");

        persons[index] = person;
        WriteAllPersons(persons);
      }
    }

    public void Delete(Guid id)
    {
      lock (_fileLock)
      {
        var persons = GetAll().ToList();
        var personToDelete = persons.FirstOrDefault(p => p.Id == id);

        if (personToDelete == null)
          throw new Exception("Nie znaleziono osoby o podanym identyfikatorze.");

        persons.Remove(personToDelete);
        WriteAllPersons(persons);
      }
    }

    private void WriteAllPersons(IEnumerable<Person> persons)
    {
      using var writer = new StreamWriter(_filePath, false);
      foreach (var person in persons)
      {
        string json = JsonSerializer.Serialize(person);
        writer.WriteLine(json);
      }
    }
  }

}