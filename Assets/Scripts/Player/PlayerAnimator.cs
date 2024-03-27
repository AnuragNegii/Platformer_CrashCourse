using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private const string IS_WALKING = "isWalking";
    private const string IS_RUNNING = "isRunning";
    private const string IS_GROUNDED = "isGrounded";
    private const string Y_VELOCITY = "yVelocity";
    private const string ATTACK_TRIGGER= "attack";
    private const string CAN_MOVE = "canMove";
    private const string IS_ALIVE = "isAlive";
    private const string IS_HIT = "isHit";

    [SerializeField] private TouchingDirections touchingDirections;
    [SerializeField] private PlayerHealthAndDamage playerHealthAndDamage;
    private Player player;
    private Animator animator;
    private GameInput gameInput;

    private bool canMove = true;
    public bool CanMove{
        get{    
            return canMove;
        }
    }
    private bool isRunning;
    public bool IsRunning{get{return isRunning;}}

    private bool isWalking;
    public bool IsWalking{ get {return isWalking;}}
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Start() {
        gameInput = GameInput.Instance;
        player = Player.Instance;
        gameInput.OnAttackPerformed += GameInput_OnAttackAction;
    }

    private void GameInput_OnAttackAction(object sender, EventArgs e)
    {
        animator.SetTrigger(ATTACK_TRIGGER);
    }

    private void Update(){
        HandleAnimation();
    }


    public void SetCanMoveAnimationEventTrue(){
        canMove = true;
    }
    
    public void SetCanMoveAnimationEventFalse(){
        canMove = false;
    }
    private void HandleAnimation(){
        Vector2 moveInput = gameInput.GetMovementVectorNormalized();
        isRunning = gameInput.IsRunning();
        isWalking = moveInput != Vector2.zero;

        animator.SetBool(IS_RUNNING, isRunning);
        animator.SetBool(IS_WALKING, isWalking);
        animator.SetBool(IS_GROUNDED, touchingDirections.IsGrounded);
        animator.SetFloat(Y_VELOCITY, player.rb.velocity.y);
        animator.SetBool(IS_ALIVE, playerHealthAndDamage.IsAlive());
        animator.SetBool(IS_HIT, playerHealthAndDamage.isHit);
        animator.SetBool(CAN_MOVE, canMove);
    }
}