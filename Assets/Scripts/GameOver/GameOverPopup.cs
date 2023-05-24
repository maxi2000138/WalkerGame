using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameOver
{
    public class GameOverPopup : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(ReplayGame);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ReplayGame);
        }

        public void Show() => 
            gameObject.SetActive(true);

        public void Close() => 
            gameObject.SetActive(false);

        public void ReplayGame()
        {
            Close();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
