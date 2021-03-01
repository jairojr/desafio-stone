Ü'
oC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\CobrancaApplication.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Application %
{ 
public 

class 
CobrancaApplication $
:% & 
ICobrancaApplication' ;
{ 
private 
readonly 
IMapper  
mapper! '
;' (
public 
ICobrancaService 
service  '
{( )
get* -
;- .
}/ 0
private 
readonly '
CobrancaViewModelValidation 4
validationInsert5 E
;E F
private 
readonly -
!BuscarCobrancaViewModelValidation :
buscaValidation; J
;J K
public## 
CobrancaApplication## "
(##" #
IMapper### *
mapper##+ 1
,##1 2
ICobrancaService$$$ 4
service$$5 <
,$$< ='
CobrancaViewModelValidation%%$ ?
insertValidation%%@ P
,%%P Q-
!BuscarCobrancaViewModelValidation&&$ E
buscaValidation&&F U
)''$ %
{(( 	
this)) 
.)) 
mapper)) 
=)) 
mapper))  
;))  !
this** 
.** 
service** 
=** 
service** "
;**" #
this++ 
.++ 
validationInsert++ !
=++" #
insertValidation++$ 4
;++4 5
this,, 
.,, 
buscaValidation,,  
=,,! "
buscaValidation,,# 2
;,,2 3
}-- 	
public55 
async55 
Task55 
<55 
IEnumerable55 %
<55% &
CobrancaViewModel55& 7
>557 8
>558 9
BuscarAsync55: E
(55E F#
BuscarCobrancaViewModel55F ]
buscaViewModel55^ l
,55l m
CancellationToken55n 
cancellationToken
55€ ‘
)
55‘ ’
{66 	
ValidationResult77 
result77 #
=77$ %
this77& *
.77* +
buscaValidation77+ :
.77: ;
Validate77; C
(77C D
buscaViewModel77D R
)77R S
;77S T
if99 
(99 
!99 
result99 
.99 
IsValid99 
)99  
result:: 
.:: 
ThrowErrosValidacao:: *
(::* +
)::+ ,
;::, -
var<< 
buscaDomain<< 
=<< 
this<< "
.<<" #
mapper<<# )
.<<) *
Map<<* -
<<<- .%
BuscarCobrancaValueObject<<. G
><<G H
(<<H I
buscaViewModel<<I W
)<<W X
;<<X Y
var== 
	cobrancas== 
=== 
await== !
this==" &
.==& '
service==' .
.==. /

BuscaAsync==/ 9
(==9 :
buscaDomain==: E
,==E F
cancellationToken==G X
)==X Y
;==Y Z
return?? 
this?? 
.?? 
mapper?? 
.?? 
Map?? "
<??" #
IEnumerable??# .
<??. /
CobrancaViewModel??/ @
>??@ A
>??A B
(??B C
	cobrancas??C L
)??L M
;??M N
}@@ 	
publicHH 
asyncHH 
TaskHH 
<HH 
CobrancaViewModelHH +
>HH+ ,

CriarAsyncHH- 7
(HH7 8
CobrancaViewModelHH8 I
cobrancaVewModelHHJ Z
,HHZ [
CancellationTokenHH\ m
cancellationTokenHHn 
)	HH €
{II 	
ValidationResultJJ 
resultJJ #
=JJ$ %
thisJJ& *
.JJ* +
validationInsertJJ+ ;
.JJ; <
ValidateJJ< D
(JJD E
cobrancaVewModelJJE U
)JJU V
;JJV W
ifLL 
(LL 
!LL 
resultLL 
.LL 
IsValidLL 
)LL  
resultMM 
.MM 
ThrowErrosValidacaoMM *
(MM* +
)MM+ ,
;MM, -
varOO 
cobrancaOO 
=OO 
thisOO 
.OO  
mapperOO  &
.OO& '
MapOO' *
<OO* +
CobrancaOO+ 3
>OO3 4
(OO4 5
cobrancaVewModelOO5 E
)OOE F
;OOF G
varPP 
cobrancaInseridaPP  
=PP! "
awaitPP# (
thisPP) -
.PP- .
servicePP. 5
.PP5 6

CriarAsyncPP6 @
(PP@ A
cobrancaPPA I
,PPI J
cancellationTokenPPK \
)PP\ ]
;PP] ^
returnRR 
thisRR 
.RR 
mapperRR 
.RR 
MapRR "
<RR" #
CobrancaViewModelRR# 4
>RR4 5
(RR5 6
cobrancaInseridaRR6 F
)RRF G
;RRG H
}SS 	
}TT 
}UU ³
{C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\Interfaces\ICobrancaApplication.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Application %
.% &

Interfaces& 0
{		 
public 

	interface  
ICobrancaApplication )
{ 
public 
Task 
< 
CobrancaViewModel %
>% &

CriarAsync' 1
(1 2
CobrancaViewModel2 C
cobrancaD L
,L M
CancellationTokenN _
cancellationToken` q
)q r
;r s
public 
Task 
< 
IEnumerable 
<  
CobrancaViewModel  1
>1 2
>2 3
BuscarAsync4 ?
(? @#
BuscarCobrancaViewModel@ W
buscaX ]
,] ^
CancellationToken_ p
cancellationToken	q ‚
)
‚ ƒ
;
ƒ „
} 
} Ç
hC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\IocExtension.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Application %
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
ICobrancaApplication 2
,2 3
CobrancaApplication4 G
>G H
(H I
)I J
;J K
service 
. 
	AddScoped 
< 
ICobrancaService .
,. /
CobrancaService0 ?
>? @
(@ A
)A B
;B C
service 
. 
	AddScoped 
< 
ICobrancaRepository 1
,1 2
CobrancaRepository3 E
>E F
(F G
)G H
;H I
service 
. 
	AddScoped 
< '
CobrancaViewModelValidation 9
>9 :
(: ;
); <
;< =
service 
. 
	AddScoped 
< -
!BuscarCobrancaViewModelValidation ?
>? @
(@ A
)A B
;B C
service!! 
.!! 
AddSingleton!!  
<!!  !
CobrancaContext!!! 0
>!!0 1
(!!1 2
)!!2 3
;!!3 4
return## 
service## 
;## 
}$$ 	
}%% 
}&& ‘	
C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\Mapping\DomainToViewModelToProfile .cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Application %
.% &
Mapping& -
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
< 
Cobranca 
, 
CobrancaViewModel  1
>1 2
(2 3
)3 4
. 
	ForMember 
( 
v 
=> 
v  !
.! "
CPF" %
,% &
opt' *
=>+ -
opt. 1
.1 2
MapFrom2 9
(9 :
d: ;
=>< >
d? @
.@ A
CPFA D
.D E
ObterComMascaraE T
(T U
)U V
)V W
)W X
;X Y
} 	
} 
} š
|C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\Mapping\ViewModelToDomainProfile.cs
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
 
Application

 %
.

% &
Mapping

& -
{ 
public 

class $
ViewModelToDomainProfile )
:* +
Profile, 3
{ 
public $
ViewModelToDomainProfile '
(' (
)( )
{ 	
	CreateMap 
< 
CobrancaViewModel '
,' (
Cobranca) 1
>1 2
(2 3
)3 4
;4 5
	CreateMap 
< #
BuscarCobrancaViewModel -
,- .%
BuscarCobrancaValueObject/ H
>H I
(I J
)J K
;K L
} 	
} 
} ¹-
ˆC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\Validation\BuscarCobrancaViewModelValidation.cs
	namespace		 	
Stone		
 
.		 
	Cobrancas		 
.		 
Application		 %
.		% &

Validation		& 0
{

 
public 

class -
!BuscarCobrancaViewModelValidation 2
:3 4
AbstractValidator5 F
<F G#
BuscarCobrancaViewModelG ^
>^ _
{ 
public -
!BuscarCobrancaViewModelValidation 0
(0 1
)1 2
{ 	
RuleFor 
( 
v 
=> 
v 
. 
Pagina !
)! "
. 
GreaterThan 
( 
$num 
) 
. 
WithErrorCode 
( 
nameof #
(# $
	Mensagens$ -
.- .!
BUSCA_INVALIDA_PAGINA. C
)C D
)D E
. 
WithMessage 
( 
	Mensagens $
.$ %!
BUSCA_INVALIDA_PAGINA% :
): ;
;; <
RuleFor 
( 
v 
=> 
v 
. 

Quantidade %
)% &
. 
GreaterThan 
( 
$num 
) 
. 
WithErrorCode 
( 
nameof #
(# $
	Mensagens$ -
.- .%
BUSCA_INVALIDA_QUANTIDADE. G
)G H
)H I
. 
WithMessage 
( 
	Mensagens $
.$ %%
BUSCA_INVALIDA_QUANTIDADE% >
)> ?
;? @
RuleFor 
( 
v 
=> 
v 
. 
CPF 
) 
.   
Must   
(   

ValidarCpf   
)   
.!! 
WithErrorCode!! 
(!! 
nameof!! #
(!!# $
	Mensagens!!$ -
.!!- .
BUSCA_CPF_INVALIDO!!. @
)!!@ A
)!!A B
."" 
WithMessage"" 
("" 
	Mensagens"" $
.""$ %
BUSCA_CPF_INVALIDO""% 7
)""7 8
.## 
When## 
(## 
BuscaPorCpf## 
)##  
;##  !
RuleFor%% 
(%% 
v%% 
=>%% 
v%% 
)%% 
.&& 
Must&& 
(&& 
ValidarBusca&&  
)&&  !
.'' 
WithErrorCode'' 
('' 
nameof'' #
(''# $
	Mensagens''$ -
.''- .
BUSCA_INVALIDA''. <
)''< =
)''= >
.(( 
WithMessage(( 
((( 
	Mensagens(( $
.(($ %
BUSCA_INVALIDA((% 3
)((3 4
;((4 5
RuleFor** 
(** 
v** 
=>** 
v** 
.** 
Ano** 
)** 
.++ 
GreaterThan++ 
(++ 
$num++  
)++  !
.,, 
WithErrorCode,, 
(,, 
nameof,, $
(,,$ %
	Mensagens,,% .
.,,. /
BUSCA_INVALIDA_ANO,,/ A
),,A B
),,B C
.-- 
WithMessage-- 
(-- 
	Mensagens-- %
.--% &
BUSCA_INVALIDA_ANO--& 8
)--8 9
... 
When.. 
(.. 
BuscaPorAnoMes.. "
).." #
;..# $
RuleFor00 
(00 
v00 
=>00 
v00 
.00 
Mes00 
)00 
.11 
InclusiveBetween11 
(11  
$num11  !
,11! "
$num11# %
)11% &
.22 
WithErrorCode22 
(22 
nameof22 #
(22# $
	Mensagens22$ -
.22- .
BUSCA_INVALIDA_MES22. @
)22@ A
)22A B
.33 
WithMessage33 
(33 
	Mensagens33 $
.33$ %
BUSCA_INVALIDA_MES33% 7
)337 8
.44 
When44 
(44 
ValidarBusca44  
)44  !
;44! "
}55 	
private77 
bool77 
ValidarBusca77 !
(77! "#
BuscarCobrancaViewModel77" 9
busca77: ?
)77? @
{88 	
return99 
BuscaPorCpf99 
(99 
busca99 $
)99$ %
||99& (
BuscaPorAnoMes99) 7
(997 8
busca998 =
)99= >
;99> ?
}:: 	
private;; 
bool;; 
BuscaPorCpf;;  
(;;  !#
BuscarCobrancaViewModel;;! 8
busca;;9 >
);;> ?
{<< 	
return== 
busca== 
.== 
CPF== 
!=== 
null==  $
;==$ %
}>> 	
private@@ 
bool@@ 
BuscaPorAnoMes@@ #
(@@# $#
BuscarCobrancaViewModel@@$ ;
busca@@< A
)@@A B
{AA 	
returnBB 
(BB 
buscaBB 
.BB 
AnoBB 
.BB 
HasValueBB &
&&BB' )
buscaBB* /
.BB/ 0
MesBB0 3
.BB3 4
HasValueBB4 <
)BB< =
;BB= >
}CC 	
privateEE 
boolEE 

ValidarCpfEE 
(EE  
stringEE  &
cpfStrEE' -
)EE- .
{FF 	
CpfGG 
cpfGG 
=GG 
cpfStrGG 
;GG 
returnHH 
cpfHH 
.HH 
EhValidoHH 
;HH  
}II 	
}JJ 
}KK Ý%
‚C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\Validation\CobrancaViewModelValidation.cs
	namespace		 	
Stone		
 
.		 
	Cobrancas		 
.		 
Application		 %
.		% &

Validation		& 0
{

 
public 

class '
CobrancaViewModelValidation ,
:- .
AbstractValidator/ @
<@ A
CobrancaViewModelA R
>R S
{ 
public '
CobrancaViewModelValidation *
(* +
)+ ,
{ 	
RuleFor 
( 
v 
=> 
v 
. 
Data 
)  
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
nameof %
(% &
	Mensagens& /
./ 0%
COBRANCA_DATA_OBRIGATORIO0 I
)I J
)J K
. 
WithMessage 
( 
	Mensagens &
.& '%
COBRANCA_DATA_OBRIGATORIO' @
)@ A
;A B
RuleFor 
( 
v 
=> 
v 
. 
Data 
.  
Year  $
)$ %
. 
GreaterThan 
( 
$num 
)  
. 
WithErrorCode 
( 
nameof #
(# $
	Mensagens$ -
.- ."
COBRANCA_DATA_INVALIDA. D
)D E
)E F
. 
WithMessage 
( 
	Mensagens $
.$ %"
COBRANCA_DATA_INVALIDA% ;
); <
. 
When 
( 
c 
=> 
c 
. 
Data 
!=  "
DateTime# +
.+ ,
MinValue, 4
)4 5
;5 6
RuleFor   
(   
v   
=>   
v   
.   
CPF   
)   
.!! 
NotEmpty!! 
(!! 
)!! 
."" 
WithErrorCode"" 
("" 
nameof"" %
(""% &
	Mensagens""& /
.""/ 0$
COBRANCA_CPF_OBRIGATORIO""0 H
)""H I
)""I J
.## 
WithMessage## 
(## 
	Mensagens## &
.##& '$
COBRANCA_CPF_OBRIGATORIO##' ?
)##? @
;##@ A
RuleFor%% 
(%% 
v%% 
=>%% 
v%% 
.%% 
CPF%% 
)%% 
.&& 
Must&& 
(&& 
c&& 
=>&& 
Cpf&& 
.&& 

ValidarCPF&& )
(&&) *
c&&* +
)&&+ ,
)&&, -
.'' 
WithErrorCode'' 
('' 
nameof'' %
(''% &
	Mensagens''& /
.''/ 0!
COBRANCA_CPF_INVALIDO''0 E
)''E F
)''F G
.(( 
WithMessage(( 
((( 
	Mensagens(( &
.((& '!
COBRANCA_CPF_INVALIDO((' <
)((< =
.)) 
When)) 
()) 
c)) 
=>)) 
!)) 
string)) "
.))" #
IsNullOrEmpty))# 0
())0 1
c))1 2
.))2 3
CPF))3 6
)))6 7
)))7 8
;))8 9
RuleFor++ 
(++ 
v++ 
=>++ 
v++ 
.++ 
Valor++  
)++  !
.,, 
NotEmpty,, 
(,, 
),, 
.-- 
WithErrorCode-- 
(-- 
nameof-- $
(--$ %
	Mensagens--% .
.--. /&
COBRANCA_VALOR_OBRIGATORIO--/ I
)--I J
)--J K
... 
WithMessage.. 
(.. 
	Mensagens.. %
...% &&
COBRANCA_VALOR_OBRIGATORIO..& @
)..@ A
;..A B
RuleFor00 
(00 
v00 
=>00 
v00 
.00 
Valor00  
)00  !
.11 
GreaterThan11 
(11 
$num11 
)11 
.22 
WithErrorCode22 
(22 
nameof22 $
(22$ %
	Mensagens22% .
.22. /#
COBRANCA_VALOR_INVALIDO22/ F
)22F G
)22G H
.33 
WithMessage33 
(33 
	Mensagens33 %
.33% &#
COBRANCA_VALOR_INVALIDO33& =
)33= >
.44 
When44 
(44 
c44 
=>44 
c44 
.44 
Valor44 !
!=44" $
$num44% &
)44& '
;44' (
}66 	
}77 
}88 ž
}C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\ViewModel\BuscarCobrancaViewModel.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Application %
.% &
	ViewModel& /
{ 
public

 

class

 #
BuscarCobrancaViewModel

 (
{ 
public 
int 
Pagina 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$num* +
;+ ,
public 
int 

Quantidade 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
$num. 0
;0 1
public 
string 
CPF 
{ 
get 
;  
set! $
;$ %
}& '
=( )
null* .
;. /
public 
int 
? 
Ano 
{ 
get 
; 
set "
;" #
}$ %
=& '
null( ,
;, -
public## 
int## 
?## 
Mes## 
{## 
get## 
;## 
set## "
;##" #
}##$ %
=##& '
null##( ,
;##, -
}$$ 
}%% Þ
wC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.Application\ViewModel\CobrancaViewModel.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
Application %
.% &
	ViewModel& /
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
} 