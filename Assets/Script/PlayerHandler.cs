using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Hazard"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}