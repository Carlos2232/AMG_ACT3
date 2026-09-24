using UnityEngine;

public class SniperTurret : MonoBehaviour
{
    public Transform player;
    public float range = 12f;
    public GameObject bulletPrefab;
    private bool hasFired = false;

    void Update()
    {
        if (player == null || hasFired) return;

        Vector3 forward = transform.forward;
        Vector3 toPlayer = player.position - transform.position;
        toPlayer.y = 0f;

        if (toPlayer.magnitude <= range)
        {
            float dot = Vector3.Dot(forward, toPlayer.normalized);
            if (dot >= 0.98f)
            {
                Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
                hasFired = true;
            }
        }
    }
}