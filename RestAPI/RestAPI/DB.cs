using RestAPI.Models;

namespace RestAPI;

public class DB
{
    public static List<Zwierz> Zwierzeta = new()
    {
        new Zwierz { Id = 1, Name = "Kotek", Kat = "kot", Waga = 1.1, Kolor = "biały" },
        new Zwierz { Id = 2, Name = "Dziku", Kat = "pies", Waga = 4.5, Kolor = "czarny" },
        new Zwierz { Id = 3, Name = "Sparkle", Kat = "lis", Waga = 8.1, Kolor = "czerwono-rudy" },
    };

    public static List<Wizyta> Wizyty = new()
    {
    };
}