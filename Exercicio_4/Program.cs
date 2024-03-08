class Program
{
  void comSwitch()
  {
    Console.WriteLine("Digite um número inteiro:");
    string? entrada = Console.ReadLine();

    int numero;
    if (int.TryParse(entrada, out numero))
    {
      switch (numero % 2)
      {
        case 0:
          Console.WriteLine("O número é par.");
          break;
        case 1:
          Console.WriteLine("O número é ímpar.");
          break;
        default:
          Console.WriteLine("Algo deu errado. Verifique o número digitado.");
          break;
      }
    }
    else
    {
      Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro válido.");
    }
  }

  void comIfsemElse()
  {
    Console.WriteLine("Digite um número inteiro:");
    string? entrada = Console.ReadLine();

    int numero;
    if (int.TryParse(entrada, out numero))
    {
      if (numero % 2 == 0)
        Console.WriteLine("O número é par.");
      if (numero % 2 == 1)
        Console.WriteLine("O número é ímpar.");
    }
    if (int.TryParse(entrada, out numero) == false)
      Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro válido.");
  }

  void semControle()
  {
    Console.WriteLine("Digite um número inteiro:");
    string? entrada = Console.ReadLine();

    int numero;
    int.TryParse(entrada, out numero);

    Console.WriteLine("O resto da divisão do valor informado é: {0}\n", numero % 2);
    Console.WriteLine("Se for 0 é par\nSe for 1 é impar.");
  }

  void comOperadorTernario()
  {
    Console.WriteLine("Digite um número inteiro:");
    string? entrada = Console.ReadLine();

    int numero;
    if (int.TryParse(entrada, out numero))
    {
      string mensagem = (numero % 2 == 0) ? "par" : "ímpar";
      Console.WriteLine($"O número é {mensagem}.");
    }
    else
    {
      Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro válido.");
    }
  }

  static void Main()
  {
    Program p = new Program();
    p.comSwitch();
    p.comIfsemElse();
    p.comOperadorTernario();
    p.semControle();


  }
}
