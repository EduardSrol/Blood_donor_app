Blood Donor App

**!!!DAL sa nachádza v branchi test!!!**

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

    Umožniť založiť darcovi účet (UUN, typ Darca, jednoduchá história odberov)

    Umožniť žiadateľovi rozšíriť informácie vo svojom profile (fotografia, krátky text atď.)
    
    Umožniť žiadateľovi/administrátorovi zmenu stavu žiadateľa (Active - NonActive)

    Zobrazovať základné informácie o žiadateľoch (má možnosť nezverejniť niektoré info)

    Prehľad všetkých Aktívnych žiadateľov v rámci príslušných kategórií, vyhľadávanie a filtrovanie žiadateľov na základe určitých parametrov pre všetkých návštevníkov webu.
    Cez verejné API získať detaily ku Active žiadateľom.

    Žiadatelia budú mať možnosť sledovať aktuálny stav svojej žiadosti (koľko darcov úspešne absolvovalo odber).

    Žiadatelia bude dosťávať upozornenie, keď sa uskutoční úspešne odber (napríklad emailom).

    Administrátor bude mať možnosť spravovať účty jednotlivých userov, úpravu informácií žiadateľov, mazanie nevhodných textov z profilov žiadateľov, pridávať práva k jednotlivým účtom (hlavne ide o Stanica adminov).

    Zaslať notifikáciu darcovi keď si nejaký žiadateľ s vyhovujúcimi informáciami zmení stav na Active

    Zaslať notifikáciu darcovi, že jeho odber dorazil úspešne k žiadateľovi

    Umožniť Stanica adminom vytvárať a editovať záznamy o odberoch so základným info (uuns, atď.)

    Umožniť zobrazovanie odberných staníc (ulica, kontakt atď.)

    Umožniť návštevníkom a userom zobraziť podmienky odberu, a dostupný formulár

    Zobrazovať štatistiku na front-page o úspešných odberoch a počte Aktívnych žiadateľov



    Príklad možného rozšírenia:

	    Hodnotenie jednotlivých darcov (za určité počty odberov možnosť získať badges, plakety, hodnosti, atď. /"Zobrazenie siene slávy"/)

	    Rozšírenie zoznamu odberných staníc o zobrazenie na mape

	    Zobraziť eventy v minulosti, budúcnosti (propagačné stretnutia, hromadné odbery, výjazdy, komerčné akcie atď.)

	    Pridanie aj iných modulov pre iný typ žiadateľov (žiadatelia o kostnú dreň, atď.)

	    Pridanie user typu Event Admin
