using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public InputActionReference Steer;
    public InputActionReference Boost;
    public float push = 20f;
    public float rotationSpeed = 100f;
    
    private Rigidbody rb;
    private Vector2 rotation;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = Steer.action.ReadValue<Vector2>();


        //forward and up
        if (Boost.action.WasPerformedThisFrame())
        {
            rb.AddForce(transform.forward * push, ForceMode.Impulse);
            rb.AddForce(transform.up * push/4, ForceMode.Impulse);
            rb.useGravity = true;
        }


        if(rotation != Vector2.zero)
        {
            //left and right
            rb.AddTorque(transform.up * rotation.x * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
            //up and down
            rb.AddTorque(-transform.right * rotation.y * rotationSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
    private void OnEnable()
    {
        Steer.action.Enable();
        Boost.action.Enable();
    }

    private void OnDisable()
    {
        Steer.action.Disable();
        Boost.action.Disable();
    }
}
