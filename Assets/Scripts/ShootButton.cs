using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShootButton : MonoBehaviour
{
    public event Action OnShootButtonClicked;
    
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(OnShootButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnShootButtonClick);
    }

    private void OnShootButtonClick() => 
        OnShootButtonClicked?.Invoke();
}
