from flask import Flask, request, jsonify
from flask_cors import CORS
import pandas as pd

app = Flask(__name__)
CORS(app)  # Permite o frontend acessar

dados_iniciais = pd.read_csv('backend/perguntas.csv', sep=';')
dados = dados_iniciais.copy()
jogador = None

@app.route("/pergunta", methods=["GET"])
def proxima_pergunta():
    global dados, jogador

    if jogador:
        return jsonify({"jogador": jogador})

    if len(dados.index) == 1:
        jogador = dados['Jogador'].values[0]
        return jsonify({"jogador": jogador})

    if len(dados.index) == 0:
        dados = dados_iniciais.copy()
        return jsonify({"pergunta": None})

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

    if resposta == "S":
        dados = dados[dados[pergunta] == 1].drop(columns=[pergunta])
    elif resposta == "N":
        dados = dados[dados[pergunta] == 0].drop(columns=[pergunta])
    elif resposta == "NS":
        dados = dados.drop(columns=[pergunta])

    return jsonify({"ok": True})

if __name__ == "__main__":
    app.run(debug=True)
