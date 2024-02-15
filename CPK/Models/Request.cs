//using Newtonsoft.Json;
//using System.Diagnostics;
//using System.IO.Pipes;
//using System.Reflection;
//using System.Resources;
//using System.Text;
////KartyTowarowe
//namespace CPK.Models
//{
//    public class ContractorRequest : Request
//    {
//        string url = @"http://localhost:7777/Contractors/Add";
//        public ContractorRequest(IEnumerable<Contractor> obj)
//        {
//            Json = new List<Contractor>(obj);
//        }
//        public ContractorRequest(IEnumerable<MiniContractor> obj)
//        {

//            Json = new List<Contractor>(obj.Select(miniContractor => new Contractor() { KntId = miniContractor.KntId, KntNazwa1 = miniContractor.KntNazwa1, KntKod = miniContractor.KntKod }));
//        }
//        public new List<Contractor> Json { get; set; }

//        public override string GetPipeName() => "HandleAddOrUpdateContractors";
//        public async override Task<InputMessage?> SendDataToXL()
//        {
//            InputMessage input = new InputMessage();
//            if (Json.Any())
//                input = await base.WrapSendAndWaitAsync(url);
//            else
//                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(ContractorRequest) + "ile pozycji:>" + Json.Count);

//            return input;
//        }
    


//    }
//    public class ContractorSQLRequest : Request
//    {
//        string url = @"http://localhost:7777/Contractors/AddSql";
//        public ContractorSQLRequest(IEnumerable<Contractor> obj)
//        {
//            Json = new List<Contractor>(obj);
//        }
//        public ContractorSQLRequest(IEnumerable<MiniContractor> obj)
//        {
//            Json = new List<Contractor>(obj.Select(miniContractor => new Contractor() { KntId = miniContractor.KntId, KntNazwa1 = miniContractor.KntNazwa1, KntKod = miniContractor.KntKod, KntTyp = miniContractor.KntTyp }));
//        }
//        public new List<Contractor> Json { get; set; }

//        public override string GetPipeName() => "HandleAddOrUpdateContractors";
//        public async override Task<InputMessage> SendDataToXL()
//        {
//            InputMessage input = new InputMessage();
//            if (Json.Any())
//            {
//                try
//                {
//                    input = await base.WrapSendAndWaitAsync(url);
//                }
//                catch (Exception)
//                {

//                }

//            }

//            else
//                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(ContractorSQLRequest) + "ile pozycji:>" + Json.Count);

//            return input;
//        }

//    }

//    public class DocRequest : Request
//    {
//        string url = @"http://localhost:7777/Documents/";
//        string stream = "";
//        public new List<Document> Json { get; set; }
//        public DocRequest(IEnumerable<Document> obj, string endPoint, string connStream)
//        {
//            url += endPoint;
//            Json = new List<Document>(obj);
//            stream = connStream;
//        }
//        public DocRequest(IEnumerable<Document> obj, string endPoint)
//        {
//            url += endPoint;
//            Json = new List<Document>(obj);
//        }
//        public DocRequest(Document obj, string endPoint)
//        {
//            Json = new List<Document> { obj };
//        }
//        public async override Task<InputMessage?> SendDataToXL()
//        {
//            InputMessage? input = null;
//            if (Json.Any())
//                input = await base.WrapSendAndWaitAsync(url);
//            else
//                Debug.WriteLine(url + "  : >" + Guid + " nie zostanie wysłany.\n Pusta lista " + nameof(DocRequest) + "ile pozycji:>" + Json.Count);

//            return input;
//        }
//        public static DocRequest Init(IEnumerable<Document> obj, string endPoint) => new DocRequest(obj, endPoint, "");
//        public static DocRequest Init(IEnumerable<Document> obj, string endPoint, string stream) => new DocRequest(obj, endPoint, stream);
//        public override string GetPipeName() => "HandleAddOrUpdateDocuments";

//    }
//    public class ImpDocRequest : Request
//    {
//        string url = @"http://localhost:7777/Documents/FA";
//        public new InputMessage Json { get; set; }
//        public ImpDocRequest(InputMessage obj)
//        {
//            Json = obj;
//        }

//        public async override Task<InputMessage> SendDataToXL()
//        {
//            InputMessage input = new InputMessage();
//            if (Json != null)
//                input = await base.WrapSendAndWaitAsync(url);

//            return input;
//        }
//        public override string GetPipeName() => "HandleAddOrUpdateDocuments";

//    }

//    //public class ImpDocRequest : Request
//    //{
//    //    string url = @"http://localhost:7777/Documents";
//    //    public new List<Document> Json { get; set; }
//    //    public ImpDocRequest(IEnumerable<Document> obj, string endPoint)
//    //    {
//    //        url += endPoint;
//    //        Json = new List<Document>(obj);
//    //    }

//    //    public async override Task<InputMessage> SendData()
//    //    {
//    //        InputMessage input = new InputMessage();
//    //        if (Json.Any())
//    //            input = await base.WrapSendAndWaitAsync(url);
//    //        else
//    //            Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(ImpDocRequest) + "ile pozycji:>" + Json.Count);

//    //        return input;
//    //    }
//    //}


//    public class CommRequest : Request
//    {
//        string url = @"http://localhost:7777/Commodities/Add";//??????
//        public new List<CommodityGroup> Json { get; set; }
//        public CommRequest(IEnumerable<CommodityGroup> obj)
//        {
//            Json = new List<CommodityGroup>(obj);
//        }

//        public async override Task<InputMessage> SendDataToXL()
//        {
//            InputMessage input = new InputMessage();
//            if (Json.Any())
//                input = await base.WrapSendAndWaitAsync(url);
//            else
//                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(CommRequest) + "ile pozycji:>" + Json.Count);
//            return input;
//        }
//        public override string GetPipeName() => "";

//    }
//    public class CatRequest : Request
//    {
//        string url = @"";
//        public new List<Category> Json { get; set; }

//        public CatRequest(IEnumerable<Category> obj)
//        {
//            Json = new List<Category>(obj);
//        }

//        public async override Task<InputMessage> SendDataToXL()
//        {
//            InputMessage input = new InputMessage();
//            if (Json.Any())
//                input = await base.WrapSendAndWaitAsync(url);
//            else
//                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(CatRequest) + "ile pozycji:>" + Json.Count);
//            return input;
//        }
//        public override string GetPipeName() => "";

//    }
//    public class MerchCardsRequest : Request
//    {
//        string url = @"";
//        public new List<MerchandiseCardExt> Json { get; set; }

//        public MerchCardsRequest(IEnumerable<MerchandiseCardExt> obj)
//        {
//            Json = new List<MerchandiseCardExt>(obj);
//        }

//        public async override Task<InputMessage> SendDataToXL()
//        {
//            InputMessage input = new InputMessage();
//            if (Json.Any())
//                input = await base.WrapSendAndWaitAsync(url);
//            else
//                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(MerchCardsRequest) + "ile pozycji:>" + Json.Count);
//            return input;
//        }
//        public override string GetPipeName() => "";
//    }
//    public class RessourcesRequest : Request
//    {

//        string url = @"http://localhost:7777/Commodities/Add";
//        public new List<Resource> Json { get; set; }
//        public RessourcesRequest(IEnumerable<Resource> obj)
//        {
//            Json = new List<Resource>(obj);
//        }

//        public async override Task<InputMessage> SendDataToXL()
//        {
//            InputMessage input = new InputMessage();

//            if (Json.Any())
//                input = await base.WrapSendAndWaitAsync(url);
//            else
//                Debug.WriteLine(Guid + " nie zostanie wysłany. Pusta lista" + nameof(RessourcesRequest) + "ile pozycji:>" + Json.Count);
//            return input;
//        }
//        public override string GetPipeName() => "HandleAddOrUpdateResource";
//    }


//    public abstract class Request
//    {
//        public Guid Guid { get; set; } = Guid.NewGuid();
//        //public MethodName? MethodName { get; set; }
//        public string? Json { get; set; }
//        public DateTime DateTime { get; set; } = DateTime.Now;
//        public virtual T? GetT<T>(string json)
//        {
//            try
//            {
//                return JsonConvert.DeserializeObject<T>(json);
//            }
//            catch
//            {
//                return default;
//            }
//        }

//        [JsonIgnore]
//        public InputMessage? ResultMessage { get; set; }

//        protected List<List<T>> ChunkList<T>(List<T> source, int chunkSize)
//        {
//            return source
//                .Select((value, index) => new { Index = index, Value = value })
//                .GroupBy(x => x.Index / chunkSize)
//                .Select(group => group.Select(x => x.Value).ToList())
//                .ToList();
//        }

//        public async Task<InputMessage?> WrapSendAndWaitAsync(string apiUrl)
//        {
//            InputMessage? input = null;
//            if (string.IsNullOrEmpty(apiUrl))
//                return input;

//            using (HttpClient client = new HttpClient())
//            {
//                string jsonRequest = "";
//                try
//                {
//                    // Serializujemy obiekt ContractorRequest do formatu JSON
//                    jsonRequest = JsonConvert.SerializeObject(this);

//                    // Tworzymy treść żądania HTTP
//                    HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

//                    // Wysyłamy żądanie PUT
//                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        // Odczytujemy odpowiedź jako ciąg znaków
//                        string jsonResponse = await response.Content.ReadAsStringAsync();

//                        // Deserializujemy odpowiedź JSON do obiektu InputMessage
//                        InputMessage? inputMessage = JsonConvert.DeserializeObject<InputMessage>(jsonResponse);

//                        return inputMessage;
//                    }
//                    else
//                    {
//                        Debug.WriteLine("Błąd podczas wysyłania żądania. Status: " + response.StatusCode + "\n");
//                    }
//                }
//                catch (HttpRequestException e)
//                {
//                    Debug.WriteLine("Błąd podczas wysyłania żądania: " + e.Message + "\n");
//                }

//                // Zwracamy pusty obiekt InputMessage w przypadku błędu
//                return input;
//            }
//        }
//        public async Task<InputMessage> WrapSendAndWaitAsync(string apiUrl, object chunks)
//        {
//            InputMessage input = new InputMessage();
//            if (string.IsNullOrEmpty(apiUrl))
//                return input;

//            using (HttpClient client = new HttpClient())
//            {
//                string jsonRequest = "";
//                try
//                {

//                    // Serializujemy obiekt ContractorRequest do formatu JSON
//                    jsonRequest = JsonConvert.SerializeObject(this);

//                    // Tworzymy treść żądania HTTP
//                    HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

//                    // Wysyłamy żądanie PUT
//                    HttpResponseMessage response = await client.PutAsync(apiUrl, content);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        // Odczytujemy odpowiedź jako ciąg znaków
//                        string jsonResponse = await response.Content.ReadAsStringAsync();

//                        // Deserializujemy odpowiedź JSON do obiektu InputMessage
//                        InputMessage inputMessage = JsonConvert.DeserializeObject<InputMessage>(jsonResponse);

//                        return inputMessage;
//                    }
//                    else
//                    {
//                        Debug.WriteLine("Błąd podczas wysyłania żądania. Status: " + response.StatusCode + "\n" + jsonRequest);
//                    }
//                }
//                catch (HttpRequestException e)
//                {
//                    Debug.WriteLine("Błąd podczas wysyłania żądania: " + e.Message + "\n" + jsonRequest);
//                }

//                // Zwracamy pusty obiekt InputMessage w przypadku błędu
//                return input;
//            }
//        }
//        public abstract Task<InputMessage?> SendDataToXL(); 
//        public abstract string GetPipeName();

//        protected async void SendDataToOptima(string pipe_name)
//        {
//            using (var potok1 = new NamedPipeClientStream(".", pipe_name, PipeDirection.InOut, PipeOptions.None))
//            {
//                potok1.Connect();
//                byte[] requestBytes = Encoding.UTF8.GetBytes(ResultMessage.ResultJson);
//                await potok1.WriteAsync(requestBytes, 0, requestBytes.Length);

//                byte[] responseBytes = new byte[1024 * 1024 * 10]; // 10 MB
//                int bytesRead = await potok1.ReadAsync(responseBytes, 0, responseBytes.Length);
//                string result = Encoding.UTF8.GetString(responseBytes, 0, bytesRead);
//                potok1.Close();
//            }
//        }
//    }
//}
