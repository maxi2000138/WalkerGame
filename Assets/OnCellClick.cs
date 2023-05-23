using System;
using UnityEngine;
using UnityEngine.UI;

public class OnCellClick : MonoBehaviour
{
    [SerializeField] private GameObject _deleteButton;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnCellButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnCellButtonClick);
    }

    public void OnCellButtonClick() => 
        _deleteButton.SetActive(!_deleteButton.activeInHierarchy);
}
