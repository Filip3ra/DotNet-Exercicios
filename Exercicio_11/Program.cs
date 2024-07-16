using System;
using System.Collections.Generic;

// Interface de Ordenação
public interface IOrdenacao
{
    void Sort(List<string> lista);
}

// Implementação do QuickSort
public class QuickSort : IOrdenacao
{
    public void Sort(List<string> lista)
    {
        QuickSort(lista, 0, lista.Count - 1);
    }

    private void QuickSort(List<string> lista, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(lista, left, right);
            QuickSort(lista, left, pivot - 1);
            QuickSort(lista, pivot + 1, right);
        }
    }

    private int Partition(List<string> lista, int left, int right)
    {
        string pivot = lista[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (string.Compare(lista[j], pivot) < 0)
            {
                i++;
                Swap(lista, i, j);
            }
        }
        Swap(lista, i + 1, right);
        return i + 1;
    }

    private void Swap(List<string> lista, int i, int j)
    {
        string temp = lista[i];
        lista[i] = lista[j];
        lista[j] = temp;
    }
}

// Implementação do MergeSort
public class MergeSort : IOrdenacao
{
    public void Sort(List<string> lista)
    {
        lista = MergeSort(lista);
    }

    private List<string> MergeSort(List<string> lista)
    {
        if (lista.Count <= 1)
            return lista;

        int middle = lista.Count / 2;
        List<string> left = new List<string>();
        List<string> right = new List<string>();

        for (int i = 0; i < middle; i++)
            left.Add(lista[i]);
        for (int i = middle; i < lista.Count; i++)
            right.Add(lista[i]);

        left = MergeSort(left);
        right = MergeSort(right);
        return Merge(left, right);
    }

    private List<string> Merge(List<string> left, List<string> right)
    {
        List<string> result = new List<string>();

        while (left.Count > 0 && right.Count > 0)
        {
            if (string.Compare(left[0], right[0]) <= 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            else
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }

        while (left.Count > 0)
        {
            result.Add(left[0]);
            left.RemoveAt(0);
        }

        while (right.Count > 0)
        {
            result.Add(right[0]);
            right.RemoveAt(0);
        }

        return result;
    }
}

// Classe ListaOrdenada
public class ListaOrdenada
{
    private List<string> lista;
    private IOrdenacao estrategia;

    public ListaOrdenada()
    {
        lista = new List<string>();
    }

    public void Add(string nome)
    {
        lista.Add(nome);
    }

    public void SetEstrategia(IOrdenacao estrategia)
    {
        this.estrategia = estrategia;
    }

    public void Sort()
    {
        if (estrategia != null)
        {
            estrategia.Sort(lista);
            foreach (var nome in lista)
            {
                Console.WriteLine(nome);
            }
        }
        else
        {
            Console.WriteLine("Estratégia de ordenação não definida.");
        }
    }
}

// Programa Principal
public class Program
{
    public static void Main(string[] args)
    {
        ListaOrdenada estudantes = new ListaOrdenada();
        estudantes.Add("Jose");
        estudantes.Add("Ana");
        estudantes.Add("Carlos");
        estudantes.Add("Beatriz");

        // Ordenação usando QuickSort
        estudantes.SetEstrategia(new QuickSort());
        Console.WriteLine("Ordenação usando QuickSort:");
        estudantes.Sort();

        Console.WriteLine();

        // Ordenação usando MergeSort
        estudantes.SetEstrategia(new MergeSort());
        Console.WriteLine("Ordenação usando MergeSort:");
        estudantes.Sort();
    }
}
