using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarSpriteBehaviour : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        gameObject.transform.eulerAngles = new Vector3(90f, player.eulerAngles.y, 0f);
    }
}
