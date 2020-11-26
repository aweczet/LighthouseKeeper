# LighthouseKeeper
Jest to adaptacja growa noweli "Latarnik" Henryka Sienkiewicza. Głównym elementem gry ma być historia. Grafika jest w low poly (póki co bez dodatkowych tekstur - tylko pełne kolory). 
W grze wcielimy się w Skawińskiego, tułacza, poszukiwacza przygód, który pod koniec swego żywota zapragnął odpoczynku od ciągłej gonitwy. Podczas pobytu na wyspie będziemy wykonywać codzienne zadania latarnika i od czasu do czasu główny bohater będzie wspominał to co się w jego życiu do tej pory działo i co doprowadziło do tego, że został latarnikiem. Takie retrospekcje będą w formie mini-gier i każda z nich będzie inna.
Repozytorium jest prywatne i dostęp do niego mają tylko dodani członkowie projektu. 
## Instalacja
Do współtworzenia projektu należy mieć:
- założone konto na GitHubie (https://github.com/)
- zainstalowanego Gita (https://git-scm.com/download/win - przy instalacji warto wybrać inny edytor niż vim, np. Nano)
- zainstalowane Unity w wersji 2019.4.13f1 (do pobrania z UnityHub)
## Git
Zanim nastąpi pobranie projektu należy zaakceptować zaproszenie do współtworzenia projektu. Zaproszenie przychodzi na maila i tam też trzeba potwierdzić zaproszenie.
W celu pobrania projektu należy przejść do folderu, w którym chcemy mieć projekt (folder o nazwie LighthouseKeeper z projektem zostanie utworzony w nim automatycznie) i w nim uruchomić `git bash` (Prawy Przycisk Myszy > `git bash here`). Następnie wpisać komendę:
`git clone https://github.com/aweczet/LighthouseKeeper.git`
Podczas klonowania repozytorium wyskoczy okienko z logowaniem do githuba. Należy się zalogować i autoryzować gita. Dzięki temu klonowanie będzie kontynuowane, zostanie automatycznie utworzony folder z projektem i powinno to ściągnąć od razu wszystkie pliki.
Przydatne komendy gita:
- `git pull` - sprawdza czy są jakieś zmiany w repozytorium i ewentualnie pobiera wszystko co się zmieniło.
- `git status` - wyświetla status plików np. **deleted** czy **modified**. Do tego kolor czerwony oznacza, że te zmiany nie zostały oznaczone do **commitu**. Natomiast kolor zielony oznacza, że zostały oznaczone.
- `git add` - zaznacza które ze zmian chcemy będziemy chcieli potem zatwierdzić (**commit**). Np. komenda `git add file.txt` doda plik *file.txt* do listy oczekującej na **commit**. Najczęściej używana będzie komenda `git add .`, gdzie kropka oznacza wszystkie pliki. Po dodaniu możemy sprawdzić czy faktycznie zmiany zostały dodane komendą `git status`.
- `git commit -m ""` - zatwierdza dodane wcześniej zmiany wraz z wiadomością (przełącznik m - message). W cudzysłowie umieszczamy komentarz do przesyłanych plików, np. `git commit -m "Dodano model postaci"`.
- `git push` - przesyła zmiany do ogólnego repozytorium
## Unity
W UnityHub należy nacisnąć przycisk `add` i podać ścieżkę do pobranego wcześniej repozytorium.
