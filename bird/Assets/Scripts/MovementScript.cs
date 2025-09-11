using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float push = 20f;
    public float rotationSpeed = 100f;
    
    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //forward and up
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * push, ForceMode.Impulse);
            rb.AddForce(transform.up * push, ForceMode.Impulse);
        }

        // rotate right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(Vector3.up * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        // rotate left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(-Vector3.up * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        // rotate left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(-Vector3.up * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        // rotate up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddTorque(-Vector3.right * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        // rotate down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddTorque(Vector3.right * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
