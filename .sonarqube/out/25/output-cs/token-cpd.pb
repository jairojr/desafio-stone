Ý
bC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Data\ClientesContext.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Data 
{		 
public

 

class

 
ClientesContext

  
:

! "
	DbContext

# ,
{ 
public 
ClientesContext 
( 
)  
{ 	
} 	
public 
ClientesContext 
( 
DbContextOptions /
</ 0
ClientesContext0 ?
>? @
optionsA H
)H I
:J K
baseL P
(P Q
optionsQ X
)X Y
{ 	
ChangeTracker 
. !
QueryTrackingBehavior /
=0 1!
QueryTrackingBehavior2 G
.G H

NoTrackingH R
;R S
ChangeTracker 
. $
AutoDetectChangesEnabled 2
=3 4
false5 :
;: ;
} 	
public 
DbSet 
< 
ClienteEntity "
>" #
Clientes$ ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
modelBuilder 
. +
ApplyConfigurationsFromAssembly 8
(8 9
typeof9 ?
(? @
ClientesContext@ O
)O P
.P Q
AssemblyQ Y
)Y Z
;Z [
} 	
} 
} Ï
pC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Data\Mappings\ClienteEntityMapping.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Data 
. 
Mappings &
{ 
internal		 
class		  
ClienteEntityMapping		 '
:		( )$
IEntityTypeConfiguration		* B
<		B C
ClienteEntity		C P
>		P Q
{

 
public 
void 
	Configure 
( 
	Microsoft '
.' (
EntityFrameworkCore( ;
.; <
Metadata< D
.D E
BuildersE M
.M N
EntityTypeBuilderN _
<_ `
ClienteEntity` m
>m n
buildero v
)v w
{ 	
builder 
. 
HasKey 
( 
c 
=> 
c  !
.! "
Id" $
)$ %
;% &
builder 
. 
Property 
( 
e 
=> !
e" #
.# $
Estado$ *
)* +
.+ ,
HasMaxLength, 8
(8 9
$num9 :
): ;
.; <

IsRequired< F
(F G
)G H
;H I
builder 
. 
Property 
( 
e 
=> !
e" #
.# $
CPF$ '
)' (
.( )
HasMaxLength) 5
(5 6
$num6 8
)8 9
.9 :

IsRequired: D
(D E
)E F
;F G
builder 
. 
HasIndex 
( 
c 
=> !
c" #
.# $
CPF$ '
)' (
.( )
IsUnique) 1
(1 2
)2 3
;3 4
} 	
} 
} 
tC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Data\Migrations\20210227213204_Initial.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Data 
. 

Migrations (
{ 
public 

partial 
class 
Initial  
:! "
	Migration# ,
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{		 	
migrationBuilder

 
.

 
CreateTable

 (
(

( )
name 
: 
$str  
,  !
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 8
,8 9
nullable: B
:B C
falseD I
)I J
,J K
Nome 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 <
,< =
nullable> F
:F G
trueH L
)L M
,M N
Estado 
= 
table "
." #
Column# )
<) *
string* 0
>0 1
(1 2
type2 6
:6 7
$str8 >
,> ?
	maxLength@ I
:I J
$numK L
,L M
nullableN V
:V W
falseX ]
)] ^
,^ _
CPF 
= 
table 
.  
Column  &
<& '
long' +
>+ ,
(, -
type- 1
:1 2
$str3 <
,< =
	maxLength> G
:G H
$numI K
,K L
nullableM U
:U V
falseW \
)\ ]
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 2
,2 3
x4 5
=>6 8
x9 :
.: ;
Id; =
)= >
;> ?
} 
) 
; 
migrationBuilder 
. 
CreateIndex (
(( )
name 
: 
$str '
,' (
table 
: 
$str !
,! "
column 
: 
$str 
, 
unique 
: 
true 
) 
; 
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{   	
migrationBuilder!! 
.!! 
	DropTable!! &
(!!& '
name"" 
:"" 
$str""  
)""  !
;""! "
}## 	
}$$ 
}%% ¿
gC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Data\Models\ClienteEntity.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Data 
. 
Models $
{ 
public 

class 
ClienteEntity 
{ 
public		 
Guid		 
Id		 
{		 
get		 
;		 
private		 %
set		& )
;		) *
}		+ ,
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
public 
string 
Estado 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 
long 
CPF 
{ 
get 
; 
private &
set' *
;* +
}, -
public 
ClienteEntity 
( 
) 
{ 	
} 	
public 
ClienteEntity 
( 
Guid !
id" $
,$ %
string& ,
nome- 1
,1 2
string3 9
estado: @
,@ A
longB F
cPFG J
)J K
{ 	
Id 
= 
id 
; 
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
} 	
} 
} Ž7
qC:\Users\jairo\source\repos\DesafioStone\src\Stone.Clientes\Stone.Clientes.Data\Repositories\ClienteRepository.cs
	namespace 	
Stone
 
. 
Clientes 
. 
Data 
. 
Repositories *
{ 
public 

class 
ClienteRepository "
:# $
IClienteRepository% 7
{ 
private 
readonly 
DbSet 
< 
ClienteEntity ,
>, -
clientesContext. =
;= >
private 
readonly 
ClientesContext (
context) 0
;0 1
public 
ClienteRepository  
(  !
ClientesContext! 0
context1 8
)8 9
{ 	
this 
. 
clientesContext  
=! "
context# *
.* +
Clientes+ 3
;3 4
this 
. 
context 
= 
context "
;" #
} 	
public 
async 
Task 
< 
Cliente !
>! "

CriarAsync# -
(- .
Cliente. 5
cliente6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 	
await 
clientesContext !
.! "
AddAsync" *
(* +
new+ .
ClienteEntity/ <
(< =
cliente= D
.D E
IdE G
,G H
clienteI P
.P Q
NomeQ U
,U V
clienteW ^
.^ _
Estado_ e
.e f
ToStringf n
(n o
)o p
,p q
clienter y
.y z
CPFz }
.} ~
ObterApenasNumeros	~ 
(
 ‘
)
‘ ’
)
’ “
,
“ ”
cancellationToken, =
)= >
;> ?
await 
context 
. 
SaveChangesAsync *
(* +
)+ ,
;, -
return 
cliente 
; 
} 	
public!! 
async!! 
Task!! 
<!! 
Cliente!! !
>!!! "
ObterPorCpfAsync!!# 3
(!!3 4
long!!4 8
cpf!!9 <
,!!< =
CancellationToken!!> O
cancellationToken!!P a
)!!a b
{"" 	
var## 
	clienteDb## 
=## 
await## !
this##" &
.##& '
clientesContext##' 6
.##6 7
FirstOrDefaultAsync##7 J
(##J K
c##K L
=>##M O
c##P Q
.##Q R
CPF##R U
==##V X
cpf##Y \
,##\ ]
cancellationToken##^ o
)##o p
;##p q
return%%  
RetornaClienteDomain%% '
(%%' (
	clienteDb%%( 1
)%%1 2
;%%2 3
}&& 	
public(( 
async(( 
Task(( 
<(( 
Cliente(( !
>((! "
ObterPorIdAsync((# 2
(((2 3
Guid((3 7
	idCliente((8 A
,((A B
CancellationToken((C T
cancellationToken((U f
)((f g
{)) 	
var** 
	clienteDb** 
=** 
await** !
this**" &
.**& '
clientesContext**' 6
.**6 7
FirstOrDefaultAsync**7 J
(**J K
c**K L
=>**M O
c**P Q
.**Q R
Id**R T
==**U W
	idCliente**X a
,**a b
cancellationToken**c t
)**t u
;**u v
return++  
RetornaClienteDomain++ '
(++' (
	clienteDb++( 1
)++1 2
;++2 3
},, 	
public.. 
Task.. 
<.. 
bool.. 
>.. (
VerificaSeClienteExisteAsync.. 6
(..6 7
long..7 ;
cpf..< ?
,..? @
CancellationToken..A R
cancellationToken..S d
)..d e
{// 	
return00 
this00 
.00 
clientesContext00 '
.00' (
AnyAsync00( 0
(000 1
c001 2
=>003 5
c006 7
.007 8
CPF008 ;
==00< >
cpf00? B
,00B C
cancellationToken00D U
)00U V
;00V W
}11 	
public33 
async33 
Task33 
<33 
List33 
<33 
Cliente33 &
>33& '
>33' (
BuscaPaginadaAsync33) ;
(33; <
int33< ?
Pagina33@ F
,33F G
int33H K

Quantidade33L V
,33V W
CancellationToken33X i
cancellationToken33j {
)33{ |
{44 	
int55 
skip55 
=55 
(55 
Pagina55 
-55  
$num55! "
)55" #
*55$ %

Quantidade55& 0
;550 1
if66 
(66 
skip66 
<66 
$num66 
)66 
skip77 
=77 
$num77 
;77 
var99 
data99 
=99 
await99 
this99 !
.99! "
clientesContext99" 1
.::  !
OrderBy::! (
(::( )
e::) *
=>::+ -
e::. /
.::/ 0
Id::0 2
)::2 3
.;;  !
Skip;;! %
(;;% &
skip;;& *
);;* +
.<<  !
Take<<! %
(<<% &

Quantidade<<& 0
)<<0 1
.==  !
ToListAsync==! ,
(==, -
cancellationToken==- >
)==> ?
;==? @
return?? 
data?? 
.?? 
Select?? 
(??  
RetornaClienteDomain?? 3
)??3 4
.??4 5
ToList??5 ;
(??; <
)??< =
;??= >
}@@ 	
privateBB 
staticBB 
ClienteBB  
RetornaClienteDomainBB 3
(BB3 4
ClienteEntityBB4 A
	clienteDbBBB K
)BBK L
{CC 	
ifDD 
(DD 
	clienteDbDD 
==DD 
nullDD !
)DD! "
returnEE 
nullEE 
;EE 
returnGG 
newGG 
ClienteGG 
(GG 
	clienteDbGG (
.GG( )
IdGG) +
,GG+ ,
	clienteDbHH, 5
.HH5 6
NomeHH6 :
,HH: ;
(II, -

EstadoEnumII- 7
)II7 8
EnumII8 <
.II< =
ParseII= B
(IIB C
typeofIIC I
(III J

EstadoEnumIIJ T
)IIT U
,IIU V
	clienteDbIIW `
.II` a
EstadoIIa g
)IIg h
,IIh i
	clienteDbJJ, 5
.JJ5 6
CPFJJ6 9
)JJ9 :
;JJ: ;
}KK 	
}LL 
}MM 