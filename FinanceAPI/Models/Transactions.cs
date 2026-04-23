namespace FinanceAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
public class Transactions
{
    [Key]
    public int Id {get; set;}  

    public string Description{get; set;} = string.Empty;
    public decimal Value {get; set;}
    public TransactionsType Type {get; set;}
    
    public Transactions (string description, decimal value, TransactionsType type)
    {
        Description = description;
        Value = value;
        Type = type;
    }
    protected Transactions(){}
    
}
