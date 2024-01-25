
using ModelliComuni;
using Newtonsoft.Json;

namespace ServiziComuni
{
    public static class ServiziComuni
    {
        public static async Task<Meteo> DaiPrevisione()
        {
            string result = "";
            string Uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(Uri))
                {
                    using (HttpContent content = response.Content)
                    {
                        result = await content.ReadAsStringAsync();

                    }
                }
            }
            Meteo meteo = JsonConvert.DeserializeObject<Meteo>(result);
            return meteo;
        }

        public static async Task<Giorno> DaiGiorno(string data)
        {
            Meteo meteo = DaiPrevisione().Result;

            List<Giorno> giorni = meteo.previsione[0].giorni;

            return giorni.Where(s => s.giorno == data).First();
        }
    }
}