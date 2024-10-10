using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class Biblioteca{
    public List<Livro> livros;
    public Biblioteca(){
        livros = new List<Livro>();
    }
    public void cadastrarLivro(){
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Cadastro de livros:");
        Console.ResetColor();
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
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Livro cadastrado com sucesso!");
        Console.ResetColor();
    }
    public void alterarLivro(){
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Alteração de livros:");
        Console.ResetColor();
        Console.WriteLine("Informe o Id do livro que deseja alterar: ");
        int id = int.Parse(Console.ReadLine());
        Livro livro = livros.Find(l => l.id == id);
        if(livro != null){
            Console.WriteLine("Altere o titulo:");
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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Livro alterado com sucesso!");
            Console.ResetColor();
        }else{
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Livro não encontrado!");
            Console.ResetColor();
        }
    }
    public void excluirLivro(){
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Excluir livros:");
        Console.ResetColor();
        Console.WriteLine("Informe o Id do livro que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());
        Livro livro = livros.Find(l => l.id == id);
        if(livro != null){
            livros.Remove(livro);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Livro removido!");
            Console.ResetColor();
        }else{
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Livro não encontrado!");
            Console.ResetColor();
        }
    }
    public void Listarlivro(){
        if(livros.Count != 0){
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Lista de livros:");
            Console.ResetColor();
            foreach(var livro in livros){
                Console.WriteLine($"Titulo: {livro.nome} - Autor: {livro.autor} - Genero: {livro.genero} - Quantidade disponivel: {livro.quantidade} - ID: {livro.id}");
            }
        }else{
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Não existe livros cadastrados!");
            Console.ResetColor();
        }
    }
    public void pegarEmprestado(){
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Emprestimo de livros:");
        Console.ResetColor();
        Console.WriteLine("Informe o Id do livro que deseja: ");
        int id = int.Parse(Console.ReadLine());
        Livro livro = livros.Find(l => l.id == id);
        Console.WriteLine(livro.quantidade + "Valor fora do IF");
        if(livro != null && livro.quantidade > 0){
            livro.quantidade --;
            Console.WriteLine(livro.quantidade + "Valor dentro do IF");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Emprestimo realizado!");
            Console.ResetColor();
        }else{
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Livro não encontrado ou indisponivel!");
            Console.ResetColor();
        }
        
    }
}
public class UserCliente{
    public string nome {get; set;}
    public string email {get; set;}
    public string user {get; set;}
    public string senha {get; set;}
    public int idade {get; set;}
    public int livrosEmprestados {get; set;}
    private Biblioteca biblioteca;
    public UserCliente(string n, string e, string u, string s, int i, Biblioteca b){
        nome = n;
        email = e;
        user = u;
        senha = s;
        idade = i;
        biblioteca = b;
    }
    public void listarLivros(){
        biblioteca.Listarlivro();
    }
    public void pegarEmprestado(){
        if(livrosEmprestados >= 3){
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Limite de 3 livros emprestado atigindo!");
            Console.ResetColor();
            }
        else{
            biblioteca.pegarEmprestado();
            livrosEmprestados++;
        }
    }
}
public class UserAdm : UserCliente{
    private Biblioteca biblioteca;
    public UserAdm(string n, string e, string u, string s, int i, Biblioteca b) : base(n , e , u , s, i,b){
        biblioteca = b;
    }
    
    public void cadastrarLivro(){
        biblioteca.cadastrarLivro();
    }
    public void alterarLivro(){
        biblioteca.alterarLivro();
    }
    public void excluirLivro(){
        biblioteca.excluirLivro();
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
class Program{
    static void Main(){
        Biblioteca biblioteca = new Biblioteca();
        UserAdm adm1 = new UserAdm("Isaac", "Isaac@outlook.com", "isaacrond", "isaac2", 25, biblioteca);
        UserCliente cliente1 = new UserCliente("Alma", "Alma@outlook.com", "almagui", "alma2", 20, biblioteca);
        bool vef = false;
        while(vef == false){
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("BEM-VINDO AO SISTEMA DE BIBLIOTECA!");
            Console.ResetColor();
            Console.WriteLine("Deseja logar como Administrador(a) ou Cliente(c)? Se não deseja logar, digite s.");
            string loginEsc = Console.ReadLine().ToLower();
            if(loginEsc == "a"){
                Console.WriteLine("Administrador usuario: ");
                string admUser = Console.ReadLine();
                Console.WriteLine("Administrador senha: ");
                string admSenha = Console.ReadLine();
                if(adm1.user == admUser && adm1.senha == admSenha){
                    Console.WriteLine("Bem-vindo administrador!");
                    bool vefAdm = false;
                    while(vefAdm == false){
                        Console.WriteLine("Escolha uma opção de ação: \n 1 - Cadastrar livro \n 2 - Alterar livro \n 3 - Excluir livro \n 4 - Listar livros \n 5 - Sair");
                        string admesc = Console.ReadLine();
                        switch(admesc){
                            case "1":
                            adm1.cadastrarLivro();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            case "2":
                            adm1.alterarLivro();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            case "3":
                            adm1.excluirLivro();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            case "4":
                            adm1.listarLivros();
                            break;
                            case "5":
                            vefAdm = true;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                }else
                    Console.WriteLine("Usuario ou senha incorretos!!");
            }else if(loginEsc == "c"){
                Console.WriteLine("Cliente usuario: ");
                string clienteUser = Console.ReadLine();
                Console.WriteLine("Cliente senha: ");
                string clienteSenha = Console.ReadLine();
                if(cliente1.user == clienteUser && cliente1.senha == clienteSenha){
                    Console.WriteLine("Bem-vindo cliente!");
                    bool vefCliente = false;
                    while(vefCliente == false){
                        Console.WriteLine("Escolha uma opção de ação: \n 1 - Listar livro \n 2 - Emprestar livro \n 3 - Sair");
                        string clienteesc = Console.ReadLine();
                        switch(clienteesc){
                            case "1":
                            cliente1.listarLivros();
                            break;
                            case "2":
                            cliente1.pegarEmprestado();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            case "3":
                            vefCliente = true;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            
                        }
                    }
                }else
                    Console.WriteLine("Usuario ou senha incorretos!!");
            }else if(loginEsc == "s")
                vef = true;
            else
                Console.WriteLine("Erro! Digite novamente!");

        }
    }
}