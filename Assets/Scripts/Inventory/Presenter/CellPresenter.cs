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
        
        public void Render(IReadonlyCell cell)
        {
            _iconField.sprite = cell.Item.Icon;
            _amountField.text = cell.Count.ToString();
        }
    }
}
