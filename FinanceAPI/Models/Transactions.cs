namespace FinanceAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
public class Transactions
{
    [Key]
    public int Id {get; set;}  

    public string Description{get; set;} = string.Empty;
    public double Value {get; set;}
    public string Type {get; set;} = string.Empty;
    
    public Transactions (string description, double value, string type)
    {
        Description = description;
        Value = value;
        Type = type;
    }
    protected Transactions(){}
    
}
