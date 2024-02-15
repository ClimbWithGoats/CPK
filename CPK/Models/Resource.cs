//Kontrahenci

using Newtonsoft.Json;

namespace CPK.Models
{
    public class Resource
    {
        [JsonProperty("OptimaId")]
        public int? TwrTwrId { get; set; }
        [JsonProperty("Kod")]
        public string? TwrKod { get; set; }
        [JsonProperty("Nazwa")]
        public string? TwrNazwa { get; set; }
        [JsonProperty("JM")]
        public string? TwrJM { get; set; }
        [JsonIgnore]
        public string? TwrTypS { get; set; }
        [JsonIgnore]
        public string? TwrNumerKat { get; set; }
        [JsonProperty("EAN")]
        public string? TwrEAN { get; set; }
        [JsonIgnore]
        public string? TwrKodDostawcy { get; set; }
        [JsonIgnore]
        public string? KntKod { get; set; }
        [JsonIgnore]
        public int? StanZasobu { get; set; }
        [JsonIgnore]
        public decimal? TwIIlosc { get; set; }
        [JsonIgnore]
        public decimal? TwIRezerwacje { get; set; }
        [JsonIgnore]
        public decimal? TwIBraki { get; set; }
        [JsonIgnore]
        public decimal? TwIZamowienia { get; set; }
        [JsonIgnore]
        public decimal? TwIBrakiPozostale { get; set; }
        [JsonIgnore]
        public decimal? TwIIloscDost { get; set; }
        [JsonIgnore]
        public decimal? TwCWartosc { get; set; }
        [JsonIgnore]
        public string? TwCWaluta { get; set; }
        [JsonIgnore]
        public decimal? TwrWartoscPLN { get; set; }
        [JsonIgnore]
        public decimal? TwrWartoscWal { get; set; }
        [JsonIgnore]
        public decimal? TwrWartoscCalosciPLN { get; set; }
        [JsonIgnore]
        public decimal? TwIWartosc { get; set; }
        [JsonIgnore]
        public decimal? KCNKod { get; set; }
        [JsonIgnore]
        public decimal? KV7Kod { get; set; }
        [JsonIgnore]
        public int? TwCTyp { get; set; }
        [JsonProperty("Typ")]
        public int? TwrTyp { get; set; }
        [JsonProperty("Kaucja")]
        public int? TwrKaucja { get; set; }
        [JsonIgnore]
        public int? TwrProdukt { get; set; }
        [JsonIgnore]
        public int? TwrKosztUslugiTyp { get; set; }
        [JsonIgnore]
        public int? TwrNieAktywny { get; set; }
        [JsonIgnore]
        public int? TwCTwCNumer { get; set; }
        [JsonIgnore]
        public int? TwCZVTwCNumer { get; set; }
        [JsonIgnore]
        public int? TwrGidNumer { get; set; }
    }

}
