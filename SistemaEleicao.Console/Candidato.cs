namespace SistemaEleicao.Console;

public class Candidato
{
    public string Nome { get; set; }
    public int Numero { get; set; }

    public int Votos { get; set; }

    public Candidato(string nome, int numero)
    {
        Nome = nome;
        Numero = numero;
        Votos = 0;
    }
}