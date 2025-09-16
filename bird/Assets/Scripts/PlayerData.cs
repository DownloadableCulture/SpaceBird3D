using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int health = 5;
    public int maxHealth = 5;

    private UpdateInterface updateInterface;
    void Start()
    {
        updateInterface = FindFirstObjectByType<UpdateInterface>();
        if (updateInterface != null )
            updateInterface.UpdateHP(health / (float)maxHealth*100f);
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

            if (updateInterface != null)
                updateInterface.UpdateHP(health / (float)maxHealth * 100f);
        }
        if(health <= 0)
        {
            health = 0;

            if (MainMenuController.Instance != null)
            {
                MainMenuController.Instance.ShowMenu("Game Over!", "Try Again?");
            }
        }
        
    }
    public void ResetPlayer()
    {
        health = maxHealth;
        if (updateInterface != null)
            updateInterface.UpdateHP(health / (int)maxHealth * 100f);

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        //Stop movement
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;       
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
        }
    }
}
