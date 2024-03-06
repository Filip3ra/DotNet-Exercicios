public class Calculadora
{
  // Verifica se é inteiro
  static bool isNumber(string s)
  {
    for (int i = 0; i < s.Length; i++)
      if (char.IsDigit(s[i]) == false)
        return false;

    return true;
  }

  static public void Main()
  {
    string[] valores;

    while (true)
    {
      Console.WriteLine("Informe dois valores inteiros: ");
      //string entrada = Console.ReadLine()!; // operador "!" apenas suprime o warning
      string ? entrada = Console.ReadLine();  // forço a variável receber um nulo

      valores = entrada.Split(' ');

      if (isNumber(valores[0]) && isNumber(valores[1]))
        break;
      else
        Console.WriteLine("Entrada invalida!");
    }

    // Converter os valores para inteiro
    int valor1 = int.Parse(valores[0] ?? "0"); // Tratamento para caso seja nulo
    int valor2 = int.Parse(valores[1] ?? "0");

    // Saída questão 1
    Console.WriteLine("Adição: {0}", valor1 + valor2);
    Console.WriteLine("Subtração: {0}", valor1 - valor2);
    Console.WriteLine("Multiplicação: {0}", valor1 * valor2);
    Console.WriteLine("Divisão: {0}", valor1 / valor2);
    Console.WriteLine("Resto: {0}", valor1 % valor2);

    // Saída questão 2
    Func<int, int, (int, int, int, int, int)> todasOperacoes =
    (a, b) => (a + b, a - b, a * b, a / b, a % b);

    Console.WriteLine("\nTodas as operações: {0}", todasOperacoes(valor1, valor2));
  }
}

/*
Q1) 
  Realiza leitura da entrada e verifica se cada caractere da string é um
  dígito com o método isDigit(), e se algum não for, então retorna falso. 
  Se todos forem, então retorna true. Depois utilizo Parse() para converter
  a string para valores inteiros e posteriormente as operações são realizadas.

Q2) 
  Como nossas operações estão estruturadas em uma tupla, isso implica que 
  o retorno também deve seguir a mesma estrutura. A quantidade de operações
  separadas por vírgula deve ser exatamente igual a quantidade de tipos de 
  retorno definos na função, no nosso caso, são cinco.
*/


