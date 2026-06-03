using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public EnemyHealth health;
    public float minPunchSpeed = 2.5f;
    public float damageMultiplier = 10f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerGlove glove = other.GetComponent<PlayerGlove>();
        if (glove == null) return;

        if (glove.Velocity.magnitude < minPunchSpeed) return;

        float damage = glove.Velocity.magnitude * damageMultiplier;
        health.TakeDamage(damage);
    }
}