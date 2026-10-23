using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEleicao.Console;

public class EleicaoManager
{
    // Armazena os candidatos cadastrados na eleição.
    private readonly List<Candidato> candidatos = new();

    // Controla os eleitores registrados.
    private readonly HashSet<string> eleitores = new();

    // Impede que um eleitor vote mais de uma vez.
    private readonly HashSet<string> eleitoresQueVotaram = new();

    public int VotosNulos { get; private set; }
    public int VotosBrancos { get; private set; }

    // Cadastra candidatos e impede números duplicados.
    public void CadastrarCandidato(string nome, int numero)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome inválido.");

        if (candidatos.Any(c => c.Numero == numero))
            throw new InvalidOperationException(
                "Já existe um candidato com esse número.");

        candidatos.Add(new Candidato(nome, numero));
    }

    // Registra eleitores utilizando CPF ou título simulado.
    public void RegistrarEleitor(string documento)
    {
        if (string.IsNullOrWhiteSpace(documento))
            throw new ArgumentException("Documento inválido.");

        if (!eleitores.Add(documento))
            throw new InvalidOperationException(
                "Eleitor já cadastrado.");
    }

    // Registra votos e impede votação duplicada.
    public void RegistrarVoto(string documento, int numero)
    {
        if (string.IsNullOrWhiteSpace(documento))
            throw new ArgumentException("Documento inválido.");

        // Registra automaticamente o eleitor no primeiro voto.
        eleitores.Add(documento);

        if (!eleitoresQueVotaram.Add(documento))
            throw new InvalidOperationException(
                "Este eleitor já votou.");

        // Número zero representa voto em branco.
        if (numero == 0)
        {
            VotosBrancos++;
            return;
        }

        // Procura o candidato pelo número informado.
        var candidato = candidatos
            .FirstOrDefault(c => c.Numero == numero);

        if (candidato == null)
        {
            VotosNulos++;
        }
        else
        {
            candidato.Votos++;
        }
    }

    // Exibe a apuração final dos votos.
    public void ExibirApuracao()
    {
        System.Console.WriteLine("\n=== APURAÇÃO ===");

        foreach (var candidato in candidatos)
        {
            System.Console.WriteLine(
                $"{candidato.Nome} ({candidato.Numero}): " +
                $"{candidato.Votos} votos");
        }

        System.Console.WriteLine($"Brancos: {VotosBrancos}");
        System.Console.WriteLine($"Nulos: {VotosNulos}");

        if (candidatos.Count == 0)
        {
            System.Console.WriteLine(
                "Nenhum candidato cadastrado.");
            return;
        }

        int maiorVotacao = candidatos.Max(c => c.Votos);

        var vencedores = candidatos
            .Where(c => c.Votos == maiorVotacao)
            .ToList();

        if (maiorVotacao == 0)
        {
            System.Console.WriteLine(
                "Nenhum candidato recebeu votos.");
        }
        else if (vencedores.Count > 1)
        {
            System.Console.WriteLine("Resultado: empate.");
        }
        else
        {
            System.Console.WriteLine(
                $"Vencedor: {vencedores[0].Nome}");
        }
    }
}