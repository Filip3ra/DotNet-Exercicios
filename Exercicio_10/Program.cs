using System;
using System.Linq;

/* Pangrama: Todas as letras do alfabeto são usadas em uma frase,
   caso tenha algum caractere além dos presentes no alfabeto isso não
   invalida a frase, mas não ter algum caractere do alfabeto sim.
*/

namespace PangramaChecker
{
  // Classe base
  public abstract class Pangrama
  {
    // Protegidos para serem acessíveis nas classes derivadas
    protected string frase;
    protected string alfabeto;

    // Como é insensível a maiúsculas e minúsculas, 
    // podemos converter tudo pra minúscula
    public Pangrama(string frase)
    {
      this.frase = frase.ToLower();
    }

    // Verifica se cada letra do alfabeto está na frase
    public bool VerificaPangrama()
    {
      foreach (char letra in alfabeto)
      {

        if (!frase.Contains(letra)) // Se não tiver a letra retorna false
        {
          Console.WriteLine("Não encontrou letra: ", letra);
          return false;
        }
      }
      return true;
    }
  }

  // Classe derivada para Inglês
  public class PangramaIngles : Pangrama
  {
    public PangramaIngles(string frase) : base(frase)
    {
      alfabeto = "abcdefghijklmnopqrstuvwxyz";
    }
  }

  // Classe derivada para Português
  public class PangramaPortugues : Pangrama
  {
    public PangramaPortugues(string frase) : base(frase)
    {
      alfabeto = "abcdefghijklmnopqrstuvwxyz";
    }
  }

  // Antes da reforma ortográfica não tínhamos k,y e w no alfabeto
  public class PangramaPortuguesAntigo : Pangrama
  {
    public PangramaPortuguesAntigo(string frase) : base(frase)
    {
      alfabeto = "abcdefghijlmnopqrstuvxz";
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Deseja usar em Inglês, Português ou Antigo Português? (I/P/A)");
      string idioma = Console.ReadLine().ToUpper();

      Console.WriteLine("Digite a frase:");
      string frase = Console.ReadLine();
      
      Pangrama pangramaChecker;

      // Seleciona o idioma
      if (idioma == "I")
      {
        pangramaChecker = new PangramaIngles(frase);
      }
      else if (idioma == "P")
      {
        pangramaChecker = new PangramaPortugues(frase);
      }
      else if (idioma == "A") // Teste português antes do acordo ortográfico
      {
        pangramaChecker = new PangramaPortuguesAntigo(frase);
      }
      else
      {
        Console.WriteLine("Idioma não suportado.");
        return;
      }

      // Exibe se é pangrama
      if (pangramaChecker.VerificaPangrama())
      {
        Console.WriteLine("É um pangrama");
      }
      else
      {
        Console.WriteLine("Não é um pangrama");
      }
    }
  }
}
