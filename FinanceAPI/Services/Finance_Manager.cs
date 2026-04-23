using FinanceAPI.Models;
using FinanceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FinanceAPI.Services;
public class Finance_Manager
{

    private readonly AppDbContext _context;
    public Finance_Manager(AppDbContext context)
    {
        _context = context;
    }
    
    /* INICIO FUNCAO NOVA TRANSACAO */
    public void addTransaction (string description, decimal value, TransactionsType type)
    {
        if(value <= 0)
        {
            throw new ArgumentException("Valor da transacao deve ser maior que zero!");
        }

        if(type == TransactionsType.Retirada)
        {
            decimal saldoatual = Balance();
            if(value > saldoatual)
            {
                throw new ArgumentException("Saldo insuficiente para realizar a retirada!");
            }
        }
        var nova = new Transactions(description, value, type);
        _context.Transactions.Add(nova);
        _context.SaveChanges();
    }
    /* FIM FUNCAO NOVA TRANSACAO */
    /*INICIO FUNCAO REMOVER TRANSACAO*/
    public void removeTransaction(int idInformado)
    {
        var idParaRemover = _context.Transactions.Find(idInformado);

        if(idParaRemover == null)
        {
            throw new ArgumentException("ID Invalido");
        }
        
        _context.Transactions.Remove(idParaRemover);
        _context.SaveChanges();
    }
    /*INICIO FUNCAO REMOVER TRANSACAO*/

    /* INICIO FUNCAO OPCOES DE EXTRATO IN/OUT/ALL */
    public List<Transactions> ShowFilteredList(string Filter)
    {
            var query = _context.Transactions.AsQueryable();

            var result = Filter.ToLower() switch
            {
                "in" => query.Where(t => t.Type == TransactionsType.Deposito),
                "out" => query.Where(t => t.Type == TransactionsType.Retirada),
                _ => query,            
            };

           return result.ToList();
        }
    /* FIM FUNCAO OPCOES DE EXTRATO IN/OUT/ALL */

    /* INICIO FUNCAO BALANCO TOTAL */
    public decimal Balance()
    {
    
        decimal entradas = _context.Transactions
        .Where(t => t.Type == TransactionsType.Deposito)
        .Sum(t => t.Value);

        decimal saidas = _context.Transactions
        .Where(t => t.Type == TransactionsType.Retirada)
        .Sum(t => t.Value);

        return entradas - saidas;
       
        
    }
    /* FIM FUNCAO BALANCO TOTAL */

    /* INICIO FUNCAO ATUALIZAR TRANSACAO */
    public void updateTransaction(int idSearch, string description, decimal value, TransactionsType type)
    {
        var forChange = _context.Transactions.Find(idSearch);
        if(forChange == null){throw new ArgumentException("Essa transacao nao existe");}
        if(value <= 0){throw new ArgumentException("O valor deve ser maior que zero!");}
        
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
    }
    /* INICIO FUNCAO ATUALIZAR TRANSACAO */
}