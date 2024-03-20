
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
      bool? teste = input != null && input.Equals("F");

      if (teste == true)
      {
        condicao = false;
      }
      else
      {
        if (int.TryParse(input, out int valor))
        {
          dataProcessor.addNumero(valor);
        }
        else
        {
          Console.WriteLine("Entrada inválida. Tente novamente.");
        }
      }
    }

    if (dataProcessor.qtdDados > 0)
    {
      Console.WriteLine($"Média: {dataProcessor.calculaMedia()}");
      Console.WriteLine($"Desvio padrão: {dataProcessor.calculaDesvioPadrao()}");
    }
    else
    {
      Console.WriteLine("Nenhum número foi fornecido para calcular a média e o desvio padrão.");
    }
  }
}

class DataProcessor
{
  private List<int> dados;

  public DataProcessor()
  {
    dados = new List<int>();
  }

  public int qtdDados => dados.Count;

  public void addNumero(int num)
  {
    dados.Add(num);
  }

  public double calculaMedia()
  {
    if (qtdDados == 0)
      return 0;

    return dados.Average();
  }

  public double calculaDesvioPadrao()
  {
    if (qtdDados == 0)
      return 0;

    double media = calculaMedia();
    double somaQuadradoDiferencas = dados.Select(val => (val - media) * (val - media)).Sum();
    double varianca = somaQuadradoDiferencas / qtdDados;
    return Math.Sqrt(varianca);
  }

  public override string ToString()
  {
    return $"Número de pontos de dados: {qtdDados}";
  }
}
