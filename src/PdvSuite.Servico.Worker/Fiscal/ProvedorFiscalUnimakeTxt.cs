using System.Text;
using PdvSuite.Dominio.Modelos;
using PdvSuite.Dominio.Servicos;

namespace PdvSuite.Servico.Worker.Fiscal;

public class ProvedorFiscalUnimakeTxt : IProvedorFiscal
{
    public Task<string> GerarTxtAsync(Pedido pedido, string pastaSaida, CancellationToken cancelamento)
    {
        // Ajuste conforme layout oficial da Unimake
        var linhas = new List<string>
        {
            $"DOC={pedido.DocumentoCliente}",
            $"ID={pedido.Id}",
            $"QTD_ITENS={pedido.Itens.Count}",
        };
        var conteudo = string.Join(Environment.NewLine, linhas);
        var caminho = Path.Combine(pastaSaida, $"NFCe_{pedido.Id}.txt");
        File.WriteAllText(caminho, conteudo, Encoding.UTF8);
        return Task.FromResult(caminho);
    }
}