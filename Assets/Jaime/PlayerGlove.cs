using UnityEngine;

public class PlayerGlove : MonoBehaviour
{
    public Vector3 Velocity { get; private set; }

    private Vector3 lastPosition;

    public bool isBlocking = false;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
}