//Crie um programa em que o usuário precisa digitar um nome e uma mensagem de boas vindas
//personalizada com o nome dele é exibida:  Olá, Welisson!Seja muito bem-vindo!

Desafio.Execute();

public static class Desafio
{
    public static void Execute()
    {
        Console.Write("Digite seu nome: ");
        var nome = Console.ReadLine();

        Console.WriteLine($"Olá {nome}! Seja muito bem-vindo(a)!");
    }
}