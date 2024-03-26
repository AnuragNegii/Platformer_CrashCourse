using UnityEngine;

public class PlayerHealthAndDamage : MonoBehaviour, IDamageable {

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private bool isAlive = true;

    [SerializeField] private int currentHealth;
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
            timeSinsceLastGotHit = 0;
            canGetHit = false;
        }
    }

    public int IsHit(int damage)
    {
        if(isAlive){
            currentHealth = currentHealth - damage;
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