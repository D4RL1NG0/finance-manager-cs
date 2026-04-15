namespace teste1;
public class Finance_Manager
{
    private List<Transactions> _transaction = new List<Transactions>();



    /* INICIO FUNCAO NOVA TRANSACAO */
    private int _proxID = 1;
    public void addTransaction (string desc, double val, string typ)
    {
    
        _transaction.Add(new Transactions(_proxID,desc,val,typ));

        _proxID++;
        
    }
    /* FIM FUNCAO NOVA TRANSACAO */


    /* INICIO FUNCAO OPCOES DE EXTRATO IN/OUT/ALL */
    public void ShowFilteredList(string Filter)
    {

         
        var result = Filter switch
        {

            "in" => _transaction.Where(t => t.Type.ToLower().Trim() == "deposito"),
            "out" => _transaction.Where(t => t.Type.ToLower().Trim() == "retirada"),

            _ => _transaction,
            
        };

        if(!result.Any())
                {
                    Console.WriteLine("Nenhuma Transacao encontrada!");
                    return;
                }

        foreach(var t in result){Console.WriteLine($" ID: {t.Id}\n Descricao: {t.Description}\n Valor: {t.Value:C}\n Tipo: {t.Type}\n");}
    }
    /* FIM FUNCAO OPCOES DE EXTRATO IN/OUT/ALL */


    /* INICIO FUNCAO BALANCO TOTAL */
    private double _valueBalance = 0;

    public void Balance()
    {
        double entradas = _transaction.Where(t => t.Type == "deposito").Sum(t => t.Value);

        double saidas = _transaction.Where(t => t.Type == "retirada").Sum(t => t.Value);

        _valueBalance = entradas -saidas;

        Console.WriteLine($"O balanco total {_valueBalance:C}!");
    }
    /* FIM FUNCAO BALANCO TOTAL */


    
}