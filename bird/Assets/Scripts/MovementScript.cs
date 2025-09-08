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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * push, ForceMode.Impulse);
            rb.AddForce(transform.up * push, ForceMode.Impulse);
        }
    }
}
