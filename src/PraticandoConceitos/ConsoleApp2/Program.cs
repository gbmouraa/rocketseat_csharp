//Crie um programa que concatene um nome e um sobrenome inseridos pelo usuário e ao final exiba o nome completo.

Desafio.Execute();

public static class Desafio
{
    public static void Execute()
    {
        Console.Write("Digite o seu nome: ");
        var nome = Console.ReadLine();

        Console.Write("Digite o seu sobrenome: ");
        var sobrenome = Console.ReadLine();

        Console.WriteLine($"Nome completo: {nome} {sobrenome}");
    }
}