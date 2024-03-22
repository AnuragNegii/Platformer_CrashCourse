using UnityEngine;

public class EnemyAnimator : MonoBehaviour {
    
    private const string HAS_TARGET = "hasTarget";
    private const string IS_Alive = "isAlive";

    [SerializeField] private DetectionZone detectionZone;
    [SerializeField] private EnemyHealthAndDamage enemyHealthAndDamage;
    
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Update(){
        animator.SetBool(HAS_TARGET, detectionZone.CanAttack);
        animator.SetBool(IS_Alive, enemyHealthAndDamage.IsAlive());
    }
}