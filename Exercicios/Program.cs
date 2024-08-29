// Programa principal
namespace Exercicios;

// Classe Tarefa
public class Tarefa
{
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public bool Concluida { get; private set; }

    public Tarefa(string titulo, string descricao)
    {
        Titulo = titulo;
        Descricao = descricao;
        Concluida = false;
    }

    public void MarcarComoConcluida()
    {
        Concluida = true;
    }

    public override string ToString()
    {
        return $"{Titulo} - {(Concluida ? "Concluída" : "Pendente")}";
    }
}

// Classe ListaDeTarefas
public class ListaDeTarefas
{
    private List<Tarefa> tarefas;

    public ListaDeTarefas()
    {
        tarefas = new List<Tarefa>();
    }

    public void AdicionarTarefa(Tarefa tarefa)
    {
        tarefas.Add(tarefa);
    }

    public void RemoverTarefa(int indice)
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public void MarcarComoConcluida(int indice)
    {
        if (indice >= 0 && indice < tarefas.Count)
        {
            tarefas[indice].MarcarComoConcluida();
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

    public void ListarTarefas()
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa na lista.");
            return;
        }

        for (int i = 0; i < tarefas.Count; i++)
        {
            Console.WriteLine($"{i}. {tarefas[i]}");
        }
    }
}

// Programa de Exemplo
public class Program
{
    public static void Main(string[] args)
    {
        ListaDeTarefas listaDeTarefas = new ListaDeTarefas();
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\n1. Adicionar Tarefa");
            Console.WriteLine("2. Remover Tarefa");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o título da tarefa: ");
                    string titulo = Console.ReadLine() ?? string.Empty;
                    Console.Write("Digite a descrição da tarefa: ");
                    string descricao = Console.ReadLine() ?? string.Empty;
                    listaDeTarefas.AdicionarTarefa(new Tarefa(titulo, descricao));
                    break;
                case "2":
                    Console.Write("Digite o índice da tarefa a ser removida: ");
                    if (int.TryParse(Console.ReadLine(), out int indiceRemover))
                    {
                        listaDeTarefas.RemoverTarefa(indiceRemover);
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido.");
                    }
                    break;
                case "3":
                    Console.Write("Digite o índice da tarefa a ser marcada como concluída: ");
                    if (int.TryParse(Console.ReadLine(), out int indiceConcluir))
                    {
                        listaDeTarefas.MarcarComoConcluida(indiceConcluir);
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido.");
                    }
                    break;
                case "4":
                    listaDeTarefas.ListarTarefas();
                    break;
                case "5":
                    executando = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
