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

  // c) Solução 1
  void semControle1()
  {
    /* Apenas informe o resultado da divisão e explique o que é
      par ou ímpar para o usuário. */

    Console.WriteLine("Digite um número inteiro:");
    string? entrada = Console.ReadLine();

    int numero;
    int.TryParse(entrada, out numero);

    Console.WriteLine("O resto da divisão do valor informado é: {0}\n", numero % 2);
    Console.WriteLine("Se for 0 é par\nSe for 1 é impar.");
  }

  // c) Solução 2
  void semControle2()
  {
    /* Cálculo com base em uma operação matemática se um caractere
       será adicionado ou não na string de resposta. 
       
       Se o número for par, resto da divisão é zero então não
       adiciono nenhum caractere na string "par".
       
       Se o número for ímpar então vou adicionar os caracteres
       faltantes para a palavra ser "ímpar".
       */
    Console.Write("Digite um número inteiro: ");
    int numero = Convert.ToInt32(Console.ReadLine());

    int restoDivisaoPor2 = numero % 2;

    // Calculo quantas vezes vou adicionar o novo caractere baseado no resto da divisão por 2
    string resultado = new string('m', restoDivisaoPor2 * 1) + "par";
    string resultado2 = new string('í', restoDivisaoPor2 * 1) + resultado;

    Console.WriteLine($"O número {numero} é {resultado2}.");
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
    // p.comSwitch();
    // p.comIfsemElse();
    // p.comOperadorTernario();
    // p.semControle1();
    p.semControle2();


  }
}
