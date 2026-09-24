using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMover : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;
    public float hitRadius = 0.8f; 

    private Transform player;

    void Start()
    {
        Destroy(gameObject, lifetime);

        GameObject pObj = GameObject.FindGameObjectWithTag("Player");
        if (pObj != null)
        {
            player = pObj.transform;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= hitRadius)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}