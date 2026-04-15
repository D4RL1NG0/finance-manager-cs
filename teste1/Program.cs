using System;
namespace teste1;
public class Program
{

    
    public static void Main()
    {

       Finance_Manager FM = new Finance_Manager();


       Console.WriteLine("Bem Vindo ao Gerenciador de Financas!");

       

       int choice = 0;

       while(choice!=4)
       {

            Console.WriteLine("Oque deseja:");
            Console.WriteLine("1-Nova Transacao.");
            Console.WriteLine("2-Balanco Total.");
            Console.WriteLine("3-Opcoes de Extrato.");
            Console.WriteLine("4-Sair.");
            Console.WriteLine("Digite o numero correspondente a acao que deseja:");

            if(!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Entre uma opcao Valida!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Descricao:\n");
                    string? D = Console.ReadLine();

                    Console.WriteLine("Valor:\n");
                    
                    double V;

                    if(!double.TryParse(Console.ReadLine(),out V))
                    {
                        Console.WriteLine("Valor invalido, insira um valor valido.");
                        continue;
                    }

                    string T = "";
                    while(true)
                    {
                        Console.WriteLine("Tipo: Deposito/Retirada:\n");

                        T = Console.ReadLine()!.ToLower().Trim();

                        if(T == "deposito" || T == "retirada")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Digite um tipo valido Receita/Retirada!");
                        }
                    }

                    Console.WriteLine("Transacao criada com sucesso!");
                    FM.addTransaction(D!, V, T);

                    break;

                case 2:

                    FM.Balance();
                    break;

                case 3:
                    Console.WriteLine("Que tipo de Extrato deseja:");
                    Console.WriteLine("1-Entradas.");
                    Console.WriteLine("2-Saidas.");
                    Console.WriteLine("3-Extrato Completo.");

                    int choice2;

                    if(!int.TryParse(Console.ReadLine(),out choice2))
                    {
                        Console.WriteLine("Digite uma opcao valida!");
                    }

                    else if(choice2 == 1)
                    {
                        FM.ShowFilteredList("in");
                    }
                    else if(choice2 == 2)
                    {
                        FM.ShowFilteredList("out");
                    }
                    else if(choice2 == 3)
                    {
                        FM.ShowFilteredList("all");
                    }
                    

                    else
                    {
                        Console.WriteLine("Digite uma opcao valida!");
                    }
                    break;

                case 4: 

                    Console.WriteLine("Fechando aplicacao...");
                    break;
            }
            
       }
   

    }
}