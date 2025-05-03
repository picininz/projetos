"""
FURIAkinator - Backend
O servidor gerencia o fluxo do jogo, processa respostas e mantém o estado do jogo.
"""

from flask import Flask, request, jsonify
from flask_cors import CORS
import pandas as pd

# Inicialização do aplicativo Flask
app = Flask(__name__)
CORS(app)  # Permite requisições cross-origin do frontend

# Carrega o banco de dados inicial de perguntas e jogadores
dados_iniciais = pd.read_csv('backend/perguntas.csv', sep=';')
dados = dados_iniciais.copy()  # Cópia para manipulação durante o jogo
jogador = None  # Armazena o jogador adivinhado

@app.route("/pergunta", methods=["GET"])
def proxima_pergunta():
    global dados, jogador

    # Se já adivinhou o jogador, retorna ele
    if jogador:
        return jsonify({"jogador": jogador})

    # Se só resta um jogador possível, retorna ele
    if len(dados.index) == 1:
        jogador = dados['Jogador'].values[0]
        return jsonify({"jogador": jogador})

    # Se não há mais jogadores possíveis, reinicia o jogo
    if len(dados.index) == 0:
        dados = dados_iniciais.copy()
        return jsonify({"pergunta": None})

    # Seleciona a próxima pergunta com base na que elimina mais opções
    perguntas = list(dados.columns[1:])
    respostas = [dados[pergunta].sum() for pergunta in perguntas]
    pergunta_rodada = perguntas[respostas.index(max(respostas))]

    return jsonify({"pergunta": pergunta_rodada})

@app.route("/responder", methods=["POST"])
def receber_resposta():
    global dados
    data = request.json
    pergunta = data["pergunta"]
    resposta = data["resposta"]

    # Filtra os jogadores com base na resposta
    if resposta == "S":
        dados = dados[dados[pergunta] == 1].drop(columns=[pergunta])
    elif resposta == "N":
        dados = dados[dados[pergunta] == 0].drop(columns=[pergunta])
    elif resposta == "NS":
        dados = dados.drop(columns=[pergunta])

    return jsonify({"ok": True})

@app.route("/reset", methods=["POST"])
def resetar_jogo():
    global dados, jogador
    dados = dados_iniciais.copy()
    jogador = None
    return jsonify({"ok": True})

if __name__ == "__main__":
    app.run(debug=True)
