using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PdvSuite.Dominio.Servicos;
using PdvSuite.Servico.Worker.Watchers;

namespace PdvSuite.Servico.Worker.Servicos;

public class ServicoEmissor : BackgroundService
{
    private readonly IPedidosServico _pedidos;
    private readonly IProvedorFiscal _fiscal;
    private readonly IWatcherRetornoArquivos _watcher;

    public ServicoEmissor(IPedidosServico pedidos, IProvedorFiscal fiscal, IWatcherRetornoArquivos watcher)
    {
        _pedidos = pedidos; _fiscal = fiscal; _watcher = watcher;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _watcher.Iniciar();
        while (!stoppingToken.IsCancellationRequested)
        {
            var lote = await _pedidos.ObterProntosParaFiscalAsync(50);
            foreach (var p in lote)
            {
                try
                {
                    await _fiscal.GerarTxtAsync(p, _watcher.PastaEnvio, stoppingToken);
                }
                catch (Exception ex)
                {
                    await _pedidos.AtualizarResultadoFiscalAsync(p.Id, null, null, ex.Message, false);
                }
            }
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}