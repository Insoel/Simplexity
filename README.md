# Simplexity
### Feito por:
#### - Caetano Lourenço   - A21704076
#### - Ianis Arquissandas - A21700021


###### [Repositório Git - https://github.com/Insoel/Simplexity](https://github.com/Insoel/Simplexity)



###### Conteúdos feitos por quem:


| Lista	    	   |   Ianis  | Caetano
| -------------- | -------- | --------
| Programação    |     X    | 
| -------------- | -------- | --------
| Doxygen	       |	   X    |
| -------------- | -------- | --------
| Diagrama UML	 |	        |    X
| -------------- | -------- | --------
| Markdown	     |	   X    |    X
| -------------- | -------- | --------
| Github Commits |	   X    |
| -------------- | -------- | --------
| Fluxograma	   |	        |    X



###### Descrição da solução:

O Programa começa por inicializar as classes todas e por explicar ao utilizador as regras do jogo.
Pergunta depois se o jogador está pronto para começar, se sim entra para o main gameloop, se não faz exit do programa.
Dentro do gameloop é renderizado a grid, determinada qual a próxima jogada e qual é o próximo jogador.

Na classe Grid, criamos um array 7 por 7 onde colocamos todas as nossas posições, sendo todas inicializadas como Undecided.
Depois caso uma posição seja ocupada por um jogador passa para o State W ou R.

Ao adicionar um State a uma posição chama também um método para trocar o jogador que vai jogar aseguir.

Quando a função para colocar a posição é invocada, é verificado se a última linha da coluna desejada já está ocupada, 
se sim o método torna-se recursivo e vai-se repetindo até encontrar um espaço vazio na coluna escolhida.

Na classe State temos uma enumeração que define qual é o State das posições.

Na classe Position usamos para criar dois valores para podermos passar esses números para a grid.

Na classe Winchecker temos muitos ciclos for que verificar a grid toda de varias maneiras a verificar se há condição de vitoria ou empate.

Na classe Renderer criamos uma grid com | e -, e dentro dos quadrados colocamos o valor dos State para indicar ao utilizador as posições.

Na classe Player indicamos quantos jogadores existem.


##### Diagrama UML e Fluxograma

![Fluxograma](https://i.gyazo.com/e28037a7a5a7d4e75882e5cffec39c15.png)
![UML](https://i.gyazo.com/9e05b1b1f39f2d47411bd9211d5d6d06.png)


###### Conclusões:

Aprendemos a trabalhar um pouco com métodos recursivos e como implementá-los corretamente sem causar stack overflow, 
aprofundamos também conhecimentos de como usar as classes e a sua organização.



###### Referências: 
Usamos como referência base o tal jogo do galo apresentado nas aulas, fomos alterando a estrutura base até termos algo funcional 
Falamos também com vários colegas sobre como eles implementaram certas classes deles, como por exemplo o exercício resolvido pelo Rui em que verificar as condições de vitoria.
