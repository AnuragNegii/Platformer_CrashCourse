using UnityEngine;

public class GameInput : MonoBehaviour {

    public static GameInput Instance{get; private set;}
    private PlayerInputActions playerInputActions;

    private void Awake() {
        if (Instance != null){
            Debug.LogError("There is more than one GameInput");
        }Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized(){
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }
    public bool IsRunning(){
        return playerInputActions.Player.Run.IsPressed();
    }
}