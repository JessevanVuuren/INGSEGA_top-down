using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayLevel2()
    {

    }
    public void PlayLevel3()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
