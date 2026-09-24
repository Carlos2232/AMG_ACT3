using UnityEngine;

public class GoalArea : MonoBehaviour
{
    [SerializeField] private GameObject winUIPanel;
    public float reachRadius = 2.5f;
    private Transform player;
    private bool hasWon = false;

    void Start()
    {
        GameObject pObj = GameObject.FindGameObjectWithTag("Player");
        if (pObj != null)
        {
            player = pObj.transform;
        }

        if (winUIPanel != null)
        {
            winUIPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (player == null || hasWon) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= reachRadius)
        {
            hasWon = true;
            TriggerWin();
        }
    }

    void TriggerWin()
    {
        if (winUIPanel != null)
        {
            winUIPanel.SetActive(true);
        }

        var turrets = Object.FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        foreach (var t in turrets)
        {
            if (t.GetType().Name.Contains("Turret"))
            {
                t.enabled = false;
            }
        }
    }
}