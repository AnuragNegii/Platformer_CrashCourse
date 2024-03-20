using UnityEngine;

public class EnemyAnimator : MonoBehaviour {
    
    private const string HAS_TARGET = "hasTarget";

    [SerializeField] private DetectionZone detectionZone;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Update(){
        animator.SetBool(HAS_TARGET, detectionZone.CanAttack);
    }
}