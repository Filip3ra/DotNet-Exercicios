class Program
{
  int meses;
  double juros, valor;

  void getEntradas()
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

    Console.WriteLine("meses: {0}", meses);
    Console.WriteLine("juros: {0}", juros);
    Console.WriteLine("valor: {0}", valor);
    Console.WriteLine("coeficiente : {0]}", coeficienteFinanciamento());
  }

  double coeficienteFinanciamento()
  {
    return (juros / (1 - (1 + juros)(-meses)));
  }




  static void Main()
  {

  }
}
