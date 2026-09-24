using UnityEngine;

public class ShotgunTurret : MonoBehaviour
{
    public Transform player;
    public float range = 6f;
    public GameObject pelletPrefab;
    private float timer;

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;
        Vector3 dir = player.position - transform.position;
        dir.y = 0f;

        if (dir.magnitude <= range && timer >= 2f)
        {
            timer = 0f;

            float baseAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float[] offsets = { -15f, 0f, 15f };

            transform.rotation = Quaternion.Euler(0f, baseAngle, 0f);

            foreach (float offset in offsets)
            {
                float pelletAngle = baseAngle + offset;
                Quaternion rot = Quaternion.Euler(0f, pelletAngle, 0f);
                Instantiate(pelletPrefab, transform.position, rot);
            }
        }
    }
}