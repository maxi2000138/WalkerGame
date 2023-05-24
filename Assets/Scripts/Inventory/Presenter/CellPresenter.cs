using Inventory.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Presenter
{
    public class CellPresenter : MonoBehaviour
    {
        [SerializeField] private Image _iconField;
        [SerializeField] private TextMeshProUGUI _amountField;
        [SerializeField] private GameObject _amountObject;
        
        private InventoryPresenter _inventoryPresenter;
        private IReadonlyCell _cell;

        public void Construct(InventoryPresenter inventoryPresenter)
        {
            _inventoryPresenter = inventoryPresenter;
        }
        
        public void Render(IReadonlyCell cell)
        {
            _cell = cell;
            
            if(cell.Count == 1)
                _amountObject.SetActive(false);
            else
                _amountField.text = cell.Count.ToString();
            
            _iconField.sprite = cell.Item.Icon;
        }

        public void RemoveItem() => 
            _inventoryPresenter.RemoveItem(_cell.Item);
    }
}
