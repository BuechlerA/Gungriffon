using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIAim : MonoBehaviour
{

    public List<Transform> enemiesInArea = new List<Transform>();
    public Transform target;
    public LayerMask targetLayer;

    public GUIBorderBehaviour borderBehaviour;

    private Rect viewRect = new Rect((Screen.width * 0.5f) - 75f, (Screen.height * 0.5f) - 75f, 150f, 150f);

    void Update()
    {
        Aim();
    }

    private void Aim()
    {
        enemiesInArea.Clear();

        if (enemiesInArea.Count <= 0)
        {
            target = null;
        }

        Collider[] enemiesList = Physics.OverlapSphere(transform.position, 100f, targetLayer);

        for (int i = 0; i < enemiesList.Length; i++)
        {
            enemiesInArea.Add(enemiesList[i].transform);
        }

        target = GetClosestTarget();

        if (target != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
            borderBehaviour.SetTransform(screenPos);
            GetComponentInChildren<Gun>().transform.LookAt(target.position);
        }
        if(target == null)
        {
            borderBehaviour.GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
    }

    Transform GetClosestTarget()
    {
        Transform closeTarget = null;
        float minDistance = Mathf.Infinity;

        foreach (Transform enemy in enemiesInArea)
        {
            float distance = Vector3.Distance(enemy.position, transform.position);
            if (distance < minDistance)
            {
                Vector3 enemyScreenPos = Camera.main.WorldToScreenPoint(enemy.position);
                if (viewRect.Contains(enemyScreenPos) && enemyScreenPos.z > 0f)
                {
                    closeTarget = enemy;
                    minDistance = distance;
                }
            }
        }
        
        return closeTarget;
    }
}
