using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public PlayerController playerController;
    public int levelToUnlock;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.gameObject.CompareTag("Player") && playerController.enemyAmount == 0)
        {
            PlayerPrefs.SetInt($"Level{levelToUnlock}_Unlock", 1);
            SceneManager.LoadScene(0);
        }
    }
}
