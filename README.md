 # Bibliotekssystem 2.0

  Ett bibliotekssystem byggt med C# och .NET 10, utvecklat med TDD (Test-Driven Development).
  Del 2 lägger till Entity Framework Core, SQLite-databas och ett Blazor-webbgränssnitt.

  ## Köra projektet

  ### Blazor-webbappen
  ```bash
  dotnet run --project LibrarySystem.Web
  ```
  Öppna sedan `https://localhost:5001` i webbläsaren.

  ### Köra testerna
  ```bash
  dotnet test
  ```

  ## Projektstruktur

  | Projekt | Beskrivning |
  |---------|-------------|
  | `LibrarySystem.Core` | Domänklasser: Book, Member, Loan |
  | `LibrarySystem.Data` | DbContext, repositories, services |
  | `LibrarySystem.Web` | Blazor-webbgränssnitt |
  | `BiblioteksystemTests` | xUnit + bUnit tester |

  ## Databasmodell

  ### Tabeller

  | Tabell | Kolumner |
  |--------|----------|
  | Books | Id, ISBN, Title, Author, PublishedYear, IsAvailable |
  | Members | Id, Name, MembershipID, CanBorrow |
  | Loans | Id, BookId, MemberId, LoanDate, DueDate, IsReturned |

  ### Relationer
  - En **Book** kan ha många **Loans**
  - En **Member** kan ha många **Loans**
  - Ett **Loan** tillhör en Book och en Member

  ## Blazor-sidor

  | Sida | URL | Beskrivning |
  |------|-----|-------------|
  | Hem | `/` | Startsida med navigering |
  | Böcker | `/books` | Lista, sök, lägg till och ta bort böcker |
  | Bokdetaljer | `/books/{id}` | Detaljinfo, lånehistorik och låna bok |
  | Medlemmar | `/members` | Lista, lägg till och ta bort medlemmar |
  | Lån | `/loans` | Hantera aktiva lån, returnera och ta bort |

  ## Tester

  - 52 enhetstester som passerar
  - Repository-tester med EF InMemory-databas
  - Blazor-komponenttester med bUnit och Moq

  ## Tekniker

  - C# / .NET 10
  - Entity Framework Core med SQLite
  - Blazor Server
  - xUnit, bUnit, Moq
  - Bootstrap 5
  - TDD (Test-Driven Development)
  - Repository Pattern + Service Layer

  ## Screenshots

  ![Hem](screenshots/Home.png)
  ![Böcker](screenshots/Books.png)
  ![Bokdetaljer](screenshots/Bookdetails.png)
  ![Medlemmar](screenshots/Members.png)
  ![Lån](screenshots/Loans.png)