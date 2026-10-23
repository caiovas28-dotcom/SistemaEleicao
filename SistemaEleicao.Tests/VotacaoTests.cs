using System;
using Xunit;
using SistemaEleicao.Console;

namespace SistemaEleicao.Tests;

public class VotacaoTests
{
    [Fact]
    public void EleitorNaoPodeVotarDuasVezes()
    {
        var eleicao = new EleicaoManager();

        eleicao.CadastrarCandidato("Ana", 10);
        eleicao.RegistrarVoto("123456789", 10);

        Assert.Throws<InvalidOperationException>(() =>
            eleicao.RegistrarVoto("123456789", 10));
    }

    [Fact]
    public void VotoEmCandidatoInexistenteDeveSerNulo()
    {
        var eleicao = new EleicaoManager();

        eleicao.CadastrarCandidato("Ana", 10);
        eleicao.RegistrarVoto("987654321", 99);

        Assert.Equal(1, eleicao.VotosNulos);
    }

    [Fact]
    public void VotoBrancoDeveSerContabilizado()
    {
        var eleicao = new EleicaoManager();

        eleicao.RegistrarVoto("111111111", 0);

        Assert.Equal(1, eleicao.VotosBrancos);
    }

    [Fact]
    public void VotoValidoDeveSerContabilizado()
    {
        var eleicao = new EleicaoManager();

        eleicao.CadastrarCandidato("Ana", 10);
        eleicao.RegistrarVoto("222222222", 10);

        Assert.Equal(0, eleicao.VotosNulos);
        Assert.Equal(0, eleicao.VotosBrancos);
    }

    [Fact]
    public void NaoDevePermitirEleitorDuplicado()
    {
        var eleicao = new EleicaoManager();

        eleicao.RegistrarEleitor("333333333");

        Assert.Throws<InvalidOperationException>(() =>
            eleicao.RegistrarEleitor("333333333"));
    }
}