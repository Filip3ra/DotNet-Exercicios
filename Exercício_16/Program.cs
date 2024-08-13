using System;
using System.Collections.Generic;

public abstract class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public decimal Peso { get; set; }
    public decimal PercentualDesconto { get; set; }
    public decimal Altura { get; set; }
    public decimal Largura { get; set; }
    public decimal Comprimento { get; set; }

    public Produto(string nome, decimal preco, decimal peso, decimal percentualDesconto, decimal altura, decimal largura, decimal comprimento)
    {
        Nome = nome;
        Preco = preco;
        Peso = peso;
        PercentualDesconto = percentualDesconto;
        Altura = altura;
        Largura = largura;
        Comprimento = comprimento;
    }

    public abstract decimal CalcularFrete(string cep);
    
    public decimal CalcularDesconto()
    {
        return Preco * PercentualDesconto / 100;
    }
}

public class Livro : Produto
{
    public string Autor { get; set; }

    public Livro(string nome, decimal preco, string autor, decimal peso, decimal percentualDesconto, decimal altura, decimal largura, decimal comprimento)
        : base(nome, preco, peso, percentualDesconto, altura, largura, comprimento)
    {
        Autor = autor;
    }

    public override decimal CalcularFrete(string cep)
    {
        return Peso * 2.5m;
    }
}

public class Roupa : Produto
{
    public string Tamanho { get; set; }

    public Roupa(string nome, decimal preco, string tamanho, decimal peso, decimal percentualDesconto, decimal altura, decimal largura, decimal comprimento)
        : base(nome, preco, peso, percentualDesconto, altura, largura, comprimento)
    {
        Tamanho = tamanho;
    }

    public override decimal CalcularFrete(string cep)
    {
        return Peso * 3.0m;
    }
}

public class Eletronico : Produto
{
    public string Marca { get; set; }

    public Eletronico(string nome, decimal preco, string marca, decimal peso, decimal percentualDesconto, decimal altura, decimal largura, decimal comprimento)
        : base(nome, preco, peso, percentualDesconto, altura, largura, comprimento)
    {
        Marca = marca;
    }

    public override decimal CalcularFrete(string cep)
    {
        return Peso * 5.0m;
    }
}

public interface IPagamento
{
    void ProcessarPagamento(decimal valor);
    void ConfirmarPagamento();
    void CancelarPagamento();
}

public class PagamentoCartaoCredito : IPagamento
{
    private string NumeroCartao { get; set; }
    private string DataValidade { get; set; }
    private string CVV { get; set; }

    public PagamentoCartaoCredito(string numeroCartao, string dataValidade, string cvv)
    {
        NumeroCartao = numeroCartao;
        DataValidade = dataValidade;
        CVV = cvv;
    }

    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Processando pagamento de {valor:C} com Cartão de Crédito.");
    }

    public void ConfirmarPagamento()
    {
        Console.WriteLine("Pagamento confirmado com Cartão de Crédito.");
    }

    public void CancelarPagamento()
    {
        Console.WriteLine("Pagamento cancelado com Cartão de Crédito.");
    }
}

public class PagamentoBoletoBancario : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Processando pagamento de {valor:C} com Boleto Bancário.");
        Console.WriteLine("Código de Barras: 111111222233333");
    }

    public void ConfirmarPagamento()
    {
        Console.WriteLine("Pagamento confirmado com Boleto Bancário.");
    }

    public void CancelarPagamento()
    {
        Console.WriteLine("Pagamento cancelado com Boleto Bancário.");
    }
}

public static class CarrinhoHelper
{
    public static decimal CalcularFreteTotal(List<Produto> carrinho, string cep)
    {
        decimal freteTotal = 0;
        foreach (var produto in carrinho)
        {
            freteTotal += produto.CalcularFrete(cep);
        }
        return freteTotal;
    }

    public static decimal CalcularTotalComDesconto(List<Produto> carrinho)
    {
        decimal total = 0;
        foreach (var produto in carrinho)
        {
            total += produto.Preco - produto.CalcularDesconto();
        }
        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Produto> carrinho = new List<Produto> {
            new Livro("C# para Iniciantes", 29.90m, "Autor A", 0.5m, 20, 15, 2, 5),
            new Roupa("Camiseta", 19.90m, "M", 0.2m, 30, 25, 1, 10),
            new Eletronico("Smartphone", 899.90m, "Marca X", 0.3m, 15, 10, 1, 15)
        };

        string cep = "12345-678";
        decimal freteTotal = CarrinhoHelper.CalcularFreteTotal(carrinho, cep);
        Console.WriteLine($"Frete total: {freteTotal:C}");

        decimal totalComDesconto = CarrinhoHelper.CalcularTotalComDesconto(carrinho);
        Console.WriteLine($"Total com desconto: {totalComDesconto:C}");

        // Escolher método de pagamento
        IPagamento pagamento = new PagamentoCartaoCredito("1234-5678-9876-5432", "12/25", "123");
        pagamento.ProcessarPagamento(totalComDesconto + freteTotal);
        pagamento.ConfirmarPagamento();
    }
}
