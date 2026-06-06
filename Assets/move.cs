using UnityEngine;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 moveInput;

    // built-in function to automatically detect keyboard/controller input
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        // translate the 2D input (X and Y) into a 3D movement vector
        Vector3 direction = new Vector3(moveInput.x, moveInput.y, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
