using System;
using System.Collections.Generic;
using System.Linq;

class AnagramFinder
{
    private string palavraBase; // A palavra base para encontrar anagramas
    private List<string> listaPalavras; // Lista de palavras para comparar com a palavra base

    // Construtor da classe AnagramFinder
    public AnagramFinder(string palavraBase, List<string> listaPalavras)
    {
        this.palavraBase = palavraBase;
        this.listaPalavras = listaPalavras;
    }

    // Propriedade para acessar e definir a palavra base
    public string PalavraBase
    {
        get { return palavraBase; }
        set
        {
            // Verifica se a palavra base não é vazia
            if (!string.IsNullOrWhiteSpace(value))
                palavraBase = value;
            else
                throw new ArgumentException("Palavra base não pode ser vazia");
        }
    }

    // Propriedade para acessar e definir a lista de palavras
    public List<string> ListaPalavras
    {
        get { return listaPalavras; }
        set { listaPalavras = value; }
    }

    // Método para ordenar uma string (usado para comparar anagramas)
    private string OrdenarString(string str)
    {
        char[] chars = str.ToLower().ToCharArray(); // Converte a string para um array de caracteres e coloca em minúsculas
        Array.Sort(chars); // Ordena os caracteres
        return new string(chars); // Retorna a string ordenada
    }

    // Método para encontrar anagramas da palavra base na lista de palavras
    public List<string> EncontrarAnagramas()
    {
        List<string> anagramas = new List<string>(); // Lista para armazenar os anagramas encontrados
        string palavraOrdenada = OrdenarString(palavraBase); // Obtém a palavra base ordenada alfabeticamente

        // Percorre cada palavra na lista de palavras
        foreach (string palavra in listaPalavras)
        {
            // Verifica se o tamanho da palavra é igual ao da palavra base e se não é a mesma palavra
            if (palavra.Length == palavraBase.Length && palavra.ToLower() != palavraBase.ToLower())
            {
                string palavraComparada = OrdenarString(palavra); // Obtém a palavra atual ordenada alfabeticamente

                // Verifica se a palavra ordenada é igual à palavra base ordenada
                if (palavraComparada == palavraOrdenada)
                    anagramas.Add(palavra); // Adiciona a palavra à lista de anagramas
            }
        }

        return anagramas; // Retorna a lista de anagramas encontrados
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite a palavra-base:");
        string palavraBase = Console.ReadLine();

        Console.WriteLine("Digite a lista de palavras separadas por espaço:");
        List<string> listaPalavras = Console.ReadLine().Split(' ').ToList();

        try
        {
            AnagramFinder finder = new AnagramFinder(palavraBase, listaPalavras);
            List<string> anagramas = finder.EncontrarAnagramas(); // pq esse finder?

            // Verifica se foram encontrados anagramas
            if (anagramas.Count > 0)
            {
                Console.WriteLine("Anagramas:");
                foreach (string anagrama in anagramas)
                {
                    Console.WriteLine(anagrama); // Exibe cada anagrama encontrado
                }
            }
            else
            {
                Console.WriteLine("Nenhum anagrama encontrado.");
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message); // Captura e exibe qualquer exceção relacionada à palavra base vazia
        }
    }
}
