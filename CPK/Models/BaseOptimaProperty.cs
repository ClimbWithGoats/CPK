//Kontrahenci

namespace CPK.Models
{
    public class BaseOptimaProperty
    {
        protected delegate void PropertyEventHandler(object sender, PropertyEventArgs e);
        protected event PropertyEventHandler? PropertyChanged;

        // Metoda, która wywoła zdarzenie
        protected virtual void OnPropertyChanged(string propertyName, string jsonValue)
        {
            PropertyEventArgs args = new PropertyEventArgs(propertyName, jsonValue);
            PropertyChanged?.Invoke(this, args);
        }

        // Metoda, która zmienia właściwość i wywołuje zdarzenie
        public void SetProperty(string propertyName, string jsonValue)
        {
            OnPropertyChanged(propertyName, jsonValue);
        }
    }
}