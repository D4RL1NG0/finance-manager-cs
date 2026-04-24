using FinanceAPI.Models;
using FinanceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Services;
public class FinanceManager
{

    private readonly AppDbContext _context;
    public FinanceManager(AppDbContext context)
    {
        _context = context;
    }
    
    
    public void AddTransaction (string description, decimal value, TransactionsType type)
    {
        using var transaction = _context.Database.BeginTransaction();
        try{
            ValidateValue(value);
            decimal saldoAtual = Balance();
            if(type == TransactionsType.Retirada && value > saldoAtual)
            {
               throw new ArgumentException("Saldo insuficiente para realizar a retirada!");
            }
                var nova = new Transactions(description, value, type);
                _context.Transactions.Add(nova);
                _context.SaveChanges();

                transaction.Commit();
        }
            catch
        {
            transaction.Rollback();
            throw;
        }
    }

       public void RemoveTransaction(int idInformado)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var idParaRemover = _context.Transactions.Find(idInformado);

            if(idParaRemover == null)
            {
                throw new ArgumentException("ID Invalido");
            }

            _context.Transactions.Remove(idParaRemover);
            _context.SaveChanges();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;

        }
       
    }
   
    public List<Transactions> ShowFilteredList(string Filter)
    {
            var query = _context.Transactions;

            var result = (Filter ?? "").ToLower().Trim() switch
            {
                "in" => query.Where(t => t.Type == TransactionsType.Deposito),
                "out" => query.Where(t => t.Type == TransactionsType.Retirada),
                _ => query,            
            };

           return result.ToList();
        }
   
    public decimal Balance()
    {
    
        return _context.Transactions
        .Sum(t => t.Type == TransactionsType.Deposito ? t.Value : -t.Value);
       
    }
   
    public void UpdateTransaction(int idSearch, string description, decimal value, TransactionsType type)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            ValidateValue(value);
            var forChange = _context.Transactions.Find(idSearch);
            if(forChange == null){throw new ArgumentException("Essa transacao nao existe");}
            decimal saldoatual = Balance();

            decimal anulando = forChange.Type == TransactionsType.Deposito ? -forChange.Value : forChange.Value;
            decimal valorfuturo =  type == TransactionsType.Deposito ? value : -value;

            decimal valorfinal = saldoatual+anulando+valorfuturo;

            if(valorfinal < 0 )
            {
                throw new ArgumentException("Saldo insuficiente!");
            }

            forChange.Description = description;
            forChange.Value = value;
            forChange.Type = type;
            _context.SaveChanges();

            transaction.Commit();
        }

        catch
        {
            transaction.Rollback();
            throw;
        }
       
    }

    private void ValidateValue(decimal value)
    {
        if(value <= 0)
        {
            throw new ArgumentException("Valor da transacao deve ser maior que zero!");
        }
    }
   
}