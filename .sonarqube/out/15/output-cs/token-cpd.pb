ı
vC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.API\Configuration\SwaggerConfiguration.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
API 
. 
Configuration +
{ 
internal		 
static		 
class		  
SwaggerConfiguration		 .
{

 
internal 
static 
IServiceCollection *

AddSwagger+ 5
(5 6
this6 :
IServiceCollection; M
servicesN V
,V W
IWebHostEnvironmentX k
envl o
)o p
{ 	
services 
. 
AddSwaggerGen "
(" #
c# $
=>% '
{ 
c 
. 

SwaggerDoc 
( 
$str !
,! "
new 
	Microsoft !
.! "
OpenApi" )
.) *
Models* 0
.0 1
OpenApiInfo1 <
(< =
)= >
{ 
Title 
= 
$str  1
,1 2
Description #
=$ %
$str& `
,` a
Version 
=  !
$str" &
} 
) 
; 
var 
pasta 
= 

AppContext &
.& '
BaseDirectory' 4
;4 5
c 
. 
IncludeXmlComments $
($ %
Path% )
.) *
Combine* 1
(1 2
pasta2 7
,7 8
$str9 R
)R S
)S T
;T U
c 
. 
IncludeXmlComments $
($ %
Path% )
.) *
Combine* 1
(1 2
pasta2 7
,7 8
$str9 Z
)Z [
)[ \
;\ ]
c 
. 
IncludeXmlComments $
($ %
Path% )
.) *
Combine* 1
(1 2
pasta2 7
,7 8
$str9 J
)J K
)K L
;L M
} 
) 
; 
return 
services 
; 
} 	
internal   
static   
IApplicationBuilder   +
UseSwaggerStone  , ;
(  ; <
this  < @
IApplicationBuilder  A T
app  U X
)  X Y
{!! 	$
SwaggerBuilderExtensions"" $
.""$ %

UseSwagger""% /
(""/ 0
app""0 3
)""3 4
.## 
UseSwaggerUI## 
(## 
setup## "
=>### %
{$$ 
setup%% 
.%% 
SwaggerEndpoint%% (
(%%( )
$str%%) C
,%%C D
$str%%E V
)%%V W
;%%W X
}&& 
)&& 
;&& 
return(( 
app(( 
;(( 
})) 	
}** 
}++  1
rC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.API\Controllers\CobrancaController.cs
	namespace		 	
Stone		
 
.		 
	Cobrancas		 
.		 
API		 
.		 
Controllers		 )
{

 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
CobrancaController #
:$ %
ControllerBase& 4
{ 
private 
readonly  
ICobrancaApplication -
cobrancaApplication. A
;A B
public 
CobrancaController !
(! " 
ICobrancaApplication" 6
cobrancaApplication7 J
)J K
{ 	
this 
. 
cobrancaApplication $
=% &
cobrancaApplication' :
;: ;
} 	
[,, 	
HttpPost,,	 
],, 
[-- 	 
ProducesResponseType--	 
(-- 
(-- 
int-- "
)--" #
HttpStatusCode--# 1
.--1 2
Created--2 9
,--9 :
Type--; ?
=--@ A
typeof--B H
(--H I
CobrancaViewModel--I Z
)--Z [
)--[ \
]--\ ]
[.. 	 
ProducesResponseType..	 
(.. 
(.. 
int.. "
).." #
HttpStatusCode..# 1
...1 2

BadRequest..2 <
,..< =
Type..> B
=..C D
typeof..E K
(..K L

ErrorModel..L V
)..V W
)..W X
]..X Y
public// 
async// 
System// 
.// 
	Threading// %
.//% &
Tasks//& +
.//+ ,
Task//, 0
<//0 1
IActionResult//1 >
>//> ?
	PostAsync//@ I
(//I J
CobrancaViewModel//J [
novaCobranca//\ h
,//h i
CancellationToken//j {
cancellationToken	//| ç
)
//ç é
{00 	
var11 
cobranca11 
=11 
await11  
this11! %
.11% &
cobrancaApplication11& 9
.119 :

CriarAsync11: D
(11D E
novaCobranca11E Q
,11Q R
cancellationToken11S d
)11d e
;11e f
return33 
CreatedAtAction33 "
(33" #
nameof33# )
(33) *
Get33* -
)33- .
,33. /
new330 3
{44 
CPF55 
=55 
cobranca55 
.55 
CPF55 "
,55" #
Ano66 
=66 
cobranca66 
.66 
Data66 #
.66# $
Year66$ (
,66( )
Mes77 
=77 
cobranca77 
.77 
Data77 #
.77# $
Month77$ )
,77) *
Pagina88 
=88 
$num88 
,88 

Quantidade99 
=99 
$num99 
,99  
}:: 
,:: 
cobranca:: 
):: 
;:: 
};; 	
[LL 	
HttpGetLL	 
]LL 
[MM 	 
ProducesResponseTypeMM	 
(MM 
(MM 
intMM "
)MM" #
HttpStatusCodeMM# 1
.MM1 2
OKMM2 4
,MM4 5
TypeMM6 :
=MM; <
typeofMM= C
(MMC D
ResultadoPaginadoMMD U
<MMU V
CobrancaViewModelMMV g
>MMg h
)MMh i
)MMi j
]MMj k
[NN 	 
ProducesResponseTypeNN	 
(NN 
(NN 
intNN "
)NN" #
HttpStatusCodeNN# 1
.NN1 2

BadRequestNN2 <
,NN< =
TypeNN> B
=NNC D
typeofNNE K
(NNK L

ErrorModelNNL V
)NNV W
)NNW X
]NNX Y
publicOO 
asyncOO 
SystemOO 
.OO 
	ThreadingOO %
.OO% &
TasksOO& +
.OO+ ,
TaskOO, 0
<OO0 1
IActionResultOO1 >
>OO> ?
GetOO@ C
(OOC D
[OOD E
	FromQueryOOE N
]OON O#
BuscarCobrancaViewModelOOP g
buscaOOh m
,OOm n
CancellationToken	OOo Ä
cancellationToken
OOÅ í
)
OOí ì
{PP 	
varQQ 

resultadosQQ 
=QQ 
awaitQQ "
thisQQ# '
.QQ' (
cobrancaApplicationQQ( ;
.QQ; <
BuscarAsyncQQ< G
(QQG H
buscaQQH M
,QQM N
cancellationTokenQQO `
)QQ` a
;QQa b
varSS 
paginaAtualSS 
=SS 
buscaSS #
.SS# $
PaginaSS$ *
;SS* +
buscaTT 
.TT 
PaginaTT 
++TT 
;TT 
returnVV 
OkVV 
(VV 
newVV 
ResultadoPaginadoVV +
<VV+ ,
CobrancaViewModelVV, =
>VV= >
(VV> ?
)VV? @
{WW 
DataXX 
=XX 

resultadosXX !
.XX! "
ToArrayXX" )
(XX) *
)XX* +
,XX+ ,
SizeYY 
=YY 
buscaYY 
.YY 

QuantidadeYY '
,YY' (
PageZZ 
=ZZ 
paginaAtualZZ "
,ZZ" #
Next[[ 
=[[ 
Url[[ 
.[[ 
Action[[ !
([[! "
nameof[[" (
([[( )
Get[[) ,
)[[, -
,[[- .
new[[/ 2
{\\ 
CPF]] 
=]] 
busca]] 
.]]  
CPF]]  #
,]]# $
Ano^^ 
=^^ 
busca^^ 
.^^  
Ano^^  #
,^^# $
Mes__ 
=__ 
busca__ 
.__  
Mes__  #
,__# $
Pagina`` 
=`` 
busca`` "
.``" #
Pagina``# )
++``) +
,``+ ,

Quantidadeaa 
=aa  
buscaaa! &
.aa& '

Quantidadeaa' 1
,aa1 2
}bb 
)bb 
}cc 
)cc 
;cc 
}dd 	
}ee 
}ff ¯$
vC:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.API\Middleware\ErrorHandlingMiddleware.cs
	namespace		 	
Stone		
 
.		 
	Cobrancas		 
.		 
API		 
.		 

Middleware		 (
{

 
public 

class #
ErrorHandlingMiddleware (
{ 
private 
readonly 
RequestDelegate (
Next) -
;- .
public #
ErrorHandlingMiddleware &
(& '
RequestDelegate' 6
next7 ;
); <
{ 	
Next 
= 
next 
; 
} 	
public!! 
async!! 
Task!! 
Invoke!!  
(!!  !
HttpContext!!! ,
context!!- 4
)!!4 5
{"" 	
try## 
{$$ 
await%% 
Next%% 
(%% 
context%% "
)%%" #
;%%# $
}&& 
catch'' 
('' 
	Exception'' 
ex'' 
)''  
{(( 
await))  
HandleExceptionAsync)) *
())* +
context))+ 2
,))2 3
ex))4 6
)))6 7
;))7 8
}** 
}++ 	
private-- 
Task--  
HandleExceptionAsync-- )
(--) *
HttpContext--* 5
context--6 =
,--= >
	Exception--? H
ex--I K
)--K L
{.. 	
List// 
<// 

ErrorModel// 
>// 
erros// "
=//# $
new//% (
List//) -
<//- .

ErrorModel//. 8
>//8 9
(//9 :
)//: ;
;//; <
HttpStatusCode00 
	errorCode00 $
=00% &
HttpStatusCode00' 5
.005 6
InternalServerError006 I
;00I J
if22 
(22 
ex22 
is22 
ValidacaoException22 (
)22( )
{33 
if44 
(44 
ex44 
is44 &
MultiplaValidacaoException44 4
)444 5
{55 
	errorCode66 
=66 
HttpStatusCode66  .
.66. /

BadRequest66/ 9
;669 :
var77 
multipleErros77 %
=77& '
(77( )&
MultiplaValidacaoException77) C
)77C D
ex77D F
;77F G
foreach88 
(88 
var88  
err88! $
in88% '
multipleErros88( 5
.885 6

Validacoes886 @
)88@ A
{99 
erros:: 
.:: 
Add:: !
(::! "
new::" %

ErrorModel::& 0
(::0 1
err::1 4
.::4 5
Codigo::5 ;
,::; <
err::= @
.::@ A
Mensagem::A I
)::I J
)::J K
;::K L
};; 
}<< 
else== 
{>> 
	errorCode?? 
=?? 
HttpStatusCode??  .
.??. /

BadRequest??/ 9
;??9 :
var@@ 
validationError@@ '
=@@( )
(@@* +
ValidacaoException@@+ =
)@@= >
ex@@> @
;@@@ A
errosAA 
.AA 
AddAA 
(AA 
newAA !

ErrorModelAA" ,
(AA, -
validationErrorAA- <
.AA< =
CodigoAA= C
,AAC D
validationErrorAAE T
.AAT U
MensagemAAU ]
)AA] ^
)AA^ _
;AA_ `
}BB 
}CC 
elseDD 
{EE 
errosFF 
.FF 
AddFF 
(FF 
newFF 

ErrorModelFF (
(FF( )
$strFF) .
,FF. /
$strFF0 C
)FFC D
)FFD E
;FFE F
}GG 
varII 
resultII 
=II 
SystemII 
.II  
TextII  $
.II$ %
JsonII% )
.II) *
JsonSerializerII* 8
.II8 9
	SerializeII9 B
(IIB C
errosIIC H
)IIH I
;III J
contextJJ 
.JJ 
ResponseJJ 
.JJ 
ContentTypeJJ (
=JJ) *
$strJJ+ =
;JJ= >
contextKK 
.KK 
ResponseKK 
.KK 

StatusCodeKK '
=KK( )
(KK* +
intKK+ .
)KK. /
	errorCodeKK/ 8
;KK8 9
returnLL 
contextLL 
.LL 
ResponseLL #
.LL# $

WriteAsyncLL$ .
(LL. /
resultLL/ 5
)LL5 6
;LL6 7
}NN 	
}OO 
}PP æ
[C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.API\Program.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
API 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public!! 
static!! 
IHostBuilder!! "
CreateHostBuilder!!# 4
(!!4 5
string!!5 ;
[!!; <
]!!< =
args!!> B
)!!B C
=>!!D F
Host"" 
.""  
CreateDefaultBuilder"" %
(""% &
args""& *
)""* +
.## $
ConfigureWebHostDefaults## )
(##) *

webBuilder##* 4
=>##5 7
{$$ 

webBuilder%% 
.%% 

UseStartup%% )
<%%) *
Startup%%* 1
>%%1 2
(%%2 3
)%%3 4
;%%4 5
}&& 
)&& 
.'' 
ConfigureServices'' 
(''  
services''  (
=>'') +
{(( 
services)) 
.)) 
AddHostedService)) *
<))* +*
ConfigureMongoDbIndexesService))+ I
>))I J
())J K
)))K L
;))L M
}** 
)** 
;** 
}++ 
},, Ê
{C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.API\Services\ConfigureMongoDbIndexesService.cs
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
 
API

 
.

 
Services

 &
{ 
public 

class *
ConfigureMongoDbIndexesService /
:0 1
IHostedService2 @
{ 
private 
readonly 
CobrancaContext (
cobrancaContext) 8
;8 9
private 
readonly 
ILogger  
<  !*
ConfigureMongoDbIndexesService! ?
>? @
loggerA G
;G H
public *
ConfigureMongoDbIndexesService -
(- .
CobrancaContext. =
cobrancaContext> M
,M N
ILoggerO V
<V W*
ConfigureMongoDbIndexesServiceW u
>u v
loggerw }
)} ~
{ 	
this 
. 
cobrancaContext  
=! "
cobrancaContext# 2
;2 3
this 
. 
logger 
= 
logger  
;  !
} 	
public$$ 
async$$ 
Task$$ 

StartAsync$$ $
($$$ %
CancellationToken$$% 6
cancellationToken$$7 H
)$$H I
{%% 	
logger&& 
.&& 
LogInformation&& !
(&&! "
$str&&" =
)&&= >
;&&> ?
await'' 
cobrancaContext'' !
.''! "
ConfigureMongoIndex''" 5
(''5 6
cancellationToken''6 G
)''G H
;''H I
logger(( 
.(( 
LogInformation(( !
(((! "
$str((" ;
)((; <
;((< =
})) 	
public,, 
Task,, 
	StopAsync,, 
(,, 
CancellationToken,, /
cancellationToken,,0 A
),,A B
=>-- 
Task-- 
.-- 
CompletedTask-- !
;--! "
}.. 
}// ˙
[C:\Users\jairo\source\repos\DesafioStone\src\Stone.Cobrancas\Stone.Cobrancas.API\Startup.cs
	namespace 	
Stone
 
. 
	Cobrancas 
. 
API 
{ 
public 

class 
Startup 
{ 
private 
IConfiguration 
Configuration ,
{- .
get/ 2
;2 3
}4 5
private 
IWebHostEnvironment #
Env$ '
{( )
get* -
;- .
}/ 0
public 
Startup 
( 
IConfiguration %
configuration& 3
,3 4
IWebHostEnvironment5 H
envI L
)L M
{ 	
Configuration 
= 
configuration )
;) *
Env 
= 
env 
; 
}   	
public&& 
void&& 
ConfigureServices&& %
(&&% &
IServiceCollection&&& 8
services&&9 A
)&&A B
{'' 	
services(( 
.(( 
AddControllers(( #
(((# $
)(($ %
;((% &
services** 
.** 

AddSwagger** 
(**  
Env**  #
)**# $
;**$ %
services,, 
.,, 
ConfigurarIoc,, "
(,," #
),,# $
;,,$ %
}-- 	
public44 
void44 
	Configure44 
(44 
IApplicationBuilder44 1
app442 5
,445 6
IWebHostEnvironment447 J
env44K N
)44N O
{55 	
if66 
(66 
env66 
.66 
IsDevelopment66 !
(66! "
)66" #
)66# $
{77 
app88 
.88 %
UseDeveloperExceptionPage88 -
(88- .
)88. /
;88/ 0
}99 
app;; 
.;; 
UseMiddleware;; 
(;; 
typeof;; $
(;;$ %#
ErrorHandlingMiddleware;;% <
);;< =
);;= >
;;;> ?
app== 
.== 
UseSwaggerStone== 
(==  
)==  !
;==! "
app?? 
.?? 

UseRouting?? 
(?? 
)?? 
;?? 
appAA 
.AA 
UseEndpointsAA 
(AA 
	endpointsAA &
=>AA' )
{BB 
	endpointsCC 
.CC 
MapControllersCC (
(CC( )
)CC) *
;CC* +
}DD 
)DD 
;DD 
}EE 	
}GG 
}HH 