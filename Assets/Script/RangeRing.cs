using UnityEngine;

public class RangeRing : MonoBehaviour
{
    public int segments = 40;
    private LineRenderer lineRend;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        float actualRange = 5f; // Default fallback

        // Automatically find the range from whichever turret script is attached here
        FlameTurret flame = GetComponent<FlameTurret>();
        SniperTurret sniper = GetComponent<SniperTurret>();
        ShotgunTurret shotgun = GetComponent<ShotgunTurret>();

        if (flame != null) actualRange = flame.range;
        else if (sniper != null) actualRange = sniper.range;
        else if (shotgun != null) actualRange = shotgun.range;

        lineRend.positionCount = segments + 1;
        lineRend.useWorldSpace = false;

        float angleStep = 360f / segments;
        for (int i = 0; i <= segments; i++)
        {
            float rad = Mathf.Deg2Rad * (i * angleStep);
            float x = Mathf.Sin(rad) * actualRange;
            float z = Mathf.Cos(rad) * actualRange;
            lineRend.SetPosition(i, new Vector3(x, 0f, z));
        }
    }
}