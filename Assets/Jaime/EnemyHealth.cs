using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public EnemyBoxingAI ai;

    private float health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            ai.KnockOut();
        }
        else
        {
            ai.Stun();
        }
    }
}