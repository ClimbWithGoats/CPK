//Kontrahenci

using Newtonsoft.Json;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CPK.Models
{
    public class BaseDocument : BaseOptimaProperty
    {

        [JsonProperty("OptimaId")]
        public int? TrnId { get; set; }
        [JsonProperty("NumerPelny")]
        public string? TrnNumerPelny { get; set; }
        [JsonProperty("NumerString")]
        public string? TrnNumerString { get; set; }
        [JsonProperty("NumeracjaDok")]
        public string? NumeracjaDok { get; set; }
        [JsonProperty("OptimaTyp")]
        public string? Rodzaj { get; set; }
        [JsonProperty("Akronim")]
        public string? Akronim { get; set; }
        [JsonIgnore]
        public int? TrnNumer { get; set; }
        [JsonIgnore]
        public int? TrnAnulowany { get; set; }
        [JsonIgnore]
        public DateTime? DataOperacji { get; set; }
        [JsonProperty("TrnDataOperacji")]
        public int? TrnDataOperacji { get; set; }
        public string? MagSymbol { get; set; }
        [JsonIgnore]
        public string? NazwaPodmiotu { get; set; }
        [JsonIgnore]
        public string? Miasto { get; set; }
        [JsonIgnore]
        public decimal? TrnRazemNetto { get; set; }
        [JsonIgnore]
        public int? Bufor { get; set; }

        [JsonProperty("TrNDataWystawienia")]
        public int? TrnDataWystawienia { get; set; }
        [JsonIgnore]
        public DateTime? DataWystawienia { get; set; }

        private string? _lista;
        [JsonProperty("Pozycje")]
        public string Lista
        {
            get { return _lista ?? ""; }
            set
            {
                _lista = value;
                if (!string.IsNullOrEmpty(_lista))
                    SetProperty(nameof(Lista), _lista);
            }
        }
        
        internal void Initialize(BaseDocument mc)
        {
            TrnId = mc.TrnId;
            TrnNumerPelny = mc.TrnNumerPelny;
            TrnNumerString = mc.TrnNumerString;
            NumeracjaDok = mc.NumeracjaDok;
            Rodzaj = mc.Rodzaj;
            Akronim = mc.Akronim;
            TrnNumer = mc.TrnNumer;
            TrnAnulowany = mc.TrnAnulowany;
            DataOperacji = mc.DataOperacji;
            TrnDataOperacji = mc.TrnDataOperacji;
            MagSymbol = mc.MagSymbol;
            NazwaPodmiotu = mc.NazwaPodmiotu;
            Miasto = mc.Miasto;
            TrnRazemNetto = mc.TrnRazemNetto;
            Bufor = mc.Bufor;
            TrnDataWystawienia = mc.TrnDataWystawienia;
            DataWystawienia = mc.DataWystawienia;
            Lista = mc.Lista;
        }
    }
}