using UnityEngine;

public class EnemyPunch : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        // Draw a raycast or something to detect wether it hit the glove as well. - dan

        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}