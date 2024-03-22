using UnityEngine;

public class EnemyHealthAndDamage : MonoBehaviour, IDamageable
{
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
            IsHit(10);
            timeSinsceLastGotHit = 0;
            Debug.Log(currentHealth);
        }
    }
    public bool IsAlive()
    {
        if(currentHealth < 1){
            return isAlive = false;
        }
        return isAlive;
    }

    public int IsHit(int damage)
    {
        currentHealth = currentHealth - damage;
        return currentHealth;
    }
}