using UnityEngine;

public enum EnemyState
{
    Idle,
    Guarding,
    Attacking,
    Dodging,
    Stunned,
    KnockedOut
}

public class EnemyBoxingAI : MonoBehaviour
{
    public Animator animator;
    public Transform playerHead;

    public float attackRange = 2.0f;
    public float decisionInterval = 1.2f;
    public float punchCooldown = 1.5f;

    private float decisionTimer;
    private float punchTimer;
    private EnemyState state;

    void Update()
    {
        if (state == EnemyState.KnockedOut) return;

        FacePlayer();

        decisionTimer -= Time.deltaTime;
        punchTimer -= Time.deltaTime;

        

        if (decisionTimer <= 0f)
        {
            decisionTimer = decisionInterval;
            DecideAction();
        }
    }

    void FacePlayer()
    {
        if (playerHead == null) return;

        Vector3 lookPos = playerHead.position;
        lookPos.y = transform.position.y;

        Vector3 dir = lookPos - transform.position;

        if (dir.sqrMagnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }

    void DecideAction()
    {
        if (playerHead == null) return;

        float distance = Vector3.Distance(transform.position, playerHead.position);

        if (distance > attackRange)
        {
            animator.SetTrigger("Guard");
            state = EnemyState.Guarding;
            return;
        }

        float roll = Random.value;

        if (punchTimer <= 0f && roll < 0.45f)
        {
            Punch();
        }
        else if (roll < 0.70f)
        {
            Guard();
        }
        else
        {
            Dodge();
        }
    }

    void Punch()
    {
        punchTimer = punchCooldown;
        state = EnemyState.Attacking;

        if (Random.value < 0.5f)
            animator.SetTrigger("LeftPunch");
        else
            animator.SetTrigger("RightPunch");
    }

    void Guard()
    {
        state = EnemyState.Guarding;
        animator.SetTrigger("Guard");
    }

    void Dodge()
    {
        state = EnemyState.Dodging;

        if (Random.value < 0.5f)
            animator.SetTrigger("DodgeLeft");
        else
            animator.SetTrigger("DodgeRight");
    }

    public void Stun()
    {
        state = EnemyState.Stunned;
        animator.SetTrigger("Stunned");
    }

    public void KnockOut()
    {
        state = EnemyState.KnockedOut;
        animator.SetTrigger("KnockOut");
    }
}