using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Inicializando a lista de produtos
List<Produto> listaProdutos = new List<Produto>
{
    new Produto { Nome = "Camiseta", Preco = 29.99, Quantidade = 100 }
};

app.MapGet("/", () => "API Produtos");

app.MapGet("/produto/listar", () =>
{
    if (listaProdutos.Count > 0)
    {
        return Results.Ok(listaProdutos);
    } // Retorna a lista de produtos

    return Results.NotFound("Nenhum produto encontrado.");
});

// app.MapGet("/produto/buscar/{nome}", (string nome) =>
// {
//     // Tenta encontrar o produto pelo nome, ignorando maiúsculas e minúsculas
//     var produto = listaProdutos.FirstOrDefault(p =>
//         p.Nome != null && p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

//     if (produto != null)
//     {
//         return Results.Ok(produto); // Retorna o produto encontrado
//     }

//     return Results.NotFound($"Produto '{nome}' não encontrado."); // Retorna 404 se não encontrar
// });

app.MapGet("/produto/buscar/{nome}", ([FromRoute] string nome) =>
{
    foreach (Produto produtoCadastrado in listaProdutos)
    {
        if (produtoCadastrado.Nome != null && produtoCadastrado.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
        {
            return Results.Ok(produtoCadastrado);
        }
    }

    return Results.NotFound($"Produto '{nome}' não encontrado."); // Retorna 404 se não encontrar
});

// app.MapPost("/produto/cadastrar/{nome}", (string nome) =>
// {
//     // Verificar se o produto já existe na lista
//     if (listaProdutos.Any(p => p.Nome != null && p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
//     {
//         return Results.NotFound($"O produto '{nome}' já está cadastrado.");
//     }

//     // Criar um novo produto
//     Produto produto = new Produto
//     {
//         Nome = nome,
//         Preco = 0.0, // Definir um valor padrão ou um valor real
//         Quantidade = 0, // Definir um valor padrão ou um valor real
//         CriadoEm = DateTime.Now
//     };

//     // Adicionar o produto à lista
//     listaProdutos.Add(produto);

//     return Results.Created($"/produto/{produto.Nome}", produto);
// });

app.MapPost("/produto/cadastrar", ([FromBody] Produto produto) =>
{

    // Adicionar o produto à lista
    listaProdutos.Add(produto);

    return Results.Created($"/produto/{produto.Nome}", produto);
});

// Método PUT para atualizar produto
app.MapPut("/produto/atualizar/{nome}", ([FromRoute] string nome, [FromBody] Produto produtoAtualizado) =>
{
    var produto = listaProdutos.FirstOrDefault(p => p.Nome != null && p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

    if (produto == null)
    {
        return Results.NotFound($"Produto '{nome}' não encontrado.");
    }

    // Atualizando os dados do produto
    produto.Preco = produtoAtualizado.Preco;
    produto.Quantidade = produtoAtualizado.Quantidade;

    return Results.Ok(produto); // Retorna o produto atualizado
});

// Método DELETE para remover produto
app.MapDelete("/produto/remover/{nome}", ([FromRoute] string nome) =>
{
    var produto = listaProdutos.FirstOrDefault(p => p.Nome != null && p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

    if (produto == null)
    {
        return Results.NotFound($"Produto '{nome}' não encontrado.");
    }

    listaProdutos.Remove(produto);
    return Results.Ok($"Produto '{nome}' removido com sucesso.");
});

app.MapGet("/segundo", () => "Segunda Funcionalidade");

app.MapGet("/retorno", () =>
{
    var endereco = new
    {
        rua = "Praça Osorio",
        numero = 125
    };
    return Results.Ok(endereco); // Retorna o endereço como resposta
});

app.MapPost("/produto/cadastrar1", (string nome, double preco, int quantidade) =>
{
    // Criar um novo produto
    Produto produto = new Produto
    {
        Nome = nome,
        Preco = preco,
        Quantidade = quantidade,
        CriadoEm = DateTime.Now
    };

    // Adicionar o produto à lista
    listaProdutos.Add(produto);

    return Results.Ok(listaProdutos); // Retorna a lista atualizada de produtos
});

// app.MapPost("/produto/cadastrar", (Produto produto) =>
// {
//     produto.CriadoEm = DateTime.Now;

//     // Adicionar o produto à lista
//     listaProdutos.Add(produto);

//     return Results.Created(`$/produto/{produto.Nome}´, produto); // Retorna 201 Created e o produto criado
// });

// Endpoint para receber dados pela URL da requisição
// app.MapGet("/dados/{nome}/{idade}", (string nome, string idade) =>
// {
//     return Results.Ok(new { Nome = nome, Idade = idade }); // Corrigido para Result.Ok e ajustado para "idade"
// });

// Endpoint para receber dados pelo corpo da requisição
// app.MapPost("/adicionar", (Produto produto) =>
// {
//     listaProdutos.Add(produto);
//     return Results.Ok("Informações adicionadas");
// });

// Estudar e entender qual é o código HTTP adequado para cadastro

// Implementar todas as funcionalidades do CRUD
// Remover produto
// Alterar produto

app.Run();



