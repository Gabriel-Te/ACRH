## 🏎️ ACRH (Assetto Corsa Real-time Hub)

Monitoramento em tempo real de telemetria automotiva.

## 📖 O que é o projeto?


<img width="1280" height="720" alt="ACRH" src="https://github.com/user-attachments/assets/c1c6d7d4-7c2a-4709-bece-8fa2b3dd5195" />



O ACRH consiste em uma API Backend em C# construída sob os princípios da Clean Architecture e dedicada ao simulador Assetto Corsa. O projeto atua como um hub de conexão WebSocket (SignalR) para o monitoramento em tempo real da telemetria dos veículos (como temperatura de pneus, rpm, e força nos pedais), podendo ser facilmente consumido por dashboards web ou sistemas de análise de dados.

## 🛒 Requerimentos

    Ter o .NET 10.0 instalado.

    Assetto Corsa instalado e rodando no computador.

## ⚙️ Funções

  1- Extração de dados com altíssima performance: lê diretamente da memória física (Shared Memory) do jogo utilizando contextos unsafe e ponteiros, operando com consumo estável de ~32MB de RAM.
  2- Transmissão ao vivo: mapeia e distribui mais de 60 variáveis físicas do veículo via WebSockets (SignalR) com baixíssima latência.
  3- Interface agnóstica: backend totalmente desacoplado, pronto para ser integrado com qualquer aplicação cliente (HTML/JS, React, etc) para renderização dos dados.

## 💿 Instruções para instalação e implementação do projeto

1- Baixe o projeto na aba Code do repositório, ou em um terminal GIT, execute git clone https://github.com/Gabriel-Te/ACHR.git

2- Com o projeto aberto em uma IDE como Visual Studio, compile e execute a solução. A API inicializará o servidor Kestrel e o hub do SignalR na porta configurada (ex: http://localhost:5000).

3- Abra o Assetto Corsa e inicie uma sessão na pista.

4- Conecte sua aplicação front-end (ou o arquivo test.html de exemplo) à rota do /telemetryHub para começar a receber o fluxo de dados em formato JSON em tempo real.
