let perguntaAtual = "";

// Função para iniciar o jogo
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

async function carregarPergunta() {
  const res = await fetch("http://127.0.0.1:5000/pergunta");
  const data = await res.json();

  if (data.jogador) {
    document.getElementById("falaContainer").style.display = "none";
    document.getElementById("botoes").style.display = "none";
    document.querySelector("h1").style.display = "none";
    document.getElementById("pergunta").innerText = "";
    document.getElementById("resultado").innerText = `O jogador é ${data.jogador}`;
    document.getElementById('jogar-novamente').style.display = 'flex';
  } else if (data.pergunta) {
    perguntaAtual = data.pergunta;
    document.getElementById("botoes").style.display = "flex";
    document.getElementById("pergunta").innerText = perguntaAtual;
  } else {
    document.getElementById("botoes").style.display = "none";
    document.querySelector("h1").style.display = "none";
    document.getElementById("pergunta").innerText = "As respostas foram inconclusivas. Recomeçando...";
    setTimeout(carregarPergunta, 1500);
  }
}

async function responder(resposta) {
  await fetch("http://127.0.0.1:5000/responder", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ pergunta: perguntaAtual, resposta }),
  });
  carregarPergunta();
}

// Iniciar na tela inicial
document.addEventListener('DOMContentLoaded', () => {
    document.querySelector('.tela-inicial').classList.add('ativo');
    document.querySelector('.jogo-container').classList.add('inativo');
});
