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
    }
}
