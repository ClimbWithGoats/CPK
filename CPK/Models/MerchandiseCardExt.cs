//Kontrahenci

using CPK.Models;
using Newtonsoft.Json;

namespace CPK.Models
{
    public class MerchandiseCardExt : MerchandiseCard
    {


        public MerchandiseCardExt(MerchandiseCard mc)
        {
            base.PropertyChanged += DeserializeJson;
            base.Initialize(mc);
            base.PropertyChanged -= DeserializeJson;

        }

        private void DeserializeJson(object sender, PropertyEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(ListaCen)))
            {
                ListaCen = JsonConvert.DeserializeObject<List<RootCDNDEFCeny>>(e.Json) ?? new List<RootCDNDEFCeny>();
            }
            else if (e.PropertyName.Equals(nameof(StawkiVAT)))
            {
                StawkiVAT = JsonConvert.DeserializeObject<List<RootStawkiVAT>>(e.Json) ?? new List<RootStawkiVAT>();

            }
            else if (e.PropertyName.Equals(nameof(PomJednMiary)))
            {
                PomJednMiary = JsonConvert.DeserializeObject<List<RootPomJednMiary>>(e.Json) ?? new List<RootPomJednMiary>();
            }
            else if (e.PropertyName.Equals(nameof(KodyEan)))
            {
                KodyEan = JsonConvert.DeserializeObject<List<RootKodyEan>>(e.Json) ?? new List<RootKodyEan>();
            }
            else if (e.PropertyName.Equals(nameof(Grupy)))
            {

                Grupy = JsonConvert.DeserializeObject < List<RootGrupy>>(e.Json) ?? new List<RootGrupy>();
            }
        }

        public new List<RootCDNDEFCeny>? ListaCen { get; set; }
        public new List<RootStawkiVAT>? StawkiVAT { get; set; }
        public new List<RootPomJednMiary>? PomJednMiary { get; set; }
        public new List<RootKodyEan>? KodyEan { get; set; }
        public new List<RootGrupy>? Grupy { get; set; }


    }
    public class CDNDEFCeny
    {
        public int? TypCeny { get; set; }
        public int? TwCNieaktywna { get; set; }
        public decimal? DfcZaokraglenie { get; set; }
        public decimal? Offset { get; set; }
        public decimal? CenaNetto { get; set; }
        public decimal? CenaBrutto { get; set; }
        public string? DfCWaluta { get; set; }
    }

    public class RootCDNDEFCeny
    {
        public int? TwcNumer { get; set; }
        public decimal? TwcMarza { get; set; }
        public decimal? Wartosc { get; set; }
        public List<CDNDEFCeny> CDNDEFCeny { get; set; } = new List<CDNDEFCeny>();
    }



    public class RootStawkiVAT
    {
        public List<RootStawkiVAT>? StawkiVAT { get; set; }
    }
    public class Stawki_VAT
    {
        public int? Id { get; set; }
        public string? KodKraju { get; set; }
        public string? NazwaKraju { get; set; }
        public decimal? Stawka { get; set; }
    }
    public class RootPomJednMiary
    {
        public List<RootPomJednMiary>? PomJednMiary { get; set; }
}
public class PomJednMiary
    {
        public int? Id { get; set; }
        public string? JednostkaPomocnicza { get; set; }
        public decimal? Licznik { get; set; }
        public int? Mianownik { get; set; }
        public string? Przelicznik { get; set; }
        public int? TwJZ_CenaJednostkowa { get; set; }
        public int? Wysokosc { get; set; }
        public int? Szerokosc { get; set; }
        public int? Dlugosc { get; set; }
    }
public class RootKodyEan
    {
        public List<RootKodyEan>? KodyEan { get; set; }
    }  public class KodyEan
    {
        public int? Id { get; set; }
        public string? KodEAN { get; set; }
        public string? Opis { get; set; }
        public string? Jednostka { get; set; }
        public int? Domyslny { get; set; }
    }


public class RootGrupy
    {
        public List<RootGrupy>? Grupy { get; set; }
    } public class Grupy
    {
        public int? TwGID { get; set; }
        public string? Sciezka { get; set; }
        public string? Nazwa { get; set; }
        public string? Kod { get; set; }
    }
}
