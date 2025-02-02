namespace Lab6
{

  public class Pesel
  {
    private string _pesel;

    public string Gender
    {
      get
      {
        return Convert.ToInt16(_pesel[9]) % 2 == 0 ? "F" : "M";
      }
    }

    public Pesel(string pesel)
    {
      this._pesel = pesel;
    }
  }
}