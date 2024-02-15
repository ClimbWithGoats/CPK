using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using CPK.Models;
using Newtonsoft.Json;

namespace CPK
{
    public class ContractorRequest : Request
    {
        string url = @"http://localhost:7777/Contractors/Add";
        public ContractorRequest()
        {
            Json = new List<Contractor>();
        }
        public ContractorRequest(IEnumerable<Contractor> obj)
        {
            Json = new List<Contractor>(obj);
        }
        public ContractorRequest(IEnumerable<MiniContractor> obj)
        {
            Json = new List<Contractor>(obj.Select(miniContractor => new Contractor() { KntId = miniContractor.KntId, KntNazwa1 = miniContractor.KntNazwa1, KntKod = miniContractor.KntKod }));
        }
        public new List<Contractor> Json { get; set; }

        public static async Task<ContractorRequest> GetContractors()
        {
            // Adres endpointu
            string endpointUrl = "http://localhost:7774/api/Contractors/GetContractors";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var contractors = await response.Content.ReadFromJsonAsync<ContractorRequest>();
                        return contractors;
                    }
                    else
                    {
                        Console.WriteLine($"Błąd podczas pobierania danych. Kod odpowiedzi: {response.StatusCode}");
                        return null; // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                return new ContractorRequest(); // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
            }
        }

        public override string GetPipeName() => "HandleAddOrUpdateContractors";
        public async override Task<InputMessage?> SendDataToXL()
        {
            InputMessage? input = null;

            if (Json.Any())
                input = await base.WrapSendAndWaitAsync(url);
            else
                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(RessourcesRequest) + "ile pozycji:>" + Json.Count);
            return input;
        }
    }
    public class ContractorSQLRequest : Request
    {
        string url = @"http://localhost:7777/Contractors/AddSql";

        public ContractorSQLRequest()
        {
            Json = new List<SQLContractor>();
        }

        public ContractorSQLRequest(IEnumerable<SQLContractor> obj)
        {
            Json = new List<SQLContractor>(obj);
        }
        public ContractorSQLRequest(IEnumerable<MiniContractor> obj)
        {
            Json = new List<SQLContractor>(obj.Select(miniContractor => new SQLContractor() { KntId = miniContractor.KntId, KntNazwa1 = miniContractor.KntNazwa1, KntKod = miniContractor.KntKod, KntTyp = miniContractor.KntTyp }));
        }
        public new List<SQLContractor> Json { get; set; }

        public static async Task<ContractorSQLRequest> GetSQLContractors()
        {
            // Adres endpointu
            string endpointUrl = "http://localhost:7774/api/Contractors/GetSqlContractors";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var contractors = await response.Content.ReadFromJsonAsync<ContractorSQLRequest>();
                        return contractors;
                    }
                    else
                    {
                        Console.WriteLine($"Błąd podczas pobierania danych. Kod odpowiedzi: {response.StatusCode}");
                        return null; // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                return new ContractorSQLRequest(); // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
            }
        }


        public override string GetPipeName() => "HandleAddOrUpdateContractors";
        public async override Task<InputMessage?> SendDataToXL()
        {
            InputMessage? input = null;

            if (Json.Any())
                input = await base.WrapSendAndWaitAsync(url);
            else
                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(RessourcesRequest) + "ile pozycji:>" + Json.Count);
            return input;
        }
    }

    public class DocRequest : Request
    {
        public string url = @"http://localhost:7777/Documents";
        string stream = "";
        public new List<Document> Json { get; set; }

        public DocRequest()
        {
            Json = new List<Document>();
        }
        public DocRequest(IEnumerable<Document> obj, string endPoint, string connStream)
        {
            url += endPoint;
            Json = new List<Document>(obj);
            stream = connStream;
        }
        public DocRequest(IEnumerable<Document> obj, string endPoint)
        {
            url += endPoint;
            Json = new List<Document>(obj);
        }
        public DocRequest(Document obj, string endPoint)
        {
            Json = new List<Document> { obj };
        }
        public async override Task<InputMessage?> SendDataToXL()
        {
            InputMessage? input = null;
            if (Json.Any())
                input = await base.WrapSendAndWaitAsync(url);
            else
                Debug.WriteLine(url + "  : >" + Guid + " nie zostanie wysłany.\n Pusta lista " + nameof(DocRequest) + "ile pozycji:>" + Json.Count);

            return input;
        }

        public static DocRequest Init(IEnumerable<Document> obj, string endPoint) => new DocRequest(obj, endPoint, "");
        public static DocRequest Init(IEnumerable<Document> obj, string endPoint, string stream) => new DocRequest(obj, endPoint, stream);
        public override string GetPipeName() => "HandleAddOrUpdateDocuments";

        public static async Task<DocRequest?> GetDocument(string endPoint)
        {
            string endpointUrl = "http://localhost:7774/api/Documents";
            endpointUrl += !string.IsNullOrEmpty(endPoint) ? string.Format("/{0}", endPoint) : "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var documents = await response.Content.ReadFromJsonAsync<DocRequest>();
                        return documents;
                    }
                    else
                    {
                        Console.WriteLine($"Błąd podczas pobierania danych. Kod odpowiedzi: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{endPoint} Wystąpił błąd: {ex.Message}");
                return null;
            }
        }
    }

    public class ImpDocRequest : Request
    {
        string url = @"http://localhost:7777/Documents/FA";
        public new InputMessage Json { get; set; }
        public ImpDocRequest(InputMessage obj)
        {
            Json = obj;
        }

        public async override Task<InputMessage?> SendDataToXL()
        {
            InputMessage? input = null;
            //poprawić zwracany typ json
            if (Json != null)
                input = await base.WrapSendAndWaitAsync(url);
            else
                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(RessourcesRequest) + "ile pozycji:>" + Json);
            return input;
        }
        public override string GetPipeName() => "HandleAddOrUpdateDocuments";


        public static async Task<ContractorRequest> GetImportDocuments()
        {
            // Adres endpointu
            string endpointUrl = "http://localhost:7774/api/Contractors";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var contractors = await response.Content.ReadFromJsonAsync<ContractorRequest>();
                        return contractors;
                    }
                    else
                    {
                        Console.WriteLine($"Błąd podczas pobierania danych. Kod odpowiedzi: {response.StatusCode}");
                        return null; // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                return new ContractorRequest(); // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
            }
        }
    }
    
    public class CommRequest : Request
    {
        string url = @"http://localhost:7777/Commodities/Add";//??????
        public new List<CommodityGroup> Json { get; set; }
        public CommRequest(IEnumerable<CommodityGroup> obj)
        {
            Json = new List<CommodityGroup>(obj);
        }
        public CommRequest()
        {
            Json = new List<CommodityGroup>();
        }

        public async override Task<InputMessage?> SendDataToXL()
        {
            InputMessage? input = null;

            if (Json.Any())
                input = await base.WrapSendAndWaitAsync(url);
            else
                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(RessourcesRequest) + "ile pozycji:>" + Json.Count);
            return input;
        }
        public override string GetPipeName() => "";

        public static async Task<CommRequest> GetCommodityGroups()
        {
            // Adres endpointu
            string endpointUrl = "http://localhost:7774/api/CommodityGroups";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var commodities = await response.Content.ReadFromJsonAsync<CommRequest>();
                        return commodities;
                    }
                    else
                    {
                        Console.WriteLine($"Błąd podczas pobierania danych. Kod odpowiedzi: {response.StatusCode}");
                        return null; // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                return new CommRequest(); // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
            }
        }
    }
    public class CatRequest : Request
    {
        string url = @"";
        public new List<Category> Json { get; set; }

        public CatRequest(IEnumerable<Category> obj)
        {
            Json = new List<Category>(obj);
        }

        public async override Task<InputMessage?> SendDataToXL()
        {
            InputMessage? input = null;

            if (Json.Any())
                input = await base.WrapSendAndWaitAsync(url);
            else
                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(RessourcesRequest) + "ile pozycji:>" + Json.Count);
            return input;
        }
        public override string GetPipeName() => "";


        public static async Task<ContractorRequest> GetContractors()
        {
            // Adres endpointu
            string endpointUrl = "http://localhost:7774/api/Contractors";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var contractors = await response.Content.ReadFromJsonAsync<ContractorRequest>();
                        return contractors;
                    }
                    else
                    {
                        Console.WriteLine($"Błąd podczas pobierania danych. Kod odpowiedzi: {response.StatusCode}");
                        return null; // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                return new ContractorRequest(); // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
            }
        }
    }
    public class MerchCardsRequest : Request
    {
        string url = @"";
        public new List<MerchandiseCardExt> Json { get; set; }

        public MerchCardsRequest(IEnumerable<MerchandiseCardExt> obj)
        {
            Json = new List<MerchandiseCardExt>(obj);
        }
        public async override Task<InputMessage?> SendDataToXL()
        {
            InputMessage? input = null;

            if (Json.Any())
                input = await base.WrapSendAndWaitAsync(url);
            else
                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(RessourcesRequest) + "ile pozycji:>" + Json.Count);
            return input;
        }
        public override string GetPipeName() => "";


        public static async Task<ContractorRequest> GetContractors()
        {
            // Adres endpointu
            string endpointUrl = "http://localhost:7774/api/Contractors";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var contractors = await response.Content.ReadFromJsonAsync<ContractorRequest>();
                        return contractors;
                    }
                    else
                    {
                        Console.WriteLine($"Błąd podczas pobierania danych. Kod odpowiedzi: {response.StatusCode}");
                        return null; // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                return new ContractorRequest(); // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
            }
        }
    }
    public class RessourcesRequest : Request
    {
        string url = @"http://localhost:7777/Commodities/Add";
        public new List<Resource> Json { get; set; }
        public RessourcesRequest(IEnumerable<Resource> obj)
        {
            Json = new List<Resource>(obj);
        }

        public RessourcesRequest()
        {
            Json = new List<Resource>();
        }

        public async override Task<InputMessage?> SendDataToXL()
        {
            InputMessage? input = null;

            if (Json.Any())
                input = await base.WrapSendAndWaitAsync(url);
            else
                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(RessourcesRequest) + "ile pozycji:>" + Json.Count);
            return input;
        }
        public override string GetPipeName() => "HandleAddOrUpdateResource";

        public static async Task<RessourcesRequest> GetResources()
        {
            // Adres endpointu
            string endpointUrl = "http://localhost:7774/api/Resources";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var contractors = await response.Content.ReadFromJsonAsync<RessourcesRequest>();
                        return contractors;
                    }
                    else
                    {
                        Console.WriteLine($"Błąd podczas pobierania danych. Kod odpowiedzi: {response.StatusCode}");
                        return null; // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                return new RessourcesRequest(); // lub pusty IEnumerable<ContractorRequest>, w zależności od potrzeb
            }
        }
    }


    public abstract class Request
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string? Json { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public virtual T? GetT<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default;
            }
        }

        [JsonIgnore]
        public InputMessage? ResultMessage { get; set; }

        protected List<List<T>> ChunkList<T>(List<T> source, int chunkSize)
        {
            return source
                .Select((value, index) => new { Index = index, Value = value })
                .GroupBy(x => x.Index / chunkSize)
                .Select(group => group.Select(x => x.Value).ToList())
                .ToList();
        }

        public async Task<InputMessage?> WrapSendAndWaitAsync(string apiUrl)
        {
            InputMessage? input = null;
            if (string.IsNullOrEmpty(apiUrl))
                return input;

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(3);
                string jsonRequest = "";
                try
                {
                    jsonRequest = JsonConvert.SerializeObject(this);

                    HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        InputMessage? inputMessage = JsonConvert.DeserializeObject<InputMessage>(jsonResponse);
                        return inputMessage;
                    }
                    else
                    {
                        Console.WriteLine(apiUrl + ":> Błąd podczas wysyłania żądania. Status: " + response.StatusCode + "\n");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Błąd podczas wysyłania żądania: " + e.Message + "\n");
                }
                return input;
            }
        }
        public async Task<InputMessage> WrapSendAndWaitAsync(string apiUrl, object chunks)
        {
            InputMessage input = new InputMessage();
            if (string.IsNullOrEmpty(apiUrl))
                return input;

            using (HttpClient client = new HttpClient())
            {
                string jsonRequest = "";
                try
                {

                    // Serializujemy obiekt ContractorRequest do formatu JSON
                    jsonRequest = JsonConvert.SerializeObject(this);

                    // Tworzymy treść żądania HTTP
                    HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    // Wysyłamy żądanie PUT
                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Odczytujemy odpowiedź jako ciąg znaków
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserializujemy odpowiedź JSON do obiektu InputMessage
                        InputMessage inputMessage = JsonConvert.DeserializeObject<InputMessage>(jsonResponse);

                        return inputMessage;
                    }
                    else
                    {
                        Debug.WriteLine("Błąd podczas wysyłania żądania. Status: " + response.StatusCode + "\n" + jsonRequest);
                    }
                }
                catch (HttpRequestException e)
                {
                    Debug.WriteLine("Błąd podczas wysyłania żądania: " + e.Message + "\n" + jsonRequest);
                }

                // Zwracamy pusty obiekt InputMessage w przypadku błędu
                return input;
            }
        }
        public abstract Task<InputMessage?> SendDataToXL();
        public abstract string GetPipeName();

        protected async void SendDataToOptima(string pipe_name)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(ResultMessage.ResultJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(pipe_name, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Odpowiedź serwera: " + responseContent);
                }
                else
                {
                    Console.WriteLine("Błąd: " + response.StatusCode);
                }
            }
        }
    }
}
