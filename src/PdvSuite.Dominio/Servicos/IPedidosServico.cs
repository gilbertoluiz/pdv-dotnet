using PdvSuite.Dominio.Modelos;

namespace PdvSuite.Dominio.Servicos;

public interface IPedidosServico
{
    Task<Pedido?> ObterAsync(long id);
    Task<IEnumerable<Pedido>> ObterProntosParaFiscalAsync(int maximo = 50);
    Task<long> SalvarAsync(Pedido pedido);
    Task AtualizarResultadoFiscalAsync(long id, string? chave, string? protocolo, string? mensagemStatus, bool sucesso);
    Task<IEnumerable<Pedido>> ListarAsync(int maximo = 200);
    Task<bool> ExcluirAsync(long id);
}