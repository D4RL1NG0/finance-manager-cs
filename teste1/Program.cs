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

            Console.WriteLine($"Oque deseja:\n 1-Nova Transacao.\n 2-Mostrar Extrato.\n 3-Balanco Total.\n 4-Sair.");
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
                        Console.WriteLine("Tipo: Receita/Retirada:\n");

                        T = Console.ReadLine()!.ToLower().Trim();

                        if(T == "receita" || T == "retirada")
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

                    FM.showList();
                    break;

                case 3:
                    FM.Balance();
                    break;

                case 4:
                    Console.WriteLine("Fechando aplicacao...");
                    break;
            }
            
       }
   

    }
}