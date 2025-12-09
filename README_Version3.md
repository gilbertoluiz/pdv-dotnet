# PDV Suite (.NET 8 + WPF + Worker + Dapper)

- Nomes em português
- Tema claro/escuro
- Tela de configuração inicial
- Login após configuração
- Home do PDV
- CRUD de pedidos
- Emissão de TXT (Unimake) e watcher de retornos (esqueleto)
- Dapper + MySqlConnector

Pastas Unimake padrão:
- `C:\Unimake\UniNFe\<cnpjdocliente>\Envio`
- `C:\Unimake\UniNFe\<cnpjdocliente>\Retorno`

Build:
- `dotnet build`
- Publicação: `dotnet publish -c Release -r win-x64 /p:PublishSingleFile=true`

Depois você decide qual projeto seguir; eu configuro CI (MSI) e assinatura.