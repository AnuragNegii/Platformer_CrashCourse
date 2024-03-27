using System;
using UnityEngine;

public class PlayerHealthAndDamage : MonoBehaviour, IDamageable {

    public event EventHandler<ONknockBackEventArgs> knockBackEvent;

    public class ONknockBackEventArgs : EventArgs{
        public Vector2 knockBack;
    }

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private int currentHealth;
    private float invulnerabilityTime = 0.5f;
    private float timeSinsceLastGotHit = 0f;
    private bool canGetHit = true;
    
    public bool isHit = false;

    private void Start() {
        currentHealth = maxHealth;
    }

    private void Update(){
        timeSinsceLastGotHit += Time.deltaTime;
        if(timeSinsceLastGotHit > invulnerabilityTime){
            canGetHit = true;
        }
        if(IsAlive() && canGetHit){
            timeSinsceLastGotHit = 0;
            canGetHit = false;
            isHit = false;
        }
    }

    public int IsHit(int damage, Vector2 knockBack)
    {
        if(isAlive){
            currentHealth = currentHealth - damage;
            isHit = true;
            knockBackEvent?.Invoke(this, new ONknockBackEventArgs{
                knockBack = knockBack
            });
            return currentHealth;
        }
        return currentHealth;
    }

    public bool IsAlive()
    {
        if (currentHealth < 1){
            return isAlive = false;
        }
        return isAlive;
    }
}