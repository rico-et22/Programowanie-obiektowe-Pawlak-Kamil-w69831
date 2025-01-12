

using Lab4;
// Zadanie 1
//List<Shape> shapes = new List<Shape>();
//shapes.Add(new Rectangle(10, 20, 30, 40));
//shapes.Add(new Triangle(15, 25, 35, 55));
//shapes.Add(new Circle(15, 55, 10));

//foreach (Shape shape in shapes)
//{
//    shape.Draw();
//}

// Zadanie 2
Uczen uczen1 = new Uczen("Jan", "Kowalski", "54041811198", "Szkoła 1");
Uczen uczen2 = new Uczen("Alina", "Kowalska", "15230197769", "Szkoła 1");
Nauczyciel nauczyciel = new Nauczyciel("Jan", "Nowak", "88050558452", "Szkoła 1", "mgr", [uczen1, uczen2]);

nauczyciel.WhichStudentCanGoHomeAlone(DateTime.Today);