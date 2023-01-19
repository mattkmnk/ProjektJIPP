Kompozyt - Wzorzec polegający na komponowaniu obiektów w drzewa, gdzie użytkownik korzysta jedynie z udostępnionego interfejsu. 
    Drzewo składa się z liści i kontenerów, przy czym każdy kontener może być złożony z liści lub kolejnych kontenerów które współdzielą jedynie interfejs.
    Kontenery rekurencyjnie wywołują określone metody, a zwracają jedynie sumę wszystkich wywołań.
    Klient korzystając z obiektów nie musi znać wszystkich podlegających pod obiekt struktur, niezależnie czy są one proste czy złożone.
    Przykład:
        Obiekty graficzne mogą składać się z innych obiektów graficznych albo figur prostych.
        Trójkąt składa się z 3 linii <kontener>
        Linia składa się z 2 punktów <kontener>
        Punkt jest figurą prostą <liść>
        Trójkąt.Draw() +-> Linia.Draw() +-> Punky.Draw();
                       |                +-> Punkt.Draw();
                       |
                       +-> Linia.Draw() +-> Punkt.Draw();
                       |                +-> Punkt.Draw();
                       |
                       +-> Linia.Draw() +-> Punkt.Draw();
                                        +-> Punkt.Draw();

        Z trójkątów możemy tworzyć dalsze obiekty graficzne, wymagane jest tylko zaimplementowanie tego samego interfejsu (Draw())

    Stosowany w wypadku gdy potrzebujemy traktować wiele elementów w ten sam sposób, a dodatkowo możemy je łączyć w większe paczki. 
    W .NET np. przy kontrolkach w interfejsie graficznym.

Obserwator - Wzorzec polegający na wysyłaniu sygnału o zaistnieniu pewnej sytuacji do wszystkich komponentów które powinny obsłużyć tę sytuację w określony
    sposób. Struktura składa się z Subject (W momencie wystąpienia eventu wysyła sygnał do wszystkich subskrybentów) 
    i Observers (Otrzymują sygnał od Subjecta i go obsługują). Używany gdy zmiana stanu jednego obiektu wpływa na wiele innych, dzięki niemu pozbywamy się wielu zależności
    W języku C# istnieje typ delegata i event których działanie odzwierciedla wzorzec Obserwatora.
    Wykorzystywany np. w sytuacji w której wykorzystujemy różne źródła danych, i w momencie w którym ulegną one zmianie musimy odświeżyć widok aby wyświetlić
    te aktualne.

Strategia - Polega na wyodrębnieniu algorytmów wykonujących określone zadania do różnych klas zwanych strategiami. Pozwala na odizolowanie logiki biznesowej
    od implementacji algorytmów. Dzięki wykorzystaniu tego samego interfejsu możemy łatwo podmieniać wykorzystany algorytm bez ingerencji w logikę aplikacji.
    Klient posiada referencje do aktualnie używanej strategii oraz funkcję która pozwala na jej zmianę.
    Przykładem może być kompresja plików do różnych formatów zależnie od wymagań (ZIP, RAR, 7Z) wykorzystując różne algorytmy przy użyciu tego samego interfejsu.
    Innym przykładem jest sortowanie danych, w przypadku którego jedynie podmieniamy wykorzystywany sposób sortowania zależnie od rodzaju danych.

Metoda Wytwórcza - Wzorzec kreacyjny w którym kontrolę nad tworzeniem obiektu oddajemy klasie wytwórczej zwracającej żądany przez nas obiekt.
    Metoda ta jest udostępniania przez klasę bazową, aczkolwiek sama może zwracać obiekty jej podtypów zależnie od np. parametrów wejściowych.
    Samym tworzeniem egzemplarzy obiektu zajmują się podklasy. Interfejsy określają możliwe do stworzenia klasy oraz ogólną funkcję np. Create()
    a od nich wyprowadza się konkretne klasy typów wraz z funkcjami wytwórczymi które dostarczają odpowiednią implementację metody tworzenia.
    Przydaje się w sytuacjach gdy ilość parametrów w konstruktorze klasy jest duża co utrudniałoby jej użycie.
    Przykład wykorzystania: Tworzenie odpowiednich przeciwników w grze przy użyciu Enemy.Create(enemyType) zależnie od danych w pliku wejściowym

Dekorator - Wzorzec strukturalny polegający na opakowaniu oryginalnej klasy w klasę dekoratora a pozwalający na przyłączanie nowych funkcjonalności
    do obiektów dzięki pośredniej klasie dekoratora. Stosowany do rozszerzania funkcjonalności klas dzięki interfejsom i klasom abstrakcyjnym bez konieczności modyfikowania kodu używanego przez klienta.
    Dodatkowo w przeciwieństwie do dziedziczenia jesteśmy w stanie stworzyć obiekt dekoratora w trakcie wykonywania programu i wprowadzić dynamicznie rozszerzenie         klasy.
    W .NET core używany przy np. rozszerzaniu działania kontrolek w interfejsie graficznym 
