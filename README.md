Projekt przedstawia aplikację konsolową, której zadaniem jest obsługa uczelnianej wypożyczalni sprzętu. 
System umożliwia:
-dodawanie użytkowników
-dodawanie sprzętu 
-wyświetlanie listy sprzętu
-wyświetlanie dostępnego sprzętu
-wypożyczanie sprzętu użytkownikowi
-zwrot sprzętu wraz z ewentualnym naliczeniem kary
-oznaczanie sprzętu jako niedostępnego
-wyświetlanie aktywnych wypożyczeń użytkownika
-wyświetlanie listy przeterminowanych wypożyczeń
-generowanie raportu podsumowującego stan wypożyczalni

Struktura projektu:
Kod został podzielony na klasy domenowe oraz klasy serwisowe w celu rozdzielenia odpowiedzialności systemu
Klasy domenowe reprezentują rzeczywiste obiekty systemu, natomiast klasy serwisowe realizują operacje na tych obiektach.

(Domenowe) Klasy przechowujące dane oraz podstawową logikę pojedynczych obiektów:
Device.cs
Laptop.cs
Camera.cs
Projector.cs
User.cs
Student.cs
Employee.cs
Rental.cs

(Serwisowe) Klasy odpowiedzialne za operacje systemowe:
DeviceService.cs
UserService.cs
RentalService.cs
ReportService.cs

Interfejs użytkownika:
program.cs

Odpowiedzialności klas
Device -	reprezentuje sprzęt
Laptop / Camera / Projector -	rozszerzają właściwości sprzętu
User -	reprezentuje użytkownika
Student / Employee	- określają limity wypożyczeń
Rental	- reprezentuje pojedyncze wypożyczenie
DeviceService -	zarządza sprzętem
UserService	- zarządza użytkownikami
RentalService	- obsługuje proces wypożyczeń
ReportService	- generuje raport systemowy

W projekcie starano się zachować kohezję poprzez przypisanie każdej klasie jednej głównej odpowiedzialności.
Przykład:
klasa Device
odpowiada za:
-identyfikator sprzętu
-nazwę sprzętu
-status dostępności urządzeń

Sprzężenie pomiędzy klasami zostało ograniczone poprzez zastosowanie klas serwisowych jako warstwy pośredniej, dzięki temu zmiana implementacji logiki biznesowej nie wymaga zmian w interfejsie użytkownika.
Dziedziczenie zostało zastosowane w przypadkach użytkowników i sprzętu:
Klasy:
-Laptop
-Camera
-Projector
Dziedziczą po klasie Device
Klasy:
-Student
-Emplyee
Dziedziczą po klasie User
