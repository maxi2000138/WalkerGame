using Data.TypeIds;
using Infrastructure.DI;
using Infrastructure.Services;
using Inventory.Model;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Inventory.View
{
    public class InventoryPresenter : MonoBehaviour
    {
        [SerializeField] private CellPresenter _cellPresenter;
        [SerializeField] private Transform _container;
    
        private Model.Inventory _inventory;
        private GameFactory _gameFactory;

        public void Construct(Model.Inventory inventory)
        {
            _inventory = inventory;
        }

        private void Start()
        {
            _gameFactory = ServiceLocator.Container.GetService<GameFactory>();
            Render();
        }

        private void OnEnable()
        {
            Render();
            _inventory.OnInventoryChanged += Render;
        }

        private void OnDisable()
        {
            _inventory.OnInventoryChanged -= Render;
        }

        public void Show() => 
            gameObject.SetActive(true);

        public void Close() => 
            gameObject.SetActive(false);

        public void RemoveItem(Item item)
        {
            _inventory.RemoveItem(item);
            Render();
        }

        [Button]
        private void ResetInventory()
        {
            _inventory = _gameFactory.CreateInventory();
        }

        [Button]
        private void AddApples()
        {
            Item item = _gameFactory.CreateLootItem(LootTypeId.Apple);
            _inventory.AddItem(item, 10);
        }

        [Button]
        private void Render()
        {
            foreach (Transform child in _container) 
                Destroy(child.gameObject);

            _inventory.Cells.ForEach(item =>
            {
                CellPresenter cell = Instantiate(_cellPresenter, _container);
                cell.Construct(this);
                cell.Render(item);
            });
        }
    }
}
