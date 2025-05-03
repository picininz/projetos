/**
 * FURIAkinator - Frontend
 * Este arquivo implementa a lógica do cliente para o jogo FURIAkinator.
 * Gerencia a interface do usuário e a comunicação com o backend.
 */

// Variável global para armazenar a pergunta atual
let perguntaAtual = "";

/**
 * Inicia uma nova partida do jogo.
 * Reseta o estado do backend e prepara a interface do usuário.
 */
async function iniciarJogo() {
    // Resetar sessão no backend antes de começar
    await fetch("http://127.0.0.1:5000/reset", { method: "POST" });

    // Restaurar elementos do jogo
    document.querySelector('.tela-inicial').classList.remove('ativo');
    document.querySelector('.tela-inicial').classList.add('inativo');
    document.querySelector('.jogo-container').classList.remove('inativo');
    document.querySelector('.jogo-container').classList.add('ativo');
    document.getElementById('falaContainer').style.display = 'block';
    document.getElementById('botoes').style.display = 'flex';
    document.querySelector('h1').style.display = '';
    document.getElementById('pergunta').innerText = '';
    document.getElementById('resultado').innerText = '';
    document.getElementById('jogar-novamente').style.display = 'none';

    // Iniciar o jogo
    carregarPergunta();
}

/**
 * Carrega a próxima pergunta do backend e atualiza a interface.
 * Se um jogador for adivinhado, exibe o resultado.
 */
async function carregarPergunta() {
    const res = await fetch("http://127.0.0.1:5000/pergunta");
    const data = await res.json();

    if (data.jogador) {
        // Exibe o jogador adivinhado
        document.getElementById("falaContainer").style.display = "none";
        document.getElementById("botoes").style.display = "none";
        document.querySelector("h1").style.display = "none";
        document.getElementById("pergunta").innerText = "";
        document.getElementById("resultado").innerText = `O jogador é ${data.jogador}`;
        document.getElementById('jogar-novamente').style.display = 'flex';
    } else if (data.pergunta) {
        // Exibe a próxima pergunta
        perguntaAtual = data.pergunta;
        document.getElementById("botoes").style.display = "flex";
        document.getElementById("pergunta").innerText = perguntaAtual;
    } else {
        // Reinicia o jogo se as respostas forem inconclusivas
        document.getElementById("botoes").style.display = "none";
        document.querySelector("h1").style.display = "none";
        document.getElementById("pergunta").innerText = "As respostas foram inconclusivas. Recomeçando...";
        setTimeout(carregarPergunta, 1500);
    }
}

/**
 * Envia a resposta do usuário para o backend e carrega a próxima pergunta.
 * @param {string} resposta - Resposta do usuário ("S", "N" ou "NS")
 */
async function responder(resposta) {
    await fetch("http://127.0.0.1:5000/responder", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ pergunta: perguntaAtual, resposta }),
    });
    carregarPergunta();
}

// Inicializa a tela inicial quando o documento é carregado
document.addEventListener('DOMContentLoaded', () => {
    document.querySelector('.tela-inicial').classList.add('ativo');
    document.querySelector('.jogo-container').classList.add('inativo');
});
