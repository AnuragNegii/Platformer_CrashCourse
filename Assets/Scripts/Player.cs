using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set;}
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float walkSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] private bool isMoving;

    private void Awake() {
        if(Instance!= null){
            Debug.LogError("There is more than one Player");
        }
        Instance = this;
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update() {
        HandleMovement();
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
    }

    private void HandleMovement(){
        moveInput = gameInput.GetMovementVectorNormalized();
        isMoving = moveInput != Vector2.zero;
    }
}