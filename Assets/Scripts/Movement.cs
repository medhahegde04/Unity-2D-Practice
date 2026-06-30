using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector2 moveInput;
    private float sprintInput;

    // built-in function to automatically detect keyboard/controller input
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnSprint(InputValue value)
    {
        sprintInput = value.Get<float>();
    }

    void Update()
    {
        // translate the 2D input (X and Y) into a 3D movement vector
        Vector3 direction = new Vector3(moveInput.x, moveInput.y, 0).normalized;
        float normal_speed = speed;
        if (sprintInput > 0)
        {
            normal_speed = speed * 2.0f;
        }
        transform.Translate(direction * normal_speed * Time.deltaTime);

    }
}
