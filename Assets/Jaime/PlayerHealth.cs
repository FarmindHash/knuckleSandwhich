using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    private float currentHealth;

    public bool dodgeLeft = false;
    public bool dodgeRight = false;
    public bool dodgeForward = false;
    public bool dodgeBack = false;

    public bool attackLeft = false;
    public bool attackRight = false;
    public bool attackForward = false;
    public bool attackBack = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        damage = CalculateDamage(damage);
        currentHealth -= damage;

        Debug.Log("Player took damage: " + damage);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Knocked Out");
    }

    float CalculateDamage(float damage)
    {
        float modifier = 1f;

        if (FailDodge())
        {
            modifier = 2f;
        }

        damage *= modifier;
        return damage;
    }

    bool FailDodge()
    {
        if ((dodgeLeft && attackLeft) || (dodgeRight && attackRight) || (dodgeForward && attackForward) || (dodgeBack && attackBack))
        {
            return true;
        }
        return false;
    }
}