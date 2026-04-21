using Microsoft.AspNetCore.Mvc;
using FinanceAPI.Services;
using FinanceAPI.Models;
using System.Numerics;
namespace FinanceAPI.Controllers;


[ApiController]

[Route("api/[controller]")]

public class TransactionsController : ControllerBase
{
    private readonly Finance_Manager _manager;

    public TransactionsController(Finance_Manager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult Listar(string Filter = "all")
    {
        var resultado = _manager.ShowFilteredList(Filter);
        return Ok(resultado);
    }

    [HttpGet("saldo")]
    public IActionResult VerSaldo()
    {
        var saldototal = _manager.Balance();
        return Ok(new{total = saldototal});
    }

    [HttpPost]
    public IActionResult Criar([FromBody]Transactions nova)
    {
        try
        {
            _manager.addTransaction(nova.Description, nova.Value, nova.Type);
            return Ok(new{mensagem = "Transacao salva com sucesso"});
        }
        catch(Exception ex)
        {
            return BadRequest(new{mensagem = ex.Message});
        }
    }
       


}

