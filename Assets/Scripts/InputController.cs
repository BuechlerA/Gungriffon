using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    PlayerController playerController;
    PlayerInputActions inputActions;

    Vector3 moveInput;
    Vector3 viewInput;

    bool fireInput;
    bool boostInput;

    public bool isInputEnabled = true;

    void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Default.Move.performed += ctx => OnMove(ctx);
        inputActions.Default.Look.performed += ctx => OnLook(ctx);
        inputActions.Default.Fire.performed += ctx => OnFire(ctx);
        inputActions.Default.Boost.performed += ctx => OnBoost(ctx);

        inputActions.Default.Fire.canceled += ctx => OnFireCancel(ctx);
        inputActions.Default.Boost.canceled += ctx => OnBoostCancel(ctx);
    }

    void OnEnable()
    {
        inputActions.Default.Move.Enable();
        inputActions.Default.Look.Enable();
        inputActions.Default.Fire.Enable();
        inputActions.Default.Boost.Enable();
    }

    void OnDisable()
    {
        inputActions.Default.Disable();
        inputActions.Default.Look.Disable();
        inputActions.Default.Fire.Disable();
        inputActions.Default.Boost.Disable();
    }

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!isInputEnabled)
        {
            moveInput = Vector3.zero;
            viewInput = Vector3.zero;
        }

        playerController.GetInput(moveInput, viewInput, fireInput, boostInput);

        if (Keyboard.current.escapeKey.isPressed)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnMove(InputAction.CallbackContext context)
    {
        if (isInputEnabled)
        {
            Vector2 input = context.ReadValue<Vector2>();
            moveInput = new Vector3(input.x, 0, input.y); // Assuming a 3D game with X and Z as horizontal axes
        }
    }

    void OnLook(InputAction.CallbackContext context)
    {
        if (isInputEnabled)
        {
            Vector2 input = context.ReadValue<Vector2>();
            viewInput = new Vector3(input.x, input.y, 0);
        }
    }

    void OnFire(InputAction.CallbackContext context)
    {
        if (isInputEnabled)
        {
            fireInput = true;
        }
    }

    void OnFireCancel(InputAction.CallbackContext context)
    {
        fireInput = false;
    }

    void OnBoost(InputAction.CallbackContext context)
    {
        if (isInputEnabled)
        {
            boostInput = true;
        }
    }

    void OnBoostCancel(InputAction.CallbackContext context)
    {
        boostInput = false;
    }
}