†
fC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Domain\Models\Cobranca.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Domain  
.  !
Models! '
{ 
public 

class 
Cobranca 
{		 
public

 
Guid

 
Id

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
public 
DateTime 
Data 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 
Cpf 
CPF 
{ 
get 
; 
private %
set& )
;) *
}+ ,
public 
decimal 
Valor 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 
Cobranca 
( 
Guid 
id 
,  
DateTime! )
data* .
,. /
Cpf0 3
cPF4 7
,7 8
decimal9 @
valorA F
)F G
{ 	
Id 
= 
id 
; 
Data 
= 
data 
; 
CPF 
= 
cPF 
; 
Valor 
= 
valor 
; 
} 	
public 
Cobranca 
( 
DateTime  
data! %
,% &
Cpf' *
cPF+ .
,. /
decimal0 7
valor8 =
)= >
:? @
thisA E
(E F
GuidF J
.J K
NewGuidK R
(R S
)S T
,T U
dataV Z
,Z [
cPF\ _
,_ `
valora f
)f g
{ 	
} 	
public 
static 
Cobranca 
CriarCobranca ,
(, -
Cpf- 0
cPF1 4
)4 5
{ 	
return 
CriarCobranca  
(  !
cPF! $
,$ %
DateTime& .
.. /
Now/ 2
)2 3
;3 4
} 	
public   
static   
Cobranca   
CriarCobranca   ,
(  , -
Cpf  - 0
cPF  1 4
,  4 5
DateTime  6 >
data  ? C
)  C D
{!! 	
var"" 
strCpf"" 
="" 
cPF"" 
."" 
ObterComMascara"" ,
("", -
)""- .
;"". /
strCpf$$ 
=$$ 
strCpf$$ 
.$$ 
Remove$$ "
($$" #
$num$$# $
,$$$ %
strCpf$$& ,
.$$, -
Length$$- 3
-$$4 5
$num$$6 7
)$$7 8
;$$8 9
string&& 
valor&& 
=&& 
strCpf&& !
;&&! "
return(( 
new(( 
Cobranca(( 
(((  
data((  $
,(($ %
cPF((& )
,(() *
Convert((+ 2
.((2 3
	ToDecimal((3 <
(((< =
valor((= B
)((B C
)((C D
;((D E
})) 	
}** 
}++ Œ
wC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Domain\Repositories\ICobrancaRepository.cs
	namespace		 	
Stone		
 
.		 
	Cobrancas		 
.		 
Domain		  
.		  !
Repositories		! -
{

 
public 

	interface 
ICobrancaRepository (
{ 
public 
Task 
< 
Cobranca 
> 

CriarAsync (
(( )
Cobranca) 1
cobranca2 :
,: ;
CancellationToken< M
cancellationTokenN _
)_ `
;` a
public 
Task 
< 
IEnumerable 
<  
Cobranca  (
>( )
>) *

BuscaAsync+ 5
(5 6%
BuscarCobrancaValueObject6 O
buscaP U
,U V
CancellationTokenW h
cancellationTokeni z
)z {
;{ |
} 
} ¦
oC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Domain\Services\CobrancaService.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Domain  
.  !
Services! )
{ 
public 

class 
CobrancaService  
:! "
ICobrancaService# 3
{ 
private 
readonly 
ICobrancaRepository ,
cobrancaRepository- ?
;? @
public 
CobrancaService 
( 
ICobrancaRepository 2
cobrancaRepository3 E
)E F
{ 	
this 
. 
cobrancaRepository #
=$ %
cobrancaRepository& 8
;8 9
} 	
public 
Task 
< 
IEnumerable 
<  
Cobranca  (
>( )
>) *

BuscaAsync+ 5
(5 6%
BuscarCobrancaValueObject6 O
buscaP U
,U V
CancellationTokenW h
cancellationTokeni z
)z {
{ 	
return 
cobrancaRepository %
.% &

BuscaAsync& 0
(0 1
busca1 6
,6 7
cancellationToken8 I
)I J
;J K
} 	
public 
async 
Task 
< 
Cobranca "
>" #

CriarAsync$ .
(. /
Cobranca/ 7
cobranca8 @
,@ A
CancellationTokenB S
cancellationTokenT e
)e f
{ 	
return 
await 
cobrancaRepository +
.+ ,

CriarAsync, 6
(6 7
cobranca7 ?
,? @
cancellationTokenA R
)R S
;S T
} 	
}   
}!! þ
pC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Domain\Services\ICobrancaService.cs
	namespace		 	
Stone		
 
.		 
	Cobrancas		 
.		 
Domain		  
.		  !
Services		! )
{

 
public 

	interface 
ICobrancaService %
{ 
public 
Task 
< 
Cobranca 
> 

CriarAsync (
(( )
Cobranca) 1
cobranca2 :
,: ;
CancellationToken< M
cancellationTokenN _
)_ `
;` a
public 
Task 
< 
IEnumerable 
<  
Cobranca  (
>( )
>) *

BuscaAsync+ 5
(5 6%
BuscarCobrancaValueObject6 O
buscaP U
,V W
CancellationTokenX i
cancellationTokenj {
){ |
;| }
} 
} ª
}C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Domain\ValueObjects\BuscarCobrancaValueObject.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Domain  
.  !
ValueObjects! -
{ 
public 

class %
BuscarCobrancaValueObject *
{		 
public

 
int

 
Pagina

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
public 
int 

Quantidade 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Cpf 
? 
CPF 
{ 
get 
; 
set "
;" #
}$ %
public 
int 
? 
Ano 
{ 
get 
; 
set "
;" #
}$ %
public 
int 
? 
Mes 
{ 
get 
; 
set "
;" #
}$ %
public %
BuscarCobrancaValueObject (
(( )
int) ,
Pagina- 3
,3 4
int5 8

Quantidade9 C
,C D
CpfE H
?H I
CPFJ M
=N O
nullP T
,T U
intV Y
?Y Z
Ano[ ^
=_ `
nulla e
,e f
intg j
?j k
Mesl o
=p q
nullr v
)v w
{ 	
this 
. 
Pagina 
= 
Pagina  
;  !
this 
. 

Quantidade 
= 

Quantidade (
;( )
this 
. 
CPF 
= 
CPF 
; 
this 
. 
Ano 
= 
Ano 
; 
this 
. 
Mes 
= 
Mes 
; 
} 	
} 
} 