// See https://aka.ms/new-console-template for more information

using Lab3;
// ZADANIE 1

// 1a
Person author1 = new Person("Jan", "Kowalski", 22);
Person author2 = new Person("Jan", "Nowak", 26);

Book book1 = new Book("Książka testowa", author1, Convert.ToDateTime("2024-06-28"));
Book book2 = new Book("Książka testowa 2", author2, Convert.ToDateTime("2013-06-28"));
Book book3 = new Book("Książka testowa 3", author1, Convert.ToDateTime("2003-06-28"));

author1.View();
author2.View();

book1.View();
book2.View();
book3.View();

// 1b
Reader reader1 = new Reader("Janina", "Nowak", 66, [book1, book2]);
Reader reader2 = new Reader("Adam", "Kowalski", 45, [book2, book3]);
//reader1.ViewBook();
//reader2.ViewBook();

// 1c
reader1.View();
reader2.View();

// 1d
Person o = new Reader("Adam", "Nowak", 25, [book1, book3]);
o.View();

// 1f
Reviewer reviewer1 = new Reviewer("Waldemar", "Kowalski", 55, [book1, book3]);
Reviewer reviewer2 = new Reviewer("Paweł", "Nowak", 39, [book2]);
reviewer1.View();
reviewer2.View();

// 1g
List<Person> people = new List<Person>([reader1,reader2,reviewer1,reviewer2]);
foreach (Person person in people)
{
    person.View();
}

// 1i 1j
Book book4 = new AdventureBook("Książka testowa 4", author1, Convert.ToDateTime("2005-06-28"),"antyk");
book4.View();
Book book5 = new DocumentaryBook("Książka testowa 5", author2, Convert.ToDateTime("2006-06-28"), "Europa");
book5.View();

// ZADANIE 2
//Samochod car1 = new SamochodOsobowy();
//Samochod car2 = new Samochod();
//Samochod car3 = new Samochod("Audi", "A6", "sedan", "biały", 1995, 500000);
//car1.View();
//car2.View();
//car3.View();
