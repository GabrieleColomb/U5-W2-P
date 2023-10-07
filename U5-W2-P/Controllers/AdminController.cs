using System.Collections.Generic;
using System.Web.Mvc;
using U5_W2_P.Models;

namespace U5_W2_P.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prenotazioni()
        {
            return View(Prenotazione.GetPrenotazione());
        }

        public List<SelectListItem> Camere
        {
            get
            {
                List<SelectListItem> listaCamere = new List<SelectListItem>();
                foreach (Stanza stanza in Stanza.GetStanza())
                {
                    SelectListItem item = new SelectListItem { Text = stanza.Descrizione + ", " + stanza.Tipologia, Value = stanza.IdCamera.ToString() };
                    listaCamere.Add(item);
                }
                return listaCamere;
            }
        }

        [HttpGet]
        public ActionResult CreaPrenotazione()
        {
            ViewBag.ListaOspiti = Ospiti;
            ViewBag.ListaCamere = Camere;
            return View();
        }

        [HttpPost]
        public ActionResult CreaPrenotazione(Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                Prenotazione.CreaPrenotazione(prenotazione);
                Prenotazione.GetPrenotazione().Add(prenotazione);
                return RedirectToAction("Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Clienti()
        {
            return View(Cliente.GetCliente());
        }

        public List<SelectListItem> Ospiti
        {
            get
            {
                List<SelectListItem> listaOspiti = new List<SelectListItem>();
                foreach (Cliente cliente in Cliente.GetCliente())
                {
                    SelectListItem item = new SelectListItem { Text = cliente.Nome + ", " + cliente.Cognome, Value = cliente.IdCliente.ToString() };
                    listaOspiti.Add(item);
                }
                return listaOspiti;
            }
        }

        [HttpGet]
        public ActionResult CreaPrenotazioni()
        {
            ViewBag.listaOspiti = Ospiti;
            return View();
        }

        [HttpGet]
        public ActionResult CreaCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreaCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Cliente.CreaCliente(cliente);
                Cliente.GetCliente().Add(cliente);
                return RedirectToAction("Cliente");
            }
            else
            {
                return View();
            }
        }

        public ActionResult PrenotazioneServiziAggiuntivi()
        {
            return View(PrenotazioneServizioAggiuntivo.GetPrenotazioneServizioAggiuntivo());
        }

        public List<SelectListItem> Servizi
        {
            get
            {
                List<SelectListItem> listaServizi = new List<SelectListItem>();
                foreach (ServizioAggiuntivo servizioAggiuntivo in ServizioAggiuntivo.GetServizioAggiuntivo())
                {
                    SelectListItem item = new SelectListItem { Text = servizioAggiuntivo.Nome + ", " + servizioAggiuntivo.Prezzo, Value = servizioAggiuntivo.IdServizioAggiuntivo.ToString() };
                    listaServizi.Add(item);
                }
                return listaServizi;
            }
        }

        [HttpGet]
        public ActionResult CreaServiziAggiuntivi()
        {
            ViewBag.ListaServizi = Servizi;
            ViewBag.listacamere = Camere;

            return View();
        }

        [HttpPost]
        public ActionResult CreaServiziAggiuntivi(PrenotazioneServizioAggiuntivo prenotazioneServizioAggiuntivo)
        {
            if (ModelState.IsValid)
            {
                PrenotazioneServizioAggiuntivo.CreaServiziAggiuntivi(prenotazioneServizioAggiuntivo);
                PrenotazioneServizioAggiuntivo.GetPrenotazioneServizioAggiuntivo().Add(prenotazioneServizioAggiuntivo);
                return RedirectToAction("PrenotazioneServiziAggiuntivi");
            }
            else
            {
                return View();
            }
        }
    }
}