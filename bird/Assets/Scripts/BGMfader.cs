using UnityEngine;

public class BGMfader : MonoBehaviour
{
    public checkpoint_collision cpc;
    public AudioSource bgmSource;
    public float FadeSpeed = 1f;
    public float TargetVolume = 1f;
    public int CheckPointTrigger = 2;

    private bool fading = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cpc  != null && !fading)
        {
            if (cpc.Checkpoints <= CheckPointTrigger)
            {
                fading = true;
            }
        }
        if (fading && bgmSource != null)
        {
            bgmSource.volume = Mathf.MoveTowards(bgmSource.volume, TargetVolume, FadeSpeed * Time.deltaTime);
        }
        
    }
}
