namespace RestAPI.Models;

public class Wizyta
{
    public DateTime Data { get; set; }
    public Zwierz Zwierze { get; set; }
    public string Opis { get; set; }
    public double Cena { get; set; }
}