## INTRODUCCIÓ

Soul Forest és un 3rd person shooter basat en un mon de fantasia. Tu ets un esperit del bosc, i la teva llar i la dels altres vilatans ha estat invaida per dimonis. La teva feina és evitar que el bosc es contamini, i per això hauràs d'anar eliminant els dimonis i arribar a la zona de purificació. Els vilatans es transformaran en dimonis si son atrapats pels dimonis.

Tens tres tipus de vares màgiques: 
- La vareta, que dispara boles verdes i que té molta munició 
- El ceptre, que dispara boles explosives i fereix enemics pròxims, però de la que tindràs la munició justa
- El ceptre rosat, que dispara bales explosives de gran poder, i de la que hi ha molt poca munició. 
No obstant, si et quedes sense munició, pots ferir als enemics impulsan-te contra ells i xocant.

![Screenshot](/Images/Image5.png)

A més, repartits pel món hi ha animals: cèrvols i geckos. Al principi et tindràn por, però si els dones dolços s'aniràn acostumant a tu. Quan arribin a cert nivell de confiança, podràs pujar-hi i moure't més depressa per l'escenari! Per mantenir-los feliços, dona'ls dolços sovint, i sobretot no els fereixis. Els geckos salten poc però son molt ràpids. Per contra, els cèrvols són més lents però salten molt amunt.

![Screenshot](/Images/Image14.png)


## FONTS DELS ASSETS UTILITZATS

### 3D models escenari:

- Cases poble: https://assetstore.unity.com/packages/3d/environments/desert-village-houses-lowpoly-200247 

- Player: https://assetstore.unity.com/packages/3d/characters/low-character-pack-free-sample-192954 

- Model clau: https://assetstore.unity.com/packages/3d/props/rust-key-167590

- Models pocions: https://assetstore.unity.com/packages/3d/props/potions-115115

- Enemics: https://assetstore.unity.com/packages/3d/characters/fantasy-stickman-pack-194654 

- Arbres i ruines: https://assetstore.unity.com/packages/3d/environments/the-lost-lands-97698 

- Armes: https://assetstore.unity.com/packages/3d/props/weapons/free-rpg-weapons-199738

- Animals: https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235

### Animacions:

- Mixamo: https://www.mixamo.com/

### Shaders: 

- Flatkit cartoon shader: https://assetstore.unity.com/packages/vfx/shaders/flat-kit-toon-shading-and-water-143368

- Highlight: https://assetstore.unity.com/packages/tools/particles-effects/highlight-plus-134149 

### Music and SFX:

Obtinguts de freesound.org i opengameart.org, links a continuació. Alguns han estat lleugerament modificats amb Audacity 

- Tiny worlds: https://opengameart.org/content/forest-ambience

- Brandon Morris: https://opengameart.org/content/creepy-forest-f

- Podcapocalipsis: https://freesound.org/people/Podcapocalipsis/sounds/578601/

- Remoz: https://freesound.org/people/Remoz/sounds/123310/

- Little Robot Sound Factory: https://opengameart.org/content/fantasy-sound-effects-library

- Rubberduck https://opengameart.org/content/80-cc0-creature-sfx

- Otto Halmén: https://opengameart.org/content/death-is-just-another-path

- Pauliuw: https://opengameart.org/content/the-field-of-dreams

- Scrabbit: https://opengameart.org/content/world-map-1

- Blender Foundation: https://opengameart.org/content/pick-up-item-yo-frankie

- JUDITH136: https://freesound.org/people/JUDITH136/sounds/408012/

- BloodPixelHero: https://freesound.org/people/BloodPixelHero/sounds/504651/

- Lerdavian: https://freesound.org/people/Lerdavian/sounds/321982/

- Cynicmusic: https://opengameart.org/content/mysterious-ambience-song21

- Darsycho: https://opengameart.org/content/tiny-vicious-creature

- InspectorJ: https://freesound.org/people/InspectorJ/sounds/421022/

- Qubodup: https://opengameart.org/content/dog-grunt

- Lokif: https://opengameart.org/content/gui-sound-effects

### Fonts de text:

- Back to the fantasy, de Woodcutter: https://www.dafont.com/es/back-to-the-fantasy.font

- Blood & Horror, de Woodcutter: https://www.dafont.com/es/blood-horror.font

- Cute Aurora, de 611 Studio: https://www.dafont.com/es/search.php?q=cute+aurora

### Textures  

- Per les flors i gespa: https://assetstore.unity.com/packages/2d/textures-materials/nature/grass-and-flowers-pack-1-17100 

- Eina Gradient texture generator per fer el gradient de l'aigua: https://assetstore.unity.com/packages/tools/utilities/gradient-texture-generator-216180 

- Textures terreny: https://assetstore.unity.com/packages/2d/textures-materials/handpainted-grass-ground-textures-187634

### VFX:

- Cartoon vfx: https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-remaster-free-109565

### Asset cleaner:

- Utilitzat per netejar el projecte d'assets no fets servir https://github.com/unity-cn/Tool-UnityAssetCleaner


### Behavior Designer:
 - Eina per fer els behavioral trees. https://assetstore.unity.com/packages/tools/visual-scripting/behavior-designer-behavior-trees-for-everyone-15277

## COM JUGAR
### Aspectes tècnics:

El joc ha estat desenvolupat en la versió 2021.3.19f de Unity i Visual Studio 2022. Per jugar des de l'editor, ves a la pantalla de SplashScreen i clica el botó de jugar.
El joc ha estat dissenyat per jugar des de l'ordinador a una resolució de 16:9. A fi de continuar practicant el nou sistema d'input, l'input s'ha manejat fent servir el New Input System de Unity, i s'ha adaptat per poder jugar tant amb teclat i ratolí com amb mando.
És recomanable jugar amb mando, l'experiència es més satisfactoria, però es pot jugar amb teclat i ratolí perfectament.

Controls mando:
- joystick esquerre per moviment horitzontal
- joystick dret pel moviment de la càmera
- botó d'abaix (A xbox) per saltar
- botó dret (B xbox) per disparar
- botó d'adalt (Y xbox) per impulsar-se (dash, serveix també per ferir als enemics si no tens munició!)
- botó esquerra (X xbox) per pujar-te i baixar-te dels animals domesticats
- botó LB esquerre per canviar d'arma
- botó RB dret (mantingut) per apuntar 
- joystick dret (apretar) per deixar caure dolços


Controls teclat i ratolí:
- WASD pel moviment horitzontal
- moviment de ratolí per moure la càmera
- botó dret del ratolí (mantingut) per apuntar
- botó esquerre del ratolí per disparar
- tecla E per impulsar-se (dash, serveix també per ferir als enemics si no tens munició!)
- tecla Z per pujar i baixar dels animals domesticats
- tecla C per canviar d'arma
- tecla R per deixar caure dolços


## COM S'HA DESENVOLUPAT

### Aspectes implementats:

S'han implementat tots els punts obligatoris i opcionals proposats. També s'han implementat alguns elements extra. No obstant, La temàtica del joc no encaixava gaire amb alguns dels punts opcionals i obligatoris, així que s'han modificat alguns aspectes. Enlloc de conduir un cotxe, pots pujar-te a animals. A més, enlloc de fer la IA complexe pel sistema de semàfors i tràfic, s'ha fet una IA complexa pels animals. Aquesta IA permet domesticar-los per poder-hi pujar.
A continuació s'explica com s'han implementat els diferents aspectes, distingint entre punt obligatori de l'enunciat (obligatori), punt opcional de l'enunciat (opcional), i coses extra implementades per mi (extra). 


### Menú per començar i menú d'opcions (obligatori 1)

S'ha creat una escena que es diu OptionsMenu. En aquest menú es poden modificar: el volum del joc (slider), la brillantor de l'escena (slider), i la dificultat del joc (botons per dificultat baixa, mitja, i alta). Tant els sliders com els botons criden a mètodes del script `OptionsSetting.cs` quan son clicats. Aquests mètodes s'encarreguen d'establir el volum, brillantor i dificultat a `GameManager.cs`. Un cop guardada la configuració, a GameScene, el script `SettingsGame.cs` s'encarrega d'ajustar els diferents elements d'acord a aquesta configuració. Pel volum es modifica el volum de l'audio listener, i per la brillantor es modifica l'intensitat de les directional lights. El nivell de dificultat modifica tres cosesde `EnemySpawner.cs`: 
1- La probabilitat de que caiguin pickups quan mor un enemic
2- L'intèrval de temps que passa fins que s'instancien enemics
3- El número d'enemics que s'instancien cada cert temps a 

![Screenshot](/Images/Image2.png)

### Tenir una ciutat amb vegetació i monstres (obligatori 2)

Aquest punt ja estava implementat a la PEC3.

### Monstres que es moguin a punts random, i ataquen al jugador si s'acosta (obligatori 3)

Aquest punt ja estava implementat a la PEC3. No obstant, s'ha modificat una mica la IA dels enemics a fi que també persegueixin als vilatans del poble, amb un child object que es diu CitizenDetection, que té el script `EnemyTargetDetection.cs`. Els enemics es van movent a punts random fins que, a través d'aquest script, detecten un NPC amb `OnTriggerEnter()`. Quan ho fan, es posen a perseguir-lo i l'ataquen amb el mateix sistema que es feia servir perque perseguissin i ataquéssin al Player. De totes maneres, si el Player s'acosta prou, els enemics donen prioritat a perseguir-lo respecte als NPCs. Així, el jugador pot evitar que els enemics ataquin als NPCs exposant-se ell com a target. 

Aquí podeu veure un enemic anant cap al Player i ignorant a l'NPC:
![Screenshot](/Images/Image6.png)


### Peatons que es van movent per la ciutat (obligatori 4) fugint dels dimonis (obligatori 5), i es transformen si els ataquen (opcional 2)

Els peatons son objectes que es diuen CitizenNPC i tenen una IA més senzilla que els enemics o els animals. Només es troben al poble central, ja que no tenia massa sentit posar-los a les altres zones. La seva IA es controla a través de tres scripts: `CitizenNPC.cs`, `CitizenHealth.cs`, i `EnemyDetection.cs`. Els NPCs es van movent a punts random igual que els enemics amb els mètodes `Roam()` i `CanGetRandomPoint()`. Però quan detecten un enemic a través de `EnemyDetection.cs`, amb `OnTriggerEnter()`, fugen en la direcció oposada a aquests. 
Si els enemics atrapen i ataquen a un ciutadà, a `CitizenHealth.cs` es crida el mètode `TakeDamage()`, que els va treient vida. Quan la vida arriba a 0, comença una animació per fer veure que els vilatans es tornen bojos, i criden (un so random entre una array de sons). Després, amb `InstantiateEnemyAndDestroy()` s'instancia un enemic en aquell punt i el vilatà desapareix. 

Aquí podeu veure un NPC fugint d'un enemic:

![Screenshot](/Images/Image4.png)

Aquí, a la dreta del jugador podeu veure un NPC rondant tranquil, i al fons podeu veure un enemic que abans era un NPC i just s'ha transformat (i es veuen les VFX de transformació):

![Screenshot](/Images/Image3.png)


### Pujar-se i conduir animals (obligatori 6) que tenen una IA complexa per domesticar-los (opcional 1) i canvas per mostrar la confiança (extra)

Aquest punt ha estat amb diferència el més llarg i difícil d'implementar, però ha resultat ser un repte molt interessant. Com que costa d'entendre sense visualitzar-ho, a part de l'explicació que ve a continuació s'ha fet un vídeo extra explicant i mostrant com s'ha dissenyat la IA dels animals (link a baix de tot).
Per implementar la IA dels animals s'han fet servir Behavioral Trees amb una eina anomenada Behavior Designer (citada més amunt). Hi ha dos tipus d'animals, cèrvols i geckos, i dins de cada espècie hi ha mascles i femelles (que tenen velocitats diferents quan el jugador els monta). 

El script que permet controlar l'animal quan el jugador hi puja és `AnimalController.cs`. No obstant, si l'animal no està domesticat (confiança major de un cert intèrval), el jugador no podra pujar-hi. La confiança de l'animal es controla amb la propietat `TrustLevel` del script `AnimalBehavior.cs`. El nivell de confiança dels animals va baixant amb el temps amb un `InvokeRepeating()` cada cert temps. Aquesta segueix baixant fins i tot quan el jugador està pujat a l'animal, a fi de fer més difícil mantenir als animals contents. A més, si el jugador, per accident o volent, fereix a un animal, disminueix la confiança amb el mètode `ReceiveDamage()`. A fi de visualitzar el nivell de confiança, s'ha fet un canvas per cada animalet, amb un cor que es va omplint o buidant cada cop que canvia `TrustLevel`. Per fer que el canvas sempre miri cap a la càmara, s'ha fet un script anomenat `LookAt.cs`.

Aquí podeu veure dos geckos (mascle i femella) i un cèrvol mascle, cada un amb el seu cor mostrant el nivell de confiança:

![Screenshot](/Images/Image14.png)

El comportament dels animals s'ha fet amb un behavioral tree. Per això, s'han creat diversos scripts que es poden classificar en Actions i Conditionals. Les Actions son accions que farà l'animal, i Conditionals son condicions per passar d'una acció a una altra. Mitjançant aquests elements, es crea un arbre de comportament que, en funció de les condicions establertes, passa a unes accions o unes altres.
Les accions que s'han fet son:
- `EatFood.cs`, que s'encarrega de fer l'animació i so de menjar dolços i pujar la confiança.
- `EatGround.cs`, que es fa servir per simular que l'animal menja herba del terra, com si estigués pasturant. Sí, els geckos son insectívors, però aquí també pasturen. Assumirem que mengen insectes de l'herba :D.
- `FollowPlayer.cs`, que es fa servir perque l'animal segueixi al jugador quan té un nivell de confiança alt (per simular que li demana dolços)
- `MoveToObject.cs`, que es fa servir perque l'animal es mogui cap a un objecte amb la tag indicada. En aquest cas es fa servir pels dolços, però podria aplicar-se a altres objectes en un futur i per això s'ha fet un script generalista.
- `MoveToPosition.cs`, que s'encarrega de moure a l'animal fins a una posició determinada.
- `RotateTowardsObject.cs`, que té la funció de rotar a l'animal cap a l'objecte que s'indiqui. Serveix, per exemple, per fer que l'animal es direccioni cap al carmel abans de començar a menjar. No obstant, a fi d'optimitzar performance, les comprovacions del behavioral tree es fan cada 0.1 segons. Això vol dir que el moviment de rotació no seria fluid si es fes des d'aquí. Per tant, el que fa aquesta classe és cridar el mètode `EnableRotation()` de la classe `RotateObject.cs`, on es fa la rotació pròpiament.
- `ScaredBehavior.cs`, que serveix per simular el comportament de l'animal quan no té confiança i es troba acorralat, començant una animació d'atacar, i grunyint.

Els condicionals que s'han fet son els següents:
- `HasRandomPoint.cs`, que es fa servir per determinar si hi ha un punt random al que l'animal podria anar.
- `HasRunAwayPoint.cs`, que indica si l'animal té un punt al que anar fugint del jugador.
- `IsObjectClose.cs`, que serveix per determinar si un objecte amb una tag determinada es troba dins d'un rang determinat.

Aquí es pot veure una imatge de l'arbre de comportament, que és el mateix pels cèrvols i geckos, però els rangs i velocitats canvien:

![Screenshot](/Images/BT_deer.png)

A més d'aquests scripts, el script de `Utils.cs` té mètodes que es fan servir des de les classes anteriorment mencionades. El script `SoundsAnimations.cs` conté mètodes públics que es criden des de les animacions per activar sons en els moments indicats de l'animació. 

Fent servir aquestes classes, el comportament dels animals aniria més o menys així: si hi ha un carmel aprop, i el jugador és lluny o li tenen prou confiança, aniran cap al carmel, rotaran cap a ell, i se'l menjaran. Si el jugador és aprop i li tenen confiança però no hi ha cap carmel, se li acostaran a demanar-li. Si el jugador s'allunya, el seguiran fins a un cert rang, demanant-li carmels. En canvi, si li tenen por, l'animal primer intentarà fugir allunyant-se i plorarà perque té por. Si no pot allunyar-se i es troba acorralat, es girarà cap al jugador i li grunyirà agressivament, fent una animació d'atacar. Finalment, si el jugador està lluny, es mouran fins a un punt random del terreny i menjaran herba durant una estona random. Després aniran cap a un altre punt random, i així consecutivament.

Aquí podeu veure un cèrvol acostant-se al jugador per demanar-li carmels:

![Screenshot](/Images/Image8.png)

Si l'animal té prou confiança, quan el jugador se li acosti podrà pujar-hi. Els animals es detecten amb `OnTriggerEnter()` el script `AnimalDetector.cs`, i es posen a una variable anomenada `domesticatedAnimalInRange`. Es pot accedir a aquest animal des de `GetDomesticatedAnimalToRide()`. El canvi de control entre animal i jugador es fa des del script `ControlSwitcher.cs`, amb el mètode `SwitchControls.cs`. Quan el control passa a ser de l'animal, es fan els canvi de controls corresponents a tots els scripts. Per exemple, es desactiva el `CharacterController.cs` del jugador i s'activa el de l'animal, es canvia el action map amb `playerInput.SwitchCurrentActionMap("OnAnimal")`, es criden els mètodes corresponents a `InputManager.cs`, es mou al jugador a damunt l'animal, i es mouen les càmeres a les noves posicions que apunten a l'animal. 

Aquí podeu veure al jugador muntant un cèrvol i apuntant (que li permet saltar molt amunt), i més avall un gecko (que li permet anar molt ràpid):

![Screenshot](/Images/Image9.png)

![Screenshot](/Images/Image13.png)


### Sistema per recollir carmels pels animals (extra) i slider pels dolços (extra)

Per poder domesticar els animals, s'ha creat un sistema que implica recollir carmels i donar-los als animals, que es fa a `SweetsStorer.cs`. Els enemics ocasionalment deixen anar cubells amb dolços, i repartits per l'escenari també hi ha pickups de dolços (`FoodPickup.cs`). Cada cop que el jugador deixa caure dolços (`DropSweets()`) o en recull (`PickupSweets()`), s'actualitza la barra de carmels que hi ha a la UI, a baix a l'esquerra (amb `UpdateSliderSweets()`). Els carmels que el jugador deixa caure tenen la classe `FoodElement.cs`, que indica quant augmenten la confiança quan se'ls mengen.

Aquí podeu veure un gecko menjant carmels, i la barra de carmels a baix a l'esquerra:

![Screenshot](/Images/Image11.png)

### Armes amagades per l'escenari (opcional 3) i disparar des dels animals (extra)

Tot el sistema per tenir diverses armes, el canvi d'armes, i disparar, ja estava implementat en la versió anterior de la PEC3. No obstant, ara s'ha afegit una tercera arma. A més, s'ha implementat un sistema per no tenir totes les armes des del principi, sinó que es fan disponibles a mesura que el jugador les recull. Això es fa a `WeaponPickup.cs`, amb `OnTriggerEnter()`, on es crida el mètode `ActivateWeapon(int index)` del script `WeaponsController.cs` per activar l'arma corresponent a l'índex passat. A més, per indicar si l'arma és o no disponible, les barres de munició son mig transparents si l'arma no ha estat recollida encara. Un cop es recull, es treu la transparència.

Aquí podeu veure al jugador recollint el ceptre de foc. Fixeu-vos que, com que encara no ha recollit els ceptres, les barres munició (a dalt a l'esquerra) son transparents: 

![Screenshot](/Images/Image15.png)

La tercera arma afegida per aquesta versió és la més potent de totes, explosiva, d'ampli rang i que causa molt mal. El jugador només pot tenir com a màxim 4 bales, d'aquesta arma.
A més, també s'ha fet que el jugador pugui apuntar i disparar tot i estar muntat a damunt dels animals. D'aquesta manera pot ferir els enemics a distancia disparant, o atropellar-los amb els animals. No obstant, els bosses no es poden eliminar atropellant-los, a fi que no sigui massa fàcil.



### Dimonis exploten quan son atropellats (opcional 4)

Tots els animals tenen un fill que es diu DamageFront, situat a la part de davant de l'animal. Aquest GameObject té un box collider i un script anomenat `DamageFront.cs`. Aquest script té dos mètodes, un per activar aquest box collider i un altre per desactivar-lo (`EnableCollider()` i `DisableCollider()`). Volem que aquest collider només s'activi quan el jugador està damunt l'animal i s'està movent. Per tant, a `AnimalController.cs`, dins del mètode `ApplyMovement()`, es mira si la direcció de moviment és major de cert valor (que indica que s'està movent), i si és així es crida al mètode `EnableCollider()`. Si no, es desactiva amb `DisableCollider()`. Si el collider està actiu i col·lisiona amb un enemic, es crida al mètode `DieByAnimal()` de `EnemyHealth.cs`, que mata l'enemic immediatament. Només s'ha fet que els enemics morin en ser atropellats pels animals, ja que no volia eliminar als NPCs d'aquesta manera. 

Aquí podeu veure els efectes d'explosió i fum en atropellar enemics:

![Screenshot](/Images/Image10.png)

![Screenshot](/Images/Image12.png)


### Tot sonoritzat (opcional 5)

La versió anterior del joc ja estava sonoritzada. En aquesta versió s'han afegit tots els sons necessaris pels NPCs i pels animals, així com música pel menú d'opcions. Les fonts dels nous sons s'han afegit a l'apartat Fonts dels assets utilitzats, més amunt. Els animals en particular tenen diversos sons per quan mengen, tenen por i surten corrents, es posen agressius quan es veuen acorralats, detecten al jugador i van a demanar-li menjar, o quan augmenta la confiança després que mengin dolços. 

  
## VÍDEOS

Vídeo del joc amb veu (explicat):

https://youtu.be/aRkGLDR7asc


Vídeo del joc sense veu (no explicat):

https://youtu.be/3qSVcQ4Jwv0


## Enllaç al vídeo explicatiu del behavior tree fet pels animals:

https://youtu.be/YWufCRTGtPc







