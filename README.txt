RM 552233 - Beatriz Maria dos Santos
RM 552323 - Heloisa Vital de Melo 

Gestão de Estoque API
API de microserviço para gerenciamento de estoque.

🏃 Como Executar
Restaure as dependências:
dotnet restore

Execute o projeto:
dotnet run

A API estará disponível em http://localhost:5000.

📈 Regras de Negócio
O estoque de um produto não pode ficar negativo.

Toda entrada ou saída gera um registro de movimentação.

A quantidade em uma movimentação (entrada/saída) deve ser maior que zero.

🏗️ Entidades
[Produto]
  - Id
  - Nome
  - Sku
  - QuantidadeEmEstoque

[MovimentacaoEstoque]
  - Id
  - ProdutoId (FK para Produto)
  - Tipo (Entrada / Saída)
  - Quantidade
  - DataMovimentacao
    
⚙️ Exemplos de API

Registrar Entrada de Estoque
Request: POST /api/estoque/entrada


JSON

{
  "produtoId": 1,
  "quantidade": 20
}

Registrar Saída de Estoque
Request: POST /api/estoque/saida

JSON

{
  "produtoId": 1,
  "quantidade": 5
}
Consultar Estoque de um Produto
Request: GET /api/produto/1