//Kontrahenci

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPK.Models
{
    public class MiniContractor
    {
        [JsonProperty("optimaId")]
        public int KntId { get; set; }
        [JsonProperty("grpTyp")]
        public int KntTyp { get; set; }
        [JsonProperty("akronim")]
        public string? KntKod { get; set; }
        [JsonProperty("nazwa1")]
        public string? KntNazwa1 { get; set; }
    }
    public class Contractor : MiniContractor
    {
        [JsonIgnore]
        public string? KntGrupa { get; set; }
        [JsonIgnore]
        public int? KntRodzaj { get; set; }
        [JsonIgnore]
        public string? KntDokumentTozsamosci { get; set; }
        [JsonProperty("nazwa2")]
        public string? KntNazwa2 { get; set; }
        [JsonProperty("nazwa3")]
        public string? KntNazwa3 { get; set; }
        [JsonIgnore]
        public string? KntNipKraj { get; set; }
        [JsonIgnore]
        public string? KntNip { get; set; }
        [JsonProperty("nipE")]
        public string? KntNipE { get; set; }
        [JsonIgnore]
        public string? IdSISC { get; set; }
        [JsonProperty("regon")]
        public string? KntRegon { get; set; }
        [JsonIgnore]
        public string? KntKraj { get; set; }
        [JsonProperty("miasto")]
        public string? KntMiasto { get; set; }
        [JsonIgnore]
        public string? KntPoczta { get; set; }
        [JsonProperty("ulica")]
        public string? KntUlica { get; set; }
        [JsonProperty("adres")]
        public string? KntAdres2 { get; set; }
        [JsonProperty("telefon1")]
        public string? KntTelefon1 { get; set; }
        [JsonProperty("telefon2")]
        public string? KntTelefon2 { get; set; }
        [JsonIgnore]
        public string? KntTelefonSms { get; set; }
        [JsonIgnore]
        public string? KntKrajISO { get; set; }
        [JsonProperty("wojewodztwo")]
        public string? KntWojewodztwo { get; set; }
        [JsonProperty("kodP")]
        public string? KntKodPocztowy { get; set; }
        [JsonIgnore]
        public string? KntNrDomu { get; set; }
        [JsonIgnore]
        public string? KntNrLokalu { get; set; }
        [JsonProperty("fax")]
        public string? KntFax { get; set; }
        [JsonProperty("eMail")]
        public string? KntEmail { get; set; }
        [JsonIgnore]
        public string? KntURL { get; set; }
        [JsonIgnore]
        public string? KntKorMiasto { get; set; }
        [JsonIgnore]
        public string? KntKorPoczta { get; set; }
        [JsonIgnore]
        public string? KntKorUlica { get; set; }
        [JsonIgnore]
        public string? KntKorKraj { get; set; }
        [JsonIgnore]
        public string? KntKorKodPocztowy { get; set; }
        [JsonIgnore]
        public string? KntKorNrDomu { get; set; }
        [JsonIgnore]
        public string? KntKorNrLokalu { get; set; }
        [JsonIgnore]
        public string? KntKatID { get; set; }
        [JsonIgnore]
        public string? KntKatZakID { get; set; }
        [JsonIgnore]
        public string? KntZezwolenie { get; set; }
        [JsonIgnore]
        public string? KntEAN { get; set; }
        [JsonIgnore]
        public string? KntGLN { get; set; }
        [JsonIgnore]
        public string? FPlNazwa { get; set; }
        [JsonIgnore]
        public string? KntWaluta { get; set; }
        [JsonIgnore]
        public string? NieRozliczajPlatnosc { get; set; }
        [JsonIgnore]
        public string? KntNaliczajPlatnosc { get; set; }
        [JsonIgnore]
        public string? KntSplitPay { get; set; }
        [JsonIgnore]
        public string? KntNieNaliczajOdsetek { get; set; }
        [JsonIgnore]
        public int? KntTerminPlatb { get; set; }
        [JsonIgnore]
        public int? knttermin { get; set; }
        [JsonIgnore]
        public int? KntMaxZwloka { get; set; }
        [JsonIgnore]
        public string? ListaRachBank { get; set; }
        [JsonIgnore]
        public string? KntWindykacjaSchematId { get; set; }
        [JsonIgnore]
        public string? KntWindykacjaOsobaId { get; set; }
        [JsonIgnore]
        public string? KntWindykacjaEMail { get; set; }
        [JsonIgnore]
        public string? KntWindykacjaTelefonSms { get; set; }
        [JsonIgnore]
        public string? KntPodmiotTyp { get; set; }
        [JsonIgnore]
        public string? KntExport { get; set; }
        [JsonIgnore]
        public string? KntMetodaKasowa { get; set; }
        [JsonIgnore]
        public string? KntRolnik { get; set; }
        [JsonIgnore]
        public string? KntPowiazanyUoV { get; set; }
        [JsonIgnore]
        public string? KntChroniony { get; set; }
        [JsonIgnore]
        public string? KntBlokadaDok { get; set; }
        [JsonIgnore]
        public string? KntNieaktywny { get; set; }
        [JsonIgnore]
        public string? KntLimitFlag { get; set; }
        [JsonIgnore]
        public string? KntLimitKredytu { get; set; }
        [JsonIgnore]
        public string? KntLimitKredytuWykorzystany { get; set; }
        [JsonIgnore]
        public string? KntLimitPrzeterKredytWartosc { get; set; }
        [JsonIgnore]
        public string? KntRabat { get; set; }
        [JsonIgnore]
        public string? KntOpis { get; set; }
        [JsonIgnore]
        public string? KontoDost { get; set; }
        [JsonIgnore]
        public string? KontoOdb { get; set; }
    }

    public class SQLContractor : MiniContractor
    {
        [JsonIgnore]
        public string? KntGrupa { get; set; }
        [JsonIgnore]
        public int? KntRodzaj { get; set; }
        [JsonIgnore]
        public string? KntDokumentTozsamosci { get; set; }
        [JsonProperty("nazwa2")]
        public string? KntNazwa2 { get; set; }
        [JsonProperty("nazwa3")]
        public string? KntNazwa3 { get; set; }
        [JsonIgnore]
        public string? KntNipKraj { get; set; }
        [JsonIgnore]
        public string? KntNip { get; set; }
        [JsonProperty("nipE")]
        public string? KntNipE { get; set; }
        [JsonIgnore]
        public string? IdSISC { get; set; }
        [JsonProperty("regon")]
        public string? KntRegon { get; set; }
        [JsonIgnore]
        public string? KntKraj { get; set; }
        [JsonProperty("miasto")]
        public string? KntMiasto { get; set; }
        [JsonIgnore]
        public string? KntPoczta { get; set; }
        [JsonProperty("ulica")]
        public string? KntUlica { get; set; }
        [JsonProperty("adres")]
        public string? KntAdres2 { get; set; }
        [JsonProperty("telefon1")]
        public string? KntTelefon1 { get; set; }
        [JsonProperty("telefon2")]
        public string? KntTelefon2 { get; set; }
        [JsonIgnore]
        public string? KntTelefonSms { get; set; }
        [JsonIgnore]
        public string? KntKrajISO { get; set; }
        [JsonProperty("wojewodztwo")]
        public string? KntWojewodztwo { get; set; }
        [JsonProperty("kodP")]
        public string? KntKodPocztowy { get; set; }
        [JsonIgnore]
        public string? KntNrDomu { get; set; }
        [JsonIgnore]
        public string? KntNrLokalu { get; set; }
        [JsonProperty("fax")]
        public string? KntFax { get; set; }
        [JsonProperty("eMail")]
        public string? KntEmail { get; set; }
        [JsonIgnore]
        public string? KntURL { get; set; }
        [JsonIgnore]
        public string? KntKorMiasto { get; set; }
        [JsonIgnore]
        public string? KntKorPoczta { get; set; }
        [JsonIgnore]
        public string? KntKorUlica { get; set; }
        [JsonIgnore]
        public string? KntKorKraj { get; set; }
        [JsonIgnore]
        public string? KntKorKodPocztowy { get; set; }
        [JsonIgnore]
        public string? KntKorNrDomu { get; set; }
        [JsonIgnore]
        public string? KntKorNrLokalu { get; set; }
        [JsonIgnore]
        public string? KntKatID { get; set; }
        [JsonIgnore]
        public string? KntKatZakID { get; set; }
        [JsonIgnore]
        public string? KntZezwolenie { get; set; }
        [JsonIgnore]
        public string? KntEAN { get; set; }
        [JsonIgnore]
        public string? KntGLN { get; set; }
        [JsonIgnore]
        public string? FPlNazwa { get; set; }
        [JsonIgnore]
        public string? KntWaluta { get; set; }
        [JsonIgnore]
        public string? NieRozliczajPlatnosc { get; set; }
        [JsonIgnore]
        public string? KntNaliczajPlatnosc { get; set; }
        [JsonIgnore]
        public string? KntSplitPay { get; set; }
        [JsonIgnore]
        public string? KntNieNaliczajOdsetek { get; set; }
        [JsonIgnore]
        public int? KntTerminPlatb { get; set; }
        [JsonIgnore]
        public int? knttermin { get; set; }
        [JsonIgnore]
        public int? KntMaxZwloka { get; set; }
        [JsonIgnore]
        public string? ListaRachBank { get; set; }
        [JsonIgnore]
        public string? KntWindykacjaSchematId { get; set; }
        [JsonIgnore]
        public string? KntWindykacjaOsobaId { get; set; }
        [JsonIgnore]
        public string? KntWindykacjaEMail { get; set; }
        [JsonIgnore]
        public string? KntWindykacjaTelefonSms { get; set; }
        [JsonIgnore]
        public string? KntPodmiotTyp { get; set; }
        [JsonIgnore]
        public string? KntExport { get; set; }
        [JsonIgnore]
        public string? KntMetodaKasowa { get; set; }
        [JsonIgnore]
        public string? KntRolnik { get; set; }
        [JsonIgnore]
        public string? KntPowiazanyUoV { get; set; }
        [JsonIgnore]
        public string? KntChroniony { get; set; }
        [JsonIgnore]
        public string? KntBlokadaDok { get; set; }
        [JsonIgnore]
        public string? KntNieaktywny { get; set; }
        [JsonIgnore]
        public string? KntLimitFlag { get; set; }
        [JsonIgnore]
        public string? KntLimitKredytu { get; set; }
        [JsonIgnore]
        public string? KntLimitKredytuWykorzystany { get; set; }
        [JsonIgnore]
        public string? KntLimitPrzeterKredytWartosc { get; set; }
        [JsonIgnore]
        public string? KntRabat { get; set; }
        [JsonIgnore]
        public string? KntOpis { get; set; }
        [JsonIgnore]
        public string? KontoDost { get; set; }
        [JsonIgnore]
        public string? KontoOdb { get; set; }
    }



    //public class Contractor : MiniContractor
    //{

    //    public int? KntGIDTyp { get; set; }
    //    public int? KntGIDFirma { get; set; }
    //    public int? KntGIDLp { get; set; }
    //    public int? KntKnATyp { get; set; }
    //    public int? KntKnAFirma { get; set; }
    //    public int? KntKnANumer { get; set; }
    //    public int? KntKnALp { get; set; }
    //    public int? KntTyp { get; set; }
    //    public int? KntAkwizytor { get; set; }
    //    public string? KntAkronim { get; set; }
    //    public string? KntAkronimFormat { get; set; }
    //    public string? KntFppKod { get; set; }
    //    public string? KntNazwa1 { get; set; }
    //    public string? KntNazwa2 { get; set; }
    //    public string? KntNazwa3 { get; set; }
    //    public string? KntKodP { get; set; }
    //    public string? KntMiasto { get; set; }
    //    public string? KntUlica { get; set; }
    //    public string? KntAdres { get; set; }
    //    public string? KntNipE { get; set; }
    //    public string? KntNip { get; set; }
    //    public string? KntRegon { get; set; }
    //    public string? KntPesel { get; set; }
    //    public string? KntKontoDostawcy { get; set; }
    //    public string? KntKontoOdbiorcy { get; set; }
    //    public string? KntKraj { get; set; }
    //    public string? KntTelefon1 { get; set; }
    //    public string? KntTelefon2 { get; set; }
    //    public string? KntFax { get; set; }
    //    public string? KntModem { get; set; }
    //    public string? KntTelex { get; set; }
    //    public string? KntEMail { get; set; }
    //    public string? KntURL { get; set; }
    //    public int? KntBnkTyp { get; set; }
    //    public int? KntBnkFirma { get; set; }
    //    public int? KntBnkNumer { get; set; }
    //    public int? KntBnkLp { get; set; }
    //    public string? KntNrRachunku { get; set; }
    //    public string? KntSoundex { get; set; }
    //    public decimal? KntRabat { get; set; }
    //    public int? KntLimitWart { get; set; }
    //    public int? KntMaxLimitWart { get; set; }
    //    public int? KntLimitPoTerminie { get; set; }
    //    public int? KntLimitOkres { get; set; }
    //    public int? KntDewizowe { get; set; }
    //    public string? KntSymbol { get; set; }
    //    public int? KntNrKursu { get; set; }
    //    public int? KntCena { get; set; }
    //    public int? KntFormaPl { get; set; }
    //    public int? KntFORMAPLZAK { get; set; }
    //    public int? KntMarza { get; set; }
    //    public int? KntTypKarty { get; set; }
    //    public string? KntNumerKarty { get; set; }
    //    public int? KntDataKarty { get; set; }
    //    public string? KntEan { get; set; }
    //    public int? KntObcaKarta { get; set; }
    //    public int? KntEanTyp { get; set; }
    //    public int? KntEanFirma { get; set; }
    //    public int? KntEanNumer { get; set; }
    //    public int? KntOsoba { get; set; }
    //    public int? KntExpoKraj { get; set; }
    //    public string? KntSeriaFa { get; set; }
    //    public int? KntPlatnikVat { get; set; }
    //    public int? KntTypDok { get; set; }
    //    public int? KntStatus { get; set; }
    //    public int? KntKoncesja { get; set; }
    //    public int? KntDataKoncesji { get; set; }
    //    public int? KntFAVATData { get; set; }
    //    public int? KntSposobDostawy { get; set; }
    //    public string? KntHasloChk { get; set; }
    //    public string? KntHasloKontrahent { get; set; }
    //    public int? KntDzialalnosc { get; set; }
    //    public int? KntZTrTyp { get; set; }
    //    public int? KntZTrFirma { get; set; }
    //    public int? KntZTrNumer { get; set; }
    //    public int? KntZTrLp { get; set; }
    //    public int? KntOpeTyp { get; set; }
    //    public int? KntOpeFirma { get; set; }
    //    public int? KntOpeNumer { get; set; }
    //    public int? KntOpeLp { get; set; }
    //    public int? KntAkwTyp { get; set; }
    //    public int? KntAkwFirma { get; set; }
    //    public int? KntAkwNumer { get; set; }
    //    public int? KntAkwLp { get; set; }
    //    public int? KntPrcTyp { get; set; }
    //    public int? KntPrcFirma { get; set; }
    //    public int? KntPrcNumer { get; set; }
    //    public int? KntPrcLp { get; set; }
    //    public string? KntAtrybut1 { get; set; }
    //    public int? KntFormat1 { get; set; }
    //    public string? KntWartosc1 { get; set; }
    //    public string? KntAtrybut2 { get; set; }
    //    public int? KntFormat2 { get; set; }
    //    public string? KntWartosc2 { get; set; }
    //    public string? KntAtrybut3 { get; set; }
    //    public int? KntFormat3 { get; set; }
    //    public string? KntWartosc3 { get; set; }
    //    public int? KntAkwProwizja { get; set; }
    //    public string? KntUmowa { get; set; }
    //    public int? KntDataW { get; set; }
    //    public int? KntLastModL { get; set; }
    //    public int? KntLastModO { get; set; }
    //    public int? KntLastModC { get; set; }
    //    public string? KntFaVATOsw { get; set; }
    //    public string? KntCechaOpis { get; set; }
    //    public int? KntAutoPotwierdzenie { get; set; }
    //    public int? KntAktywna { get; set; }
    //    public int? KntWsk { get; set; }
    //    public int? KntMagTyp { get; set; }
    //    public int? KntMagFirma { get; set; }
    //    public int? KntMagNumer { get; set; }
    //    public int? KntMagLp { get; set; }
    //    public string? KntOutlookUrl { get; set; }
    //    public int? KntNieaktywny { get; set; }
    //    public int? KntZrodlo { get; set; }
    //    public int? KntBranza { get; set; }
    //    public int? KntRodzaj { get; set; }
    //    public int? KntRolaPartnera { get; set; }
    //    public int? KntOdleglosc { get; set; }
    //    public int? KntKarTyp { get; set; }
    //    public int? KntKarFirma { get; set; }
    //    public int? KntKarNumer { get; set; }
    //    public int? KntKarLp { get; set; }
    //    public int? KNTKnPTyp { get; set; }
    //    public int? KNTKnPNumer { get; set; }
    //    public int? KNTKnPParam { get; set; }

    //    //KntKntId KntKod KntNazwa KntNipE KntNipKraj KntNipPelny KntEAN KntKodPocztowy KntMiasto  ntUlica KntTelefon1 KntOpis Naleznosci Zobowiazania KodyJPKV7 KntNazwa1 KntGrupa KntNieaktywny KntNadID KntNip KRDStatus KRDMonitoring JestPrzeterminowanaNaleznosc JestPrzeterminowaneZobowiazanie
    //}

}
