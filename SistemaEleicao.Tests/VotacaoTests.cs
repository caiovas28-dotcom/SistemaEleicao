using System;
using Xunit;
using SistemaEleicao.Console;

namespace SistemaEleicao.Tests;

public class VotacaoTests
{
    [Fact]
    public void EleitorNaoPodeVotarDuasVezes()
    {
        // Arrange: prepara a eleição
        var eleicao = new EleicaoManager();

        eleicao.CadastrarCandidato("Ana", 10);

        // Act: eleitor realiza o primeiro voto
        eleicao.RegistrarVoto("123456789", 10);

        // Assert: segundo voto deve ser bloqueado
        Assert.Throws<InvalidOperationException>(() =>
            eleicao.RegistrarVoto("123456789", 10));
    }

    [Fact]
    public void VotoEmCandidatoInexistenteDeveSerNulo()
    {
        // Arrange
        var eleicao = new EleicaoManager();

        eleicao.CadastrarCandidato("Ana", 10);

        // Act: eleitor vota em número inexistente
        eleicao.RegistrarVoto("987654321", 99);

        // Assert: verifica se o voto foi contabilizado como nulo
        Assert.Equal(1, eleicao.VotosNulos);
    }
}