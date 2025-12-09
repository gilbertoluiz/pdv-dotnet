using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using PdvSuite.Dominio.Modelos;

namespace PdvSuite.Infra.Repositorios;

public class PedidosRepositorio
{
    private readonly string _conexao;
    public PedidosRepositorio(string conexao) => _conexao = conexao;

    public async Task<IEnumerable<Pedido>> ListarAsync(int maximo)
    {
        await using var db = new MySqlConnection(_conexao);
        var sql = @"SELECT id, documento_cliente, criado_em, status, chave_fiscal, protocolo, mensagem_erro
                    FROM pedidos ORDER BY criado_em DESC LIMIT @maximo";
        var rows = await db.QueryAsync(sql, new { maximo });
        return rows.Select(r => new Pedido
        {
            Id = (long)r.id,
            DocumentoCliente = (string)r.documento_cliente,
            CriadoEm = (DateTime)r.criado_em,
            Status = (StatusPedido)(int)r.status,
            ChaveFiscal = (string?)r.chave_fiscal,
            Protocolo = (string?)r.protocolo,
            MensagemErro = (string?)r.mensagem_erro
        });
    }

    public async Task<IEnumerable<Pedido>> ObterProntosParaFiscalAsync(int maximo)
    {
        await using var db = new MySqlConnection(_conexao);
        var sql = @"SELECT id, documento_cliente, criado_em
                    FROM pedidos WHERE status = @status LIMIT @maximo";
        var rows = await db.QueryAsync(sql, new { status = (int)StatusPedido.ProntoFiscal, maximo });
        return rows.Select(r => new Pedido
        {
            Id = (long)r.id,
            DocumentoCliente = (string)r.documento_cliente,
            CriadoEm = (DateTime)r.criado_em,
            Status = StatusPedido.ProntoFiscal
        });
    }

    public async Task<long> SalvarAsync(Pedido pedido)
    {
        await using var db = new MySqlConnection(_conexao);
        var sql = @"INSERT INTO pedidos (documento_cliente, criado_em, status)
                    VALUES (@doc, @criado, @status); SELECT LAST_INSERT_ID();";
        var id = await db.ExecuteScalarAsync<long>(sql, new
        {
            doc = pedido.DocumentoCliente,
            criado = pedido.CriadoEm,
            status = (int)pedido.Status
        });
        return id;
    }

    public async Task AtualizarResultadoFiscalAsync(long id, string? chave, string? protocolo, string? mensagem)
    {
        await using var db = new MySqlConnection(_conexao);
        var sql = @"UPDATE pedidos SET chave_fiscal=@chave, protocolo=@protocolo, mensagem_erro=@mensagem, status=@status WHERE id=@id";
        await db.ExecuteAsync(sql, new
        {
            chave,
            protocolo,
            mensagem,
            status = chave != null ? (int)StatusPedido.Emitido : (int)StatusPedido.Erro,
            id
        });
    }

    public async Task<bool> ExcluirAsync(long id)
    {
        await using var db = new MySqlConnection(_conexao);
        var sql = @"DELETE FROM pedidos WHERE id=@id";
        return (await db.ExecuteAsync(sql, new { id })) > 0;
    }
}