using System;
using UnityEngine;

public class KnightEnemy : MonoBehaviour {
    
    [SerializeField] private DetectionZone detectionZone;
    [SerializeField] private EnemyHealthAndDamage enemyHealthAndDamage;
    private Rigidbody2D rb;
    private TouchingDirections td;
    private Vector2 walkDirection = new Vector2(1, 0);

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        td = GetComponent<TouchingDirections>();
    }

    private void Start() {
        enemyHealthAndDamage.knockBackEvent += EnemyHealthAndDamage_KnockBackEvent;
    }

    private void EnemyHealthAndDamage_KnockBackEvent(object sender, EnemyHealthAndDamage.KnockBackOnIsHitEventArgs e)
    {
       rb.velocity = new Vector2(e.knockBack.x, e.knockBack.y);
    }

    private void Update(){
        wallCheckDirection();
    }

    private void FixedUpdate()
    {
        if(enemyHealthAndDamage.IsAlive() && !enemyHealthAndDamage.isHit){
            EnemyWalk();
        }
    }

    private void EnemyWalk()
    {
        float walkSpeed = 3f;
        float enemyStop = 0f;
        float time = 0.2f;
        if(!detectionZone.CanAttack){
            rb.velocity = new Vector2(walkSpeed * walkDirection.x, rb.velocity.y);
        }else{
            //rb.velocity.x is taken because the velocity will decrease with time but if we had taken walk speed then it would not have changed
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, enemyStop, time), rb.velocity.y);
        }
    }

    private void wallCheckDirection(){
        if(td.IsGrounded && td.IsOnWall && enemyHealthAndDamage.IsAlive()){
            transform.localScale *= new Vector2(-1, 1);
            walkDirection *= -1;
        }
    }
}