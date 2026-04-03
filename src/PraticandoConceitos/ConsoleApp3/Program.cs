// Crie um programa com 2 valores do tipo double já declarados que retorne:
//  - A soma entre esses dois números;
//  - A subtração entre os dois números;
//  - A multiplicação entre os dois números;
//  - A divisão entre os dois números (vale uma verificação se o segundo número é 0!);
//  - A média entre os dois números.

Desafio.Execute();

static public class Desafio
{
    public static void Soma(double n1, double n2) => Console.WriteLine($"Soma: {n1 + n2}");
    public static void Subtrai(double n1, double n2) => Console.WriteLine($"Subtração: {n1 - n2}");
    public static void Multiplica(double n1, double n2) => Console.WriteLine($"Multiplicação: {n1 * n2}");

    public static void Divide(double n1, double n2)
    {
        if (n2 == 0)
            Console.WriteLine("Não é possivel dividir por 0");

        Console.WriteLine($"Divisão: {n1 / n2}");
    }

    public static void Execute()
    {
        Console.Write("Digite o primeiro numero: ");
        double n1 = Double.Parse(Console.ReadLine());

        Console.Write("Digite o segundo numero: ");
        double n2 = Double.Parse(Console.ReadLine());

        Soma(n1, n2);
        Subtrai(n1, n2);
        Multiplica(n1, n2);
        Divide(n1, n2);
    }
}