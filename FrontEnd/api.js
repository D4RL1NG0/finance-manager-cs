const API_URL = "http://localhost:5296/api/Transactions";

// FUNÇÃO: Buscar e Listar Transações
async function buscarDados(filtro) {
    const container = document.getElementById('resultado');
    if (!container) return;
    
    container.innerHTML = `<p style="text-align:center; color:#888;">Carregando...</p>`;

    try {
        // O timestamp ?t= evita que o navegador mostre dados antigos do cache
        const resposta = await fetch(`${API_URL}?Filter=${filtro}&t=${Date.now()}`);
        const dados = await resposta.json();
        
        if (!dados || dados.length === 0) {
            container.innerHTML = "<p style='text-align:center; padding:20px;'>Nenhuma transação encontrada.</p>";
            return;
        }

        // --- ORDENAÇÃO: Inverte a lista para mostrar os mais recentes no topo ---
        const dadosParaExibir = [...dados].reverse();

        let listaHTML = "";
        dadosParaExibir.forEach(item => {
            // Ajuste de Cor: Agora verificamos por 'deposito', que é como o C# salva
            const tipoOriginal = item.type ? item.type.toLowerCase().trim() : "";
            const isInput = (tipoOriginal === 'deposito' || tipoOriginal === 'in'); 
            
            const classeCor = isInput ? 'val-in' : 'val-out';
            const classeIcone = isInput ? 'icon-in' : 'icon-out';
            const icone = isInput ? '↙' : '↗';
            const sinal = isInput ? '+' : '-';

            listaHTML += `
                <div class="transaction-item">
                    <div class="transaction-icon ${classeIcone}">${icone}</div>
                    <div class="transaction-info" style="flex:1">
                        <span style="font-weight:600; display:block; color:#2d3436">${item.description}</span>
                        <small style="color:#aaa">${isInput ? 'Recebido' : 'Pago'}</small>
                    </div>
                    <div class="transaction-value ${classeCor}">
                        ${sinal} ${item.value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}
                    </div>
                </div>
            `;
        });
        container.innerHTML = listaHTML;
    } catch (e) { 
        console.error("Erro ao carregar lista:", e);
        container.innerHTML = "<p style='text-align:center; color:red'>Erro ao carregar dados.</p>"; 
    }
}

// FUNÇÃO: Buscar Saldo Atualizado
async function verSaldo() {
    const display = document.getElementById('display-saldo');
    if (!display) return;

    try {
        const res = await fetch(`${API_URL}/saldo?t=${Date.now()}`);
        const dados = await res.json();
        const valorTotal = dados.total !== undefined ? dados.total : 0;
        display.innerText = valorTotal.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
    } catch (e) { 
        display.innerText = "R$ 0,00";
    }
}

// FUNÇÃO: Cadastrar Nova Transação
async function cadastrarGasto(tipoBotao) {
    const desc = document.getElementById('desc').value.trim();
    const valorRaw = document.getElementById('valor').value;
    const valor = parseFloat(valorRaw);

    if (!desc || isNaN(valor) || valor <= 0) {
        alert("Preencha a descrição e um valor válido!");
        return;
    }

    // CONVERSÃO CRUCIAL: Seu C# espera "deposito" ou "retirada" para filtrar e somar o saldo
    const tipoParaOBack = (tipoBotao === 'in') ? 'deposito' : 'retirada';

    try {
        const resposta = await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                description: desc, 
                value: valor, 
                type: tipoParaOBack // Enviando o nome que o C# conhece
            })
        });

        if (resposta.ok) {
            alert("✅ Transação salva com sucesso!");
            // Pequeno delay para garantir que o banco persistiu antes de atualizar a tela
            setTimeout(() => {
                window.location.href = "extrato.html";
            }, 150);
        } else {
            const erro = await resposta.json();
            alert("❌ Erro: " + (erro.mensagem || "Falha ao salvar"));
        }
    } catch (e) { 
        alert("🔌 Erro de conexão com a API. Verifique se o servidor está rodando."); 
    }
}