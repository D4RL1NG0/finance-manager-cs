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
            try
            {
                if(!int.TryParse(Console.ReadLine(), out choice))
                {
                Console.WriteLine("Entre uma opcao Valida!");
                continue;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado {ex.Message}");
            }
            

            /* INICIO DOS CASOS DE ESCOLHHA */
            switch (choice)
            {
                case 1:
                    try
                    {
                    Console.WriteLine("Descricao:\n");
                    string? desc = Console.ReadLine();

                   
                    /* INICIO ENTRADA DE VALOR */
                    double val;
                    while(true)
                    {
                        Console.WriteLine("Valor:\n");
                        if(double.TryParse(Console.ReadLine(),out val)) break;

                        Console.WriteLine("Valor invalido, insira um valor valido.");  
                    }
                    /* FIM ENTRADA DE VALOR */
                    
                    /* INICIO ENTRADA DE TIPO */
                    string typ = "";
                    while(true)
                    {
                        
                        Console.WriteLine("Tipo: Deposito/Retirada:\n");

                        typ = Console.ReadLine()!.ToLower().Trim();

                        if(typ == "deposito" || typ == "retirada")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Digite um tipo valido Receita/Retirada!");
                        }
                    }
                    /* FIM ENTRADA DE TIPO */

                    //CRIANDO TRANSACAO//
                    FM.addTransaction(desc!, val, typ);
                    Console.WriteLine("Transacao criada com sucesso!");

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Ocorreu um erro inesperado {ex.Message}");
                    }
                    
                    break;

                case 2:

                    //BALANCO TOTAL//
                    FM.Balance();
                    break;

                case 3:

                    /* INICIO SUBMENU EXTRATO */
                    Console.WriteLine("Que tipo de Extrato deseja:");
                    Console.WriteLine("1-Entradas.");
                    Console.WriteLine("2-Saidas.");
                    Console.WriteLine("3-Extrato Completo.");

                    int choice2;

                    if(!int.TryParse(Console.ReadLine(),out choice2))
                    
                    {
                        Console.WriteLine("Digite uma opcao valida!");
                    }
                    switch (choice2)
                    {
                        case 1:
                            FM.ShowFilteredList("in");
                            break;
                        case 2:
                            FM.ShowFilteredList("out");
                            break;
                        case 3:
                            FM.ShowFilteredList("all");
                            break;
                    }
                    break;
                    /* FIM SUBMENU EXTRATO */

                case 4: 
                    Console.WriteLine("Fechando aplicacao...");
                    break;
            }
            /* FIM DOS CASOS DE ESCOLHHA */
            
       }
   

    }
}