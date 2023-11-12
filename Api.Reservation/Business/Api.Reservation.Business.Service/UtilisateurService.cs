
using Api.Reservation.Datas.Repository;
using Api.Utilisateur.Datas.Repository;

namespace Api.Reservation.Business.Service
{
    public class UtilisateurService : IUtilisateurService
    {
        /// <summary>
        /// The utilisateur repository
        /// </summary>
        private readonly IUtilisateurRepository _utilisateurRepository;

        /// <summary>
        /// The reservation repository
        /// </summary>
        private readonly IReservationRepository _reservationRepository;

        /// <summary>
        /// The flights API
        /// </summary>
        private readonly IFlightsApi _flightsApi;


        /// <summary>
        /// Initializes a new instance of the <see cref="UtilisateurService"/> class.
        /// </summary>
        /// <param name="utilisateurRepository">The utilisateur repository.</param>
        /// <param name="flightsApi">The flights API.</param>
        public UtilisateurService(IUtilisateurRepository utilisateurRepository, IReservationRepository reservationRepository, IFlightsApi flightsApi)
        {
            _utilisateurRepository = utilisateurRepository;
            _reservationRepository = reservationRepository;
            _flightsApi = flightsApi;
        }


        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Datas.Entities.Utilisateur>> GetUtilisateursAsync()
        {
            return await _utilisateurRepository.GetUtilisateursAsync()
                .ConfigureAwait(false);
        }
    }


}
