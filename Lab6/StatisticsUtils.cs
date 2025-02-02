namespace Lab6
{
  public static class StatisticsUtils
  {
    public static long GetPopulationDifference(StatisticsItem start, StatisticsItem end)
    {
      return Convert.ToInt64(end.Value) - Convert.ToInt64(start.Value);
    }
    public static double GetPopulationPercentageDifference(StatisticsItem start, StatisticsItem end)
    {
      double startPopulation = Convert.ToDouble(start.Value);
      double endPopulation = Convert.ToDouble(end.Value);
      return (startPopulation - endPopulation) / endPopulation * 100;
    }
  }
}