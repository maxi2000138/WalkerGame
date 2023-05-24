using Inventory.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class InventoryButton : MonoBehaviour
    {
        [SerializeField] private InventoryPresenter _inventoryPanel;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        public void OnButtonClick()
        {
            if(_inventoryPanel.gameObject.activeInHierarchy)
                _inventoryPanel.Close();
            else
                _inventoryPanel.Show();
        }
    }
}
