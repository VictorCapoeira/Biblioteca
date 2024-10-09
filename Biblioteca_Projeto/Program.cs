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
    
    static void cadastrarLivro(){
        Console.WriteLine("Digite")
        string n;
        string a;
        string g;
        int q;
        int i;
        Livro novoLivro = new Livro(n,a,g,q,i);

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
