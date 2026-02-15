# Bibliotekssystem

Ett bibliotekssystem byggt med C# och .NET 8, utvecklat med TDD (Test-Driven Development).

## Funktioner

- Visa alla bocker med tillganglighetsstatus
- Sok bocker via titel
- Lana och returnera bocker
- Visa medlemmar
- Statistik (antal bocker, utlanade, medlemmar, lan)
- Forseningsavgifter (10 kr per dag)
- Maxgrans for lan (3 bocker per medlem)
- Sortering av bocker (titel, ar)

## Projektstruktur

### Klasser

| Klass | Beskrivning |
|-------|-------------|
| `Book` | Representerar en bok med ISBN, titel, forfattare och tillganglighet |
| `Member` | Representerar en biblioteksmedlem med lanerattiggheter |
| `Loan` | Representerar ett lan med forfallodatum och forseningsavgift |
| `BookCatalog` | Hanterar boksamlingen med sok- och sorteringsfunktionalitet |
| `MemberRegistry` | Hanterar medlemsregistret med sokfunktionalitet |
| `LoanManager` | Hanterar utlaning och retur med affarsregler |
| `ISearchable<T>` | Generiskt interface for sokbara samlingar |

### Affarsregler

- Endast tillgangliga bocker kan lanas
- Medlemmen maste ha lanerattiggheter (`CanBorrow`)
- Max 3 bocker per medlem
- Forseningsavgift: 10 kr per dag efter forfallodatum
- Lanetid: 14 dagar

## Kor programmet

```bash
dotnet run --project Bibliotekssytem
```

## Kor testerna

```bash
dotnet test
```

### Teststatistik

- 35 enhetstester
- Anvander xUnit med `[Fact]` och `[Theory]`
- Foljer AAA-monster (Arrange, Act, Assert)
- Tacker edge cases och felhantering

## Tekniker

- C# / .NET 8
- xUnit (testramverk)
- TDD (Test-Driven Development)
- LINQ (lambda-uttryck)
- Generiskt interface (`ISearchable<T>`)
- Komposition
- Guard clauses och try-catch felhantering
