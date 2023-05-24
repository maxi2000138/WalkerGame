using Infrastructure.Services;
using Player;
using UnityEngine;

namespace Data
{
    public class DataSaver : MonoBehaviour
    {
        private SaveLoadService _saveLoadService;
        private Inventory.Model.Inventory _inventory;
        private PlayerHealth _playerHealth;
        private PlayerDeath _playerDeath;

        public void Construct(SaveLoadService saveLoadService, Inventory.Model.Inventory inventory, Player.Player player)
        {
            _playerHealth = player.PlayerHealth;
            _playerDeath = player.PlayerDeath;
            _inventory = inventory;
            _saveLoadService = saveLoadService;
        }

        private void OnEnable()
        {
            _inventory.OnInventoryChanged += SaveData;
            _playerHealth.HealthChanged += SaveData;
            _playerDeath.Happened += ResetData;
        }

        private void OnDisable()
        {
            _inventory.OnInventoryChanged -= SaveData;
            _playerHealth.HealthChanged -= SaveData;
            _playerDeath.Happened -= ResetData;
        }

        private void SaveData()
        {
            _saveLoadService.SaveProgress();
        }

        private void ResetData()
        {
            _saveLoadService.ResetProgress();
        }
    }
}
