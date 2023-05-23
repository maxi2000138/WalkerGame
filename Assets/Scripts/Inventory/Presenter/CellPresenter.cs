using Inventory.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.View
{
    public class CellPresenter : MonoBehaviour
    {
        [SerializeField] private Image _iconField;
        [SerializeField] private TextMeshProUGUI _amountField;
        
        private InventoryPresenter _inventoryPresenter;
        private IReadonlyCell _cell;

        public void Construct(InventoryPresenter inventoryPresenter)
        {
            _inventoryPresenter = inventoryPresenter;
        }
        
        public void Render(IReadonlyCell cell)
        {
            _cell = cell;
            _iconField.sprite = cell.Item.Icon;
            _amountField.text = cell.Count.ToString();
        }

        public void RemoveItem() => 
            _inventoryPresenter.RemoveItem(_cell.Item);
    }
}
