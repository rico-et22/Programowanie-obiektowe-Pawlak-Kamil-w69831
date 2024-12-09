using System;

public class Licz
{
    private double value = 0;

    public void Dodaj(double d) { value += d; }
    public void Odejmij(double d) { value -= d; }

    public void GetValue()
    {
        Console.WriteLine(value);
    }

    public Licz(double initialValue)
	{
        value = initialValue;
	}
}
