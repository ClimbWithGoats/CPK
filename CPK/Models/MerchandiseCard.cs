//Kontrahenci

using Newtonsoft.Json;

namespace CPK.Models
{
    public class MerchandiseCard : BaseOptimaProperty
    {
        public int? TwrId { get; set; }
        public string? TwrKod { get; set; }
        public string? TwrNrKatalogowy { get; set; }
        public string? TwgKodGrupy { get; set; }
        public string? TwgNazwa { get; set; }
        public int? TwrTyp { get; set; }
        public string? TwrEan { get; set; }
        public string? TwrSSW { get; set; }
        public string? KodCN { get; set; }
        public decimal? StawkaVatSprz { get; set; }
        public decimal? StawkaVatZak { get; set; }
        public int? TwcNumerSelect { get; set; }
        public int? TwrSplitPay { get; set; }
        public int? TwrOdwrotneObciazenie { get; set; }
        public string? TwrNazwa { get; set; }
        public string? TwrKat { get; set; }
        public string? TwrKatZak { get; set; }
        public string? TwrJM { get; set; }
        public int? TwrJmCalowite { get; set; }

        private string? _listaCen;

        public string? ListaCen
        {
            get => _listaCen; 
            set
            {
                _listaCen = value;
                if (!string.IsNullOrEmpty(_listaCen))
                    SetProperty(nameof(ListaCen), _listaCen);
            }
        }

        private string? _stawkiVat;
        public string? StawkiVAT
        {
            get => _stawkiVat;
            set
            {
                _stawkiVat = value;
                if (!string.IsNullOrEmpty(_stawkiVat))
                    SetProperty(nameof(StawkiVAT), _stawkiVat);

            }
        }

        private string? _pomJednMiary;
        public string? PomJednMiary
        {
            get => _pomJednMiary; set
            {
                _pomJednMiary = value;
                if (!string.IsNullOrEmpty(_kodyEAN))
                    SetProperty(nameof(PomJednMiary), _kodyEAN);


            }
        }
        private string? _kodyEAN;
        public string? KodyEan
        {
            get => _kodyEAN; set
            {
                _kodyEAN = value;
                if (!string.IsNullOrEmpty(_kodyEAN))
                    SetProperty(nameof(KodyEan), _kodyEAN);


            }
        }
        private string? _grupy;
        public string? Grupy
        {
            get => _grupy; set
            {
                _grupy = value;
                if (!string.IsNullOrEmpty(_grupy))
                    SetProperty(nameof(Grupy), _grupy);

            }
        }

        internal void Initialize(MerchandiseCard mc)
        {
            TwrId = mc.TwrId;
            TwrKod = mc.TwrKod;
            TwrNrKatalogowy = mc.TwrNrKatalogowy;
            TwgKodGrupy = mc.TwgKodGrupy;
            TwgNazwa = mc.TwgNazwa;
            TwrTyp = mc.TwrTyp;
            TwrEan = mc.TwrEan;
            TwrSSW = mc.TwrSSW;
            KodCN = mc.KodCN;
            StawkaVatSprz = mc.StawkaVatSprz;
            StawkaVatZak = mc.StawkaVatZak;
            TwcNumerSelect = mc.TwcNumerSelect;
            TwrSplitPay = mc.TwrSplitPay;
            TwrOdwrotneObciazenie = mc.TwrOdwrotneObciazenie;
            TwrNazwa = mc.TwrNazwa;
            TwrKat = mc.TwrKat;
            TwrKatZak = mc.TwrKatZak;
            TwrJM = mc.TwrJM;
            TwrJmCalowite = mc.TwrJmCalowite;
            ListaCen = mc.ListaCen;
            StawkiVAT = mc.StawkiVAT;
            PomJednMiary = mc.PomJednMiary;
            KodyEan = mc.KodyEan;
            Grupy = mc.Grupy;
        }
    }

}
