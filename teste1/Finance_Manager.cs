namespace teste1;
public class Finance_Manager
{
    private List<Transactions> _transaction = new List<Transactions>();



    /* INICIO FUNCAO NOVA TRANSACAO */
    private int _proxID = 1;
    public void addTransaction (string desc, double val, string typ)
    {
        Transactions T = new Transactions();
        T.Id = _proxID;
        T.Description = desc;
        T.Value = val;
        T.Type = typ;
        _proxID++;

        _transaction.Add(T);
        
    }
    /* FIM FUNCAO NOVA TRANSACAO */


    /* INICIO FUNCAO OPCOES DE EXTRATO IN/OUT/ALL */
    public void ShowFilteredList(string Filter)
    {

         
        var result = Filter switch
        {
           
            "in" => _transaction.Where(t => t.Type.ToLower().Trim() == "deposito"),
            "out" => _transaction.Where(t => t.Type.ToLower().Trim() == "retirada"),

            "all" => _transaction

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
        _valueBalance = 0;

        foreach(Transactions transaction in _transaction)
        {
            if(transaction.Type.ToLower() == "deposito")
            {
                _valueBalance+=transaction.Value;
            }

            else
            {
                _valueBalance-=transaction.Value;
            }
        }
        Console.WriteLine($"O balanco total atualizado e de {_valueBalance:C}!");
    }
    /* FIM FUNCAO BALANCO TOTAL */


    
}