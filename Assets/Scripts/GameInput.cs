using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {

    public static GameInput Instance{get; private set;}
    private PlayerInputActions playerInputActions;
    public event EventHandler OnAttackPerformed;
    public event EventHandler OnJumpPerformed;


    private void Awake() {
        if (Instance != null){
            Debug.LogError("There is more than one GameInput");
        }Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Attack.performed += Attack_Performed;
        playerInputActions.Player.Jump.performed += Jump_Performed;
    }
    void Jump_Performed(InputAction.CallbackContext context)
    {
        OnJumpPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void Attack_Performed(InputAction.CallbackContext context)
    {
        OnAttackPerformed ?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized(){
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }
    
    public bool IsRunning(){
        return playerInputActions.Player.Run.IsPressed();
    }
}