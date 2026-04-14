namespace teste1;
public class Finance_Manager
{
    private List<Transactions> _transaction = new List<Transactions>();


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

    public void showList()
    {
        foreach(Transactions transaction in _transaction)
        {
            Console.WriteLine($"ID: {transaction.Id} Description: {transaction.Description} Value: {transaction.Value} Type: {transaction.Type}");
        }
    }

    private double _valueBalance = 0;

    public void Balance()
    {
        _valueBalance = 0;

        foreach(Transactions transaction in _transaction)
        {
            if(transaction.Type.ToLower() == "receita")
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



    
}