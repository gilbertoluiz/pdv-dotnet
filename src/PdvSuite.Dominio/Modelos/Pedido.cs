namespace PdvSuite.Dominio.Modelos;

public enum StatusPedido { Rascunho, ProntoFiscal, Emitido, Erro }

public class ItemPedido
{
    public string Sku { get; set; } = "";
    public string Descricao { get; set; } = "";
    public decimal Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal Total => Quantidade * PrecoUnitario;
}

public class Pedido
{
    public long Id { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public string DocumentoCliente { get; set; } = "";
    public List<ItemPedido> Itens { get; set; } = new();
    public StatusPedido Status { get; set; } = StatusPedido.Rascunho;
    public string? ChaveFiscal { get; set; }
    public string? Protocolo { get; set; }
    public string? MensagemErro { get; set; }
}