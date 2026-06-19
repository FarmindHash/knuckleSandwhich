using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public InputActionReference DodgeActionReference;
    public InputActionReference LeftBlockReference;
    public InputActionReference RightBlockReference;
    public InputActionReference LeftAudioReference;
    public InputActionReference RightAudioReference;

    InputAction LeftAudio;
    InputAction RightAudio;
    InputAction DodgeAction;
    InputAction LeftBlock;
    InputAction RightBlock;


    public PlayerHealth playerHealth;
    public PlayerGlove playerLeftGlove;
    public PlayerGlove PlayerRightGlove;

    public Transform dodgeVisualiser;
    private Vector3 relativeDodgeVisual;

    public AudioSource leftSource;
    public AudioSource rightSource;

    float xDodge;
    float yDodge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DodgeAction = DodgeActionReference;
        LeftBlock = LeftBlockReference;
        RightBlock = RightBlockReference;
        LeftAudio = LeftAudioReference;
        RightAudio = RightAudioReference;
        relativeDodgeVisual = dodgeVisualiser.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        xDodge = DodgeAction.ReadValue<Vector2>().x;
        yDodge = DodgeAction.ReadValue<Vector2>().y;

        CheckDodge();
        CheckBlock();
        DebugPunchSound();
    }

    void CheckDodge()
    {

        Vector3 targetPosition = relativeDodgeVisual;
        targetPosition.x = relativeDodgeVisual.x + (xDodge / 10);
        targetPosition.z = relativeDodgeVisual.z + (yDodge / 10);

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

        dodgeVisualiser.localPosition = targetPosition;
        /*
        Debug.Log("Dodge status right: " + playerHealth.dodgeRight);
        Debug.Log("Dodge status left: " + playerHealth.dodgeLeft);
        Debug.Log("Dodge status forward: " + playerHealth.dodgeForward);
        Debug.Log("Dodge status back: " + playerHealth.dodgeBack);
        */
    }

    void CheckBlock()
    {
        if (LeftBlock.IsPressed())
        {
            Debug.Log("BLOCKING WITH LEFT HAND!");
            playerLeftGlove.isBlocking = true;
        }
        else
        {
            playerLeftGlove.isBlocking = false;
        }

        if (RightBlock.IsPressed())
        {
            Debug.Log("BLOCKING WITH RIGHT HAND!");
            PlayerRightGlove.isBlocking = true;
        }
        else
        {
            PlayerRightGlove.isBlocking = false;
        }
    }

    void DebugPunchSound()
    {
        if (LeftAudio.WasPressedThisFrame())
        {
            leftSource.Play();
        }
        else if (RightAudio.WasPressedThisFrame()) 
        {
            rightSource.Play();
        }
    }
}
