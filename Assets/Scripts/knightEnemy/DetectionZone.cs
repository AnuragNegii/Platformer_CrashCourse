using UnityEngine;

public class DetectionZone : MonoBehaviour {
    
    private bool canAttack;
    public bool CanAttack{
        get{return canAttack;}
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            canAttack = false;
        }
    }
}