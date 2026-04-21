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
    public void addTransaction (string description, double value, string type)
    {
        if(value <= 0)
        {
            throw new ArgumentException("Valor da transacao deve ser maior que zero!");
        }

        if(type.ToLower() == "retirada")
        {
            var saldoatual = Balance();
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

            var result = Filter.ToLower().Trim() switch
            {
                "in" => query.Where(t => t.Type == "deposito"),
                "out" => query.Where(t => t.Type == "retirada"),
                _ => query,            
            };

           return result.ToList();
        }
    /* FIM FUNCAO OPCOES DE EXTRATO IN/OUT/ALL */

    /* INICIO FUNCAO BALANCO TOTAL */
    public double Balance()
    {
    
        double entradas = _context.Transactions
        .Where(t => t.Type == "deposito")
        .Sum(t => t.Value);

        double saidas = _context.Transactions
        .Where(t => t.Type == "retirada")
        .Sum(t => t.Value);

        return entradas - saidas;
       
        
    }
    /* FIM FUNCAO BALANCO TOTAL */
}