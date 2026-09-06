# API Biblioteca

API REST minimalista para gerenciamento de livros, desenvolvida com ASP.NET Core e .NET 10.

## Requisitos

- .NET SDK 10.0 ou superior

## Como executar

Na raiz do projeto, execute:

```bash
dotnet run
```

A API estará disponível em:

- HTTP: `http://localhost:5220`
- HTTPS: `https://localhost:7017`

Para verificar se a API está funcionando:

```http
GET http://localhost:5220/
```

Resposta esperada:

```text
API da biblioteca está no ar
```

## Endpoints

| Metodo | Rota | Descricao |
| --- | --- | --- |
| GET | `/api/livros` | Lista todos os livros |
| GET | `/api/livros/{id}` | Busca um livro pelo ID |
| POST | `/api/livros` | Cadastra um novo livro |
| PUT | `/api/livros/{id}` | Atualiza um livro existente |
| DELETE | `/api/livros/{id}` | Remove um livro |

### Listar livros

```http
GET /api/livros
```

### Buscar livro por ID

```http
GET /api/livros/1
```

### Cadastrar livro

```http
POST /api/livros
Content-Type: application/json

{
  "titulo": "O Senhor dos Aneis"
}
```

### Atualizar livro

```http
PUT /api/livros/1
Content-Type: application/json

{
  "titulo": "Dom Casmurro - Edicao revisada"
}
```

### Remover livro

```http
DELETE /api/livros/1
```

## Observacoes

- A aplicacao inicia com os livros `Dom Casmurro` e `Capitaes da Areia`.
- Os dados ficam armazenados somente em memoria e sao perdidos ao reiniciar a aplicacao.
- Operacoes para um ID inexistente retornam HTTP `404 Not Found`.
- O cadastro retorna HTTP `201 Created` e a remocao bem-sucedida retorna HTTP `204 No Content`.
