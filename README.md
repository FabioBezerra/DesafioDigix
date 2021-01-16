# DesafioDigix

Comecei a codificação do projeto criando primeiramente as respectivas class libraries:

    -Desafio.Api (responsável por fazer a comunicação com o lado cliente e fazer comunicação com outro módulo)
    -Desafio.Domain (responsável pelos domínios do projeto, onde estará o core do projeto)
    -Desafio.Infra.MockedData (responsável pela infraestrutura de acesso a dados)

Lógica e arquitetura utilizadas:

    -Procurei utilizar o design pattern DDD (Domain-driven Design) para facilitar na criação das regras de negócios.
    -Além disso, na minha opnião a utilização do DDD facilita o uso de micro ou mini serviços na API.
    -Também utilizei a arquitetura do tipo repository para o acesso a dados e utilizei a injeção de dependência atravéz do uso de interfaces.
    -A camada de Infra.MockedData não ficou totalmente pronta, mas dei inicio a criação do contexto através de migrations utilizando a metodologia code-first.

Pendências:

    -Não tive tempo para implementar os testes de unidade, mas mesmo assim, criei uma class library para dar inicio aos testes de unidade do domínio.
