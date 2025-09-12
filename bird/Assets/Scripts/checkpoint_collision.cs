using UnityEngine;

public class checkpoint_collision : MonoBehaviour
{
    public int Checkpoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        Debug.Log("Total Checkpoints:" +  Checkpoints); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            Checkpoints--;
            Debug.Log("Checkpoints left:" + Checkpoints);
            Destroy(other.gameObject);
        }
        
    }

}
