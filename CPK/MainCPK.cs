using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;
using CPK.Models;
using System.Net.Sockets;
using System.Net;

namespace CPK
{
    public static class MainCPK
    {
        private static Timer timer;

        static MainCPK()
        {
        }

        static public void InitializeProccess()
        {
            try
            {
                Task.Run(() =>
                {
                    try
                    {
                        CheckConnection();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Błąd podczas wykonywania CheckConnection: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd podczas wykonywania InitializeProccess: {ex.Message}");
            }
            try
            {
                Task.Run(() =>
                {
                    try
                    {
                        ProcessQueue();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Błąd podczas wykonywania CheckConnection: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd podczas wykonywania InitializeProccess: {ex.Message}");
            }
        }

        public static BlockingCollection<Request>? blockingCollectionToSendXLApi = null;
        private static async Task ProcessQueue()
        {
            while (true)
            {
                if (blockingCollectionToSendXLApi == null)
                    RunLoop();

                //     AddNewOperationalThreaded();
                foreach (var responseTask in blockingCollectionToSendXLApi.GetConsumingEnumerable())
                {
                    try
                    {
                        Request response = responseTask;
                        if (response != null)
                        {
                            var t = await ExecuteResponseAsync(response);
                            Debug.WriteLine($"odpowiedź z response:>" + response.Guid + " " + t.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static async Task CheckConnection()
        {
            int time = 2000;
            while (true)
            {
                try
                {
                    //bool optima = SprawdzPolaczenie("localhost", 7773);
                    //if (optima) { }
                    bool portOptima = CheckConnections("localhost", 7774);
                    if (portOptima) { }

                    bool portXL = CheckConnections("localhost", 7777);
                    if (portXL) { }

                    //bool xl = SprawdzPolaczenie("localhost", 7778);
                    //if (xl) { }

                    bool potokOptima = CheckPipeLines(".", "ItegerOptima");
                    if (potokOptima) { }

                    bool potokXL = CheckPipeLines(".", "ItegerXL");
                    if (potokXL) { }

                    await Task.Delay(time);
                    if (portOptima)
                    {
                        if (blockingCollectionToSendXLApi != null && blockingCollectionToSendXLApi.Count == 0)
                        {
                            AddNewOperationalThreaded();
                        }
                        else if (blockingCollectionToSendXLApi == null)
                        {

                        }
                    }
                    else
                    {
                        if (blockingCollectionToSendXLApi != null)
                        {
                            blockingCollectionToSendXLApi?.CompleteAdding();
                            blockingCollectionToSendXLApi?.Dispose();
                            blockingCollectionToSendXLApi = null;
                            isProcessQueueRunning = false;
                        }
                        Console.CursorTop = 0;
                        Console.CursorLeft = 0;
                        Console.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas sprawdzania połączenia: {ex.Message}");
                }
            }
        }

        static void RunLoop()
        {
            if (blockingCollectionToSendXLApi == null)
            {
                blockingCollectionToSendXLApi = new BlockingCollection<Request>();
                if (!isProcessQueueRunning)
                {
                    isProcessQueueRunning = true;
                    Console.WriteLine("uruchamia proces");
                }
                else
                {
                    Console.WriteLine("proces istnieje");
                }
            }
        }

        private static bool isProcessQueueRunning = false;

        static bool CheckConnections(string host, int port)
        {
            bool result;
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(host, port);
                Console.WriteLine($"Połączo z {host}:{port}");
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd połączenia z {host}:{port}; {ex.Message}");
                result = false;
            }
            finally
            {
                tcpClient.Close();
            }
            return result;
        }
        static bool CheckPipeLines(string host, string nazwaPotoku)
        {
            bool result;
            TcpClient tcpClient = new TcpClient();
            try
            {
                using (var potok1 = new NamedPipeClientStream(host, nazwaPotoku, PipeDirection.InOut, PipeOptions.None))
                {
                    potok1.Connect(1000);
                    potok1.Close();
                    Console.WriteLine(nazwaPotoku + " OK");
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd połączenia z potokiem {nazwaPotoku}; {ex.Message}");
                result = false;
            }
            finally
            {
                tcpClient.Close();
            }
            return result;
        }

        public static void SendData(string server, string PipeName)
        {
            if (!string.IsNullOrEmpty(PipeName))
            {
                try
                {
                    using (NamedPipeClientStream clientStream = new NamedPipeClientStream(server, PipeName, PipeDirection.InOut, PipeOptions.None))
                    {
                        clientStream.Connect();
                        clientStream.Close();
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Potok {PipeName} jest już używany: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas tworzenia potoku: {ex.Message}");
                }
            }
        }

        private static async Task<InputMessage> ExecuteResponseAsync(Request resp)
        {
            try
            {
                var result = await resp.SendDataToXL();
                if (result != null)
                {
                    try
                    {
                        Debug.WriteLine("Przetwarzanie odpowiedzi z " + resp.Guid + " do Optimy");

                        resp.ResultMessage = result;
                        ProcessQueueToSendOptima(resp).Wait();
                        Debug.WriteLine("Zakończono " + resp.Guid + " do Optimy");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(resp.Guid + ":> " + ex.Message);
                    }
                }
                return result ?? new InputMessage() { Message = $"Zwrócone puste wartosci" };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd podczas wykonywania ExecuteResponseAsync: {ex.Message}");
                return new InputMessage() { Message = $"Błąd podczas wykonywania ExecuteResponseAsync: {ex.Message}" };
            }
        }

        private static void AddNewOperationalThreaded()
        {
            AddNewContractors();
            AddNewContractorsSQL();
            ////// AddCommodities();
            AddResources();
            //AddMerchandiseCards();
            AddDocuments();
        }

        public static async void AddCategories() { }

        public static async void AddCommodities()
        {
            var result = await CommRequest.GetCommodityGroups();
            if (result != null && result.Json.Any())
            {
                var chunks = ChunkList<CommodityGroup>(result.Json, 200);
                foreach (var chunk in chunks)
                {
                    var newCommodities = new CommRequest(chunk);
                    blockingCollectionToSendXLApi?.Add(newCommodities);
                    Console.WriteLine("... > " + nameof(AddCommodities) + $"{newCommodities.Guid} Done");
                }
            }
        }

        public static async void AddNewContractors()
        {
            var result = await ContractorRequest.GetContractors();
            if (result != null && result.Json.Any())
            {
                var chunks = ChunkList<Contractor>(result.Json, 200);
                foreach (var chunk in chunks)
                {
                    var newContractor = new ContractorRequest(chunk);
                    blockingCollectionToSendXLApi?.Add(newContractor);
                    Console.WriteLine("... > " + nameof(AddNewContractors) + $"{newContractor.Guid} Done");
                }
            }
        }
        
        public static async void AddNewContractorsSQL()
        {
            var result = await ContractorSQLRequest.GetSQLContractors();
            if (result != null && result.Json.Any())
            {
                var chunks = ChunkList<SQLContractor>(result.Json, 200);
                foreach (var chunk in chunks)
                {
                    var newContractor = new ContractorSQLRequest(chunk);
                    blockingCollectionToSendXLApi?.Add(newContractor);
                    Console.WriteLine("... > " + nameof(AddNewContractorsSQL) + $"{newContractor.Guid} Done");
                }
            }
        }

        private static List<List<T>> ChunkList<T>(List<T> source, int chunkSize)
        {
            return source
                .Select((value, index) => new { Index = index, Value = value })
                .GroupBy(x => x.Index / chunkSize)
                .Select(group => group.Select(x => x.Value).ToList())
                .ToList();
        }

        public static async void AddDocuments()
        {
            var fz = await DocRequest.GetDocument("FZ");
            if (fz != null && fz.Json.Count > 0)
            {
                fz.url += string.Format("/FZ");
                blockingCollectionToSendXLApi?.Add(fz);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {fz.Guid}  FZ Done");
            }

            var pz = await DocRequest.GetDocument("PZ");
            if (pz != null && pz.Json.Count > 0)
            {
                pz.url += string.Format("/PZ");
                blockingCollectionToSendXLApi?.Add(pz);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {pz.Guid}  PZ Done");
            }

            var fa = await DocRequest.GetDocument("FA");
            if (fa != null && fa.Json.Any())
            {
                fa.url += string.Format("/FA");
                blockingCollectionToSendXLApi?.Add(fa);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {fa.Guid}  FA Done");
            }

            var wz = await DocRequest.GetDocument("WZ");
            if (wz != null && wz.Json.Count > 0)
            {
                wz.url += string.Format("/WZ");
                blockingCollectionToSendXLApi?.Add(wz);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {wz.Guid}  WZ Done");
            }


            var fpa = await DocRequest.GetDocument("FPA");
            if (fpa != null && fpa.Json.Count > 0)
            {
                fpa.url += string.Format("/FPA");
                blockingCollectionToSendXLApi?.Add(fpa);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {fpa.Guid}  FPA Done");
            }

            var frod = await DocRequest.GetDocument("FROD");
            if (frod != null && frod.Json.Count > 0)
            {
                frod.url += string.Format("/FROD");
                blockingCollectionToSendXLApi?.Add(frod);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {frod.Guid}  FROD Done");
            }

            var fpf = await DocRequest.GetDocument("FPF");
            if (fpf != null && fpf.Json.Count > 0)
            {
                fpf.url += string.Format("/FPF");
                blockingCollectionToSendXLApi?.Add(fpf);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {fpf.Guid}  FPF Done");
            }

            var pw = await DocRequest.GetDocument("PW");
            if (pw != null && pw.Json.Count > 0)
            {
                pw.url += string.Format("/PW");
                blockingCollectionToSendXLApi?.Add(pw);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {pw.Guid}  PW Done");
            }

            var rw = await DocRequest.GetDocument("RW");
            if (rw != null && rw.Json.Count > 0)
            {
                rw.url += string.Format("/RW");
                blockingCollectionToSendXLApi?.Add(rw);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {rw.Guid}  RW Done");
            }

            var pa = await DocRequest.GetDocument("PA");
            if (pa != null && pa.Json.Count > 0)
            {
                pa.url += string.Format("/PA");
                blockingCollectionToSendXLApi?.Add(pa);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {pa.Guid}  PA Done");
            }

            var pawz = await DocRequest.GetDocument("PAWZ");
            if (pawz != null && pawz.Json.Count > 0)
            {
                pawz.url += string.Format("/PAWZ");
                blockingCollectionToSendXLApi?.Add(pawz);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {pawz.Guid}  PAWZ Done");
            }

            var paro = await DocRequest.GetDocument("PARO");
            if (paro != null && paro.Json.Count > 0)
            {
                paro.url += string.Format("/PARO");
                blockingCollectionToSendXLApi?.Add(paro);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {paro.Guid}  PARO Done");
            }


            var pzzd = await DocRequest.GetDocument("PZZD");
            if (pzzd != null && pzzd.Json.Count > 0)
            {
                pzzd.url += string.Format("/PZZD");
                blockingCollectionToSendXLApi?.Add(pzzd);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {pzzd.Guid}  PZZD Done");
            }

            var ro = await DocRequest.GetDocument("RO");
            if (ro != null && ro.Json.Count > 0)
            {
                ro.url += string.Format("/RO");
                blockingCollectionToSendXLApi?.Add(ro);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {ro.Guid}  RO Done");
            }

            var ropf = await DocRequest.GetDocument("ROPF");
            if (ropf != null && ropf.Json.Count > 0)
            {
                ropf.url += string.Format("/ROPF");
                blockingCollectionToSendXLApi?.Add(ropf);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {ropf.Guid}  ROPF Done");
            }

            var zd = await DocRequest.GetDocument("ZD");
            if (zd != null && zd.Json.Count > 0)
            {
                zd.url += string.Format("/ZD");
                blockingCollectionToSendXLApi?.Add(zd);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {zd.Guid}  ZD Done");
            }

            var zrod = await DocRequest.GetDocument("ZROD");
            if (zrod != null && zrod.Json.Count > 0)
            {
                zrod.url += string.Format("/ZROD");

                blockingCollectionToSendXLApi?.Add(zrod);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {zrod.Guid}  ZROD Done");
            }

            var mm = await DocRequest.GetDocument("MM");
            if (mm != null && mm.Json.Count > 0)
            {
                mm.url += string.Format("/MM");
                blockingCollectionToSendXLApi?.Add(mm);
                Console.WriteLine("... > " + nameof(AddDocuments) + $" {mm.Guid}  MM Done");
            }
        }

        public static async void AddResources()
        {
            var result = await RessourcesRequest.GetResources();
            if (result != null && result.Json.Any())
            {
                var chunks = ChunkList<Resource>(result.Json, 200);
                foreach (var chunk in chunks)
                {
                    var newResources = new RessourcesRequest(chunk);
                    blockingCollectionToSendXLApi?.Add(newResources);
                    Console.WriteLine("... > " + nameof(AddResources) + $"{newResources.Guid} Done");
                }
            }
        }


        public static async void AddMerchandiseCards()
        {
        }

        public static BlockingCollection<Request> blockingCollectionToSendOptimaApi = new();
        private static async Task ProcessQueueToSendOptima(Request responseTask)
        {
            try
            {
                if (responseTask != null)
                {
                    if (!string.IsNullOrEmpty(responseTask.GetPipeName()))
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            string pipe_name = responseTask.GetPipeName() + "_" + responseTask?.ResultMessage?.Guid;
                            if (!string.IsNullOrEmpty(responseTask?.Json))
                            {
                                StringContent content = new StringContent(responseTask.Json, Encoding.UTF8, "application/json");
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
            }
            catch (IOException io)
            {
                Console.WriteLine("io:> " + io.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex:> " + ex.Message);
            }
        }

        static bool CheckThePipeConnection(string pipeName)
        {
            string _pipeName = "MainPipeClientStream";

            if (!CheckThePipeConnection(_pipeName))
            {
                CreateThePipeConnection(_pipeName);
            }
            else
            {
                Console.WriteLine($"Połączenie w potoku {_pipeName} już istnieje.");
            }

            try
            {
                using (var potok = new NamedPipeClientStream(".", _pipeName, PipeDirection.InOut, PipeOptions.None))
                {
                    potok.Connect(100); // Czas oczekiwania na połączenie w milisekundach
                    return potok.IsConnected;
                }
            }
            catch (IOException)
            {
                return true; // Potok jest już używany
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void CreateThePipeConnection(string pipeName)
        {
            try
            {
                using (var potok = new NamedPipeServerStream(pipeName))
                {
                    Console.WriteLine($"Utworzono potok o nazwie {pipeName}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Potok {pipeName} jest już używany: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas tworzenia potoku: {ex.Message}");
            }
        }
    }
}
