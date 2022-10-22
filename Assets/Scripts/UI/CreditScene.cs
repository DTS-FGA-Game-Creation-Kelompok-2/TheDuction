using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TheDuction.UI
{
    public class CreditScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        
        private void Start()
        {
            _backButton.onClick.AddListener(BackToMenu);
        }
        
        private void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

