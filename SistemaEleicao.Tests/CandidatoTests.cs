using System;
using Xunit;
using SistemaEleicao.Console;

namespace SistemaEleicao.Tests;

public class CandidatoTests
{
    [Fact]
    public void NaoDevePermitirCandidatosComMesmoNumero()
    {
        var eleicao = new EleicaoManager();

        eleicao.CadastrarCandidato("Ana", 10);

        Assert.Throws<InvalidOperationException>(() =>
            eleicao.CadastrarCandidato("Carlos", 10));
    }
}