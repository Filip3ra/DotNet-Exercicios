using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace PangramaChecker
{
  // Classe base
  public abstract class Pangrama
  {
    protected string frase;
    protected string alfabeto;

    public Pangrama(string frase)
    {
        this.frase = Auxiliar.RemoveAcento(frase.ToLower());
    }

    public bool VerificaPangrama()
    {
        foreach (char letra in alfabeto)
        {
            if (!frase.Contains(letra)) // Se não tiver a letra retorna false
            {
                return false;
            }
        }
        return true;
    }
  }

  // Classe auxiliar para tratamento de caracteres
  public static class Auxiliar
  {
    public static string RemoveAcento(string frase)
    {
    frase = Regex.Replace(frase, "[áàâãä]", "a");
    frase = Regex.Replace(frase, "[éèêë]", "e");
    frase = Regex.Replace(frase, "[íìîï]", "i");
    frase = Regex.Replace(frase, "[óòôõö]", "o");
    frase = Regex.Replace(frase, "[úùûü]", "u");
    frase = Regex.Replace(frase, "[ç]", "c");
    return frase;
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

  // Classe derivada para Português - sem K W Y
  public class PangramaPortugues : Pangrama
  {
    public PangramaPortugues(string frase) : base(frase)
    {
    alfabeto = "abcdefghijlmnopqrstuvxz";
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
        // Para suportar palavras com acento
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine("Deseja usar em Inglês ou Português? (I/P)");
        string idioma = Console.ReadLine().ToUpper();

        Console.WriteLine("Digite a frase:");
        string frase = Console.ReadLine();

        Pangrama pangramaChecker;

        if (idioma == "I")
        {
            pangramaChecker = new PangramaIngles(frase);
        }
        else if (idioma == "P")
        {
            pangramaChecker = new PangramaPortugues(frase);
        }
        else
        {
            Console.WriteLine("Idioma não suportado.");
            return;
        }

        if (pangramaChecker.VerificaPangrama())
        {
            Console.WriteLine("É um pangrama");
        }
        else
        {
            Console.WriteLine("Não é um pangrama ");
        }
    }
      
  }
}
