using API.Models;

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
    return Results.Ok(listaProdutos); // Retorna a lista de produtos
});

app.MapPost("/produto/cadastrar/{nome}", (string nome) =>
{
    // Criar um novo produto
    Produto produto = new Produto
    {
        Nome = nome,
        // Define valores padrão para as outras propriedades, se necessário
        Preco = 0.0, // Definir um valor padrão ou um valor real
        Quantidade = 0, // Definir um valor padrão ou um valor real
        CriadoEm = DateTime.Now
    };

    // Adicionar o produto à lista
    listaProdutos.Add(produto);

    return Results.Ok(listaProdutos); // Retorna a lista atualizada de produtos
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

app.Run();


