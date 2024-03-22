using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private const string IS_WALKING = "isWalking";
    private const string IS_RUNNING = "isRunning";
    private const string IS_GROUNDED = "isGrounded";
    private const string Y_VELOCITY = "yVelocity";
    private const string ATTACK_TRIGGER= "attack";
    private const string CAN_MOVE = "canMove";
    private const string IS_ALive = "isAlive";

    [SerializeField] private TouchingDirections touchingDirections;
    [SerializeField] private PlayerHealthAndDamage playerHealth;
    private Player player;
    private Animator animator;
    private GameInput gameInput;

    
    public bool canMove{
        get{    
            return animator.GetBool(CAN_MOVE);
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

    private void HandleAnimation(){
        Vector2 moveInput = gameInput.GetMovementVectorNormalized();
        isRunning = gameInput.IsRunning();
        isWalking = moveInput != Vector2.zero;

        animator.SetBool(IS_RUNNING, isRunning);
        animator.SetBool(IS_WALKING, isWalking);
        animator.SetBool(IS_GROUNDED, touchingDirections.IsGrounded);
        animator.SetFloat(Y_VELOCITY, player.rb.velocity.y);
        animator.SetBool(IS_ALive, playerHealth.IsAlive());
    }
}