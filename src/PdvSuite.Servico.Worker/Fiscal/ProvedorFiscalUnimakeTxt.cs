using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PdvSuite.Dominio.Modelos;
using PdvSuite.Dominio.Servicos;

namespace PdvSuite.Servico.Worker.Fiscal;

public class ProvedorFiscalUnimakeTxt : IProvedorFiscal
{
    public Task<string> GerarTxtAsync(Pedido pedido, string pastaSaida, CancellationToken cancelamento)
    {
        var linhas = new List<string>
        {
            $"DOC={pedido.DocumentoCliente}",
            $"ID={pedido.Id}",
            $"QTD_ITENS={pedido.Itens.Count}",
        };
        var conteudo = string.Join(System.Environment.NewLine, linhas);
        var caminho = Path.Combine(pastaSaida, $"NFCe_{pedido.Id}.txt");
        File.WriteAllText(caminho, conteudo, Encoding.UTF8);
        return Task.FromResult(caminho);
    }
}