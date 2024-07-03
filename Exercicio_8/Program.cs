

//dif ref e aut
class EncontraAnagrama
{
    private string palavraBase;
    private List<string> listaPalavras;

    // Construtor
    public EncontraAnagrama(string palavraBase, List<string> listaPalavras)
    {
        this.palavraBase = palavraBase;
        this.listaPalavras = listaPalavras;
    }

    // Get e set palavra-base
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

    // Get e set lista de palavras
    public List<string> ListaPalavras
    {
        get { return listaPalavras; }
        set { listaPalavras = value; }
    }

    // Método para ordenar uma string (usado para comparar anagramas)
    private string OrdenarString(string str)
    {
        char[] chars = str.ToLower().ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }

    // Método para encontrar anagramas da palavra base na lista de palavras
    public List<string> EncontrarAnagramas()
    {
        List<string> anagramas = new List<string>();
        string palavraBaseOrdenada = OrdenarString(palavraBase);

        // Percorre cada palavra na lista de palavras
        foreach (string palavra in listaPalavras)
        {
            // Verifica se o tamanho da palavra é igual ao da palavra base e se não é a mesma palavra
            if (palavra.Length == palavraBase.Length && palavra.ToLower() != palavraBase.ToLower())
            {
                string palavraAtualOrdenada = OrdenarString(palavra);

                // Verifica se a palavra atual ordenada é igual à palavra base ordenada
                if (palavraAtualOrdenada == palavraBaseOrdenada)
                    anagramas.Add(palavra);
            }
        }

        return anagramas;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite a palavra-base:");
        string? palavraBase = Console.ReadLine();

        Console.WriteLine("Digite a lista de palavras separadas por espaço:");
        List<string>? listaPalavras = Console.ReadLine()?.Split(' ').ToList(); // "?" verifica se o retorno do readline é nulo

        if (palavraBase is not null && listaPalavras is not null)
        {
            try
            {
                EncontraAnagrama objeto = new EncontraAnagrama(palavraBase, listaPalavras);
                List<string> anagramas = objeto.EncontrarAnagramas();

                // Verifica se foram encontrados anagramas
                if (anagramas.Count > 0)
                {
                    Console.WriteLine("Anagramas:");
                    foreach (string anagrama in anagramas)
                    {
                        Console.WriteLine(anagrama);
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum anagrama encontrado.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Entradas não podem ser nulas.");
        }


    }
}
