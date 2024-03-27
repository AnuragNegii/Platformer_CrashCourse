using UnityEngine;

public class DamageTheEnemy : MonoBehaviour {
    
    [SerializeField] private int damage = 10;
    [SerializeField] private Vector2 knockBack;

    private void OnTriggerEnter2D(Collider2D other) {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null){
            damageable.IsHit(damage, knockBack);
        }
    }
}