using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILerp : MonoBehaviour
{
    public Vector2 amount;
    public float lerp = 0.5f;

    void Update()
    {
    }

    public void Lerp(Vector3 movement)
    {
        //float x = Input.GetAxis("ViewHorizontal");
        //float y = Input.GetAxis("ViewVertical");
        float x = movement.x;
        float y = movement.y;

        transform.localEulerAngles = new Vector3(Mathf.LerpAngle(transform.localEulerAngles.x, y * amount.y, lerp), Mathf.LerpAngle(transform.localEulerAngles.y, x * amount.x, lerp), 0);
    }
}
