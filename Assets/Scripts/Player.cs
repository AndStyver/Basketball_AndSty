using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;

    float inputX;

    Rigidbody2D rbody;

    public bool isGrounded;

    [SerializeField] Animator animator;

    [SerializeField] GameObject[] playerSprites;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>(false); //(false) means it wont search in inactive children
        if (animator == null) { Debug.LogError("Can't find Animator, are all PlayerSprites inactive?"); }
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = new(inputX * speed, rbody.velocity.y);
        animator.SetFloat("velocityX", Mathf.Abs(inputX));

        if (inputX > 0) { transform.localScale = Vector3.one; }
        else if (inputX < 0) { transform.localScale = new(-1, 1, 1); }

        if (isGrounded) { animator.SetBool("isAirborne", false); }
        else { animator.SetBool("isAirborne", true); }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0); //Reset our y speed before the jump
            rbody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }
}
