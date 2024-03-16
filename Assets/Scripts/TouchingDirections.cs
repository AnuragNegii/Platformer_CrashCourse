using UnityEngine;

public class TouchingDirections : MonoBehaviour {
    
    [SerializeField] private ContactFilter2D contactFilter2D;
    private CapsuleCollider2D capsuleCollider2D;
    private RaycastHit2D[] groundHit = new RaycastHit2D[5];
    private RaycastHit2D[] wallHit = new RaycastHit2D[5];
    private RaycastHit2D[] ceilingHit = new RaycastHit2D[5];

    private Vector2 wallCheckDirection => transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    private bool isGrounded;
    public bool IsGrounded{get{return isGrounded;}}

    private bool isOnWall;
    public bool IsOnWall { get{return isOnWall;}}

    private bool isOnCeiling;
    public bool IsOnCeiling{get{return isOnCeiling;}}

    private void Awake() {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    
    private void FixedUpdate(){
        float groundDistance = 0.05f;
        float wallDistance = 0.05f;
        float ceilingDistance = 0.2f;

        isGrounded = capsuleCollider2D.Cast(Vector2.down, contactFilter2D, groundHit, groundDistance) > 0;
        isOnWall = capsuleCollider2D.Cast(wallCheckDirection, contactFilter2D, wallHit, wallDistance) > 0;
        isOnCeiling = capsuleCollider2D.Cast(Vector2.up, contactFilter2D, ceilingHit, ceilingDistance) > 0;
    }
}