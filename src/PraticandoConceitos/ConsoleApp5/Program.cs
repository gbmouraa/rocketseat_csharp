//Crie um programa em que o usuário precisa digitar a placa de um veículo
//e o programa verifica se a placa é válida, seguindo o padrão brasileiro válido até 2018:
// - A placa deve ter 7 caracteres alfanuméricos;
// - Os três primeiros caracteres são letras (maiúsculas ou minúsculas);
// - Os quatro últimos caracteres são números;

//Ao final, o programa deve exibir ***Verdadeiro*** se a placa for válida e ***Falso*** caso contrário.

Desafio.Execute();

public static class Desafio
{
    public static void Execute()
    {
        Console.Write("Digite a placa de veiculo: ");
        string placa = Console.ReadLine();

        Console.WriteLine(ValidaPlaca(placa));
    }

    private static bool ValidaPlaca(string? placa)
    {
        if (string.IsNullOrEmpty(placa) || placa.Length != 7)
            return false;

        if (placa[0..3].All(char.IsLetter) && placa[3..].All(char.IsDigit))
            return true;

        return false;
    }
}