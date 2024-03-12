using System;

class Program
{
  private int meses;
  private double juros, valor;

  void setEntradas()
  {
    Console.WriteLine("Nº de meses: ");
    string? m = Console.ReadLine();

    Console.WriteLine("Juros: ");
    string? j = Console.ReadLine();

    Console.WriteLine("Valor financiado: ");
    string? v = Console.ReadLine();

    int.TryParse(m, out meses);
    double.TryParse(j, out juros);
    double.TryParse(v, out valor);

  }

  double coeficienteFinanciamento()
  {
    double jurosDecimal = juros / 100.0; // Convertendo juros de percentual para decimal
    return (jurosDecimal / (1 - Math.Pow(1 + jurosDecimal, -meses)));
  }

  void getSaida()
  {
    double parcela = valor * coeficienteFinanciamento();
    double total = meses * parcela;
      Console.WriteLine("meses : {0}", meses);
      Console.WriteLine("juros : {0}", juros);
      Console.WriteLine("valor : {0}", valor);
      Console.WriteLine("coeficiente : {0:F3}", coeficienteFinanciamento());
      Console.WriteLine("Valor parcela : {0:F2}", parcela);
      Console.WriteLine("Valor total : {0:F2}", total);
      Console.WriteLine("Juros totais : {0:F2}", total - valor);
  }

  static void Main()
  {
      Program p = new Program();
      p.setEntradas();
      p.getSaida();
  }
}
