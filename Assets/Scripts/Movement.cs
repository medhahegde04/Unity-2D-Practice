using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector2 moveInput;
    private float sprintInput;
    private string lastPressedAxis = "";
    private Animator anim;
    private AudioSource footstepAudio;

    void Start()
    {
        // automatically find the Animator component when the game starts
        anim = GetComponent<Animator>();
        footstepAudio = GetComponent<AudioSource>();
    }

    // built-in function to automatically detect keyboard/controller input
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (value.Get<Vector2>().x != 0)
        {
            lastPressedAxis = "Horizontal";
        }
        if (value.Get<Vector2>().y != 0)
        {
            lastPressedAxis = "Vertical";
        }
    }

    public void OnSprint(InputValue value)
    {
        sprintInput = value.Get<float>();
    }

    public void PlayFootstepSound()
    {
        if (footstepAudio != null)
        {
            footstepAudio.Play();
        }
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;
        // translate the 2D input (X and Y) into a 3D movement vector
        if (lastPressedAxis == "Horizontal")
        {
            direction = new Vector3(moveInput.x, 0, 0).normalized;
        }
        else
        {
            direction = new Vector3(0, moveInput.y, 0).normalized;
        }

        float normal_speed = speed;
        if (sprintInput > 0)
        {
            normal_speed = speed * 2.0f;
        }
        transform.Translate(direction * normal_speed * Time.deltaTime);


        // send direction variables to the Animator parameters
        if (moveInput.magnitude > 0)
        {
            if (lastPressedAxis == "Horizontal")
            {
                anim.SetFloat("Horizontal", direction.x);
                anim.SetFloat("Vertical", 0f);
            }
            else
            {
                anim.SetFloat("Horizontal", 0f);
                anim.SetFloat("Vertical", direction.y);
            }

            // update the Speed parameter to switch between Idle and Walk states
            anim.SetFloat("Speed", 1f);
        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }


    }
}
