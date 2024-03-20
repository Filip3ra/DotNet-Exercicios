
class Program
{
  static void Main()
  {
    DataProcessor dataProcessor = new DataProcessor();

    bool condicao = true;
    while (condicao)
    {
      Console.Write("Digite um número ou digite 'F' para finalizar: ");
      string? input = Console.ReadLine();

      if (input.ToUpper() == "F")
      {
        condicao = false;
      }
      else
      {
        if (int.TryParse(input, out int number))
        {
          dataProcessor.AddNumber(number);
        }
        else
        {
          Console.WriteLine("Entrada inválida. Tente novamente.");
        }
      }
    }

    if (dataProcessor.NumberOfDataPoints > 0)
    {
      Console.WriteLine($"Média: {dataProcessor.CalculateMean()}");
      Console.WriteLine($"Desvio padrão: {dataProcessor.CalculateStandardDeviation()}");
    }
    else
    {
      Console.WriteLine("Nenhum número foi fornecido para calcular a média e o desvio padrão.");
    }
  }
}

class DataProcessor
{
  private List<int> dataPoints;

  public DataProcessor()
  {
    dataPoints = new List<int>();
  }

  public int NumberOfDataPoints => dataPoints.Count;

  public void AddNumber(int number)
  {
    dataPoints.Add(number);
  }

  public double CalculateMean()
  {
    if (NumberOfDataPoints == 0)
      return 0;

    return dataPoints.Average();
  }

  public double CalculateStandardDeviation()
  {
    if (NumberOfDataPoints == 0)
      return 0;

    double mean = CalculateMean();
    double sumOfSquaresOfDifferences = dataPoints.Select(val => (val - mean) * (val - mean)).Sum();
    double variance = sumOfSquaresOfDifferences / NumberOfDataPoints;
    return Math.Sqrt(variance);
  }

  public override string ToString()
  {
    return $"Número de pontos de dados: {NumberOfDataPoints}";
  }
}
