using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
