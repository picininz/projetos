let perguntaAtual = "";

async function carregarPergunta() {
  const res = await fetch("http://127.0.0.1:5000/pergunta");
  const data = await res.json();

  if (data.jogador) {
    document.getElementById("falaContainer").style.display = "none";
    document.getElementById("botoes").style.display = "none";
    document.querySelector("h1").style.display = "none";
    document.getElementById("pergunta").innerText = "";
    document.getElementById("resultado").innerText = `O jogador é ${data.jogador}`;
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

window.onload = carregarPergunta;
