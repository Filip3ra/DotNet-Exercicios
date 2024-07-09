using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Digite uma frase:");
        string frase = Console.ReadLine();

        Console.WriteLine("Você digitou:");
        Console.WriteLine(frase);
    }
}
