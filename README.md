## Loteria Extensível
Mini sistema de Loteria extensível tendo a possíbilidade de adicionar novos jogos: TimeMania, LotoFácil, Sena, Quina ...

## Tecnologias:
- Asp.Net Core
- Angular


## Domínio
Termos e seus significados:
- Jogo: MegaSena, TimeMania, LotoFácil, Quina ...
- APosta: Feita por um jogador
- Volante: Escolha dos valores disponiveis feita pelo jogador
- Resultado: Resultado de um sorteio
- Acerto: Acertos em um jogo e concurso de um jogador
- Concurso: Cada aposta é vinculada a um concurso cujo sorteio ocerrá em um dia pré definido

## Pontos de extensão
Para adicionar um novo Jogo basta implementar a classe abstrata JogoBase e seus dois métodos, ApostaVencedoraTemplate 
(Indica se um Volante (aposta) é vencedor retornando um IAcerto, caso contrário (não é vencedor) retorna null) 
e  ValidarVolanteTemplate (valida se um volante informado pelo jogador é valido).

JogoBase implementa a interface IJogo que tem como objetivo ser o ponto central da abstração no sistema.

Implementar as interfaces:
- IResultado: Resultado de um concurso 
- IVolante: Jogos feito pelo jogador
- IAcerto: Acerto feito pelo jogado
- IResultadoService: Obtém o resultado de um concurso de alguma fonte (arquivo, BD, WebService). 
No caso da Mega Sena o resultado é obtido através da classe MaquinaDeNumerosAleatorios .

