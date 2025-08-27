using System;
using System.Linq;
using System.Collections.Generic; // Necessário para usar a classe List

public class Desafios
{
    // O método Main é o ponto de entrada do seu programa.
    public static void Main(string[] args)
    {
        // Escolha qual desafio você quer rodar:
        // Descomente a linha para o desafio desejado e comente as outras.

        //ExecutarDesafio1_SomarAlgarismos();
        ExecutarDesafio2_SistemaDePagamento();
    }
    
    // --- Desafio 1: Somar Algarismos ---
    public static void ExecutarDesafio1_SomarAlgarismos()
    {
        Console.Write("Informe um número: ");
        string numeroDigitado = Console.ReadLine();

        int resultado = SomarAlgarismos(numeroDigitado);

        Console.WriteLine($"O resultado final é: {resultado}");
    }

    public static int SomarAlgarismos(string numero)
    {
        int[] arrayDeInts = numero.ToCharArray().Select(c => c - '0').ToArray();
        int soma = arrayDeInts.Sum();

        while (soma > 9)
        {
            int novaSoma = 0;
            int numeroAtual = soma;

            while (numeroAtual > 0)
            {
                novaSoma += numeroAtual % 10;
                numeroAtual /= 10;
            }

            soma = novaSoma;
        }

        return soma;
    }


    // --- Desafio 2: Herança e Polimorfismo ---
    public static void ExecutarDesafio2_SistemaDePagamento()
    {

        List<Pagamento> listaDePagamentos = new List<Pagamento>();

        listaDePagamentos.Add(new PagamentoCartao());
        listaDePagamentos.Add(new PagamentoBoleto());
        listaDePagamentos.Add(new PagamentoCartao());

        foreach (var p in listaDePagamentos)
        {
            p.ProcessarPagamento();
        }
    }
    
    public class Pagamento
    {
        public virtual void ProcessarPagamento()
        {
            
        }
    }

    public class PagamentoCartao : Pagamento
    {
        public override void ProcessarPagamento()
        {
            Console.WriteLine("Processando pagamento via cartão...");
        }
    }

    public class PagamentoBoleto : Pagamento
    {
        public override void ProcessarPagamento()
        {
            Console.WriteLine("Gerando boleto bancário...");
        }
    }
}