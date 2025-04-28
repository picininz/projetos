import pandas as pd

dados = pd.read_csv('perguntas.csv', sep=';')
jogador = None

while not jogador:

    perguntas = list(dados.columns[1:].values)  # Ignora a primeira coluna (Jogador)
    respostas = []
    for pergunta in perguntas:
        respostas.append(dados[pergunta].sum())

    pergunta_rodada = perguntas[respostas.index(max(respostas))]
    resposta_rodada = input(f'{pergunta_rodada} (S: Sim / N: Não / NS: Não Sei): ').strip().upper()

    if resposta_rodada == 'S':
        dados = dados[dados[pergunta_rodada] == 1].drop(columns=[pergunta_rodada])
    elif resposta_rodada == 'N':
        dados = dados[dados[pergunta_rodada] == 0].drop(columns=[pergunta_rodada])
    elif resposta_rodada == 'NS':
        dados = dados.drop(columns=[pergunta_rodada])
    else:
        print('Resposta inválida. Por favor, digite S, N ou NS.')

    if len(dados.index) == 1:
        jogador = dados['Jogador'].values[0]
    elif len(dados.index) == 0:
        print('As respostas foram inconclusivas. Vamos recomeçar!')
        dados = pd.read_csv('perguntas.csv', sep=';')  # <- Corrigido para recarregar direito!

print(f'O jogador é {jogador}')
