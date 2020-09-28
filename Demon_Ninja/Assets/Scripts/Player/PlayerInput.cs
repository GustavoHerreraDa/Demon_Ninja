using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float horizontal;
    [HideInInspector] public bool jumpPressed;

    bool readyToClear;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ClearInput();

        ProcessInputs();

        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
    }

    void FixedUpdate()
    {
        readyToClear = true;
    }

    void ProcessInputs()
    {
        horizontal += Input.GetAxis("Horizontal");
        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
    }


    void ClearInput()
    {
        if (!readyToClear)
            return;

        horizontal = 0f;
        jumpPressed = false;

        readyToClear = false;
    }


}
