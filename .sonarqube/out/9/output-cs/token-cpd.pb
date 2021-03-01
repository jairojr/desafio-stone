Î.
lC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Application\ClienteApplication.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Application $
{ 
public 

class 
ClienteApplication #
:$ %
IClienteApplication& 9
{ 
private 
readonly 
IMapper  
mapper! '
;' (
private 
readonly 
IClienteService (
clienteService) 7
;7 8
private 
readonly &
ClienteViewModelValidation 3

validation4 >
;> ?
public   
ClienteApplication   !
(  ! "
IMapper  " )
mapper  * 0
,  0 1
IClienteService!!" 1
clienteService!!2 @
,!!@ A&
ClienteViewModelValidation""" <

validation""= G
)""G H
{## 	
this$$ 
.$$ 
mapper$$ 
=$$ 
mapper$$  
;$$  !
this%% 
.%% 
clienteService%% 
=%%  !
clienteService%%" 0
;%%0 1
this&& 
.&& 

validation&& 
=&& 

validation&& (
;&&( )
}'' 	
public00 
async00 
Task00 
<00 
ClienteViewModel00 *
>00* +

CriarAsync00, 6
(006 7
ClienteViewModel007 G
clienteViewModel00H X
,00X Y
CancellationToken00Z k
cancellationToken00l }
)00} ~
{11 	
ValidationResult22 
result22 #
=22$ %
this22& *
.22* +

validation22+ 5
.225 6
Validate226 >
(22> ?
clienteViewModel22? O
)22O P
;22P Q
if44 
(44 
!44 
result44 
.44 
IsValid44 
)44  
result55 
.55 
ThrowErrosValidacao55 *
(55* +
)55+ ,
;55, -
var77 
clienteInserido77 
=77  !
await77" '
clienteService77( 6
.776 7

CriarAsync777 A
(77A B
this77B F
.77F G
mapper77G M
.77M N
Map77N Q
<77Q R
Cliente77R Y
>77Y Z
(77Z [
clienteViewModel77[ k
)77k l
,77l m
cancellationToken77n 
)	77 Ä
;
77Ä Å
return99 
this99 
.99 
mapper99 
.99 
Map99 "
<99" #
ClienteViewModel99# 3
>993 4
(994 5
clienteInserido995 D
)99D E
;99E F
}:: 	
publicBB 
asyncBB 
TaskBB 
<BB 
ClienteViewModelBB *
>BB* +
ObterPorCpfAsyncBB, <
(BB< =
longBB= A
cpfBBB E
,BBE F
CancellationTokenBBG X
cancellationTokenBBY j
)BBj k
{CC 	
varDD 
clienteDD 
=DD 
awaitDD 
clienteServiceDD  .
.DD. /
ObterPorCpfAsyncDD/ ?
(DD? @
cpfDD@ C
,DDC D
cancellationTokenDDE V
)DDV W
;DDW X
returnFF 
thisFF 
.FF 
mapperFF 
.FF 
MapFF "
<FF" #
ClienteViewModelFF# 3
>FF3 4
(FF4 5
clienteFF5 <
)FF< =
;FF= >
}GG 	
publicOO 
asyncOO 
TaskOO 
<OO 
ClienteViewModelOO *
>OO* +
ObterPorIdAsyncOO, ;
(OO; <
GuidOO< @
	idClienteOOA J
,OOJ K
CancellationTokenOOL ]
cancellationTokenOO^ o
)OOo p
{PP 	
varQQ 
clienteQQ 
=QQ 
awaitQQ 
clienteServiceQQ  .
.QQ. /
ObterPorIdAsyncQQ/ >
(QQ> ?
	idClienteQQ? H
,QQH I
cancellationTokenQQJ [
)QQ[ \
;QQ\ ]
returnSS 
thisSS 
.SS 
mapperSS 
.SS 
MapSS "
<SS" #
ClienteViewModelSS# 3
>SS3 4
(SS4 5
clienteSS5 <
)SS< =
;SS= >
}TT 	
public]] 
async]] 
Task]] 
<]] 
IEnumerable]] %
<]]% &
ClienteViewModel]]& 6
>]]6 7
>]]7 8
BuscaPaginadaAsync]]9 K
(]]K L
int]]L O
pagina]]P V
,]]V W
int]]X [
tamanho]]\ c
,]]c d
CancellationToken]]e v
cancellationToken	]]w à
)
]]à â
{^^ 	
if__ 
(__ 
pagina__ 
<=__ 
$num__ 
||__ 
tamanho__ &
<=__' )
$num__* +
)__+ ,
throw`` 
new`` 
ValidacaoException`` ,
(``, -
nameof``- 3
(``3 4
	Mensagens``4 =
.``= >
BUSCA_INVALIDA``> L
)``L M
,``M N
	Mensagens``O X
.``X Y
BUSCA_INVALIDA``Y g
)``g h
;``h i
varbb 
resultbb 
=bb 
awaitbb 
thisbb #
.bb# $
clienteServicebb$ 2
.bb2 3
BuscaPaginadaAsyncbb3 E
(bbE F
paginabbF L
,bbL M
tamanhobbN U
,bbU V
cancellationTokenbbW h
)bbh i
;bbi j
returndd 
thisdd 
.dd 
mapperdd 
.dd 
Mapdd "
<dd" #
IEnumerabledd# .
<dd. /
ClienteViewModeldd/ ?
>dd? @
>dd@ A
(ddA B
resultddB H
)ddH I
;ddI J
}ee 	
}ff 
}gg Ω 
jC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Application\Enums\EstadoEnum.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Application $
.$ %
Enums% *
{ 
public 

enum 

EstadoEnum 
{		 
[

 	
Description

	 
(

 
$str

 $
)

$ %
]

% &
NaoInformado 
= 
$num 
, 
[ 	
Description	 
( 
$str 
) 
] 
AC 

,
 
[ 	
Description	 
( 
$str 
) 
]  
AL 

,
 
[ 	
Description	 
( 
$str 
) 
] 
AP 

,
 
[ 	
Description	 
( 
$str 
)  
]  !
AM 

,
 
[ 	
Description	 
( 
$str 
) 
] 
BA 

,
 
[ 	
Description	 
( 
$str 
) 
] 
CE 

,
 
[ 	
Description	 
( 
$str '
)' (
]( )
DF 

,
 
[ 	
Description	 
( 
$str %
)% &
]& '
ES 

,
 
[ 	
Description	 
( 
$str 
) 
] 
GO 

,
 
[ 	
Description	 
( 
$str 
)  
]  !
MA 

,
 
[   	
Description  	 
(   
$str   "
)  " #
]  # $
MT!! 

,!!
 
["" 	
Description""	 
("" 
$str"" )
)"") *
]""* +
MS## 

,##
 
[$$ 	
Description$$	 
($$ 
$str$$ #
)$$# $
]$$$ %
MG%% 

,%%
 
[&& 	
Description&&	 
(&& 
$str&& 
)&& 
]&& 
PA'' 

,''
 
[(( 	
Description((	 
((( 
$str(( 
)(( 
]((  
PB)) 

,))
 
[** 	
Description**	 
(** 
$str** 
)** 
]** 
PR++ 

,++
 
[,, 	
Description,,	 
(,, 
$str,, !
),,! "
],," #
PE-- 

,--
 
[.. 	
Description..	 
(.. 
$str.. 
).. 
].. 
PI// 

,//
 
[00 	
Description00	 
(00 
$str00 %
)00% &
]00& '
RJ11 

,11
 
[22 	
Description22	 
(22 
$str22 *
)22* +
]22+ ,
RN33 

,33
 
[44 	
Description44	 
(44 
$str44 (
)44( )
]44) *
RS55 

,55
 
[66 	
Description66	 
(66 
$str66 
)66  
]66  !
RO77 

,77
 
[88 	
Description88	 
(88 
$str88 
)88 
]88  
RR99 

,99
 
[:: 	
Description::	 
(:: 
$str:: %
)::% &
]::& '
SC;; 

,;;
 
[<< 	
Description<<	 
(<< 
$str<<  
)<<  !
]<<! "
SP== 

,==
 
[>> 	
Description>>	 
(>> 
$str>> 
)>> 
]>>  
SE?? 

,??
 
[@@ 	
Description@@	 
(@@ 
$str@@ 
)@@  
]@@  !
TOAA 

}BB 
}CC í
xC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Application\Interfaces\IClienteApplication.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Application $
.$ %

Interfaces% /
{ 
public 

	interface 
IClienteApplication (
{ 
public 
Task 
< 
ClienteViewModel $
>$ %

CriarAsync& 0
(0 1
ClienteViewModel1 A
clienteB I
,I J
CancellationTokenK \
cancellationToken] n
)n o
;o p
public 
Task 
< 
ClienteViewModel $
>$ %
ObterPorIdAsync& 5
(5 6
Guid6 :
	idCliente; D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
;j k
public$$ 
Task$$ 
<$$ 
ClienteViewModel$$ $
>$$$ %
ObterPorCpfAsync$$& 6
($$6 7
long$$7 ;
cpf$$< ?
,$$? @
CancellationToken$$A R
cancellationToken$$S d
)$$d e
;$$e f
public-- 
Task-- 
<-- 
IEnumerable-- 
<--  
ClienteViewModel--  0
>--0 1
>--1 2
BuscaPaginadaAsync--3 E
(--E F
int--F I
pagina--J P
,--P Q
int--R U
tamanho--V ]
,--] ^
CancellationToken--_ p
cancellationToken	--q Ç
)
--Ç É
;
--É Ñ
}.. 
}// ç
fC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Application\IocExtension.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Application $
{ 
public 

static 
class 
IocExtension $
{ 
public 
static 
IServiceCollection (
ConfigurarIoc) 6
(6 7
this7 ;
IServiceCollection< N
serviceO V
)V W
{ 	
service 
. 
AddSingleton  
(  !
p! "
=># %
new& )
MapperConfiguration* =
(= >
cfg> A
=>B D
{ 
cfg 
. 

AddProfile 
< $
ViewModelToDomainProfile 7
>7 8
(8 9
)9 :
;: ;
cfg 
. 

AddProfile 
< &
DomainToViewModelToProfile 9
>9 :
(: ;
); <
;< =
} 
) 
. 
CreateMapper 
( 
) 
) 
; 
service 
. 
	AddScoped 
< 
IClienteApplication 1
,1 2
ClienteApplication3 E
>E F
(F G
)G H
;H I
service 
. 
	AddScoped 
< 
IClienteService -
,- .
ClienteService/ =
>= >
(> ?
)? @
;@ A
service 
. 
	AddScoped 
< 
IClienteRepository 0
,0 1
ClienteRepository2 C
>C D
(D E
)E F
;F G
service 
. 
	AddScoped 
< #
ClienteInsertValidation 5
>5 6
(6 7
)7 8
;8 9
service 
. 
	AddScoped 
< &
ClienteViewModelValidation 8
>8 9
(9 :
): ;
;; <
return!! 
service!! 
;!! 
}"" 	
}## 
}$$ å	
}C:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Application\Mapping\DomainToViewModelToProfile .cs
	namespace 	
Stone
 
. 
Clientes 
. 
Application $
.$ %
Mapping% ,
{		 
public 

class &
DomainToViewModelToProfile +
:, -
Profile. 5
{ 
public &
DomainToViewModelToProfile )
() *
)* +
{ 	
	CreateMap 
< 
Cliente 
, 
ClienteViewModel /
>/ 0
(0 1
)1 2
. 
	ForMember 
( 
v  
=>! #
v$ %
.% &
CPF& )
,) *
opt+ .
=>/ 1
opt2 5
.5 6
MapFrom6 =
(= >
d> ?
=>@ B
dC D
.D E
CPFE H
.H I
ObterComMascaraI X
(X Y
)Y Z
)Z [
)[ \
;\ ]
} 	
} 
} ¿	
zC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Application\Mapping\ViewModelToDomainProfile.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Application $
.$ %
Mapping% ,
{ 
public 

class $
ViewModelToDomainProfile )
:* +
Profile, 3
{ 
public $
ViewModelToDomainProfile '
(' (
)( )
{ 	
	CreateMap 
< 
ClienteViewModel &
,& '
Cliente( /
>/ 0
(0 1
)1 2
. 
ForCtorParam  
(  !
$str! )
,) *
opt+ .
=>/ 1
opt2 5
.5 6
MapFrom6 =
(= >
src> A
=>B D
EnumExtensionE R
.R S
	ObterEnumS \
<\ ]
Enums] b
.b c

EstadoEnumc m
>m n
(n o
srco r
.r s
Estados y
)y z
)z {
){ |
; 
} 	
} 
} ˇ$
C:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Application\Validation\ClienteViewModelValidation.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Application $
.$ %

Validation% /
{ 
public 

class &
ClienteViewModelValidation +
:, -
AbstractValidator. ?
<? @
ClienteViewModel@ P
>P Q
{ 
public &
ClienteViewModelValidation )
() *
)* +
{ 	
RuleFor 
( 
v 
=> 
v 
. 
Nome 
)  
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
nameof %
(% &
	Mensagens& /
./ 0$
CLIENTE_NOME_OBRIGATORIO0 H
)H I
)I J
. 
WithMessage 
( 
	Mensagens &
.& '$
CLIENTE_NOME_OBRIGATORIO' ?
)? @
;@ A
RuleFor 
( 
v 
=> 
v 
. 
CPF 
) 
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
nameof %
(% &
	Mensagens& /
./ 0#
CLIENTE_CPF_OBRIGATORIO0 G
)G H
)H I
. 
WithMessage 
( 
	Mensagens &
.& '#
CLIENTE_CPF_OBRIGATORIO' >
)> ?
;? @
RuleFor!! 
(!! 
v!! 
=>!! 
v!! 
.!! 
CPF!! 
)!! 
."" 
Must"" 
("" 
c"" 
=>"" 
Cpf"" 
."" 

ValidarCPF"" '
(""' (
c""( )
)"") *
)""* +
.## 
WithErrorCode## 
(## 
nameof## #
(### $
	Mensagens##$ -
.##- . 
CLIENTE_CPF_INVALIDO##. B
)##B C
)##C D
.$$ 
WithMessage$$ 
($$ 
	Mensagens$$ $
.$$$ % 
CLIENTE_CPF_INVALIDO$$% 9
)$$9 :
.%% 
When%% 
(%% 
c%% 
=>%% 
!%% 
string%%  
.%%  !
IsNullOrEmpty%%! .
(%%. /
c%%/ 0
.%%0 1
CPF%%1 4
)%%4 5
)%%5 6
;%%6 7
RuleFor'' 
('' 
v'' 
=>'' 
v'' 
.'' 
Estado'' !
)''! "
.(( 
NotEmpty(( 
((( 
)(( 
.)) 
WithErrorCode)) 
()) 
nameof)) $
())$ %
	Mensagens))% .
.)). /&
CLIENTE_ESTADO_OBRIGATORIO))/ I
)))I J
)))J K
.** 
WithMessage** 
(** 
	Mensagens** %
.**% &&
CLIENTE_ESTADO_OBRIGATORIO**& @
)**@ A
;**A B
RuleFor,, 
(,, 
d,, 
=>,, 
d,, 
.,, 
Estado,, !
),,! "
.-- 
Must-- 
(-- 
EstadoValido-- 
)--  
... 
WithErrorCode.. 
(.. 
nameof.. "
(.." #
	Mensagens..# ,
..., -#
CLIENTE_ESTADO_INVALIDO..- D
)..D E
)..E F
.// 
WithMessage// 
(// 
	Mensagens// #
.//# $#
CLIENTE_ESTADO_INVALIDO//$ ;
)//; <
.00 
When00 
(00 
c00 
=>00 
!00 
string00 
.00  
IsNullOrWhiteSpace00  2
(002 3
c003 4
.004 5
Estado005 ;
)00; <
)00< =
;00= >
}11 	
private33 
bool33 
EstadoValido33 !
(33! "
string33" (
	strEstado33) 2
)332 3
{44 	
var55 
estado55 
=55 
EnumExtension55 &
.55& '
	ObterEnum55' 0
<550 1

EstadoEnum551 ;
>55; <
(55< =
	strEstado55= F
)55F G
;55G H
if77 
(77 
estado77 
==77 

EstadoEnum77 $
.77$ %
NaoInformado77% 1
)771 2
return88 
false88 
;88 
return:: 
true:: 
;:: 
};; 	
}<< 
}== ◊
tC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Application\ViewModel\ClienteViewModel.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Application $
.$ %
	ViewModel% .
{ 
public 

class 
ClienteViewModel !
{		 
public 
string 
Nome 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Estado 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
CPF 
{ 
get 
;  
set! $
;$ %
}& '
} 
} 