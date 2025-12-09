using System.IO;
using System.Linq;

namespace PdvSuite.Servico.Worker.Watchers;

public interface IWatcherRetornoArquivos
{
    string PastaEnvio { get; }
    void Iniciar();
}

public class WatcherRetornoArquivos : IWatcherRetornoArquivos
{
    public string PastaEnvio { get; private set; } = @"C:\Unimake\UniNFe\<cnpjdocliente>\Envio";
    private FileSystemWatcher? _watcher;

    public void Iniciar()
    {
        var retorno = @"C:\Unimake\UniNFe\<cnpjdocliente>\Retorno";
        _watcher = new FileSystemWatcher(retorno)
        {
            Filter = "*.txt",
            EnableRaisingEvents = true,
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite
        };
        _watcher.Created += (_, e) => TratarRetorno(e.FullPath);
        _watcher.Changed += (_, e) => TratarRetorno(e.FullPath);
    }

    private void TratarRetorno(string caminho)
    {
        var linhas = File.ReadAllLines(caminho);
        var chave = linhas.FirstOrDefault(l => l.StartsWith("CHAVE="))?.Split('=')[1];
        var protocolo = linhas.FirstOrDefault(l => l.StartsWith("PROTOCOLO="))?.Split('=')[1];
        // TODO: chamar IPedidosServico.AtualizarResultadoFiscalAsync(...)
    }
}