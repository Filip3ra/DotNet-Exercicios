// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


/*
Tipos de referência armazenam uma referência ao dado na memória. 
Tipos de valor armazena o dado em si na memória. Tendo em mente 
essas duas diferenças, o que você deve levar em conta ao decidir 
usar tipos de valores e de referência em um projeto?


Primeiro iria considerar quais as necessidades específicas do programa, 
tipos de valores são eficientes em termos de performance e uso de 
memória pois os valores são armazenados na própria variável, ocupando 
menos espaço se comparado ao uso de variável por referência, pois 
esses precisam de espaço para as referências também. Mas os tipos 
de referências são mais flexíveis, onde podemos ter várias variáveis 
guardando referência de um mesmo dado, sem necessidade de cópia. 
Por ser um tipo de dado armazenado em heap, a alocação de memória 
dinâmica pode ser uma vantagem interessante também. 

Então se o programa não possui dados que são alterados ou compartilhados 
com muita frequência, tipos de valores podem ser uma boa escolha. 
Por outro lado, se a flexibilidade na manipulação e compartilhamento 
dos dados for essencial ou muito utilizada, tipos de referência 
podem ser uma melhor alternativa.

*/