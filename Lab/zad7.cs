//static void zadanie7()
//{
//    int n = IntInput("Podaj liczbę elementów do posortowania:");
//    int[] list = new int[n];

//    for (int i = 0; i < n; i++)
//    {
//        list[i] = IntInput($"Element {i + 1}:");
//    }

//    int method = IntInput("Metoda sortowania: 1 - bąbelkowe, 2 - wstawianie");

//    switch (method)
//    {
//        case 1:
//            BubbleSort(list);
//            break;
//        case 2:
//            InsertionSort(list);
//            break;
//        default:
//            Console.WriteLine("Nieprawidłowy wybór.");
//            return;
//    }

//    Console.WriteLine("\nPosortowane liczby:");
//    foreach (int el in list)
//    {
//        Console.WriteLine(el);
//    }
//}

//zadanie7();

//static int IntInput(string text = "Podaj liczbe: ")
//{
//    Console.Write($"{text} ");
//    int input = Convert.ToInt32(Console.ReadLine());
//    return input;
//}

//static void BubbleSort(int[] tab)
//{
//    int n = tab.Length;
//    for (int i = 0; i < n - 1; i++)
//    {
//        for (int j = 0; j < n - i - 1; j++)
//        {
//            if (tab[j] > tab[j + 1])
//            {
//                int temp = tab[j];
//                tab[j] = tab[j + 1];
//                tab[j + 1] = temp;
//            }
//        }
//    }
//}

//static void InsertionSort(int[] tab)
//{
//    int n = tab.Length;
//    for (int i = 1; i < n; i++)
//    {
//        int klucz = tab[i];
//        int j = i - 1;

//        while (j >= 0 && tab[j] > klucz)
//        {
//            tab[j + 1] = tab[j];
//            j--;
//        }
//        tab[j + 1] = klucz;
//    }
//}
