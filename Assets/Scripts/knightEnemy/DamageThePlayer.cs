using UnityEngine;

public class DamageThePlayer : MonoBehaviour {
    
    private int attackDamage = 10;
    [SerializeField] private Vector2 knockBack;

    private void OnTriggerEnter2D(Collider2D other) {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if(damageable != null){
            damageable.IsHit(attackDamage, knockBack);
        }
    }
}