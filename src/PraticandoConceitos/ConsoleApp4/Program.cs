//Crie um programa em que o usuário digita uma ou mais palavras e é exibido
//a quantidadede caracteres que a palavra inserida tem.

Desafio.Execute();

public static class Desafio
{
    public static void Execute()
    {
        Console.Write("Digite uma ou mais palavras: ");
        string[] palavras = Console.ReadLine().Trim().Split(" ");

        Contador(palavras);
    }

    private static void Contador(string[] strings)
    {
        Dictionary<string, int> palavras = new Dictionary<string, int>();

        foreach (string str in strings)
            palavras[str] = str.Length;

        foreach (var item in palavras)
            Console.WriteLine($"{item.Key}: {item.Value} caracteres");
    }
}