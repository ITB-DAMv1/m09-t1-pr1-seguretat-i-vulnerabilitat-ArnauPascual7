[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/S9WTUTwx)

# Exercicis

## 1. L’organització OWASP Foundation va actualitzar en 2021 el seu Top 10 de vulnerabilitats més trobades en aplicacions web. 

### Escull 3 vulnerabilitats d’aquesta llista i descriu-les. Escriu l’impacte que tenen a la seguretat i quins danys pot arribar a fer un atac en aquesta vulnerabilitat. Enumera diferents mesures i tècniques per poder evitar-les.

---

**A06:2021 – Components vulnerables i desactualitzats**: Aquesta vulnerabilitat són tots aquells components que podríen ser vulnerbales sense saber-ho, o que no estanm en una versió actual.

**Alguns dels impactes que pot tenir en la seguretat són**:
- Com que un component està desactualitzat és molt probable que ja existeixi un mètode per a explotar-ho.
- Al haber vulnerabilitats visibles un atacant pot injectar i executar codi arbitrari dins del sistema.
- L'ús de components vulnerables permet el robatori de dades i la modificació d'informació.
- Regulacions com RGPD, PCI-DSS o ISO 27001 requereixen mantenir el programari actualitzat per garantir la seguretat de les dades.

**Els danys que pot causar són**: Filtració de dades, Control remot del sistema, Distribució de malware o ransomware, i Fallades crítiques en aplicacions.

**Mesures per evitar-ho**:
- Eliminar tot el que no sigui necessari, com dependències, funcionalitats o documentació.
- Realitzar un inventari continu de les versions dels components y de les seves depnedències.
- Només utilitzar components que provinguin de fonts oficials a través d'enllaços segurs.
- Supervisar les biblioteques i els components que no siguin mantinguts o no generin "parches" de seguretat per a versions anteriors

---

**A07:2021 – Falles d'identificació i autenticació**: Aquesta vulnerabilitat és sobre la identitat, l'autenticació y la gestió de les sessións de l'usuari.

**Alguns dels impactes que pot tenir en la seguretat són**:
- Explotant una vulnerabilitat un atacant podría accedir a comptes d'usuari sense les credencials.
- Podría ser que un usuari amb privilegis baixos tingui accés a comptes amb privilegis superiors com el compte d'administrador.
- Un atacant es pot fer passar per un usuari.

**Els danys que pot causar són**: Fitració de dades, Modificació o destrucció de dades, Fraus i enganys, Desprestigi i pèrdua de confiança, i Multes i sancions legals

**Mesures per evitar-ho**:
- Implementar l'autenticació de múltiple factor, per a evitar diferents tipus d'atacs com el de força bruta o els automàtitzats.
- No utilitzar softwares que proporcionin credencials per defecte.
- Implementar un control de contrasenyes dèbils.
- Implementar una política de contrasenyes moderna, basada en evidències.
- Assegurarse que mitjançant missatges genèrics en totes les sortides els resgistres, la recuperació de credencials y les APIs, no permetin els atacs d'enumeració d'usuaris.
- Limitar o incrementar el temps d'espera entre intents erronis, i registrar totes les fallades.
- Utilitzar un generador d'id aleatori después d'iniciar sessió a través d'un gestor de sessions al servidor.

---

**A09:2021 – Falles al Registre i Monitorització**: Aquesta vulnerabilitat tracte, com el títol indica sobre les fallades en el regsitres i monitorització de seguretat.

**Alguns dels impactes que pot tenir en la seguretat són**:
- Si un registre no és adequat els atacs poden passar desapercebuts.
- Si no hi ha evidències clares és molt més complicat investigar i mitigar un atac en curs.
- Normatives com el RGPD, PCI-DSS i ISO 27001 requereixen registres de seguretat i monitorització per protegir dades sensibles.
- Al no haber un registre adequat podría haber algú dins de la xarxa sense ser detectat, extraient informació o realitzant moviments laterals.

**Els danys que pot causar són**: Filtració de dades, Execució de codi maliciós sense detecció, Accions fraudulentes sense rastre, i Impacte econòmic i reputacional.

**Mesures per evitar-ho**:
- Asegurar-se que tots els errors relacionats amb l'inici de sessió i la validació per part del servidor s'estan registrant amb suficient informació.
- Assegurar-se que els registres es generin en un format fàcil de processar.
- Assegurar-se que les dades dels regsitres són codificades correctament.
- Establir un pla de resposta i recuperació.

## 2. Obre el següent enllaç ([sql inseckten](https://www.sql-insekten.de)) i realitza un mínim de 7 nivells fent servir tècniques d’injecció SQL.

### Copia cada una de les sentències SQL resultant que has realitzat a cada nivell i comenta que has aconseguit.

El primer nivell primer has de iniciar sessió com a l'usuari jane, i posar una contrasenya qualsevol per a poder continuar. Un cop ho has fet ara pot utilitzar ***jane'--*** per a passar el nivell, això permet entrar com a l'usuari jane sense saber la seva contrasenya, ja que el AND que junta amb la condició de la contrasenya està ara comentat.

El segon nivell la solució és ***';drop table users;--***, això inicia com a l'usuari per defecte i acaba la comanda, però després d'aquesta afegim una altre comanda per a eliminar la taula d'usuaris, també comentem la part de la contrasenya com en el nivell anterior.

En el tercer nivell iniciem sessió sense saber el nom de cap usuari, així que amb això podrem iniciar sessió ***a' or true--***, l'usuari pot ser qualsevol, però la part important és la del OR, que afegim un true per a que deixi entrar sempre i amb qualsevol usuari, encara que no existeixi.

El quart nivell ens demanda fer el mateix que en el tercer, però aquesta vegada només pot retornar un resultat, així que afegim un limit al final per a que limiti la consulta a un resultat, ***a' or true limit 1--***.

En el cinquè nivell al igual que en el primer hem de fer una primera cerca amb Nicke, un cop ho haguem fet podrem resoldre el nivell amb ***';select user_id, username, password, email from users;--***, això ens mostra la llista d'usuaris en comptes de la de sabates, ja que la consulta de la de sabates l'hem acabat i no hi ha cap resultat que s'assembli a la cerca, mentre que també hem creat una nova consulta a la taula d'usuaris. En aquest exercici no et permet utilitzar el SELECT *, encara que retorna el mateix resultat.

En el nivell sis volem veure el salari de Greta Maria, per a passar aquest nivell hem de fer ***';select salary as username from staff where firstname = 'Greta Maria'--***, amb aquesta comanda acabem la primera consulta igual que en el nivell anterior i fem una altre a la taula d'staff per a veure el salary de Greta maria, també utilitzem un AS per a canviar el nom de salary a username per a poder iniciar sessió.

El nivell set demana veure alguna informació de la taula staff, però aquesta vegada ja no es pot utilitzar el ; per a acabar comandes, així que utilitzem el union per a unir comandes. Al unir les comandes hem de fer que el tipus de dades de cada columna coincideixin, ***' union select employed_since, name, email, salary from staff--***.

### Enumera i raona diferents formes que pot evitar un atac per SQL injection en projectes fets amb Razor Pages i Entity Framework. 

---

Una de les formes per a evitar-ho és utilitzar el Prepared Statement al fer una consulta, per a afegir els paràmetres després de crear la consulta, en comptes d'afegir-los en el string de la consulta:

Segur:
```
string name = txtName.Text;
sqlCommand.CommandText = "select * from product where name = @name";
sqlCommand.Parameters.AddWithValue("name", name);
```
No segur:
```
string name = txtName.Text;
sqlCommand.CommandText = "select * from product where name = " + name;
```

---

En Entity Framework es pot utilitzar LINQ per a evitar la concatenació de consultes.

Segur:
```
var usuari = await _context.Usuaris
    .FirstOrDefaultAsync(u => u.NomUsuari == inputUsuari);
```
No segur:
```
var query = $"SELECT * FROM Usuaris WHERE NomUsuari = '{inputUsuari}'";
var usuari = _context.Usuaris.FromSqlRaw(query).ToList();
```

---

Es pot utilitzar *FromSqlInterpolated* que protejeix contra SQL Injection en assegurar que els paràmetres es tractin com a valors literals.

Segur:
```
var usuari = _context.Usuaris
    .FromSqlInterpolated($"SELECT * FROM Usuaris WHERE NomUsuari = {inputUsuari}")
    .FirstOrDefault();
```
No segur:
```
var query = $"SELECT * FROM Usuaris WHERE NomUsuari = '{inputUsuari}'";
var usuari = _context.Usuaris.FromSqlRaw(query).FirstOrDefault();
```

---

També es possible validar les dades que són introduïdes a trvés de la classe.

Segur:
```
[BindProperty]
[Required]
[StringLength(50, MinimumLength = 3)]
public string NomUsuari { get; set; }
```
No segur:
```
[BindProperty]
public string NomUsuari { get; set; }
```

---

Utilitzant un DbContext també és possible evitar la injecció directe, en comptes d’executar SQL directament, s’ha d’utilitzar el model de dades de Entity Framework per assegurar consultes segures i prevenir manipulacions SQL.

Segur:
```
var usuari = await _context.Usuaris
    .Where(u => u.NomUsuari == inputUsuari)
    .FirstOrDefaultAsync();
```
No segur:
```
var command = $"DELETE FROM Usuaris WHERE NomUsuari = '{inputUsuari}'";
_context.Database.ExecuteSqlRaw(command);
```

---

Per a evitar que usuaris no autoritzats puguin accedir a dades sensibles es pot implementar una Autenticació i Autorització segura.

Segur:
```
[Authorize(Roles = "Admin")]
public class AdministracioModel : PageModel { }
```
No segur:
```
public class AdministracioModel : PageModel { }
```

---

També és possible monitoritzar els registres de logs per a detectar injeccions SQL per a poder respondre ràpidament en el cas de que ocureixi una.

Segur:
```
try
{
    var usuari = await _context.Usuaris.FirstOrDefaultAsync(u => u.NomUsuari == inputUsuari);
}
catch (Exception ex)
{
    _logger.LogError($"Error en la consulta SQL: {ex.Message}");
}
```
No segur:
```
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

## 3. L’empresa a la qual treballes desenvoluparà una aplicació web de venda d’obres d’art. Els artistes registren les seves obres amb fotografies, títol, descripció i preu.  Els clients poden comprar les obres i poden escriure ressenyes públiques dels artistes a qui han comprat. Tant clients com artistes han d’estar registrats. L’aplicació guarda nom, cognoms, adreça completa, dni i telèfon. En el cas dels artistes guarda les dades bancaries per fer els pagaments. Hi ha un tipus d’usuari Acount Manager que s’encarrega de verificar als nous artistes. Un cop aprovats poden publicar i vendre les seves obres.

Artista: fotografies, títol, descripció i preu.
Client i Artista: nom, cognoms, adreça completa, dni i telèfon. Artista: dades bancaries.
Acount Manager: Verifica Artistes.

#### Ara es vol aplicar aplicant els principis  de seguretat per tal de garantir el servei i la integritat de les dades. T’han encarregat l'elaboració de part de les polítiques de seguretat. Elabora els següents apartats:
1. Definició del control d’accés: enumera els rols  i quin accés a dades tenen cada rol.

    Hi ha tres rols principals:
    - Clients: Tenen accés al catàleg de obres d'art i al seu perfil d'usuari. Els clients podrán comprar i escriure resenyes de les obres d'art a través d'aquest catàleg.
    - Artistes: Tenen els mateixos privilegis que els Clients, però s'els hi afegix el poder publicar obres d'art i vendre-les, només si un Acount Manager o autoritza. Els artistes tembé guarden el seu compte bancari.
    - Acount Manager: No s'explica gairé d'aquest usuari, com que no diu que sigui un andministrador, sino que només és un genstor de comptes, llavor només té els mateixos privilegis que un Client, però també pot gestionar els comptes de Clients i Artistes, així com aprovar les solicituds de publicament de les obres dels artistes.
    - Adminstrador?: Podría haber un quart rol de adminstrador que si qui tingui tots els privilegis de tota l'aplicació.

2. Definició de la política de contrasenyes: normes de creació, d’ús i canvi de contrasenyes. Raona si són necessàries diferents polítiques segons el perfil d’usuari.

    Totes les de tots els usuaris contrasenyes han de tenir una complexitat mínima, de 12 caràcters com a mínim, mínim de una majúscula, minúscula, número i caràcter especial, i no ha d'incloure paraules comunes com el nom propi. També és important que la contrasenya con contigui el nom d'usuari en parts o complet. Una altra forma de fer les contrasenyes més segures és fer que aquestes no contiguin paraules llegibles com password o P@ssw0rd.

    Al crear una contrasenya aquesta s'ha de quedar guardada, i al canviar-la no podrà ser la mateixa, el sistema hauría de recordar dues contrasenyes, la actual i la anterior, per a que la proxima vegada que es canvii no pugui ser cap de les dues anteriors.

    Les contrasenyes serán encriptades només escriure-les, i seràn desades encriptades, per a no deixar vulnerabilitats.

    Segons el perfil d'usuari no caldria una diferent política si tots els usuaris tenen la política més restrictiva possible, però en el cas contrari l'usuari Artista hauría de ser més segur, ja que conté un compte bancari, al igual que l'usuari Acount Manager, ja que aquest genstiona tots els usuaris.

3. Avaluació de la informació: determina quin valor tenen les dades que treballa l'aplicació. Determina com tractar les dades més sensibles. Quines dades encriptaries?

    Totes les dades personals de tots els usuaris són sensibles, així que no harien de ser visibles de forma predeterminada a menys que siguis l'usuari resposable del compte o autoritzis que siguin visibles. El compte bancari de l'usuari Artista és important tenir-lo ocult. En tots els usuaris s'ha d'encriptar la contrasenya com està declarat en el punt anterior, només introduïrla aquesta s'encripta i s'envia i es desa ja encriptada, només l'usuari responsable haria de saber quina és la contrasenya original que genera aquest patró encriptat.

## 4. En el control d’accessos, existeixen mètodes d’autenticació basats en tokens. Defineix l’autenticació basada en tokens. Quins tipus hi ha? Com funciona mitjançant la web? Cerca llibreries .Net que ens poden ajudar a implementar autenticació amb tokens.

La autenticació basada en tokens comença amb una validació inicial de l'inici de sessió d'un usuari en un sistema, un cop el servidor autoritza l'usuari aquest li envia un token, una espècie de clau o certificat per dir-ho d'alguna forma, aquest token permet a l'usuari entrar al sistema de froma segura. A través s'aquest token l'usuari pot accedir als recursos del sistema sense haver de autenticar-se cada vegada que demana un registre. Els tokens tenen un cicle de vida limitats, aquest finalitzen el seu cicle de vida un cop l'usuari hagui tancat la sessió del seu compte o abandona l'aplicació que està utilitzant.

Tipus de tokens:
- **Token web JSON (JWT)**: Aquest token s'utilitza per a intercanviar informació de forma segura entre el client i el servidor. Els JWT contenen informació sobre la identificació de l'usuari i es  firma digitalment per a confirmar la legitimitat de les dades. Aquest token està froma per la **capçalera**, que conté infromació sobre el JWT, la **càrrega útil**, que conté reclamacions del usuari i alguna informació adicional com la expiració del token o els permisos del usuari, i la **firma digital**, que conté una clau criptogràfica que verifica la capcelera i la càrrega útil.
- **Tokens d'accés**: Aquest és el tipus de token web JSON més comuns, aquests serveixen per a autoritzar el accés al usuari a un servei en particular. Al iniciar sessió a l'usuari se li assigna un token que li permet accedir a recursos i serveis designats durant un temps limitat.
- **Tokens d'identificació**: Aquests tokens no donen accés al usuari, sino que serveixen per a identificar a l'usuari, aquests conetenen informació del usuari i son proporcionats a les aplicacions client per a verificar la identificació del usuari.
- **Tokens d'actualització**: Aquests tokens només s'utilitzen per a extendre la vida útil d'un token d'accés, aquests serveixen per a obtenir tokens d'accés adicionals sense que l'usuari hagui de tornar a introduïr les credencials d'inici de sessió.
- **Tokens de API**: Aquests són una cadena de codis que correspon a l'usuari que demana l'autenticació a una API. Autentica la identificació de l'usuari i otorga accés als punts finals de l'API.

L'autenticació mitjançant tokens web comença amb el servidor enviant un missatge al client, en el que el client inclou una còpia del token en les seguents solicituds enviades al servidor per a confirmar el estat de l'autenticació del client. Els token web mantenen la sessió del client iniciada.

Llibreries per a realitzar una utenticació basada en tokens:
- Microsoft.AspNetCore.Authentication.JwtBearer
- IdentityServer4
- Duende IdentityServer
- Azure.Identity
- Newtonsoft.Json
- Microsoft.IdentityModel.Tokens

## 5. Crea un projecte de consola amb un menú amb tres opcions:
1. Registre: l’usuari ha d’introduir username i una password. De la combinació dels dos camps guarda en memòria directament l'encriptació. Utilitza l’encriptació de hash SHA256. Mostra per pantalla el resultat.
2. Verificació de dades: usuari ha de tornar a introduir les dades el programa mostra per pantalla si les dades són correctes.
3. Encriptació i desencriptació amb RSA. L’usuari entrarà un text per consola. A continuació mostra el text encriptat i en la següent línia el text desencriptat. L’algoritme de RSA necessita una clau pública per encriptar i una clau privada per desencriptar. No cal guardar-les en memòria persistent.

**Per realitzar aquest exercici utilitza la llibreria System.Security.Cryptography.**

## 6. Indica les referències que has consultat, seguint el següent format:

> Sense Autor. (Sense Data). Bienvenido al OWASP Top 10 - 2021. Owasp. Recuperat el 30/3/2025 de https://owasp.org/Top10/es/

> Sense Autor. (Sense Data). A07:2021 – Fallas de Identificación y Autenticación. Owasp. Recuperat el 30/3/2025 de https://owasp.org/Top10/es/A07_2021-Identification_and_Authentication_Failures/

> Sense Autor. (Sense Data). A09:2021 – Fallas en el Registro y Monitoreo. Owasp. Recuperat el 30/3/2025 de https://owasp.org/Top10/es/A09_2021-Security_Logging_and_Monitoring_Failures/

> mrtsherman. (28/2/2011). Does asp.net protect against sql injection attacks. StackOverflow. Recuperat el 30/3/2025 de https://stackoverflow.com/questions/5144566/does-asp-net-protect-against-sql-injection-attacks

> Sense Autor. (Sense Data). Proveedores de identidad ¿Qué es la autenticación basada en tokens?. Entrust. Recuperat el 30/3/2025 de https://www.entrust.com/es/resources/learn/what-is-token-based-authentication

> Sense Autor. (Sense Data). ¿Qué es la autenticación basada en token?. CloudFlare. Recuperat el 30/3/2025 de https://www.cloudflare.com/es-es/learning/access-management/token-based-authentication/

> Sense Autor. (Sense Data). ¿Qué es la autenticación basada en tokens?. Keeper. Recuperat el 30/3/2025 de https://www.keepersecurity.com/es_ES/resources/glossary/what-is-token-based-authentication/

> **Escriu l’impacte que tenen a la seguretat i quins danys pot arribar a fer un atac en aquesta vulnerabilitat. A07:2021 – Falles d'identificació i autenticació**
>
> Impacte en la seguretat i danys potencials d’un atac a la vulnerabilitat A07:2021 – Falles d'identificació i autenticació
La vulnerabilitat A07:2021 – Falles d'identificació i autenticació es produeix quan un sistema no gestiona correctament els mecanismes d’identificació i autenticació dels usuaris, permetent que atacants puguin accedir indegudament a recursos protegits. Aquesta falla compromet la seguretat del sistema i pot tenir greus conseqüències.
Impacte en la seguretat:
Accés no autoritzat: Si un atacant pot explotar aquesta vulnerabilitat, podria accedir a comptes d’usuaris sense necessitat de conèixer les seves credencials.
Escalada de privilegis: Un usuari amb privilegis baixos podria obtenir accés a comptes administratius o amb permisos elevats.
Suplantació d’identitat: L’atacant podria fer-se passar per un altre usuari, afectant la confidencialitat i integritat de la informació.
Pèrdua de control del sistema: Si un administrador és compromès, l’atacant pot prendre el control total de l’aplicació o infraestructura.
Danys potencials:
Filtració de dades sensibles: Informació personal, financera o confidencial podria ser robada i exposada.
Modificació o destrucció de dades: L’atacant podria alterar o eliminar informació crítica.
Fraus i enganys: L’ús fraudulent de comptes compromesos podria permetre estafes, com compres il·legítimes o transaccions fraudulentes.
Desprestigi i pèrdua de confiança: Si un sistema pateix un atac per falles d’autenticació, podria perdre la confiança dels seus usuaris i veure afectada la seva reputació.
Multes i sancions legals: Empreses que no protegeixin adequadament la identificació i autenticació poden ser sancionades segons regulacions com el RGPD o PCI-DSS.
Exemples d’atacs possibles:
Brute Force Attack: Intent repetitiu de credencials fins a trobar-ne una vàlida.
Session Hijacking: Robatori de sessió per accedir com un usuari autenticat.
Credential Stuffing: Ús de credencials filtrades en altres serveis per intentar accedir al sistema.
Bypass d’autenticació: Errors en la implementació permeten esquivar la validació d’usuari.
Conclusió:
Les falles d'identificació i autenticació poden tenir conseqüències greus per a la seguretat d’un sistema i els seus usuaris. Implementar mecanismes com autenticació multifactor (MFA), bloqueig d’intents repetitius, gestió segura de sessions i encriptació de contrasenyes és essencial per mitigar aquest tipus d’atacs.

> **Escriu l’impacte que tenen a la seguretat i quins danys pot arribar a fer un atac en aquesta vulnerabilitat. A09:2021 – Falles al Registre i Monitorització**
>
> Impacte en la seguretat i danys potencials d’un atac a la vulnerabilitat A09:2021 – Falles al Registre i Monitorització
La vulnerabilitat A09:2021 – Falles al Registre i Monitorització es produeix quan un sistema no registra adequadament els esdeveniments de seguretat ni monitoritza l’activitat sospitosa. Aquesta manca de visibilitat impedeix detectar i respondre a atacs a temps, cosa que augmenta el risc d’explotació de vulnerabilitats i accés no autoritzat.
Impacte en la seguretat:
Detecció retardada d’atacs: Sense un registre adequat, els atacs poden passar desapercebuts durant dies, setmanes o fins i tot mesos.
Dificultat en la resposta a incidents: Sense evidències clares, és complicat investigar i mitigar un atac en curs.
Incompliment normatiu: Normatives com el RGPD, PCI-DSS i ISO 27001 requereixen registres de seguretat i monitorització per protegir dades sensibles.
Persistència d’atacants al sistema: Un ciberdelinqüent podria mantenir-se dins la xarxa sense ser detectat, realitzant moviments laterals o extraient informació confidencial.
Danys potencials:
Filtració de dades: Si un atacant accedeix a informació sensible i no hi ha registres, pot ser impossible identificar quines dades han estat compromeses.
Execució de codi maliciós sense detecció: Un atac pot implantar malware o ransomware i propagar-se sense ser identificat.
Accions fraudulentes sense rastre: Operacions no autoritzades, com fraus financers, poden ser realitzades sense que quedin evidències clares.
Impacte econòmic i reputacional: Una empresa que no detecti ni respongui a incidents pot patir pèrdues financeres i danys a la seva imatge pública.
Exemples d’atacs possibles:
Persistent Threat (APT): Atacants mantenen presència prolongada dins un sistema sense ser detectats.
Insider Threat: Treballadors amb males intencions poden realitzar accions malicioses sense deixar rastre.
Evasió de detecció: Malware o hackers poden modificar registres d’auditoria o desactivar sistemes de monitorització.
Conclusió:
Un registre i monitorització inadequats deixen els sistemes exposats a atacs sense detecció ni resposta efectiva. Per mitigar aquest risc, és essencial implementar logs detallats, monitorització en temps real, alertes automatitzades i eines de resposta a incidents (SIEM, IDS/IPS) per identificar i aturar possibles amenaces abans que causin danys irreversibles.

> **Escriu l’impacte que tenen a la seguretat i quins danys pot arribar a fer un atac en aquesta vulnerabilitat. A06:2021 – Components vulnerables i desactualitzats**
>Impacte en la seguretat i danys potencials d’un atac a la vulnerabilitat A06:2021 – Components vulnerables i desactualitzats
La vulnerabilitat A06:2021 – Components vulnerables i desactualitzats es produeix quan un sistema utilitza programari, llibreries, frameworks o components sense actualitzar, que contenen falles de seguretat conegudes. Això pot permetre als atacants explotar aquestes vulnerabilitats per comprometre el sistema.
Impacte en la seguretat:
Explotació de vulnerabilitats conegudes: Si un component està desactualitzat, és probable que ja existeixin atacs documentats per explotar-lo.
Execució de codi maliciós: Un atacant pot aprofitar vulnerabilitats per injectar i executar codi arbitrari dins el sistema.
Pèrdua de confidencialitat, integritat i disponibilitat: L’ús de components vulnerables pot permetre el robatori de dades, la modificació d’informació o la denegació de servei (DDoS).
Incompliment normatiu: Regulacions com RGPD, PCI-DSS o ISO 27001 requereixen mantenir el programari actualitzat per garantir la seguretat de les dades.
Danys potencials:
Filtració de dades: Un atacant podria accedir a informació sensible mitjançant vulnerabilitats conegudes en llibreries o bases de dades desactualitzades.
Control remot del sistema: L’explotació d’un component vulnerable pot permetre l’accés il·limitat a l’entorn atacat.
Distribució de malware o ransomware: Un sistema vulnerable pot ser utilitzat per instal·lar programari maliciós o xifrar dades a canvi d’un rescat.
Fallades crítiques en aplicacions: La incompatibilitat entre versions pot provocar errors i interrupcions en el servei.
Exemples d’atacs possibles:
Log4Shell (Log4j - 2021): Una vulnerabilitat en la llibreria Log4j va permetre l’execució remota de codi en milers de sistemes a nivell mundial.
EternalBlue (Windows SMB - 2017): Una vulnerabilitat en el protocol SMB de Windows va ser explotada per WannaCry, afectant empreses i institucions governamentals.
Heartbleed (OpenSSL - 2014): Una fallada en OpenSSL va exposar dades sensibles com credencials i claus privades.
Conclusió:
L’ús de components vulnerables i desactualitzats és una de les causes principals d’atacs informàtics. Per minimitzar el risc, és fonamental:
Mantenir el programari actualitzat amb els últims pegats de seguretat.
Monitoritzar dependències per detectar vulnerabilitats conegudes.
Eliminar components obsolets que ja no rebin suport oficial.
Realitzar proves de seguretat periòdiques per identificar riscos abans que els atacants ho facin.
Un sistema segur és un sistema actualitzat.

> **Enumera i raona diferents formes que pot evitar un atac per SQL injection en projectes fets amb Razor Pages i Entity Framework.**
>
> Per evitar atacs per SQL Injection en projectes desenvolupats amb Razor Pages i Entity Framework (EF), es poden aplicar diverses mesures de seguretat. A continuació, es presenten diferents formes d’evitar aquesta vulnerabilitat, juntament amb el seu raonament:
Ús de Entity Framework per evitar concatenació manual de SQL
Raó: EF utilitza LLINQ (Language Integrated Query) per generar consultes segures, evitant la necessitat de concatenar cadenes de text en les consultes SQL.
Exemple segur:
>
>var usuari = await _context.Usuaris
    .FirstOrDefaultAsync(u => u.NomUsuari == inputUsuari);
>
>Exemple vulnerable (evitar!):
>
>var query = $"SELECT * FROM Usuaris WHERE NomUsuari = '{inputUsuari}'";
var usuari = _context.Usuaris.FromSqlRaw(query).ToList();
>
>Perill: L’ús de FromSqlRaw amb valors concatenats permet injeccions SQL si no es controla adequadament.
Ús de Consultes Parametritzades amb FromSqlInterpolated
Raó: Quan es necessita executar consultes SQL personalitzades, s’ha d’utilitzar FromSqlInterpolated, que protegeix contra SQL Injection en assegurar que els paràmetres es tractin com a valors literals.
Exemple segur:
>
>var usuari = _context.Usuaris
    .FromSqlInterpolated($"SELECT * FROM Usuaris WHERE NomUsuari = {inputUsuari}")
    .FirstOrDefault();
>
>Exemple vulnerable (evitar!):
>
>var query = $"SELECT * FROM Usuaris WHERE NomUsuari = '{inputUsuari}'";
var usuari = _context.Usuaris.FromSqlRaw(query).FirstOrDefault();
>
>Perill: FromSqlRaw sense paràmetres protegits permet atacs SQL Injection.
Validació i normalització d’entrada de l’usuari
Raó: Encara que EF protegeix contra SQL Injection, és recomanable validar i netejar les dades d’entrada per evitar atacs d’injecció indirecta o falles de lògica.
Exemple segur (amb validació de dades en Razor Pages Model):
>
>[BindProperty]
[Required]
[StringLength(50, MinimumLength = 3)]
public string NomUsuari { get; set; }
>
>Exemple vulnerable (evitar!):
>
>[BindProperty]
public string NomUsuari { get; set; } // Sense validació!
>
>Perill: Sense restriccions, un atacant pot injectar codi maliciós o sobrecarregar el sistema.
Ús de DbContext per evitar execució directa de SQL
Raó: En comptes d’executar SQL directament, s’ha d’utilitzar el model de dades de Entity Framework per assegurar consultes segures i prevenir manipulacions SQL.
Exemple segur:
>
>var usuari = await _context.Usuaris
    .Where(u => u.NomUsuari == inputUsuari)
    .FirstOrDefaultAsync();
>  
>Exemple vulnerable (evitar!):
>
>var command = $"DELETE FROM Usuaris WHERE NomUsuari = '{inputUsuari}'";
_context.Database.ExecuteSqlRaw(command);
>
>Perill: ExecuteSqlRaw sense parametrització pot permetre que un atacant esborri o manipuli dades.
Implementació d’Autenticació i Autorització Segura
Raó: Evitar que usuaris no autoritzats puguin accedir a dades sensibles redueix el risc d’explotació de vulnerabilitats.
Exemple segur (Razor Pages amb autorització):
>
>[Authorize(Roles = "Admin")]
public class AdministracioModel : PageModel { }
>
>Exemple vulnerable (evitar!):
>
>public class AdministracioModel : PageModel { } // Sense control d’accés
>
>Perill: Si qualsevol usuari pot accedir a una pàgina que executa consultes SQL, augmenta el risc de manipulació de dades.
Monitorització i Registre d’Errors (Logging & Auditing)
Raó: Configurar registres de logs permet detectar intents d’injecció SQL i respondre ràpidament davant possibles atacs.
Exemple segur (implementació de logs en Razor Pages):
>
>try
{
    var usuari = await _context.Usuaris.FirstOrDefaultAsync(u => u.NomUsuari == inputUsuari);
}
catch (Exception ex)
{
    _logger.LogError($"Error en la consulta SQL: {ex.Message}");
}
>
>Exemple vulnerable (evitar!):
>
>catch (Exception ex)
{
    Console.WriteLine(ex.Message); // No es registra l’error correctament
}
>
>Perill: Sense registre adequat, els intents d’injecció poden passar desapercebuts.
Conclusió
Per protegir Razor Pages i Entity Framework d’atacs SQL Injection:
Utilitza LINQ per evitar consultes SQL directes.
Empra FromSqlInterpolated en lloc de FromSqlRaw.
Valida totes les dades d’entrada.
Evita l’execució directa de SQL amb ExecuteSqlRaw.
Configura autenticació i autorització.
Activa registres de logs per detectar intents d’atac.
Si s’apliquen aquestes mesures, el risc d’injecció SQL es redueix dràsticament i es millora la seguretat del sistema.

> **Proporciona'm llibreries .Net per a fer una autenticació basada en tokens**
>
> Si vols implementar una autenticació basada en tokens en un projecte .NET, aquí tens algunes llibreries que et poden ajudar:
>
>1. Microsoft.AspNetCore.Authentication.JwtBearer
Descripció: Llibreria oficial de Microsoft per treballar amb autenticació basada en JWT (JSON Web Tokens) en aplicacions ASP.NET Core.
Característiques:
Compatible amb OAuth 2.0 i OpenID Connect.
Suport natiu en ASP.NET Core.
Integració fàcil amb IdentityServer, Azure AD i altres proveïdors d’autenticació.
>Instal·lació:
>
>dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
>
>Exemple d’ús en Program.cs (ASP.NET Core 7+):
>
>builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://your-auth-server.com";
        options.Audience = "your-api";
>    });
>
>2. IdentityServer4
Descripció: Un servidor d’identitat OpenID Connect i OAuth 2.0 per a aplicacions .NET. Permet gestionar autenticació i autorització amb tokens JWT.
Característiques:
Autenticació basada en OAuth2 i OpenID Connect.
Gestió d’identitats centralitzada per a microserveis.
Compatible amb Single Sign-On (SSO) i autenticació federada.
>Instal·lació:
>
>dotnet add package IdentityServer4
>
>Exemple bàsic de configuració:
>
>services.AddIdentityServer()
    .AddInMemoryClients(Clients.Get())
    .AddInMemoryApiResources(ApiResources.Get())
    .AddInMemoryIdentityResources(IdentityResources.Get())
    .AddTestUsers(TestUsers.Users)
>    .AddDeveloperSigningCredential();
>
>3. Duende IdentityServer (Successor d’IdentityServer4)
Descripció: Successor d’IdentityServer4 per gestionar autenticació i autorització en aplicacions .NET modernes.
Característiques:
Implementa OAuth 2.0 i OpenID Connect.
Compatible amb .NET 6+ i microserveis.
Proporciona autenticació basada en tokens JWT amb alta seguretat.
>Instal·lació:
>
>dotnet add package Duende.IdentityServer
>
>Exemple bàsic de configuració: (similar a IdentityServer4)
>
>services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryIdentityResources(Config.IdentityResources)
>    .AddDeveloperSigningCredential();
>
>Nota: Duende IdentityServer requereix una llicència per a ús comercial.
>4. Azure.Identity (Autenticació amb Azure AD)
Descripció: Llibreria per gestionar autenticació basada en Azure Active Directory (Azure AD) i MSAL (Microsoft Authentication Library).
Característiques:
Autenticació basada en tokens amb Azure AD, Azure AD B2C i Microsoft Entra ID.
Integració amb Microsoft Graph API.
Compatible amb .NET Core i .NET 6+.
>Instal·lació:
>
>dotnet add package Azure.Identity
>
>Exemple d’ús per obtenir un token d’Azure AD:
>
>var credential = new DefaultAzureCredential();
var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://graph.microsoft.com/.default" }));
>
>5. Newtonsoft.Json per treballar amb JWT manualment
Descripció: Si necessites deserialitzar un token JWT manualment, pots usar Newtonsoft.Json.
>Instal·lació:
>
>dotnet add package Newtonsoft.Json
>
>Exemple de lectura d’un token JWT:
>
>var handler = new JwtSecurityTokenHandler();
var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
Console.WriteLine($"Usuari: {jsonToken.Claims.First(c => c.Type == "name").Value}");
>
>6. Microsoft.IdentityModel.Tokens (Validació avançada de tokens)
Descripció: Llibreria oficial de Microsoft per a validar i generar tokens JWT en aplicacions .NET.
>Instal·lació:
>
>dotnet add package Microsoft.IdentityModel.Tokens
>
>Exemple de validació d’un token JWT:
>
>var tokenHandler = new JwtSecurityTokenHandler();
>var key = Encoding.ASCII.GetBytes("clau-secreta-molt-segura");
>
>var tokenValidationParameters = new TokenValidationParameters
>{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false
>};
>
>var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
>
>Conclusió
Si vols implementar autenticació basada en tokens en un projecte .NET, et recomano:
Per aplicacions ASP.NET Core → Microsoft.AspNetCore.Authentication.JwtBearer
Per autenticació personalitzada → IdentityServer4 o Duende IdentityServer
Per autenticació amb Azure AD → Azure.Identity
Per validar JWT manualment → Microsoft.IdentityModel.Tokens
Tens alguna preferència sobre el tipus d’autenticació que vols implementar?