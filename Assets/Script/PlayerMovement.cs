using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 currentPosition = transform.position;

        if (h != 0)
        {
            currentPosition.x += h * speed * Time.deltaTime;
        }
        else if (v != 0)
        {
            currentPosition.z += v * speed * Time.deltaTime;
        }

        transform.position = currentPosition;
    }
}