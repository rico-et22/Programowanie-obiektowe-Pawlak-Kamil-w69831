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

string? fileName;
do
{
    Console.WriteLine("podaj nazwe pliku"); fileName = Console.ReadLine();

} while (fileName == null);

if (File.Exists(fileName))
{
    string content = File.ReadAllText(fileName);
    Console.WriteLine(content);
}
else Console.WriteLine("plik nie istnieje");