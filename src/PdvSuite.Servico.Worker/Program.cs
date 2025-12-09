using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;
using Serilog;
using PdvSuite.Servico.Worker.Servicos;
using PdvSuite.Dominio.Servicos;
using PdvSuite.Servico.Worker.Fiscal;
using PdvSuite.Servico.Worker.Watchers;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("pdv-worker.log")
    .CreateLogger();

await Host.CreateDefaultBuilder()
    .UseWindowsService() // comente esta linha se quiser rodar em console durante os testes
    .UseSerilog()        // agora disponível via Serilog.Extensions.Hosting
    .ConfigureServices((ctx, services) =>
    {
        services.AddHostedService<ServicoEmissor>();
        services.AddSingleton<IWatcherRetornoArquivos, WatcherRetornoArquivos>();
        services.AddSingleton<IProvedorFiscal, ProvedorFiscalUnimakeTxt>();
        // TODO: Registrar IPedidosServico quando a implementação estiver pronta
    })
    .Build()
    .RunAsync();