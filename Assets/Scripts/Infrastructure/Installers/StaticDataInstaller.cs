using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Installers
{
    public class StaticDataInstaller : MonoBehaviour
    {
        private StaticDataService _staticDataService;

        public void Construct(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void LoadStaticData()
        {
            _staticDataService.LoadStaticData();
        }
    }
}
