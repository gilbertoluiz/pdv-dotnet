using System.Threading;
using System.Threading.Tasks;
using PdvSuite.Dominio.Modelos;

namespace PdvSuite.Dominio.Servicos;

public interface IProvedorFiscal
{
    Task<string> GerarTxtAsync(Pedido pedido, string pastaSaida, CancellationToken cancelamento);
}