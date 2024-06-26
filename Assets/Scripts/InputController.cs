using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    PlayerController playerController;

    Vector3 moveInput;
    Vector3 viewInput;

    bool fireInput;
    bool boostInput;

    public bool isInputEnabled = true;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInputEnabled)
        {
            float horMove = Input.GetAxisRaw("MoveHorizontal");
            float verMove = Input.GetAxisRaw("MoveVertical");

            float horView = Input.GetAxisRaw("ViewHorizontal");
            float verView = Input.GetAxisRaw("ViewVertical");

            moveInput = new Vector3(horMove, verMove);
            viewInput = new Vector3(horView, verView);

            fireInput = Input.GetButton("Fire");
            boostInput = Input.GetButton("Boost");
        }
        else
        {
            moveInput = new Vector3(0, 0, 0);
            viewInput = new Vector3(0, 0, 0);
        }

        playerController.GetInput(moveInput, viewInput, fireInput, boostInput);

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
