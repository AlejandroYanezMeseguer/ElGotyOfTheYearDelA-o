using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private Transform playerTransform;
    private float movementX;
    private float movementY;
    public float knockbackForce = 0.001f;
    private float speed = 20;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private float jumpForce = 6;
    public Vector3 respawn = new Vector3(14, 1, 16);
    public Camera cameraMain;
    public Camera cameraLevel3;
    public Camera camera1st;
    private bool lvl3 = false;
    
    
    void Start()
    {
        camera1st.enabled = false;
        cameraMain.enabled = true;
        cameraLevel3.enabled = false;
        winTextObject.SetActive(false);
        SetCountText();
        rb = GetComponent<Rigidbody>();
        count = 0;
        playerTransform = GetComponent<Transform>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        if (!lvl3 && Input.GetKeyDown(KeyCode.F))
        {
            cameraMain.enabled = !cameraMain.enabled;
            camera1st.enabled = !camera1st.enabled;

        }
        
        
    }

    private void FixedUpdate()
    {
        if (camera1st.enabled)
        {
            Vector3 cameraForward = camera1st.transform.forward;
            Vector3 cameraRight = camera1st.transform.right;
            
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 movement = cameraForward * movementY + cameraRight * movementX;
            rb.AddForce(movement * speed);
        }
        else if (cameraLevel3.enabled)
        {
            Vector3 cameraForward = cameraLevel3.transform.forward;
            Vector3 cameraRight = cameraLevel3.transform.right;
            
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 movement = cameraForward * movementY + cameraRight * movementX;
            rb.AddForce(movement * speed);
        }
        else if (cameraMain.enabled)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
            Vector3 dir = Vector3.zero;

            dir.x = -Input.acceleration.x;
            dir.z = Input.acceleration.y;

            // clamp acceleration vector to unit sphere
            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            // Make it move 10 meters per second instead of 10 meters per frame...
            dir *= Time.deltaTime;
            int acelspeed = 5;

            // Move object
            playerTransform.Translate(dir * acelspeed,Space.World);
        }
    }
    
    public void ApplyKnockback()
    {
        Vector3 knockback = new Vector3(0f, knockbackForce, 0f);
        rb.AddForce(knockback, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            SetCountText();
            count = count + 1;
        }

        if (other.gameObject.CompareTag("dead"))
        {
            playerTransform.position = respawn;
        }
        
        if (other.gameObject.CompareTag("Level2"))
        {
            respawn = new Vector3(-13, 1, 35);
            print("webos");
        }
        
        if (other.gameObject.CompareTag("powerup"))
        {
            speed = 100;
        }
        
        if (other.gameObject.CompareTag("Level3"))
        {
            speed = 20;
            jumpForce = 10;
            lvl3 = true;
        }
        
        if (other.gameObject.CompareTag("changeCamera"))
        {
            cameraMain.enabled = false;
            cameraLevel3.enabled = true;
        }
        
        if (other.gameObject.CompareTag("win"))
        {
            winTextObject.SetActive(true);
            speed = 0;
            jumpForce = 0;
        }

    }
}