public class Calculadora
{
    public static string Calcular(int num1, int num2, string operador)
    {

        if (operador == null)
            throw new ArgumentNullException(nameof(operador), "O operador não pode ser nulo.");

        if (string.IsNullOrWhiteSpace(operador))
            throw new ArgumentException("O operador não pode estar vazio ou conter apenas espaços em branco.", nameof(operador));

        switch (operador)
        {
            case "+":
                return $"{num1} + {num2} = {num1 + num2}";
            case "*":
                return $"{num1} * {num2} = {num1 * num2}";
            case "/":
                if (num2 == 0)
                    throw new ArgumentException("Divisão por zero não é permitida.", nameof(num2));
                return $"{num1} / {num2} = {num1 / num2}";
            default:
                throw new ArgumentOutOfRangeException(nameof(operador), "Operador inválido. Apenas adição (+), multiplicação (*) e divisão (/) são suportadas.");
        }
    }

    public static void Main(string[] args)
    {
        try
        {
            int val = 8;

            // Teste da calculadora
            Console.WriteLine(Calcular(16, 51, "+"));
            Console.WriteLine(Calcular(16, val, "*"));
            //Console.WriteLine(Calcular(16, 0, "/")); // Divisão por zero
            Console.WriteLine(Calcular(16, 51, "-")); // Operador inválido
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
