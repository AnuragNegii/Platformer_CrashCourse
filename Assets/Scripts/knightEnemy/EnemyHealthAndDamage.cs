using System;
using UnityEngine;

public class EnemyHealthAndDamage : MonoBehaviour, IDamageable
{
    public event EventHandler<KnockBackOnIsHitEventArgs> knockBackEvent;
    public class KnockBackOnIsHitEventArgs : EventArgs
    {
        public Vector2 knockBack;
    }
    public bool isHit = false;

    [SerializeField] private int maxHealth;
    private int currentHealth;
    private bool isAlive = true;
    private float invulnerabilityTime = 0.5f;
    private float timeSinsceLastGotHit = 0f;
    private bool canGetHit = true;

    private void Start() {
        currentHealth = maxHealth;
    }

    private void Update(){
        timeSinsceLastGotHit += Time.deltaTime;
        if(timeSinsceLastGotHit > invulnerabilityTime){
            canGetHit = true;
        }
        if(IsAlive() && canGetHit){
            canGetHit = false;
            timeSinsceLastGotHit = 0;
            isHit = false;
        }
    }
    public bool IsAlive()
    {
        if(currentHealth < 1){
            return isAlive = false;
        }
        return isAlive;
    }

    public int IsHit(int damage, Vector2 knockBack)
    {
        if(isAlive){
            currentHealth = currentHealth - damage;
            isHit = true;
            knockBackEvent?.Invoke(this, new KnockBackOnIsHitEventArgs{
                knockBack = knockBack
            });
            return currentHealth;
        }
        return currentHealth;
    }
}

