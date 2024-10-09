using System.Collections.Generic;
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
public class UserAdm{
    public string nome {get; set;}
    public string email {get; set;}
    public string user {get; set;}
    public string senha {get; set;}
    private List<Livro> livros;
    public UserAdm(string n, string e, string u, string s){
        nome = n;
        email = e;
        user = u;
        senha = s;
        livros = new List<Livro>();
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
