// zadanie 1

string? fileName;
do
{
    Console.WriteLine("podaj nazwe pliku"); fileName = Console.ReadLine();

} while (fileName == null);

using (StreamWriter sw = new StreamWriter(fileName))
{
    sw.WriteLine("w69831");
}