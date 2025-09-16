using UnityEngine;

public class checkpoint_collision : MonoBehaviour
{
    public int Checkpoints {get; private set;}
    public AudioSource checkpointSound;

    private UpdateInterface updateInterface;
    //public AudioClip checkpointClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        Debug.Log("Total Checkpoints:" +  Checkpoints); 

        checkpointSound = GetComponent<AudioSource>();

        updateInterface = FindFirstObjectByType<UpdateInterface>();
        if (updateInterface != null)
            updateInterface.UpdateCheckpoints(Checkpoints);
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

            if (updateInterface != null)
                updateInterface.UpdateCheckpoints(Checkpoints);

            Destroy(other.gameObject);
        }
        
    }

}
