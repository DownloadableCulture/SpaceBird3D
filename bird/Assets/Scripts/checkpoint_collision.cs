using UnityEngine;

public class checkpoint_collision : MonoBehaviour
{
    public int Checkpoints {get; private set;}
    public AudioSource checkpointSound;
    //public AudioClip checkpointClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        Debug.Log("Total Checkpoints:" +  Checkpoints); 

        checkpointSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            AudioSource checkpointSound= GetComponent<AudioSource>();
            if (checkpointSound != null)
            {
                checkpointSound.Play();
            }


            Checkpoints--;
            Debug.Log("Checkpoints left:" + Checkpoints);
            Destroy(other.gameObject);
        }
        
    }

}
