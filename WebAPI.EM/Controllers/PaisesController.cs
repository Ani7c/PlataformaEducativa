using Ecosistemas_Marinos.Interfaces_Repositorios;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfaceUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebAPI.EM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private HttpClient cliente = new HttpClient();
        private string urlPaises = "https://restcountries.com/v3.1/all";


        private IGuardarPaises GuardarPaisesUC;
        private IGetCountries GetCountriesUC;

        public PaisesController(IGuardarPaises guardarPaisesUC, IGetCountries getCountriesUC)
        {
            GuardarPaisesUC = guardarPaisesUC;
            GetCountriesUC = getCountriesUC;
        }



        /// <summary>
        /// Obtiene todos los paises cargados en el sistema
        /// </summary>
        /// <returns> Lista de todos los paises </returns>
        [HttpGet(Name = "GetPaises")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Get()
        {
            try
            {
                return Ok(this.GetCountriesUC.GetCountries());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Guarda en la base de datos los paises obtenidos desde REST Countries
        /// </summary>
        /// <param name="paises"></param>
        /// <returns></returns>
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post()
        {
            try
            {
                //Traemos los paises de la API
                Uri uri = new Uri(urlPaises);
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Get, uri);
                Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    Task<string> response = respuesta.Result.Content.ReadAsStringAsync();
                    response.Wait();
                    List<PaisModel> paises = JsonConvert.DeserializeObject<List<PaisModel>>(response.Result);

                    this.GuardarPaisesUC.GuardarPaises(paises);
                }
                
                return Ok(); 
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


    }
}
