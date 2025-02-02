using System.Reflection;
using System.Text.Json;
using Lab6;
// zadanie 1

//string? fileName;
//do
//{
//    Console.WriteLine("podaj nazwe pliku"); fileName = Console.ReadLine();

//} while (fileName == null);

//using (StreamWriter sw = new StreamWriter(fileName))
//{
//    sw.WriteLine("w69831");
//}

// zadanie 2

// string? fileName;
// do
// {
//     Console.WriteLine("podaj nazwe pliku"); fileName = Console.ReadLine();

// } while (fileName == null);

// if (File.Exists(fileName))
// {
//     string content = File.ReadAllText(fileName);
//     Console.WriteLine(content);
// }
// else Console.WriteLine("plik nie istnieje");

// zadanie 3
// z uwagi na prywatność, nie wrzucam listy publicznie
// należy wygenerować i wrzucić do /bin/debug/net8.0/pesels.txt

// List<Pesel> pesels = new List<Pesel>();
// string fileName = "pesels.txt";
// using (StreamReader sr = new StreamReader(fileName))
// {
//   string line;
//   while ((line = sr.ReadLine()) != null)
//   {
//     pesels.Add(new Pesel(line));
//   }
// }
// Console.WriteLine($"Peseli żeńskich jest: {pesels.FindAll(pesel => pesel.Gender == "F").Count}");

// zadanie 4

// enum Operation
// {
//   India = 1,
//   USA,
//   China,
//   ShowSelectPopulation,
//   PopulationDifference,
//   PopulationPercentage
// }

// class Program
// {
//   static void Main(string[] args)
//   {
//     string workingDirectory = Environment.CurrentDirectory;
//     string filePath = $"{Directory.GetParent(workingDirectory).Parent.Parent.FullName}/db.json";
//     string jsonString = File.ReadAllText(filePath);
//     StatisticsItem[] dataItems = JsonSerializer.Deserialize<StatisticsItem[]>(jsonString);

//     Operation? selection = null;

//     do
//     {
//       do
//       {
//         Console.WriteLine("Podaj typ operacji:");
//         Console.WriteLine("1- różnica populacji pomiędzy rokiem 1970 a 2000 dla Indii:");
//         Console.WriteLine("2- różnica populacji pomiędzy rokiem 1965 a 2010 dla USA");
//         Console.WriteLine("3- różnica populacji pomiędzy rokiem 1980 a 2018 dla Chin");
//         Console.WriteLine("4- wyświetl populację z danego roku i kraju");
//         Console.WriteLine("5- wyświetl różnicę populacji z danego zakresu i kraju");
//         Console.WriteLine("6- wyświetl procentowy przyrost populacji z danego roku i kraju");
//         Console.WriteLine("0- zakończ");

//         try
//         {
//           int input = int.Parse(Console.ReadLine());
//           if (input == 0) return;
//           if (Enum.IsDefined(typeof(Operation), input)) selection = (Operation)input;
//           else Console.WriteLine("Nieprawidłowy wybór");
//         }
//         catch (FormatException ex) { Console.WriteLine("Nieprawidłowy format danych"); }
//         catch (Exception ex) { Console.WriteLine(ex.Message); }
//         ;
//       } while (selection == null);

//       if (selection.HasValue)
//       {
//         double? result;
//         string selectedCountry, start, end, year;
//         try
//         {
//           switch (selection)
//           {
//             case Operation.India:
//               Console.WriteLine(StatisticsUtils.GetPopulationDifference(dataItems.First(x => x.Country.Id == "IN" && x.Date == "1970"), dataItems.First(x => x.Country.Id == "IN" && x.Date == "2000")));
//               break;
//             case Operation.USA:
//               Console.WriteLine(StatisticsUtils.GetPopulationDifference(dataItems.First(x => x.Country.Id == "US" && x.Date == "1960"), dataItems.First(x => x.Country.Id == "US" && x.Date == "2010")));
//               break;
//             case Operation.China:
//               Console.WriteLine(StatisticsUtils.GetPopulationDifference(dataItems.First(x => x.Country.Id == "CN" && x.Date == "1980"), dataItems.First(x => x.Country.Id == "CN" && x.Date == "2018")));
//               break;
//             case Operation.ShowSelectPopulation:
//               Console.Write("ID Kraju (CN,IN,US): ");
//               selectedCountry = Console.ReadLine();
//               Console.WriteLine();
//               Console.Write("Rok początkowy: ");
//               year = Console.ReadLine();
//               Console.WriteLine(dataItems.First(x => x.Country.Id == selectedCountry && x.Date == year).Value);
//               break;
//             case Operation.PopulationDifference:
//               Console.Write("ID Kraju (CN,IN,US): ");
//               selectedCountry = Console.ReadLine();
//               Console.WriteLine();
//               Console.Write("Rok początkowy: ");
//               start = Console.ReadLine();
//               Console.WriteLine();
//               Console.Write("Rok końcowy: ");
//               end = Console.ReadLine();
//               Console.WriteLine(StatisticsUtils.GetPopulationDifference(dataItems.First(x => x.Country.Id == selectedCountry && x.Date == start), dataItems.First(x => x.Country.Id == selectedCountry && x.Date == end)));
//               break;
//             case Operation.PopulationPercentage:
//               Console.Write("ID Kraju (CN,IN,US): ");
//               selectedCountry = Console.ReadLine();
//               Console.WriteLine();
//               Console.Write("Rok: ");
//               year = Console.ReadLine();
//               Console.WriteLine(StatisticsUtils.GetPopulationPercentageDifference(dataItems.First(x => x.Country.Id == selectedCountry && x.Date == year), dataItems.First(x => x.Country.Id == selectedCountry && x.Date == Convert.ToString(Convert.ToInt32(year) - 1))) + "%");
//               break;
//             default: throw new ArgumentOutOfRangeException();
//           }
//         }
//         catch (Exception ex) { Console.WriteLine(ex.Message); }
//       }
//       selection = null;
//     } while (true);
//   }
// }

// zadanie 5

class Program
{
  static void Main(string[] args)
  {
    IPersonRepository repository = new FilePersonRepository("persons.json");

    // Dodajemy kilka przykładowych osób
    var person1 = new Person { FirstName = "Jan", LastName = "Kowalski", Age = 30 };
    var person2 = new Person { FirstName = "Anna", LastName = "Nowak", Age = 25 };

    repository.Add(person1);
    repository.Add(person2);

    Console.WriteLine("Wszystkie osoby:");
    foreach (var person in repository.GetAll())
    {
      Console.WriteLine($"{person.Id} - {person.FirstName} {person.LastName}, wiek: {person.Age}");
    }

    Person updatedPerson1 = repository.GetAll().First() with { Age = 99 };
    repository.Update(updatedPerson1);

    repository.Delete(person2.Id);

    Console.WriteLine("\nPo aktualizacji i usunięciu:");
    foreach (var person in repository.GetAll())
    {
      Console.WriteLine($"{person.Id} - {person.FirstName} {person.LastName}, wiek: {person.Age}");
    }

    Console.WriteLine("\nNaciśnij enter, aby zakończyć...");
    Console.ReadLine();
  }
}

