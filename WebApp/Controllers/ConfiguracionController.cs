using Ecosistemas_Marinos.Entidades;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ConfiguracionController : Controller
    {
        private IUpdateSettings UpdateSettingsUC;
        private IGetSettings GetSettingsUC;
        private IFindSettingsByName GetSettingsByNameUC;

        public ConfiguracionController(IUpdateSettings updateSettingsUC, IGetSettings getSettingsUC, IFindSettingsByName getSettingsByNameUC)
        {
            UpdateSettingsUC = updateSettingsUC;
            GetSettingsUC = getSettingsUC;
            GetSettingsByNameUC = getSettingsByNameUC;
        }

        
        // GET: ConfiguracionController
        public ActionResult Index()
        {
            return View(this.GetSettingsUC.GetSettings());
        }
        

   

        // GET: ConfiguracionController/Edit/5
        public ActionResult Edit(String id, string mensaje)
        {
            string alias = HttpContext.Session.GetString("LogueadoAlias");
            if (alias != null)
            {
                ViewBag.Mensaje = mensaje;
                return View(this.GetSettingsByNameUC.FindSettingsByName(id));
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ConfiguracionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Configuracion setting)
        {
            try
            {
                this.UpdateSettingsUC.UpdateSettings(setting);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();            
            }
        }

        
    }
}
