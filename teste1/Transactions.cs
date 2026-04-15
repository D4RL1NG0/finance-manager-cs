namespace teste1;
using System;
public class Transactions
{
    public int Id {get; set;}  
    public string Description{get; set;} = string.Empty;
    public double Value {get; set;}
    public string Type {get; set;} = string.Empty;
    
    public Transactions (int id, string desc, double val, string typ)
    {
        Id = id;
        Description = desc;
        Value = val;
        Type = typ;
    }
    
}
