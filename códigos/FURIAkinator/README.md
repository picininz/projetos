# FURIAkinator - Processo Seletivo FURIA

## 📋 Sobre o Projeto
O FURIAkinator é um jogo de adivinhação desenvolvido como parte do processo seletivo da FURIA. Inspirado no famoso jogo Akinator, este projeto tem como objetivo adivinhar quaisquer jogadores de CS que ja foram do time da FURIA com base em respostas a perguntas específicas.

## 🎮 Funcionalidades
- Interface interativa para responder perguntas sobre jogadores de CS:GO
- Sistema de adivinhação baseado em respostas do usuário
- Banco de dados de jogadores e perguntas relacionadas
- Interface amigável e responsiva

## 🛠️ Tecnologias Utilizadas
### Frontend
- HTML5
- CSS3
- JavaScript (Vanilla)

### Backend
- Python
- Flask (Framework web)
- CSV para armazenamento de dados

## 📁 Estrutura do Projeto
```
FURIAkinator/
├── frontend/
│   ├── img/           # Imagens utilizadas no projeto
│   ├── index.html     # Página principal
│   └── script.js      # Lógica do frontend
└── backend/
    ├── app.py         # Servidor Flask
    └── perguntas.csv  # Banco de dados de perguntas e jogadores
```

## 🚀 Como Executar o Projeto

### Pré-requisitos
- Python 3.x
- Flask, Flask_cors e pandas
- Navegador web moderno

### Instalação
1. Clone o repositório
2. Instale as dependências do Python:
   ```bash
   pip install pandas flask flask_cors
   ```

### Executando
1. Inicie o servidor backend:
   ```bash
   cd backend
   python app.py
   ```
2. Abra o arquivo `frontend/index.html` em seu navegador

## 🎯 Como Jogar
1. Pense em um jogador de CS do Time da furia
2. Responda as perguntas com "Sim" , "Não" ou "Não Sei"
3. O sistema tentará adivinhar o jogador com base em suas respostas

## 🤝 Contribuindo
Este projeto foi desenvolvido como parte do processo seletivo da FURIA. 

