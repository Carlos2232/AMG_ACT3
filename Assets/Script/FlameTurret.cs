using UnityEngine;

public class FlameTurret : MonoBehaviour
{
    public Transform player;
    public float range = 8f;
    public float coneAngle = 60f;

    public GameObject flamePrefab; 
    public float fireRate = 0.25f; 
    private float fireTimer;

    void Update()
    {
        if (player == null) return;

        Vector3 dir = player.position - transform.position;
        dir.y = 0f;

        if (dir.magnitude <= range)
        {
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            float currentRotY = transform.eulerAngles.y;
            float delta = Mathf.Abs(Mathf.DeltaAngle(currentRotY, angle));

            if (delta <= coneAngle / 2f)
            {
                fireTimer += Time.deltaTime;
                if (fireTimer >= fireRate)
                {
                    fireTimer = 0f;
                    ShootFlame();
                }
            }
        }
    }

    void ShootFlame()
    {
        if (flamePrefab != null)
        {
            Instantiate(flamePrefab, transform.position + transform.forward, transform.rotation);
        }
    }
}