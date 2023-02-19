using bouwmarkt_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace bouwmarkt_API.Repositories
{
    public interface IVestigingRepository
    {
        Task<ActionResult<IEnumerable<Vestiging>>> GetVestigingen();

        Task<ActionResult<Vestiging>> GetVestiging(int id);

        void PutVestiging(Vestiging vestiging);

        void PostVestiging(Vestiging vestiging);

        public void DeleteVestiging(Vestiging vestiging);

        Task<Vestiging?> FindVestigingById(int id);

        bool VestigingExists(int id);
    }
}
