//Kontrahenci

namespace CPK.Models
{
    public class PropertyEventArgs : EventArgs
    {
        public PropertyEventArgs(string Name, string _json)
        {
            PropertyName = Name;
            Json = _json;
        }
        public string PropertyName { get; set; }
        public string Json { get; set; }
    }





    //public class MerchandiseCard
    //{
    //    public int? TwrGIDTyp { get; set; }
    //    public int? TwrGIDFirma { get; set; }
    //    public int? TwrGIDNumer { get; set; }
    //    public int? TwrGIDLp { get; set; }
    //    public int? TwrTyp { get; set; }
    //    public string? TwrKod { get; set; }
    //    public string? TwrKodFormat { get; set; }
    //    public string? TwrFPPKod { get; set; }
    //    public string? TwrNazwa { get; set; }
    //    public string? TwrNazwa1 { get; set; }
    //    public string? TwrCertyfikat { get; set; }
    //    public string? TwrSww { get; set; }
    //    public string? TwrEan { get; set; }
    //    public string? TwrJm { get; set; }
    //    public int? TwrWaga { get; set; }
    //    public string? TwrWJm { get; set; }
    //    public int? TwrJmFormat { get; set; }
    //    public decimal? TwrIloscZam { get; set; }
    //    public decimal? TwrIloscMin { get; set; }
    //    public decimal? TwrIloscMax { get; set; }
    //    public int? TwrUbytek { get; set; }
    //    public int? TwrProg { get; set; }
    //    public int? TwrUpust { get; set; }
    //    public int? TwrUpustData { get; set; }
    //    public DateTime? TwrUpustDataOd { get; set; }
    //    public DateTime? TwrUpustDataDo { get; set; }
    //    public int? TwrUpustGodz { get; set; }
    //    public TimeOnly? TwrUpustGodzOd { get; set; }
    //    public TimeOnly? TwrUpustGodzDo { get; set; }
    //    public int? TwrAutoZam { get; set; }
    //    public int? TwrIloscAZam { get; set; }
    //    public int? TwrCzasDst { get; set; }
    //    public int? TwrCenaSpr { get; set; }
    //    public int? TwrJmDomyslna { get; set; }
    //    public int? TWRJMDomyslnaZak { get; set; }
    //    public int? TwrDstDomyslny { get; set; }
    //    public int? TwrRozliczMag { get; set; }
    //    public int? TwrZakup { get; set; }
    //    public int? TwrSprzedaz { get; set; }
    //    public string? TwrGrupaPod { get; set; }
    //    public int? TwrAkcyza { get; set; }
    //    public int? TwrOpeTyp { get; set; }
    //    public int? TwrOpeFirma { get; set; }
    //    public int? TwrOpeNumer { get; set; }
    //    public int? TwrOpeLp { get; set; }
    //    public int? TwrPrcTyp { get; set; }
    //    public int? TwrPrcFirma { get; set; }
    //    public int? TwrPrcNumer { get; set; }
    //    public int? TwrPrcLp { get; set; }
    //    public int? TwrKontaktTyp { get; set; }
    //    public int? TwrKontaktZa { get; set; }
    //    public int? TwrKontaktJC { get; set; }
    //    public int? TwrOkresowy { get; set; }
    //    public string? TwrCel { get; set; }
    //    public string? TwrAtrybut1 { get; set; }
    //    public int? TwrFormat1 { get; set; }
    //    public string? TwrWartosc1 { get; set; }
    //    public string? TwrAtrybut2 { get; set; }
    //    public int? TwrFormat2 { get; set; }
    //    public string? TwrWartosc2 { get; set; }
    //    public string? TwrAtrybut3 { get; set; }
    //    public int? TwrFormat3 { get; set; }
    //    public string? TwrWartosc3 { get; set; }
    //    public int? TwrPunkty { get; set; }
    //    public int? TwrKoncesja { get; set; }
    //    public string? TwrKonto1 { get; set; }
    //    public string? TwrKonto2 { get; set; }
    //    public string? TwrKonto3 { get; set; }
    //    public string? TwrPolozenie { get; set; }
    //    public string? TwrKatalog { get; set; }
    //    public int? TwrWCenniku { get; set; }
    //    public int? TwrEdycjaNazwy { get; set; }
    //    public int? TwrBezRabatu { get; set; }
    //    public int? TwrKopiujOpis { get; set; }
    //    public string? TwrURL { get; set; }
    //    public string? TwrWarunek { get; set; }
    //    public int? TwrObjetoscL { get; set; }
    //    public int? TwrObjetoscM { get; set; }
    //    public int? TwrLastModL { get; set; }
    //    public int? TwrLastModO { get; set; }
    //    public int? TwrLastModC { get; set; }
    //    public int? TwrTerminZwrotu { get; set; }
    //    public int? TwrZakupAutoryz { get; set; }
    //    public int? TwrMagTyp { get; set; }
    //    public int? TwrMagFirma { get; set; }
    //    public int? TwrMagNumer { get; set; }
    //    public int? TwrMagLp { get; set; }
    //    public decimal? TwrMarzaMin { get; set; }
    //    public decimal? TwrKosztUslugi { get; set; }
    //    public int? TwrKosztUTyp { get; set; }
    //    public int? TwrClo { get; set; }
    //    public int? TwrPodatekImp { get; set; }
    //    public int? TwrStanInfoLimit { get; set; }
    //    public int? TwrStanInfoMax { get; set; }
    //    public int? TwrStanInfoProcent { get; set; }
    //    public int? TwrAktywna { get; set; }
    //    public int? TwrWsk { get; set; }
    //    public int? TwrCCKTyp { get; set; }
    //    public int? TwrCCKFirma { get; set; }
    //    public int? TwrCCKNumer { get; set; }
    //    public int? TwrCCKLp { get; set; }
    //    public int? TwrPrdTyp { get; set; }
    //    public int? TwrPrdFirma { get; set; }
    //    public int? TwrPrdNumer { get; set; }
    //    public int? TwrPrdLp { get; set; }
    //    public int? TwrOpeTypM { get; set; }
    //    public int? TwrOpeFirmaM { get; set; }
    //    public int? TwrOpeNumerM { get; set; }
    //    public int? TwrOpeLpM { get; set; }
    //    public string? TwrPCN { get; set; }
    //    public int? TwrNotowania { get; set; }
    //    public int? TwrWagaBrutto { get; set; }
    //    public string? TwrWJmBrutto { get; set; }
    //    public string? TwrGrupaPodSpr { get; set; }
    //    public int? TwrLicencja { get; set; }

    //}
}
