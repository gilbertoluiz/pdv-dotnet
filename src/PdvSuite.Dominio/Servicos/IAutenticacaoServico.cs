namespace PdvSuite.Dominio.Servicos;

public interface IAutenticacaoServico
{
    Task<bool> ConfigurarAsync(Configuracao.ConfiguracaoAplicacao configuracao);
    Task<bool> EstaConfiguradoAsync();
    Task<bool> EntrarAsync(string usuario, string senha);
    Task SairAsync();
}