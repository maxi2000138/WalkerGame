using System;
using Data.DataObjects;
using Inventory.Model;
using UnityEngine;
using UnityEngine.UI;

public class LootObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Inventory.Model.Inventory _inventory;
    private Item _item;

    public void Construct(Item item, Inventory.Model.Inventory inventory)
    {
        _item = item;
        _inventory = inventory;
        _spriteRenderer.sprite = item.Icon;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        PickUp();
    }

    private void PickUp()
    {
        _inventory.AddItem(_item, 1);
        gameObject.SetActive(false);
    }
    
    
}
