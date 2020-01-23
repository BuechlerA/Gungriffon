using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraTilt : MonoBehaviour
{
    private Camera viewCam;
    private CharacterController characterController;

    public float tiltAmount = 10f;
    public float smoothAmount = 2f;


    private void Start()
    {
        viewCam = GetComponent<Camera>();
        characterController = GetComponentInParent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.GetComponent<PlayerController>().movementState == MovementModes.boost)
        {
            float tiltAroundZ = Input.GetAxis("MoveHorizontal") * tiltAmount;
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
            // Damper towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smoothAmount);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0f, 0f, 0f, 0f), Time.deltaTime * smoothAmount);
        }
    }
}
