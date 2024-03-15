using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set;}
    [SerializeField] private PlayerAnimator playerAnimator;

    private GameInput gameInput;
    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float currentMoveSpeed{
        get{
            if(playerAnimator.IsWalking){
                if(playerAnimator.IsRunning){
                    return runSpeed;
                }else{
                    return walkSpeed;
                }
            }return 0;
        }}
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;


    private void Awake() {
        if(Instance!= null){
            Debug.LogError("There is more than one Player");
        }
        Instance = this;
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start() {
        gameInput = GameInput.Instance;
    }
    private void Update() {
        HandleMovement();
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveInput.x * currentMoveSpeed, rb.velocity.y);
    }

    private void HandleMovement(){
        moveInput = gameInput.GetMovementVectorNormalized();
    }
}