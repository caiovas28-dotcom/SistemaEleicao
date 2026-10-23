using Xunit;
using SistemaEleicao.Console;

namespace SistemaEleicao.Tests;

public class CandidatoTests
{
    [Fact]
    public void NaoDevePermitirCandidatosComMesmoNumero()
    {
        // Arrange: prepara o cenário
        var eleicao = new EleicaoManager();

        eleicao.CadastrarCandidato("Ana", 10);

        // Act e Assert: verifica se o cadastro duplicado é rejeitado
        Assert.Throws<InvalidOperationException>(() =>
            eleicao.CadastrarCandidato("Carlos", 10));
    }
}