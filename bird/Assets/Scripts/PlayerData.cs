using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int health = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Object"))
        {
            health--;
            Debug.Log("Health:" + health);
        }
    }
}
