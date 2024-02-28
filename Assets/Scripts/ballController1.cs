using UnityEngine;
using System.Collections;
public class ballController1 : MonoBehaviour
{
    LayerMask groundLayerMask;
    LayerMask hillLayerMask;


    //need to create onGround variable
    public float earlyJumpforce = 10f;
    public float jumpForce = 0.25f;
    public float maxJumpTime = 1f;
    public float tiltSpeed = 5f;
    public float maxTiltAngle = 30f;
    public float fallMulti = 2.5f;
    public float lowJump = 2f;
    public float maxFall = 10f;
    public float moveSpeed = -5f; // Adjust this to control the speed of movement
    float tiltInput;


    //sound
    public AudioSource source;
    public AudioClip jump;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private float jumpTime = 0f;

    //public bool is jumping
    public bool Hilled;
    public bool Grounded ;
    public bool AirJump = false;

    void Awake()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        hillLayerMask = LayerMask.GetMask("Hill");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
       

    }


    void Update()
    { 
        Grounded = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0.5f, groundLayerMask);
        Hilled = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0.5f, hillLayerMask);

        if (Grounded == true)
        {
            AirJump = false;
        }
        // Check for jump input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Grounded){
                source.PlayOneShot(jump);
                isJumping = true;
                rb.AddForce((Vector2.up * earlyJumpforce), ForceMode2D.Impulse);
                Debug.Log(" early jumping");
            }
            

            //Jump();
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (isJumping)
            {
                //ump();
                isJumping = false;
               // jumpTime = 0f;
            }
        }




        // Longer jump if tapping longer, but not exceeding max jump time
        if (isJumping)
        {
            Jump();
            jumpTime += (Time.deltaTime);

            if (jumpTime >= maxJumpTime)
            {
                isJumping = false;
                jumpTime = 0f;
            }
        }
        //left and right code
        float tiltInput = -Input.acceleration.x;
        if (Grounded == true)
        {
            // Rotate the ball based on device tilt 
            

            // Remove velocity code

            float targetRotationZ = tiltInput * maxTiltAngle;

            rb.MoveRotation(rb.rotation + (targetRotationZ * tiltSpeed));
            Debug.Log("grounded is TRUE");

        }  else 
        {
            Invoke("AirJumpIsTrue", 0.1f);
        }
        if(AirJump == true && Hilled == false)
        {
            Debug.Log("grounded is false");
            // Tilt the ball based on device tilt

            Vector2 currentVelocity = rb.velocity;
            rb.velocity = new Vector2(tiltInput * moveSpeed, currentVelocity.y);

            float targetRotationZ = tiltInput * maxTiltAngle;
            transform.rotation = Quaternion.Euler(0, 0, targetRotationZ);
        }
       

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJump - 1) * Time.deltaTime;
        }
    }

    void Jump()
    {
        Debug.Log(" late jumping");
        rb.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
    }

    void AirJumpIsTrue()
    {
        AirJump = true;
    }
}