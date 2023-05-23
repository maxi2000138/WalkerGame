using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryButton : MonoBehaviour
    {
        [SerializeField] private GameObject InventoryPanel;

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
            InventoryPanel.SetActive(!InventoryPanel.activeInHierarchy);
        }
    }
}
