using SistemaEleicao.Console;

var eleicao = new EleicaoManager();

while (true)
{
    System.Console.WriteLine("\n=== SISTEMA DE ELEIÇÃO ===");
    System.Console.WriteLine("1 - Cadastrar candidato");
    System.Console.WriteLine("2 - Registrar eleitor");
    System.Console.WriteLine("3 - Votar");
    System.Console.WriteLine("4 - Apurar votos");
    System.Console.WriteLine("0 - Sair");
    System.Console.Write("Escolha: ");

    string? opcao = System.Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                System.Console.Write("Nome: ");
                string nome = System.Console.ReadLine() ?? "";

                System.Console.Write("Número: ");
                int numero = int.Parse(
                    System.Console.ReadLine() ?? "");

                eleicao.CadastrarCandidato(nome, numero);
                System.Console.WriteLine("Candidato cadastrado!");
                break;

            case "2":
                System.Console.Write("CPF/Título: ");
                string documento = System.Console.ReadLine() ?? "";

                eleicao.RegistrarEleitor(documento);
                System.Console.WriteLine("Eleitor registrado!");
                break;

            case "3":
                System.Console.Write("CPF/Título: ");
                string eleitor = System.Console.ReadLine() ?? "";

                System.Console.Write("Número (0 = branco): ");
                int voto = int.Parse(
                    System.Console.ReadLine() ?? "");

                eleicao.RegistrarVoto(eleitor, voto);
                System.Console.WriteLine("Voto registrado!");
                break;

            case "4":
                eleicao.ExibirApuracao();
                break;

            case "0":
                return;

            default:
                System.Console.WriteLine("Opção inválida.");
                break;
        }
    }
    catch (Exception ex)
    {
        System.Console.WriteLine($"Erro: {ex.Message}");
    }
}