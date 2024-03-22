using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set;}
    [SerializeField] private PlayerAnimator playerAnimator;
    private TouchingDirections touchingDirections;
    private HealthAndDamage healthAndDamage;
    private GameInput gameInput;
    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float airWalkSpeed = 3f;
    private float currentMoveSpeed{ /// this sets the movement speed for player and the checks for the player if it is alive or not
        get{
            if(playerAnimator.canMove && healthAndDamage.IsAlive()){
                if(playerAnimator.IsWalking && !touchingDirections.IsOnWall){
                    if(touchingDirections.IsGrounded){
                        if(playerAnimator.IsRunning){
                            return runSpeed;
                        }else{
                            return walkSpeed;
                        }
                    }else{
                        //air walk
                        return airWalkSpeed;
                    }
                }return 0;
            }return 0;
        }
    }
    public Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isFacingRight = true;

    private void Awake() {
        if(Instance!= null){
            Debug.LogError("There is more than one Player");
        }
        Instance = this;
        rb= GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        healthAndDamage = GetComponent<HealthAndDamage>();
    }
    private void Start() {
        gameInput = GameInput.Instance;
        gameInput.OnJumpPerformed += gameInput_OnJumpPerformed;
    }

    private void Update() {
        HandleMovement();
        SetFacingDeirection(moveInput);
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveInput.x * currentMoveSpeed, rb.velocity.y);
    }

    private void gameInput_OnJumpPerformed(object sender, EventArgs e)
    {
        float jumpImpulse = 10f;
        if(touchingDirections.IsGrounded && playerAnimator.canMove && healthAndDamage.IsAlive()){
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
    
    private void HandleMovement(){
        moveInput = gameInput.GetMovementVectorNormalized();
    }

    private void SetFacingDeirection(Vector2 movInut){
        if(moveInput.x >0 && !isFacingRight && healthAndDamage.IsAlive()){
            transform.localScale *= new Vector2(-1, 1);
            //move to the right
            isFacingRight = true;
        }else if(moveInput.x < 0 && isFacingRight && healthAndDamage.IsAlive()){
            transform.localScale *= new Vector2(-1, 1);
            //move to the left
            isFacingRight = false;
        }
    }
}