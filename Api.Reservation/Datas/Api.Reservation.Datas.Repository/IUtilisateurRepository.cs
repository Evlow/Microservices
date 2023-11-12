
namespace Api.Utilisateur.Datas.Repository
{
    public interface IUtilisateurRepository
    {

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Reservation.Datas.Entities.Utilisateur>> GetUtilisateursAsync();

        /// <summary>
        /// Cette méthode permet de recupérer les informations d'une utilisateur par son identifiant
        /// </summary>
        /// <param name="id">L'identifiant de la utilisateur</param>
        /// <returns></returns>
        Task<Reservation.Datas.Entities.Utilisateur> GetUtilisateurByIdAsync(int id);

        /// <summary>
        /// Cette methode permet de créer un nouvel utilisateur.
        /// </summary>
        /// <param name="utilisateur">Les informations du nouveau utilisateur</param>
        /// <returns></returns>
        Task<Reservation.Datas.Entities.Utilisateur> CreateUtilisateurAsync(Reservation.Datas.Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d'un utilisateur
        /// </summary>
        /// <param name="utilisateur">les informations modifié d'une utilisateur.</param>
        Task UpdateUtilisateur(Reservation.Datas.Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task DeleteUtilisateurAsync(int id);
    }
}

