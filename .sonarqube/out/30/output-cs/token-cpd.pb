î
dC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Data\CobrancaContext.cs
	namespace

 	
Stone


 
.

 
	Cobrancas

 
.

 
Data

 
{ 
public 

class 
CobrancaContext  
{ 
private 
readonly 
MongoClient $
client% +
;+ ,
private 
readonly 
IMongoDatabase '
database( 0
;0 1
public 
CobrancaContext 
( 
IConfiguration -
configuration. ;
); <
{ 	
var 
url 
= 
new 
MongoUrl "
(" #
configuration# 0
[0 1
$str1 L
]L M
)M N
;N O
this 
. 
client 
= 
new 
MongoClient )
() *
url* -
)- .
;. /
this 
. 
database 
= 
client "
." #
GetDatabase# .
(. /
url/ 2
.2 3
DatabaseName3 ?
)? @
;@ A
} 	
public 
IMongoCollection 
<  
CobrancaEntity  .
>. /
	Cobrancas0 9
{ 	
get 
{ 
return 
database 
.  
GetCollection  -
<- .
CobrancaEntity. <
>< =
(= >
$str> I
)I J
;J K
} 
} 	
public   
async   
Task   
ConfigureMongoIndex   -
(  - .
CancellationToken  . ?
cancellationToken  @ Q
)  Q R
{!! 	
var"" 
indexKeyCpf"" 
="" 
Builders"" &
<""& '
CobrancaEntity""' 5
>""5 6
.""6 7
	IndexKeys""7 @
.""@ A
	Ascending""A J
(""J K
x""K L
=>""M O
x""P Q
.""Q R
CPF""R U
)""U V
;""V W
var## 
indexDataCobranca## !
=##" #
Builders##$ ,
<##, -
CobrancaEntity##- ;
>##; <
.##< =
	IndexKeys##= F
.##F G
	Ascending##G P
(##P Q
x##Q R
=>##S U
x##V W
.##W X
Data##X \
)##\ ]
;##] ^
var%% 
listIndexCobranca%% !
=%%" #
new%%$ '
List%%( ,
<%%, -
CreateIndexModel%%- =
<%%= >
CobrancaEntity%%> L
>%%L M
>%%M N
(%%N O
)%%O P
{&& 
new'' 
CreateIndexModel'' $
<''$ %
CobrancaEntity''% 3
>''3 4
(''4 5
indexKeyCpf''5 @
)''@ A
,''A B
new(( 
CreateIndexModel(( $
<(($ %
CobrancaEntity((% 3
>((3 4
(((4 5
indexDataCobranca((5 F
)((F G
,((G H
})) 
;)) 
await** 
	Cobrancas** 
.** 
Indexes** #
.**# $
CreateManyAsync**$ 3
(**3 4
listIndexCobranca**4 E
,**E F
cancellationToken**G X
:**X Y
cancellationToken**Z k
)**k l
;**l m
}++ 	
},, 
}-- ñ
jC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Data\Models\CobrancaEntity.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Data 
. 
Models %
{ 
public		 

class		 
CobrancaEntity		 
{

 
[ 	
BsonRepresentation	 
( 
BsonType $
.$ %
String% +
)+ ,
], -
public 
Guid 
Id 
{ 
get 
; 
private %
set& )
;) *
}+ ,
public 
DateTime 
Data 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 
long 
CPF 
{ 
get 
; 
private &
set' *
;* +
}, -
public 
decimal 
Valor 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 
CobrancaEntity 
( 
Guid "
id# %
,% &
DateTime' /
data0 4
,4 5
long6 :
cPF; >
,> ?
decimal@ G
valorH M
)M N
{ 	
Id 
= 
id 
; 
Data 
= 
data 
; 
CPF 
= 
cPF 
; 
Valor 
= 
valor 
; 
} 	
} 
} «8
tC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Data\Repositories\CobrancaRepository.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Data 
. 
Repositories +
{ 
public 

class 
CobrancaRepository #
:$ %
ICobrancaRepository& 9
{ 
private 
IMongoCollection  
<  !
CobrancaEntity! /
>/ 0

cobrancaDb1 ;
;; <
public 
CobrancaRepository !
(! "
CobrancaContext" 1
context2 9
)9 :
{ 	
this 
. 

cobrancaDb 
= 
context %
.% &
	Cobrancas& /
;/ 0
} 	
public 
CobrancaContext 
Context &
{' (
get) ,
;, -
}. /
public 
async 
Task 
< 
IEnumerable %
<% &
Cobranca& .
>. /
>/ 0

BuscaAsync1 ;
(; <%
BuscarCobrancaValueObject< U
buscaV [
,[ \
CancellationToken] n
cancellationToken	o €
)
€ 
{ 	
int 
skip 
= 
( 
busca 
. 
Pagina $
-% &
$num' (
)( )
** +
busca, 1
.1 2

Quantidade2 <
;< =
List 
< 
FilterDefinition !
<! "
CobrancaEntity" 0
>0 1
>1 2
filtros3 :
=; <
new= @
ListA E
<E F
FilterDefinitionF V
<V W
CobrancaEntityW e
>e f
>f g
(g h
)h i
;i j
if!! 
(!! 
busca!! 
.!! 
CPF!! 
.!! 
HasValue!! "
)!!" #
{"" 
var## 
cpf## 
=## 
busca## 
.##  
CPF##  #
.### $
Value##$ )
.##) *
ObterApenasNumeros##* <
(##< =
)##= >
;##> ?
filtros$$ 
.$$ 
Add$$ 
($$ 
Builders$$ $
<$$$ %
CobrancaEntity$$% 3
>$$3 4
.$$4 5
Filter$$5 ;
.$$; <
Eq$$< >
($$> ?
x$$? @
=>$$A C
x$$D E
.$$E F
CPF$$F I
,$$I J
cpf$$K N
)$$N O
)$$O P
;$$P Q
}%% 
if'' 
('' 
busca'' 
.'' 
Ano'' 
.'' 
HasValue'' "
)''" #
{(( 
var)) 
dataInicial)) 
=))  !
new))" %
DateTime))& .
()). /
busca))/ 4
.))4 5
Ano))5 8
.))8 9
Value))9 >
,))> ?
busca))@ E
.))E F
Mes))F I
.))I J
Value))J O
,))O P
$num))Q R
)))R S
;))S T
var** 
	dataFinal** 
=** 
dataInicial**  +
.**+ ,
	AddMonths**, 5
(**5 6
$num**6 7
)**7 8
.**8 9
AddMilliseconds**9 H
(**H I
-**I J
$num**J K
)**K L
;**L M
filtros++ 
.++ 
Add++ 
(++ 
Builders++ $
<++$ %
CobrancaEntity++% 3
>++3 4
.++4 5
Filter++5 ;
.++; <
Gte++< ?
(++? @
x++@ A
=>++B D
x++E F
.++F G
Data++G K
,++K L
dataInicial++M X
)++X Y
)++Y Z
;++Z [
filtros,, 
.,, 
Add,, 
(,, 
Builders,, $
<,,$ %
CobrancaEntity,,% 3
>,,3 4
.,,4 5
Filter,,5 ;
.,,; <
Lte,,< ?
(,,? @
x,,@ A
=>,,B D
x,,E F
.,,F G
Data,,G K
,,,K L
	dataFinal,,M V
),,V W
),,W X
;,,X Y
}-- 
var00 
result00 
=00 
await00 
this00 #
.00# $

cobrancaDb00$ .
.00. /
Find00/ 3
(003 4
Builders004 <
<00< =
CobrancaEntity00= K
>00K L
.00L M
Filter00M S
.00S T
And00T W
(00W X
filtros00X _
)00_ `
)00` a
.11( )
Skip11) -
(11- .
skip11. 2
)112 3
.22( )
Limit22) .
(22. /
busca22/ 4
.224 5

Quantidade225 ?
)22? @
.33( )
ToListAsync33) 4
(334 5
cancellationToken335 F
)33F G
;33G H
return55 
result55 
.55 
Select55  
(55  !!
RetornaCobrancaDomain55! 6
)556 7
;557 8
}66 	
private88 
static88 
Cobranca88 !
RetornaCobrancaDomain88  5
(885 6
CobrancaEntity886 D

CobrancaDb88E O
)88O P
{99 	
if:: 
(:: 

CobrancaDb:: 
==:: 
null:: "
)::" #
return;; 
null;; 
;;; 
return== 
new== 
Cobranca== 
(==  

CobrancaDb==  *
.==* +
Id==+ -
,==- .

CobrancaDb==/ 9
.==9 :
Data==: >
,==> ?

CobrancaDb==@ J
.==J K
CPF==K N
.==N O
ToString==O W
(==W X
)==X Y
,==Y Z

CobrancaDb==[ e
.==e f
Valor==f k
)==k l
;==l m
}>> 	
public@@ 
async@@ 
Task@@ 
<@@ 
Cobranca@@ "
>@@" #

CriarAsync@@$ .
(@@. /
Cobranca@@/ 7
cobranca@@8 @
,@@@ A
CancellationToken@@B S
cancellationToken@@T e
)@@e f
{AA 	
varBB 

cobrancaDbBB 
=BB 
newBB  
CobrancaEntityBB! /
(BB/ 0
cobrancaBB0 8
.BB8 9
IdBB9 ;
,BB; <
cobrancaBB= E
.BBE F
DataBBF J
,BBJ K
cobrancaBBL T
.BBT U
CPFBBU X
.BBX Y
ObterApenasNumerosBBY k
(BBk l
)BBl m
,BBm n
cobrancaBBo w
.BBw x
ValorBBx }
)BB} ~
;BB~ 
awaitCC 
thisCC 
.CC 

cobrancaDbCC !
.CC! "
InsertOneAsyncCC" 0
(CC0 1

cobrancaDbCC1 ;
,CC; <
nullCC= A
,CCA B
cancellationTokenCCC T
)CCT U
;CCU V
returnDD 
cobrancaDD 
;DD 
}EE 	
}HH 
}II 