using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 1f;
    public float turnSpeed = 1f;

    public float maxBoostTime = 0.8f;
    public float boostSpeed = 2f;
    public float dashStopTime = 0.3f;
    private float currentBoostTime;

    public MovementModes movementState;

    private CharacterController characterController;
    private Camera viewCam;
    private Camera guiCam;

    public Gun gun;

    private void Start()
    {
        movementState = MovementModes.walk;
        currentBoostTime = maxBoostTime;

        characterController = GetComponent<CharacterController>();
        viewCam = Camera.main;
        guiCam = GameObject.Find("GUICamera").GetComponent<Camera>();
    }

    public void GetInput(Vector3 moveVector, Vector3 viewVector, bool shoot, bool dash)
    {
        Movement(moveVector, dash);
        View(viewVector, moveVector);

        if (shoot)
        {
            Shoot();
        }
    }

    public void Movement(Vector3 movePlayer, bool dash)
    {

        if (dash)
        {
            movementState = MovementModes.boost;
            currentBoostTime = 0f;
            if (currentBoostTime < maxBoostTime)
            {
                characterController.Move(transform.TransformDirection(new Vector3(0f, 0f, boostSpeed) * Time.deltaTime));
                currentBoostTime += dashStopTime;
            }
        }
        else
        {
            movementState = MovementModes.walk;
        }

        if (movementState == MovementModes.walk)
        {
            characterController.Move(transform.TransformDirection(movePlayer.x, 0, -movePlayer.y) * walkSpeed * Time.deltaTime);
            viewCam.GetComponent<Camerabob>().Headbobbing(movePlayer.magnitude);
        }
    }

    public void View(Vector3 viewPlayer, Vector3 movePlayer)
    {
        if (movementState == MovementModes.walk)
        {
            transform.localEulerAngles += new Vector3(0, viewPlayer.x, 0) * turnSpeed;
            viewCam.transform.localEulerAngles += new Vector3(viewPlayer.y, 0, 0) * turnSpeed;
            guiCam.GetComponent<GUILerp>().Lerp(viewPlayer);
        }
        if (movementState == MovementModes.boost)
        {
            transform.localEulerAngles += new Vector3(0, movePlayer.x, 0) * turnSpeed;
            viewCam.transform.localEulerAngles += new Vector3(movePlayer.y, 0, 0) * turnSpeed;
            guiCam.GetComponent<GUILerp>().Lerp(movePlayer);
        }
    }

    public void Shoot()
    {
        gun.Shoot();
    }

}

public enum MovementModes
{
    walk,
    boost
}
