using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEleicao.Console;

public class EleicaoManager
{
    private readonly List<Candidato> candidatos = new();

    public void CadastrarCandidato(string nome, int numero)
    {
        if (candidatos.Any(c => c.Numero == numero))
        {
            throw new InvalidOperationException(
                "Já existe um candidato com esse número.");
        }

        candidatos.Add(new Candidato(nome, numero));
    }
}