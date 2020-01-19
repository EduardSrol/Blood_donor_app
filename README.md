oprava:
edit account vôbec nič
nezobrazovať hospital id pre bežných užívateľov
atribút display môže byť fajn
pridať filtrovania applicantov aspoň podľa krvnej skupiny, UUN
registrácia prejde aj s už existujúcim mailom
nerušiť add new blood donation
pridať nejaký check na donor Id, applicant id samplestation id a aby to nepadalo
vymyslieť nejakú non CRUD funkcionalitu inu ako filtrovanie
prihodte link na ten vas vec do gitu
pri registracii nepridavate hodnotu do UUN

https://dbloodweb.azurewebsites.net/Home/Index

Blood Donor App

**!!!MASTER JE CESTA!!!**

**Vedení:**

Ivan Vanát, učo 456691 (vedoucí) 

**Tím:**
Ján Dovjak, Eduard Šrol, Denis Valko


**Oficiální zadání:**

Typy používateľov systému:
	-Návštevník stránky
	-Registrovaný používateľ
		--Žiadateľ
		--Darca
	-Neregistrovaný darca
	-Stanica admin
	-(Event Admin)
	-Administrátor

**Systém bude umožňovať:**

Spájať ľudí žiadajúcich o krv (ďalej ako žiadateľ - nutná registrácia) a ľudí s dobrým srdcom a úmyslom pomôcť iným v núdzi (ďalej ako darca - voliteľná registrácia)

Každému registrovanému používateľovi (ďalej ako user) priradiť Unique User Number - 16 miestne číslo, v rámci zachovania ochrany osobných údajov.

Umožniť administratorovi - nemocnici založiť účet pre žiadateľov (základné osobné údaje, kontakt, krvná skupina, typ Žiadateľ, stav Active, vygeneruje sa UUN)
//TODO - generujúca funkcia - ms, guid,...

Umožniť založiť darcovi účet (UUN, typ Darca)
// registerDto, registerService, registerFacade(checkAvailability)

Umožniť žiadateľovi rozšíriť informácie vo svojom profile (krátky text atď.)
// updateDto, updateService 

Umožniť žiadateľovi/administrátorovi zmenu stavu žiadateľa (Active - NonActive)
// changeStateDto, ...

Zobrazovať základné informácie o žiadateľoch (má možnosť nezverejniť niektoré info)
// shortInfoDto, ...

Prehľad všetkých Aktívnych žiadateľov v rámci príslušných kategórií, vyhľadávanie a filtrovanie žiadateľov na základe určitých parametrov pre všetkých návštevníkov webu.
// filtersDto

Cez verejné API získať informácie o odberoch (počet za čas, v rámci krv. skupiny, ml,...)

Darcovia budu dostávať upozornenie, keď sa uskutoční úspešne odber (napríklad emailom).
// podobné ako vyššie, dto, service

Administrátor bude mať možnosť spravovať účty jednotlivých userov, úpravu informácií žiadateľov, mazanie nevhodných textov z profilov žiadateľov, pridávať práva k jednotlivým účtom .
// detailedDto, service

Umožniť zobrazovanie odberných staníc (ulica, kontakt atď.)
// infoDto

**Príklad možného rozšírenia:**
Hodnotenie jednotlivých darcov (za určité počty odberov možnosť získať badges, plakety, hodnosti, atď. /"Zobrazenie siene slávy"/)

Rozšírenie zoznamu odberných staníc o zobrazenie na mape

Zobraziť eventy v minulosti, budúcnosti (propagačné stretnutia, hromadné odbery, výjazdy, komerčné akcie atď.)

Pridanie aj iných modulov pre iný typ žiadateľov (žiadatelia o kostnú dreň, atď.)

Pridanie user typu Event Admin
