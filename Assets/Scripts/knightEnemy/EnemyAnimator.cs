using UnityEngine;

public class EnemyAnimator : MonoBehaviour {
    
    private const string HAS_TARGET = "hasTarget";
    private const string IS_Alive = "isAlive";

    [SerializeField] private DetectionZone detectionZone;
    [SerializeField] private EnemyHealthAndDamage enemyHealthAndDamage;
    [SerializeField] private KnightEnemy knightEnemy;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Color startColor;
    private float timer;

    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
    }
    private void Update(){
        animator.SetBool(HAS_TARGET, detectionZone.CanAttack);
        animator.SetBool(IS_Alive, enemyHealthAndDamage.IsAlive());
        if (!enemyHealthAndDamage.IsAlive()){
            timer += Time.deltaTime;
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(startColor.a, 0, timer));
            if(timer > 1){
                Destroy(knightEnemy.gameObject);
            }
        }
    }
}