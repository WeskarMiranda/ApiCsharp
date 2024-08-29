var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! em C#");

app.MapGet("/segundo", () => "Segunda Funcionalidade");

app.MapGet("/retorno", () =>
{
    dynamic endereco = new
    {
        rua = "Praça Osorio",
        numero = 125
    };
    return endereco;
});

//Criar novas funcionalidades/Endpoints para receber dados
// Pela URL da requisição
// Corpo da requisição
// Guardar as informações em uma lista

app.Run();
