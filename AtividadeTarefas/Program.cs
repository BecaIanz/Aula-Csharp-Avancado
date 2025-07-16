using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var ProximoID = 0;
List<Tarefa> tarefas = [];

// app.MapGet("produtos", () => tarefas);

app.MapGet("produtos", () =>
{
    string textinho = "---LISTA DE TAREFAS---\n";

    foreach (var tarefinhas in tarefas)
    {
        string status;
        if (tarefinhas.Concluida)
            status = "[✓]";
        else
            status = "[ ]"; 

        textinho += $"{tarefinhas.ID} - {status} {tarefinhas.Descricao} \n";
    }

    return textinho;
});

app.MapPost("produtos/{descricao}", (string descricao) =>
{
    ProximoID++;
    tarefas.Add(new Tarefa(descricao, false, ProximoID));
});

app.MapPut("produtos/{id}", (int id) =>
{
    for (int i = 0; i < tarefas.Count; i++)
    {
        var task = tarefas[i];
        if (tarefas[i].ID == id)
            tarefas[i] = task with { Concluida = true, ID = tarefas[i].ID };
    }
});

app.MapDelete("produtos/{id}", (int id) =>
{
    for (int i = 0; i < tarefas.Count; i++)
    {
        var task = tarefas[i];
        if (tarefas[i].ID == id)
        {
            tarefas.Remove(task);
            ProximoID--;
            for (int j = tarefas[i].ID; j < tarefas.Count; j++)
            {
                var tasks = tarefas[i];
                tarefas[i] = tasks with {ID = tarefas[i].ID - 1};
            }
        }
        
    }
});

app.Run();

public record Tarefa(string Descricao, bool Concluida, int ID);