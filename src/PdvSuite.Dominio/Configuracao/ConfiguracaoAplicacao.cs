namespace PdvSuite.Dominio.Configuracao;

public class ConfiguracaoAplicacao
{
    public string ConexaoMySql { get; set; } = "";
    public string PastaUnimakeEnvio { get; set; } = @"C:\Unimake\UniNFe\<cnpjdocliente>\Envio";
    public string PastaUnimakeRetorno { get; set; } = @"C:\Unimake\UniNFe\<cnpjdocliente>\Retorno";
    public bool ContingenciaOffline { get; set; } = true;
    public bool TefHabilitado { get; set; } = true;
    public string? EnderecoImpressora { get; set; }
}