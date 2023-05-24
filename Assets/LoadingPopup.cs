using UnityEngine;

public class LoadingPopup : MonoBehaviour
{
    public void Show() => 
        gameObject.SetActive(true);

    public void Close() => 
        gameObject.SetActive(false);
}
