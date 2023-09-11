using UnityEngine;
using UnityEngine.InputSystem;

public class UnitychanController : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    private InputAction moveAction, cameraAction, jumpAction;



    private void Awake()
    {
        SetupInputAction();
    }



    private void SetupInputAction()
    {
        moveAction = playerInput.currentActionMap["Move"];
        cameraAction = playerInput.currentActionMap["Camera"];
        jumpAction = playerInput.currentActionMap["Jump"];
    }



    public Vector2 GetMove() { return moveAction.ReadValue<Vector2>(); }
    public Vector2 GetCamera() { return cameraAction.ReadValue<Vector2>(); }
    public bool GetJump() { return jumpAction.triggered; }
}
