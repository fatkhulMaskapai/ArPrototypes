using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BussScene : MonoBehaviour
{
    [SerializeField] Button backBtn;
    [SerializeField] string backScene = "MainMenu";
    void Start()
    {
        backBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(backScene);
        });
    }

   
}
