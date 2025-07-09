// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

while (true)
{
    var op = Console.ReadLine();
    switch (op)
    {
        case "vernome":
            MeuCodigo();
            break;
            
        case "veramigos":
            MeuCodigo2();
            break;
        
        case "amigosdosamigos":
            MeuCodigo3();
            break;
            //copiaroadData

        case "sair":
            return;
    }
}

int pegarTamanhoNome(string nome)
{
    return nome.Length;
}


async Task<string[]> PegarAmigos(int id)
{
    var nome = await pegarNomeUsuarioAsync(id);
    var amigos = await buscarAmigosAsync(nome);
    return amigos;
}

async Task MeuCodigo()
{
    int id = int.Parse(Console.ReadLine()); 
    var nome = await pegarNomeUsuarioAsync(id);
    var tamanho = pegarTamanhoNome(nome);
    Console.WriteLine(tamanho);
    Console.WriteLine(nome);
}

async Task MeuCodigo2()
{
    int id = int.Parse(Console.ReadLine());
    var amigos = await PegarAmigos(id);
    foreach (var amigo in amigos)
        Console.WriteLine(amigo);
}

async Task MeuCodigo3()
{
    int id = int.Parse(Console.ReadLine());
    var amigos = await PegarAmigos(id);
    foreach (var amigo in amigos)
    {
        var amigosdosamigos = await buscarAmigosAsync(amigo);
        foreach (var amigodoamigo in amigosdosamigos)
            Console.WriteLine(amigodoamigo);
    }
}


// Veio pronto

Task<string> pegarNomeUsuarioAsync(int id)
{
    Task<string> tarefa = Task.Factory.StartNew(() =>
    {
        var nome = pegarNomeUsuario(id);
       return nome;
    });
    return tarefa;
}

Task<string[]> buscarAmigosAsync(string nome)
{
    return Task<string[]>.Factory.StartNew(() =>
    {
        return buscarAmigos(nome);
    });
}

string pegarNomeUsuario(int idUsuario)
{
    string[] nomes = [ "Don", "Cristian", "Queila" ];
    Thread.Sleep(1000);
    return nomes[idUsuario];
}

string[] buscarAmigos(string nome)
{
    Thread.Sleep(1000);
    if (nome == "Cristian")
        return [ "Trevis", "Queilis" ];
    return [ "Trevis" ];
}