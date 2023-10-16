using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecosistemas_Marinos.Interfaces_Repositorios
{
    public interface IRepositorioEspecie : IRepositorio<EspecieMarina>
    {
        void AsociarEspecieAEcosistema(EspecieMarina especieId, EcosistemaMarino eco);

        public List<EspecieMarina> GetEspeciesPorNombre(string nombreCientifico);


        public IEnumerable<EcosistemaMarino> GetPosiblesEcosistemas();
    }

}
