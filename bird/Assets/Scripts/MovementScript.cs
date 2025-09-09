using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float push = 20f;
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

        //right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * push, ForceMode.Impulse);
        }

        //left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * push, ForceMode.Impulse);
        }
    }
}
