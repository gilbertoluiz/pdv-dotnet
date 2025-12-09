using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using PdvSuite.Servico.Worker.Servicos;
using PdvSuite.Dominio.Servicos;
using PdvSuite.Servico.Worker.Fiscal;
using PdvSuite.Servico.Worker.Watchers;

await Host.CreateDefaultBuilder()
    .UseWindowsService()
    .UseSerilog((ctx, cfg) => cfg.WriteTo.File("pdv-worker.log"))
    .ConfigureServices((ctx, services) =>
    {
        services.AddHostedService<ServicoEmissor>();
        services.AddSingleton<IWatcherRetornoArquivos, WatcherRetornoArquivos>();
        services.AddSingleton<IProvedorFiscal, ProvedorFiscalUnimakeTxt>();
        // TODO: Registrar implementação de IPedidosServico com PedidosRepositorio via DI
    })
    .Build()
    .RunAsync();