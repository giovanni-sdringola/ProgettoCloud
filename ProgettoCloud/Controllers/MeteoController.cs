using Microsoft.AspNetCore.Mvc;
using ModelliComuni;
using ProgettoCloud.ViewModels;

namespace ProgettoCloud.Controllers
{
    public class MeteoController : Controller
    {
        public IActionResult MostraMeteo()
        {
            Meteo meteo = ServiziComuni.ServiziComuni.DaiPrevisione().Result;

            MeteoMostraMeteoViewModel vm = new MeteoMostraMeteoViewModel
            {
                Previsioni = meteo.previsione,
                Descrizione = meteo.evoluzioneBreve
            };

            return View(vm);

        }

        public IActionResult DettaglioGiorno(string Data)
        {

            MeteoDettaglioGiornoViewModel vm = new MeteoDettaglioGiornoViewModel
            {
                Giorno = ServiziComuni.ServiziComuni.DaiGiorno(Data).Result
            };

            return View(vm);

        }
    }
}
