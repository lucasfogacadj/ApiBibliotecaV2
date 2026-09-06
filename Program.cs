var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Criar nossa lista
var livros = new List<LivroDto>
{
    new LivroDto(1, "Dom Casmurro"),
    new LivroDto(2, "Capitães da Areia")
};


app.MapGet("/", () => "API da biblioteca está no ar");

app.MapGet("/api/livros", () =>
{
    return Results.Ok(livros);
});

app.MapGet("/api/livros/{id:int}", (int id) =>
{
    var livro = livros.Find(livroDaLista => livroDaLista.Id == id);

    if (livro is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(livro);
});

app.MapPost("/api/livros", (LivroEntradaDto dados) =>
{
    int proximoId = livros.Count + 1;

    var novoLivro = new LivroDto(proximoId, dados.Titulo);

    livros.Add(novoLivro);

    return Results.Created($"/api/livros/{novoLivro.Id}", novoLivro);

});


app.MapPut("/api/livros/{id:int}", (int id, LivroEntradaDto dados) => 
{
    int indice = livros.FindIndex(livroDaLista => livroDaLista.Id == id);
    if(indice == -1)
    {
        return Results.NotFound();
    }

    var livroAtualizado = new LivroDto(id, dados.Titulo);

    livros[indice] = livroAtualizado;

    return Results.Ok(livroAtualizado);
});

app.MapDelete("/api/livros/{id:int}", (int id) => 
{
    int indice = livros.FindIndex(livroDaLista => livroDaLista.Id == id);
    if(indice == -1)
    {
        return Results.NotFound();
    }
    livros.RemoveAt(indice);
    return Results.NoContent();
});

app.Run();


record LivroDto(int Id, string Titulo);
record LivroEntradaDto(string Titulo);
