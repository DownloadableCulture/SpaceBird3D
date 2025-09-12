using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float RotationSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, RotationSpeed * Time.deltaTime);
    }
}
