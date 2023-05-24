using Infrastructure.Services;
using UnityEngine;

public class SaveArea : MonoBehaviour
{
    private SaveLoadService _saveLoadService;

    public void Construct(SaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        _saveLoadService.SaveProgress();
        Debug.Log("Progress Saved!");
    }
}
