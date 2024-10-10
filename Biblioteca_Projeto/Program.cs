using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class Biblioteca{
    public List<Livro> livros;
    public Biblioteca(){
        livros = new List<Livro>();
    }
    public void Listarlivro(){
        if(livros.Count != 0){
            foreach(var livro in livros){
                Console.WriteLine($"Titulo: {livro.nome} - Autor: {livro.autor} - Genero: {livro.genero} - Quantidade disponivel: {livro.quantidade} - ID: {livro.id}");
            }
        }else
            Console.WriteLine("Não existe livros cadastrados!");
    }
}
public class UserCliente{
    public string nome {get; set;}
    public string email {get; set;}
    public string user {get; set;}
    public string senha {get; set;}
    public int idade {get; set;}
    public int livrosEmprestados {get; set;}
    public UserCliente(string n, string e, string u, string s, int i){
        nome = n;
        email = e;
        user = u;
        senha = s;
        idade = i;
    }
    
}
public class UserAdm : UserCliente{
    public UserAdm(string n, string e, string u, string s, int i) : base(n , e , u , s, i){
        
    }
    
    public void cadastrarLivro(){
        Console.WriteLine("Informe o titulo:");
        string n = Console.ReadLine();
        Console.WriteLine("Informe o autor:");
        string a = Console.ReadLine();
        Console.WriteLine("Informe o genero:");
        string g = Console.ReadLine();
        Console.WriteLine("Informe a quantidade:");
        int q = int.Parse(Console.ReadLine());
        Console.WriteLine("Informe o Id:");
        int i = int.Parse(Console.ReadLine());
        Livro novoLivro = new Livro(n,a,g,q,i);
        livros.Add(novoLivro);
    }
    public void alterarLivro(){
        Console.WriteLine("Informe o Id do livro que deseja alterar: ");
        int id = int.Parse(Console.ReadLine());
        Livro livro = livros.Find(l => l.id == id);
        if(livro != null){
            Console.WriteLine("Altere o titul:");
            string n = Console.ReadLine();
            livro.nome = n;
            Console.WriteLine("Altere o autor:"); 
            string a = Console.ReadLine();
            livro.autor = a;
            Console.WriteLine("Altere o genero:");
            string g = Console.ReadLine();
            livro.genero = g;
            Console.WriteLine("Altere a quantidade: ");
            int q = int.Parse(Console.ReadLine());
            livro.quantidade = q;
            Console.WriteLine("Altere o id: ");
            int i = int.Parse(Console.ReadLine());
            livro.id = i;
        }else
            Console.WriteLine("Livro não encontrado!");
    }
    public void excluirLivro(){
        Console.WriteLine("Informe o Id do livro que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());
        Livro livro = livros.Find(l => l.id == id);
        if(livro != null){
            livros.Remove(livro);
            Console.WriteLine("Livro removido!");
        }else
            Console.WriteLine("Livro não encontrado!");
    }
    
}
public class Livro{
    public string nome {get; set;}
    public string autor {get; set;}
    public string genero {get; set;}
    public int quantidade {get; set;}
    public int id {get; set;}
    public Livro(string n, string a, string g, int q, int i){
        nome = n;
        autor = a;
        genero = g;
        quantidade = q;
        id = i;
    }
}
