using UnityEngine;

public interface IDamageable{

    public bool IsAlive();

    public int IsHit(int damage, Vector2 knockBack);
}