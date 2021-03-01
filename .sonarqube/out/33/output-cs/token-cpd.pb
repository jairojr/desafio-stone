Ú
tC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.API\Configuration\SwaggerConfiguration.cs
	namespace

 	
Stone


 
.

 
Clientes

 
.

 
API

 
.

 
Configuration

 *
{ 
internal 
static 
class  
SwaggerConfiguration .
{ 
internal 
static 
IServiceCollection *

AddSwagger+ 5
(5 6
this6 :
IServiceCollection; M
servicesN V
,V W
IWebHostEnvironmentX k
envl o
)o p
{ 	
services 
. 
AddSwaggerGen "
(" #
c# $
=>% '
{ 
c 
. 

SwaggerDoc 
( 
$str !
,! "
new 
	Microsoft !
.! "
OpenApi" )
.) *
Models* 0
.0 1
OpenApiInfo1 <
(< =
)= >
{ 
Title 
= 
$str  0
,0 1
Description #
=$ %
$str& X
,X Y
Version 
=  !
$str" &
} 
) 
; 
var 
pasta 
= 

AppContext &
.& '
BaseDirectory' 4
;4 5
c 
. 
IncludeXmlComments $
($ %
Path% )
.) *
Combine* 1
(1 2
pasta2 7
,7 8
$str9 Q
)Q R
)R S
;S T
c 
. 
IncludeXmlComments $
($ %
Path% )
.) *
Combine* 1
(1 2
pasta2 7
,7 8
$str9 Y
)Y Z
)Z [
;[ \
c 
. 
IncludeXmlComments $
($ %
Path% )
.) *
Combine* 1
(1 2
pasta2 7
,7 8
$str9 J
)J K
)K L
;L M
} 
) 
; 
return   
services   
;   
}!! 	
internal## 
static## 
IApplicationBuilder## +
UseSwaggerStone##, ;
(##; <
this##< @
IApplicationBuilder##A T
app##U X
)##X Y
{$$ 	$
SwaggerBuilderExtensions%% $
.%%$ %

UseSwagger%%% /
(%%/ 0
app%%0 3
)%%3 4
.&& 
UseSwaggerUI&& 
(&& 
setup&& "
=>&&# %
{'' 
setup(( 
.(( 
SwaggerEndpoint(( )
((() *
$str((* D
,((D E
$str((F V
)((V W
;((W X
})) 
))) 
;)) 
return++ 
app++ 
;++ 
},, 	
}-- 
}.. â8
pC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.API\Controllers\ClientesController.cs
	namespace

 	
Stone


 
.

 
Clientes

 
.

 
API

 
.

 
Controllers

 (
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
ClientesController #
:$ %
ControllerBase& 4
{ 
private 
readonly 
IClienteApplication ,
clienteApplication- ?
;? @
public 
ClientesController !
(! "
IClienteApplication" 5
clienteApplication6 H
)H I
{ 	
this 
. 
clienteApplication #
=$ %
clienteApplication& 8
;8 9
} 	
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
ClienteViewModel--I Y
)--Y Z
)--Z [
]--[ \
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
ClienteViewModel//J Z
novoCliente//[ f
,//f g
CancellationToken//h y
cancellationToken	//z ã
)
//ã å
{00 	
var11 
cliente11 
=11 
await11 
this11  $
.11$ %
clienteApplication11% 7
.117 8

CriarAsync118 B
(11B C
novoCliente11C N
,11N O
cancellationToken11P a
)11a b
;11b c
Cpf33 
cpf33 
=33 
cliente33 
.33 
CPF33 !
;33! "
return44 
CreatedAtAction44 "
(44" #
nameof44# )
(44) *
Get44* -
)44- .
,44. /
new440 3
{444 5
cpf446 9
=44: ;
cpf44< ?
.44? @
ObterApenasNumeros44@ R
(44R S
)44S T
}44U V
,44V W
cliente44X _
)44_ `
;44` a
}55 	
[AA 	
HttpGetAA	 
(AA 
$strAA 
)AA 
]AA 
[BB 	 
ProducesResponseTypeBB	 
(BB 
(BB 
intBB "
)BB" #
HttpStatusCodeBB# 1
.BB1 2
OKBB2 4
,BB4 5
TypeBB6 :
=BB; <
typeofBB= C
(BBC D
ClienteViewModelBBD T
)BBT U
)BBU V
]BBV W
[CC 	 
ProducesResponseTypeCC	 
(CC 
(CC 
intCC "
)CC" #
HttpStatusCodeCC# 1
.CC1 2

BadRequestCC2 <
,CC< =
TypeCC> B
=CCC D
typeofCCE K
(CCK L

ErrorModelCCL V
)CCV W
)CCW X
]CCX Y
publicDD 
asyncDD 
SystemDD 
.DD 
	ThreadingDD %
.DD% &
TasksDD& +
.DD+ ,
TaskDD, 0
<DD0 1
IActionResultDD1 >
>DD> ?
GetDD@ C
(DDC D
longDDD H
cpfDDI L
,DDL M
CancellationTokenDDN _
cancellationTokenDD` q
)DDq r
{EE 	
varFF 
clienteFF 
=FF 
awaitFF 
thisFF  $
.FF$ %
clienteApplicationFF% 7
.FF7 8
ObterPorCpfAsyncFF8 H
(FFH I
cpfFFI L
,FFL M
cancellationTokenFFN _
)FF_ `
;FF` a
ifHH 
(HH 
clienteHH 
==HH 
nullHH 
)HH  
returnII 
NotFoundII 
(II  
)II  !
;II! "
returnKK 
OkKK 
(KK 
clienteKK 
)KK 
;KK 
}LL 	
[YY 	
HttpGetYY	 
]YY 
[ZZ 	 
ProducesResponseTypeZZ	 
(ZZ 
(ZZ 
intZZ "
)ZZ" #
HttpStatusCodeZZ# 1
.ZZ1 2
OKZZ2 4
,ZZ4 5
TypeZZ6 :
=ZZ; <
typeofZZ= C
(ZZC D
ResultadoPaginadoZZD U
<ZZU V
ClienteViewModelZZV f
>ZZf g
)ZZg h
)ZZh i
]ZZi j
[[[ 	 
ProducesResponseType[[	 
([[ 
([[ 
int[[ "
)[[" #
HttpStatusCode[[# 1
.[[1 2

BadRequest[[2 <
,[[< =
Type[[> B
=[[C D
typeof[[E K
([[K L

ErrorModel[[L V
)[[V W
)[[W X
][[X Y
public\\ 
async\\ 
System\\ 
.\\ 
	Threading\\ %
.\\% &
Tasks\\& +
.\\+ ,
Task\\, 0
<\\0 1
IActionResult\\1 >
>\\> ?
GetLista\\@ H
(\\H I
int\\I L
page\\M Q
,\\Q R
int\\S V
size\\W [
,\\[ \
CancellationToken\\] n
cancellationToken	\\o Ä
)
\\Ä Å
{]] 	
var^^ 

resultados^^ 
=^^ 
await^^ "
this^^# '
.^^' (
clienteApplication^^( :
.^^: ;
BuscaPaginadaAsync^^; M
(^^M N
page^^N R
,^^R S
size^^T X
,^^X Y
cancellationToken^^Z k
)^^k l
;^^l m
return`` 
Ok`` 
(`` 
new`` 
ResultadoPaginado`` +
<``+ ,
ClienteViewModel``, <
>``< =
(``= >
)``> ?
{aa 
Databb 
=bb 

resultadosbb !
.bb! "
ToArraybb" )
(bb) *
)bb* +
,bb+ ,
Sizecc 
=cc 
sizecc 
,cc 
Pagedd 
=dd 
pagedd 
,dd 
Nextee 
=ee 
Urlee 
.ee 
Actionee !
(ee! "
nameofee" (
(ee( )
GetListaee) 1
)ee1 2
,ee2 3
newee4 7
{ee8 9
pageee: >
=ee? @
++eeA C
pageeeC G
,eeG H
sizeeeI M
=eeN O
sizeeeP T
}eeU V
)eeV W
}ff 
)ff 
;ff 
}gg 	
}hh 
}ii ı$
tC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.API\Middleware\ErrorHandlingMiddleware.cs
	namespace		 	
Stone		
 
.		 
Clientes		 
.		 
API		 
.		 

Middleware		 '
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
}PP Ò

YC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.API\Program.cs
	namespace

 	
Stone


 
.

 
Clientes

 
.

 
API

 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host   
.    
CreateDefaultBuilder   %
(  % &
args  & *
)  * +
.!! $
ConfigureWebHostDefaults!! )
(!!) *

webBuilder!!* 4
=>!!5 7
{"" 

webBuilder## 
.## 

UseStartup## )
<##) *
Startup##* 1
>##1 2
(##2 3
)##3 4
;##4 5
}$$ 
)$$ 
;$$ 
}%% 
}&& ¥
YC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.API\Startup.cs
	namespace 	
Stone
 
. 
Clientes 
. 
API 
{ 
public 

class 
Startup 
{ 
private 
IConfiguration 
Configuration ,
{- .
get/ 2
;2 3
}4 5
private 
IWebHostEnvironment #
Env$ '
{( )
get* -
;- .
}/ 0
public 
Startup 
( 
IConfiguration %
configuration& 3
,3 4
IWebHostEnvironment5 H
envI L
)L M
{ 	
Configuration 
= 
configuration )
;) *
Env 
= 
env 
; 
} 	
public%% 
void%% 
ConfigureServices%% %
(%%% &
IServiceCollection%%& 8
services%%9 A
)%%A B
{&& 	
services'' 
.'' 
AddControllers'' #
(''# $
)''$ %
;''% &
services)) 
.)) 

AddSwagger)) 
())  
Env))  #
)))# $
;))$ %
services++ 
.++ 
ConfigurarIoc++ "
(++" #
)++# $
;++$ %
services-- 
.-- 
AddDbContext-- !
<--! "
ClientesContext--" 1
>--1 2
(--2 3
opt--3 6
=>--7 9
opt--: =
.--= >
	UseSqlite--> G
(--G H
Configuration--H U
[--U V
$str	--V Ä
]
--Ä Å
)
--Å Ç
)
--Ç É
;
--É Ñ
}.. 	
public66 
void66 
	Configure66 
(66 
IApplicationBuilder66 1
app662 5
,665 6
IWebHostEnvironment667 J
env66K N
,66N O
ClientesContext66P _
context66` g
)66g h
{77 	
if88 
(88 
env88 
.88 
IsDevelopment88 !
(88! "
)88" #
)88# $
{99 
app:: 
.:: %
UseDeveloperExceptionPage:: -
(::- .
)::. /
;::/ 0
};; 
app== 
.== 
UseMiddleware== 
(== 
typeof== $
(==$ %#
ErrorHandlingMiddleware==% <
)==< =
)=== >
;==> ?
app?? 
.?? 
UseSwaggerStone?? 
(??  
)??  !
;??! "
appAA 
.AA 

UseRoutingAA 
(AA 
)AA 
;AA 
contextCC 
.CC 
DatabaseCC 
.CC 
MigrateCC $
(CC$ %
)CC% &
;CC& '
appEE 
.EE 
UseEndpointsEE 
(EE 
	endpointsEE &
=>EE' )
{FF 
	endpointsGG 
.GG 
MapControllersGG (
(GG( )
)GG) *
;GG* +
}HH 
)HH 
;HH 
}II 	
}KK 
}LL 