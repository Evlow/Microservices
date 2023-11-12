using Api.Reservation.Datas.Repository;
using Api.Utilisateur.Datas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Reservation.Business.Service
{
    public interface IUtilisateurService
    {
        Task<List<Datas.Entities.Utilisateur>> GetUtilisateursAsync();


    }
}
