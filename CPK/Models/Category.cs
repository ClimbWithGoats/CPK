//Kontrahenci

namespace CPK.Models
{
    public class Category
    {
        public int? KatKatId { get; set; }
        public string? KatKodSzczegol { get; set; }
        public string? KatOpis { get; set; }
        public string? KodyJPKV7 { get; set; }
        public string? KatKodOgolny { get; set; }
        public int? KatPoziom { get; set; }
        public int? KatParentId { get; set; }
        public int? KatNieaktywny { get; set; }
    }
}
