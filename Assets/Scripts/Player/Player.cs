using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Speed and Jump")]
    public float speed;
    public float jump;
    float inputX;

    [Header("Bools")]
    public bool isGrounded;
    public bool isOnBall;

    [Header("Components")]
    public Animator animator;
    public SpriteRenderer[] playerSprites;
    GroundCheck gCheck;
    Rigidbody2D rbody;
    AudioSource audSource;

    [Header("Kick")]
    [SerializeField] GameObject kick;
    public float kickPower;
    [SerializeField] float kickDuration;
    float kickTimer;

    // Start is called before the first frame update
    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        gCheck = GetComponentInChildren<GroundCheck>();
        audSource = GetComponent<AudioSource>();
        //animator is not assigned here! it is assigned in SetupScene
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocityX", Mathf.Abs(inputX)); //talks to the animator

        //flips the sprite depending on which way it is faced
        if (inputX > 0) { transform.localScale = Vector3.one; }
        else if (inputX < 0) { transform.localScale = new(-1, 1, 1); }

        //sets the airborne bool in animator, note it should be opposite of grounded
        if (isGrounded) { animator.SetBool("isAirborne", false); }
        else { animator.SetBool("isAirborne", true); }

        if (kickTimer > 0) { kickTimer -= Time.deltaTime; }
        if (kickTimer <= 0) { kick.SetActive(false); }
    }

    private void FixedUpdate() { rbody.velocity = new(inputX * speed, rbody.velocity.y); } //sets velocity

    //unitys new input system
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (isGrounded) //if on ground, do a regular jump
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0); //Reset our y speed before the jump
            rbody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            audSource.Play();
        }
        if (isOnBall) //if were standing on the ball, apply a force to it backwards
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0);
            rbody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

            gCheck.ball.gameObject.GetComponent<Rigidbody2D>().AddForce(new(4f * (transform.localScale.x * -1), -4), ForceMode2D.Impulse);
        }
    }

    public void Kick(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            kick.SetActive(true);
            kickTimer = kickDuration;
            animator.SetTrigger("kick");
        }
    }
}
