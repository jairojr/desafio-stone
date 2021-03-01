˜
nC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Worker\Models\ClienteViewModel.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Worker  
.  !
Models! '
{ 
public 

class 
ClienteViewModel !
{ 
public		 
string		 
CPF		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
}

 
} Î
oC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Worker\Models\CobrancaViewModel.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Worker  
.  !
Models! '
{ 
public

 

class

 
CobrancaViewModel

 "
{ 
public 
DateTime 
Data 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
CPF 
{ 
get 
;  
set! $
;$ %
}& '
public 
decimal 
Valor 
{ 
get "
;" #
set$ '
;' (
}) *
} 
} ‰
^C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Worker\Program.cs
	namespace		 	
Stone		
 
.		 
	Cobrancas		 
.		 
Worker		  
{

 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. 
ConfigureServices "
(" #
(# $
hostContext$ /
,/ 0
services1 9
)9 :
=>; =
{ 
services 
. 
AddHttpClient *
<* +
ClienteService+ 9
>9 :
(: ;
); <
;< =
services 
. 
AddHttpClient *
<* +
CobrancaService+ :
>: ;
(; <
)< =
;= >
services 
. 
AddHostedService -
<- .
Worker. 4
>4 5
(5 6
)6 7
;7 8
} 
) 
; 
} 
} ˆ
nC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Worker\Services\ClienteService.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Worker  
.  !
Services! )
{ 
public 

class 
ClienteService 
{ 
private 
readonly 

HttpClient #
_httpClient$ /
;/ 0
public 
ClienteService 
( 

HttpClient (

httpClient) 3
,3 4
IConfiguration5 C
configurationD Q
)Q R
{ 	

httpClient 
. 
BaseAddress "
=# $
new% (
Uri) ,
(, -
configuration- :
[: ;
$str; U
]U V
)V W
;W X
_httpClient 
= 

httpClient $
;$ %
} 	
public 
async 
Task 
< 
ResultadoPaginado +
<+ ,
ClienteViewModel, <
>< =
>= >
GetClientes? J
(J K
intK N
paginaO U
,U V
intW Z

quantidade[ e
,e f
CancellationTokeng x
CancellationToken	y Š
)
Š ‹
{ 	
var 
uri 
= 
$" 
/api/Clientes?page= +
{+ ,
pagina, 2
}2 3
&size=3 9
{9 :

quantidade: D
}D E
"E F
;F G
return 
await 
_httpClient $
.$ %
GetFromJsonAsync% 5
<5 6
ResultadoPaginado6 G
<G H
ClienteViewModelH X
>X Y
>Y Z
(Z [
uri[ ^
,^ _
CancellationToken` q
)q r
;r s
} 	
}   
}!! Ï
oC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Worker\Services\CobrancaService.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Worker  
.  !
Services! )
{ 
public 

class 
CobrancaService  
{ 
private 
readonly 

HttpClient #
_httpClient$ /
;/ 0
public 
CobrancaService 
( 

HttpClient )

httpClient* 4
,4 5
IConfiguration6 D
configurationE R
)R S
{ 	

httpClient 
. 
BaseAddress "
=# $
new% (
Uri) ,
(, -
configuration- :
[: ;
$str; V
]V W
)W X
;X Y
_httpClient 
= 

httpClient $
;$ %
} 	
public 
async 
Task 
< 
bool 
> 
InserirCobranca  /
(/ 0
CobrancaViewModel0 A
cobrancaB J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 	
var 
uri 
= 
$" 
/api/cobranca %
"% &
;& '
var 
response 
= 
await  
_httpClient! ,
., -
PostAsJsonAsync- <
(< =
uri= @
,@ A
cobrancaB J
,J K
cancellationTokenL ]
)] ^
;^ _
return 
response 
. 
IsSuccessStatusCode /
;/ 0
} 	
}   
}!! ‡B
]C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Worker\Worker.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Worker  
{ 
public 

class 
Worker 
: 
BackgroundService +
{ 
private 
readonly 
ILogger  
<  !
Worker! '
>' (
_logger) 0
;0 1
private 
readonly 
ClienteService '
clienteService( 6
;6 7
private 
readonly 
CobrancaService (
cobrancaService) 8
;8 9
private 
readonly 
int ,
 intervaloEntreCobrancasEmMinutos =
;= >
private 
readonly 
int #
clientesQuantidadeBusca 4
;4 5
private 
readonly 
int !
delayInicioEmSegundos 2
;2 3
public 
Worker 
( 
ILogger 
< 
Worker $
>$ %
logger& ,
,, -
ClienteService $
clienteService% 3
,3 4
CobrancaService %
cobrancaService& 5
,5 6
IConfiguration $
configuration% 2
)2 3
{ 	
_logger   
=   
logger   
;   
this!! 
.!! 
clienteService!! 
=!!  !
clienteService!!" 0
;!!0 1
this"" 
."" 
cobrancaService""  
=""! "
cobrancaService""# 2
;""2 3
this$$ 
.$$ ,
 intervaloEntreCobrancasEmMinutos$$ 1
=$$2 3
configuration$$4 A
.$$A B
GetValue$$B J
<$$J K
int$$K N
>$$N O
($$O P
$str$$P r
)$$r s
;$$s t
this%% 
.%% #
clientesQuantidadeBusca%% (
=%%) *
configuration%%+ 8
.%%8 9
GetValue%%9 A
<%%A B
int%%B E
>%%E F
(%%F G
$str%%G s
)%%s t
;%%t u
this&& 
.&& !
delayInicioEmSegundos&& &
=&&' (
configuration&&) 6
.&&6 7
GetValue&&7 ?
<&&? @
int&&@ C
>&&C D
(&&D E
$str&&E \
)&&\ ]
;&&] ^
}'' 	
	protected)) 
override)) 
async))  
Task))! %
ExecuteAsync))& 2
())2 3
CancellationToken))3 D
stoppingToken))E R
)))R S
{** 	
_logger++ 
.++ 
LogInformation++ "
(++" #
$str++# W
,++W X!
delayInicioEmSegundos++Y n
)++n o
;++o p
await,, 
Task,, 
.,, 
Delay,, 
(,, 
TimeSpan,, %
.,,% &
FromSeconds,,& 1
(,,1 2!
delayInicioEmSegundos,,2 G
),,G H
),,H I
;,,I J
while-- 
(-- 
!-- 
stoppingToken-- !
.--! "#
IsCancellationRequested--" 9
)--9 :
{.. 
_logger// 
.// 
LogInformation// &
(//& '
$str//' M
,//M N
DateTimeOffset//O ]
.//] ^
Now//^ a
)//a b
;//b c
ConcurrentBag11 
<11 
Task11 "
>11" #
insercoesCobranca11$ 5
=116 7
new118 ;
ConcurrentBag11< I
<11I J
Task11J N
>11N O
(11O P
)11P Q
;11Q R
ResultadoPaginado22 !
<22! "
ClienteViewModel22" 2
>222 3
	listaCpfs224 =
=22> ?
new22@ C
ResultadoPaginado22D U
<22U V
ClienteViewModel22V f
>22f g
(22g h
)22h i
;22i j
int33 
pagina33 
=33 
$num33 
;33 
do44 
{55 
_logger66 
.66 
LogInformation66 *
(66* +
$str66+ m
,66m n
pagina66o u
)66u v
;66v w
	listaCpfs77 
=77 
await77  %
clienteService77& 4
.774 5
GetClientes775 @
(77@ A
pagina77A G
,77G H#
clientesQuantidadeBusca77I `
,77` a
stoppingToken77b o
)77o p
;77p q
foreach88 
(88 
var88  
cliente88! (
in88) +
	listaCpfs88, 5
.885 6
Data886 :
)88: ;
{99 
var:: 
task::  
=::! "%
EnviarCobrancaParaCliente::# <
(::< =
cliente::= D
,::D E
stoppingToken::F S
)::S T
;::T U
insercoesCobranca;; )
.;;) *
Add;;* -
(;;- .
task;;. 2
);;2 3
;;;3 4
}<< 
pagina== 
++== 
;== 
}>> 
while?? 
(?? 
	listaCpfs??  
.??  !
Next??! %
!=??& (
null??) -
)??- .
;??. /
awaitAA 
TaskAA 
.AA 
WhenAllAA "
(AA" #
insercoesCobrancaAA# 4
)AA4 5
;AA5 6
_loggerBB 
.BB 
LogInformationBB &
(BB& '
$strBB' `
,BB` a
insercoesCobrancaBBb s
.BBs t
CountBBt y
)BBy z
;BBz {
_loggerCC 
.CC 
LogInformationCC &
(CC& '
$str	CC' ‰
,
CC‰ Š.
 intervaloEntreCobrancasEmMinutos
CC‹ «
)
CC« ¬
;
CC¬ ­
awaitDD 
TaskDD 
.DD 
DelayDD  
(DD  !
TimeSpanDD! )
.DD) *
FromMinutesDD* 5
(DD5 6,
 intervaloEntreCobrancasEmMinutosDD6 V
)DDV W
)DDW X
;DDX Y
}EE 
}FF 	
privateHH 
asyncHH 
TaskHH %
EnviarCobrancaParaClienteHH 4
(HH4 5
ClienteViewModelHH5 E
clienteHHF M
,HHM N
CancellationTokenHHO `
cancellationTokenHHa r
)HHr s
{II 	
varJJ 
cobrancaJJ 
=JJ 
CobrancaJJ #
.JJ# $
CriarCobrancaJJ$ 1
(JJ1 2
clienteJJ2 9
.JJ9 :
CPFJJ: =
)JJ= >
;JJ> ?
varLL 
cobrancaInserirLL 
=LL  !
newLL" %
CobrancaViewModelLL& 7
(LL7 8
)LL8 9
{MM 
CPFNN 
=NN 
cobrancaNN 
.NN 
CPFNN "
.NN" #
ObterComMascaraNN# 2
(NN2 3
)NN3 4
,NN4 5
DataOO 
=OO 
cobrancaOO 
.OO  
DataOO  $
,OO$ %
ValorPP 
=PP 
cobrancaPP  
.PP  !
ValorPP! &
,PP& '
}QQ 
;QQ 
_loggerSS 
.SS 
LogInformationSS "
(SS" #
$strSS# Y
,SSY Z
clienteSS[ b
.SSb c
CPFSSc f
,SSf g
cobrancaSSh p
.SSp q
ValorSSq v
)SSv w
;SSw x
varUU 
cobrancaInseridaUU  
=UU! "
awaitUU# (
thisUU) -
.UU- .
cobrancaServiceUU. =
.UU= >
InserirCobrancaUU> M
(UUM N
cobrancaInserirUUN ]
,UU] ^
cancellationTokenUU_ p
)UUp q
;UUq r
ifXX 
(XX 
cobrancaInseridaXX  
)XX  !
_loggerYY 
.YY 
LogInformationYY &
(YY& '
$strYY' k
,YYk l
clienteYYm t
.YYt u
CPFYYu x
,YYx y
cobranca	YYz ‚
.
YY‚ ƒ
Valor
YYƒ ˆ
)
YYˆ ‰
;
YY‰ Š
elseZZ 
_logger[[ 
.[[ 
LogError[[  
([[  !
$str[[! _
,[[_ `
cliente[[a h
.[[h i
CPF[[i l
)[[l m
;[[m n
}^^ 	
}__ 
}`` 