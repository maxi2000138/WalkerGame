using Inventory.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class DeleteItemButton : MonoBehaviour
    {
        [SerializeField] private CellPresenter _cellPresenter;
    
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(DeleteItem);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(DeleteItem);
        }

        public void DeleteItem() => 
            _cellPresenter.RemoveItem();
    }
}
