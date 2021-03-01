³ 
eC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Domain\Enums\EstadoEnum.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Domain 
.  
Enums  %
{ 
public 

enum 

EstadoEnum 
{ 
[ 	
Description	 
( 
$str $
)$ %
]% &
NaoInformado 
= 
$num 
, 
[		 	
Description			 
(		 
$str		 
)		 
]		 
AC

 

,


 
[ 	
Description	 
( 
$str 
) 
]  
AL 

,
 
[ 	
Description	 
( 
$str 
) 
] 
AP 

,
 
[ 	
Description	 
( 
$str 
)  
]  !
AM 

,
 
[ 	
Description	 
( 
$str 
) 
] 
BA 

,
 
[ 	
Description	 
( 
$str 
) 
] 
CE 

,
 
[ 	
Description	 
( 
$str '
)' (
]( )
DF 

,
 
[ 	
Description	 
( 
$str %
)% &
]& '
ES 

,
 
[ 	
Description	 
( 
$str 
) 
] 
GO 

,
 
[ 	
Description	 
( 
$str 
)  
]  !
MA 

,
 
[ 	
Description	 
( 
$str "
)" #
]# $
MT 

,
 
[ 	
Description	 
( 
$str )
)) *
]* +
MS   

,  
 
[!! 	
Description!!	 
(!! 
$str!! #
)!!# $
]!!$ %
MG"" 

,""
 
[## 	
Description##	 
(## 
$str## 
)## 
]## 
PA$$ 

,$$
 
[%% 	
Description%%	 
(%% 
$str%% 
)%% 
]%%  
PB&& 

,&&
 
['' 	
Description''	 
('' 
$str'' 
)'' 
]'' 
PR(( 

,((
 
[)) 	
Description))	 
()) 
$str)) !
)))! "
]))" #
PE** 

,**
 
[++ 	
Description++	 
(++ 
$str++ 
)++ 
]++ 
PI,, 

,,,
 
[-- 	
Description--	 
(-- 
$str-- %
)--% &
]--& '
RJ.. 

,..
 
[// 	
Description//	 
(// 
$str// *
)//* +
]//+ ,
RN00 

,00
 
[11 	
Description11	 
(11 
$str11 (
)11( )
]11) *
RS22 

,22
 
[33 	
Description33	 
(33 
$str33 
)33  
]33  !
RO44 

,44
 
[55 	
Description55	 
(55 
$str55 
)55 
]55  
RR66 

,66
 
[77 	
Description77	 
(77 
$str77 %
)77% &
]77& '
SC88 

,88
 
[99 	
Description99	 
(99 
$str99  
)99  !
]99! "
SP:: 

,::
 
[;; 	
Description;;	 
(;; 
$str;; 
);; 
];;  
SE<< 

,<<
 
[== 	
Description==	 
(== 
$str== 
)==  
]==  !
TO>> 

}?? 
}@@ ì
cC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Domain\Models\Cliente.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Domain 
.  
Models  &
{ 
public 

class 
Cliente 
{ 
public		 
Guid		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
public

 
string

 
Nome

 
{

 
get

  
;

  !
private

" )
set

* -
;

- .
}

/ 0
public 

EstadoEnum 
Estado  
{! "
get# &
;& '
private( /
set0 3
;3 4
}5 6
public 
Cpf 
CPF 
{ 
get 
; 
private %
set& )
;) *
}+ ,
public 
Cliente 
( 
string 
nome "
," #

EstadoEnum$ .
estado/ 5
,5 6
string7 =
cPF> A
)A B
{ 	
Id 
= 
Guid 
. 
NewGuid 
( 
) 
;  
Nome 
= 
nome 
; 
Estado 
= 
estado 
; 
CPF 
= 
cPF 
; 
} 	
public 
Cliente 
( 
string 
nome "
," #

EstadoEnum$ .
estado/ 5
,5 6
long7 ;
cPF< ?
)? @
:A B
thisC G
(G H
nomeH L
,L M
estadoN T
,T U
cPFV Y
.Y Z
ToStringZ b
(b c
)c d
)d e
{ 	
} 	
public 
Cliente 
( 
Guid 
id 
, 
string  &
nome' +
,+ ,

EstadoEnum- 7
estado8 >
,> ?
string@ F
cPFG J
)J K
{   	
Id!! 
=!! 
id!! 
;!! 
Nome"" 
="" 
nome"" 
;"" 
Estado## 
=## 
estado## 
;## 
CPF$$ 
=$$ 
cPF$$ 
;$$ 
}%% 	
public'' 
Cliente'' 
('' 
Guid'' 
id'' 
,'' 
string''  &
nome''' +
,''+ ,

EstadoEnum''- 7
estado''8 >
,''> ?
long''@ D
cPF''E H
)''H I
:''J K
this''L P
(''P Q
id''Q S
,''S T
nome''U Y
,''Y Z
estado''[ a
,''a b
cPF''c f
.''f g
ToString''g o
(''o p
)''p q
)''q r
{(( 	
})) 	
},, 
}-- ñ
tC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Domain\Repositories\IClienteRepository.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Domain 
.  
Repositories  ,
{		 
public

 

	interface

 
IClienteRepository

 '
{ 
public 
Task 
< 
Cliente 
> 

CriarAsync '
(' (
Cliente( /
cliente0 7
,7 8
CancellationToken9 J
cancellationTokenK \
)\ ]
;] ^
public 
Task 
< 
Cliente 
> 
ObterPorIdAsync ,
(, -
Guid- 1
	idCliente2 ;
,; <
CancellationToken= N
cancellationTokenO `
)` a
;a b
public 
Task 
< 
Cliente 
> 
ObterPorCpfAsync -
(- .
long. 2
cpf3 6
,6 7
CancellationToken8 I
cancellationTokenJ [
)[ \
;\ ]
public 
Task 
< 
bool 
> (
VerificaSeClienteExisteAsync 6
(6 7
long7 ;
cpf< ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
;e f
public 
Task 
< 
List 
< 
Cliente  
>  !
>! "
BuscaPaginadaAsync# 5
(5 6
int6 9
Pagina: @
,@ A
intB E

QuantidadeF P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
;v w
} 
} •#
lC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Domain\Services\ClienteService.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Domain 
.  
Services  (
{ 
public 

class 
ClienteService 
:  !
IClienteService" 1
{ 
private 
readonly 
IClienteRepository +
clienteRepository, =
;= >
private 
readonly #
ClienteInsertValidation 0
validationInsert1 A
;A B
public 
ClienteService 
( 
IClienteRepository 0
clienteRepository1 B
,B C#
ClienteInsertValidationD [

validation\ f
)f g
{ 	
this 
. 
clienteRepository "
=# $
clienteRepository% 6
;6 7
this 
. 
validationInsert !
=" #

validation$ .
;. /
} 	
public 
async 
Task 
< 
Cliente !
>! "

CriarAsync# -
(- .
Cliente. 5
cliente6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 	
ValidationResult 
result #
=$ %
validationInsert& 6
.6 7
Validate7 ?
(? @
cliente@ G
)G H
;H I
if   
(   
!   
result   
.   
IsValid   
)    
result!! 
.!! 
ThrowErrosValidacao!! *
(!!* +
)!!+ ,
;!!, -
return## 
await## 
clienteRepository## *
.##* +

CriarAsync##+ 5
(##5 6
cliente##6 =
,##= >
cancellationToken##? P
)##P Q
;##Q R
}$$ 	
public&& 
async&& 
Task&& 
<&& 
Cliente&& !
>&&! "
ObterPorCpfAsync&&# 3
(&&3 4
long&&4 8
cpfPesquisa&&9 D
,&&D E
CancellationToken&&F W
cancellationToken&&X i
)&&i j
{'' 	
Cpf(( 
cpf(( 
=(( 
cpfPesquisa(( !
.((! "
ToString((" *
(((* +
)((+ ,
;((, -
if** 
(** 
!** 
cpf** 
.** 
EhValido** 
)** 
throw++ 
new++ 
ValidacaoException++ ,
(++, -
nameof++- 3
(++3 4
	Mensagens++4 =
.++= > 
CLIENTE_CPF_INVALIDO++> R
)++R S
,++S T
	Mensagens++U ^
.++^ _ 
CLIENTE_CPF_INVALIDO++_ s
)++s t
;++t u
return-- 
await-- 
clienteRepository-- *
.--* +
ObterPorCpfAsync--+ ;
(--; <
cpfPesquisa--< G
,--G H
cancellationToken--I Z
)--Z [
;--[ \
}.. 	
public00 
async00 
Task00 
<00 
Cliente00 !
>00! "
ObterPorIdAsync00# 2
(002 3
Guid003 7
	idCliente008 A
,00A B
CancellationToken00C T
cancellationToken00U f
)00f g
{11 	
return22 
await22 
clienteRepository22 *
.22* +
ObterPorIdAsync22+ :
(22: ;
	idCliente22; D
,22D E
cancellationToken22F W
)22W X
;22X Y
}33 	
public55 
async55 
Task55 
<55 
IEnumerable55 %
<55% &
Cliente55& -
>55- .
>55. /
BuscaPaginadaAsync550 B
(55B C
int55C F
pagina55G M
,55M N
int55O R

quantidade55S ]
,55] ^
CancellationToken55_ p
cancellationToken	55q ‚
)
55‚ ƒ
{66 	
return77 
await77 
clienteRepository77 *
.77* +
BuscaPaginadaAsync77+ =
(77= >
pagina77> D
,77D E

quantidade77F P
,77P Q
cancellationToken77R c
)77c d
;77d e
}88 	
}99 
}:: Í
mC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Domain\Services\IClienteService.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Domain 
.  
Services  (
{ 
public		 

	interface		 
IClienteService		 $
{

 
public 
Task 
< 
Cliente 
> 

CriarAsync '
(' (
Cliente( /
cliente0 7
,7 8
CancellationToken9 J
cancellationTokenK \
)\ ]
;] ^
public 
Task 
< 
Cliente 
> 
ObterPorIdAsync ,
(, -
Guid- 1
	idCliente2 ;
,; <
CancellationToken= N
cancellationTokenO `
)` a
;a b
public 
Task 
< 
Cliente 
> 
ObterPorCpfAsync -
(- .
long. 2
cpf3 6
,6 7
CancellationToken8 I
cancellationTokenJ [
)[ \
;\ ]
public 
Task 
< 
IEnumerable 
<  
Cliente  '
>' (
>( )
BuscaPaginadaAsync* <
(< =
int= @
paginaA G
,G H
intI L

quantidadeM W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
;} ~
} 
} ›
wC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Domain\Validation\ClienteInsertValidation.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Domain 
.  

Validation  *
{ 
public 

class #
ClienteInsertValidation (
:) *
AbstractValidator+ <
<< =
Cliente= D
>D E
{ 
private 
readonly 
IClienteRepository +
clienteRepository, =
;= >
public #
ClienteInsertValidation &
(& '
IClienteRepository' 9
clienteRepository: K
)K L
{ 	
this 
. 
clienteRepository "
=# $
clienteRepository% 6
;6 7
RuleFor 
( 
d 
=> 
d 
. 
CPF 
) 
. 
Must 
( 
d 
=> 
d 
. 
EhValido "
)" #
. 
WithErrorCode 
( 
nameof "
(" #
	Mensagens# ,
., - 
CLIENTE_CPF_INVALIDO- A
)A B
)B C
. 
WithMessage 
( 
	Mensagens #
.# $ 
CLIENTE_CPF_INVALIDO$ 8
)8 9
;9 :
RuleFor 
( 
d 
=> 
d 
. 
CPF 
) 
. 
	MustAsync 
( 
ValidaSeCpfJaExiste .
). /
. 
WithErrorCode 
( 
nameof %
(% &
	Mensagens& /
./ 0 
CLIENTE_JA_EXISTENTE0 D
)D E
)E F
. 
WithMessage 
( 
	Mensagens &
.& ' 
CLIENTE_JA_EXISTENTE' ;
); <
;< =
}   	
private"" 
async"" 
Task"" 
<"" 
bool"" 
>""  
ValidaSeCpfJaExiste""! 4
(""4 5
CpfExtensions""5 B
.""B C
Cpf""C F
cpf""G J
,""J K
CancellationToken""L ]
cancellationToken""^ o
)""o p
{## 	
return$$ 
!$$ 
($$ 
await$$ 
clienteRepository$$ ,
.$$, -(
VerificaSeClienteExisteAsync$$- I
($$I J
cpf$$J M
.$$M N
ObterApenasNumeros$$N `
($$` a
)$$a b
,$$b c
cancellationToken$$d u
)$$u v
)$$v w
;$$w x
}%% 	
}&& 
}'' 