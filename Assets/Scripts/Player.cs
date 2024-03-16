using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set;}
    [SerializeField] private PlayerAnimator playerAnimator;
    private TouchingDirections touchingDirections;
    private GameInput gameInput;
    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float airWalkSpeed = 3f;
    private float currentMoveSpeed{
        get{
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
        }}
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
    }
    private void Start() {
        gameInput = GameInput.Instance;
        gameInput.OnJumpPerformed += gameInput_OnJumpPerformed;
    }

    private void gameInput_OnJumpPerformed(object sender, EventArgs e)
    {
        float jumpImpulse = 10f;
        if(touchingDirections.IsGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
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