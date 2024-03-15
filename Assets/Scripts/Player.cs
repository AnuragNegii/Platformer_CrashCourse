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
    private bool isFacingRight = true;

    private void Awake() {
        if(Instance!= null){
            Debug.LogError("There is more than one Player");
        }
        Instance = this;
        rb= GetComponent<Rigidbody2D>();
    }
    private void Start() {
        gameInput = GameInput.Instance;
    }
    private void Update() {
        HandleMovement();
        SetFacingDeirection(moveInput);
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveInput.x * currentMoveSpeed, rb.velocity.y);
    }

    private void HandleMovement(){
        moveInput = gameInput.GetMovementVectorNormalized();
    }

    private void SetFacingDeirection(Vector2 movInut){
        if(moveInput.x >0 && !isFacingRight){
            transform.localScale *= new Vector2(-1, 1);
            //move to the right
            isFacingRight = true;
        }else if(moveInput.x < 0 && isFacingRight){
            transform.localScale *= new Vector2(-1, 1);
            //move to the left
            isFacingRight = false;
        }

    }
}