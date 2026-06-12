using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public InputActionReference DodgeActionReference;
    public PlayerHealth playerHealth;

    float xDodge;
    float yDodge;
    InputAction DodgeAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DodgeAction = DodgeActionReference;
    }

    // Update is called once per frame
    void Update()
    {
        xDodge = DodgeAction.ReadValue<Vector2>().x;
        yDodge = DodgeAction.ReadValue<Vector2>().y;

        CheckDodge();
    }

    void CheckDodge()
    {
        if (xDodge > 0.01f)
        {
            playerHealth.dodgeRight = true;
            playerHealth.dodgeLeft = false;
        }
        else if (xDodge < -0.01f)
        {
            playerHealth.dodgeRight = false;
            playerHealth.dodgeLeft = true;
        }
        else
        {
            playerHealth.dodgeRight = false;
            playerHealth.dodgeLeft = false;
        }

        if (yDodge > 0.01f)
        {
            playerHealth.dodgeForward = true;
            playerHealth.dodgeBack = false;
        }
        else if (yDodge < -0.01f)
        {
            playerHealth.dodgeForward = false;
            playerHealth.dodgeBack = true;
        }
        else
        {
            playerHealth.dodgeForward = false;
            playerHealth.dodgeBack = false;
        }
        Debug.Log("Dodge status right: " + playerHealth.dodgeRight);
        Debug.Log("Dodge status left: " + playerHealth.dodgeLeft);
        Debug.Log("Dodge status forward: " + playerHealth.dodgeForward);
        Debug.Log("Dodge status back: " + playerHealth.dodgeBack);
    }
}
