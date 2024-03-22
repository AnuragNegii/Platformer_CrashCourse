using UnityEngine;

public class PlayerHealthAndDamage : MonoBehaviour, IDamageable {

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    [SerializeField]private bool isAlive = true;
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
            IsHit(10);
            timeSinsceLastGotHit = 0;
            canGetHit = false;
            Debug.Log(currentHealth);
        }
    }
    public int IsHit(int damage)
    {
        currentHealth = currentHealth - damage;
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