using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button level2;
    public Button level3;

    [ContextMenu("Reset PlayerPrefs")]
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs reset successfully!");
    }

    public void Start()
    {
        if (!IsLevelUnlocked(2))
        {
            ColorBlock cb1 = level2.colors;
            cb1.highlightedColor = Color.gray;
            cb1.normalColor = Color.gray;
            cb1.selectedColor = Color.gray;
            cb1.pressedColor = Color.gray;
            level2.colors = cb1;
        }

        if (!IsLevelUnlocked(3))
        {
            ColorBlock cb2 = level3.colors;
            cb2.highlightedColor = Color.gray;
            cb2.normalColor = Color.gray;
            cb2.selectedColor = Color.gray;
            cb2.pressedColor = Color.gray;
            level3.colors = cb2;
        }
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayLevel2()
    {
        if (IsLevelUnlocked(2))
        {
            SceneManager.LoadScene(2);
        }
    }
    public void PlayLevel3()
    {
        if (IsLevelUnlocked(3))
        {
            SceneManager.LoadScene(3);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    public bool IsLevelUnlocked(int levelNumber)
    {
        return PlayerPrefs.GetInt($"Level{levelNumber}_Unlock", 0) == 1;
    }

    public void UnlockLevel(int levelNumber)
    {
        PlayerPrefs.SetInt($"Level{levelNumber}_Unlock", 1);
    }
}
