# DESAFIO - Processamento de Cobrança
O objetivo do desafio é avaliar a capacidade de construir um cenário de processamento de cobrança
baseada em micro serviços. Será levado em conta na avaliação os padrões de projeto aplicados, a
cobertura de testes e a performance da aplicação. A aplicação deve possuir testes unitários, de
integração e de performance.

## API de clientes
Serviço que permite cadastro e consulta de clientes.O Método de cadastro deve receber como
parâmetros: Nome (string), Estado(string), CPF (string), deve validar o CPF e formatá-lo para um
valor numérico, além disso não devem ser aceitos CPFs duplicados ou campos vazios. Persistir os
dados da maneira que desejar. O Método de consulta deve receber como parâmetros um CPF
(string), validar o CPF e realizar a consulta.

## API de cobranças
Serviço que registra uma cobrança para um determinado cliente. A API deve expor um método que
recebe como parâmetros a Data de vencimento, o CPF e o Valor da cobrança. Após validar os
dados, a API deve persistir as cobranças recebidas no MongoDB. A API deve expor um método que
recebe como parâmetro um CPF ou um mês de referência e retorna as cobranças registradas de
acordo com o filtro (CPF Vencimento e valor). Pelo menos um dos filtros é obrigatório.

## Serviço de cálculo de consumo
Serviço que calcula o valor das cobranças do cliente, seu processo consiste em consultar todos os
clientes cadastrados, calcular e registrar as cobranças da maneira mais rápida possível (Usando as
duas APIs construídas nos passos anteriores). O cálculo é feito da seguinte maneira: 2 primeiros
dígitos do CPF concatenados aos 2 últimos dígitos do CPF do cliente. Por exemplo, no CPF
12345678, o valor cobrado será R$ 1278,00.


# Projeto Desenvolvido
[![Build status](https://dev.azure.com/jairojr-desafio-stone/DesafioStone/_apis/build/status/DesafioStone-.NET%20Core%20with%20SonarCloud-CI)](https://dev.azure.com/jairojr-desafio-stone/DesafioStone/_build/latest?definitionId=2)

O Desafio foi desenvolvido criando API Stone.Clientes, API Stone.Cobrancas e um WorkerServices StoneCobrancas que utiliza o domain da Stone.Cobrancas.

A API Stone.Clientes é executada na porta 5000 e o Stone.Cobrancas na porta 5200. 

Dentro do da aplicação Stone.Cobrancas.Worker existe a configuração da url das aplicações de clientes e cobrancas.

Para realizar a execução das aplicações é necessario ter acesso a internet e executar Stone.Clientes.API, Stone.Cobrancas.API e Stone.Cobrancas.Worker.
Ao iniciar o Stone.Cobrancas.Worker, ele irá aguardar 10s para iniciar e então irá utilizar o endpoint da Stone.Clientes "GET /api/Clientes", para buscar clientes e então inserir uma cobrança do Stone.Cobrancas no endpoint "POST /api/Cobranca". 

Após finalizado a inserção de cobranças para todos clientes, o woker aguardará 5 minutos para executar o processo novamente.
As configurações de tempo do worker estão disponíveis para personalização dentro do appsettings de Stone.Cobrancas.Worker.

