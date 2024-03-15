using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    private Animator animator;
    private GameInput gameInput;

    private bool isRunning;
    public bool IsRunning{get{return isRunning;}}

    private bool isWalking;
    public bool IsWalking{ get {return isWalking;}}
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Start() {
        gameInput = GameInput.Instance;
    }

    private void Update(){
        HandleAnimation();
    }

    private void HandleAnimation(){
        Vector2 moveInput = gameInput.GetMovementVectorNormalized();
        isRunning = gameInput.IsRunning();
        isWalking = moveInput != Vector2.zero;

        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isWalking", isWalking);
    }
}