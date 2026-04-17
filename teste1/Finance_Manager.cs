namespace teste1;
public class Finance_Manager
{
    
    /* INICIO FUNCAO NOVA TRANSACAO */
    public void addTransaction (string description, double value, string type)
    {
        using(var context = new AppDbContext())
        {
            var nova = new Transactions(description, value, type);
            context.Transactions.Add(nova);
            context.SaveChanges();
        }
    }
    /* FIM FUNCAO NOVA TRANSACAO */

    /* INICIO FUNCAO OPCOES DE EXTRATO IN/OUT/ALL */
    public void ShowFilteredList(string Filter)
    {
        using(var context = new AppDbContext())
        {
            var query = context.Transactions.AsQueryable();

            var result = Filter.ToLower().Trim() switch
            {
                "in" => query.Where(t => t.Type == "deposito"),
                "out" => query.Where(t => t.Type == "retirada"),
                _ => query,            
            };
            
            var Listafinal = result.ToList();
            if(!Listafinal.Any())
            {
                Console.WriteLine("Nenhuma Transacao encontrada!");
                return;
            }

            foreach(var t in Listafinal){Console.WriteLine($" ID: {t.Id}\n Descricao: {t.Description}\n Valor: {t.Value:C}\n Tipo: {t.Type}\n");}
            }
        }
    /* FIM FUNCAO OPCOES DE EXTRATO IN/OUT/ALL */

    /* INICIO FUNCAO BALANCO TOTAL */
    public void Balance()
    {
        using(var context = new AppDbContext())
        {
            double entradas = context.Transactions
            .Where(t => t.Type == "deposito")
            .Sum(t => t.Value);

             double saidas = context.Transactions
            .Where(t => t.Type == "retirada")
            .Sum(t => t.Value);

             double balance = entradas -saidas;

              Console.WriteLine($"O balanco total {balance:C}!");
              }
        }
    /* FIM FUNCAO BALANCO TOTAL */
}