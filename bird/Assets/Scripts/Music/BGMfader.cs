using UnityEngine;

public class BGMfader : MonoBehaviour
{
    public checkpoint_collision cpc;
    public AudioSource bgmSource;
    public float FadeSpeed = 1f;
    [SerializeField]
    private float TargetVolume = 1f;
    public int CheckPointTrigger = 2;
    public PlayerData player;

    private bool fading = false;
    private bool gameOverTriggered = false;
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
        if (player.health == 0 && !gameOverTriggered)
            GameOverReset();
        else if (gameOverTriggered && player.health > 0 && cpc != null && cpc.Checkpoints <= CheckPointTrigger)
        {
            FadeIn(1f);
            gameOverTriggered = false;
        }

        if (fading && bgmSource != null)
        {
            bgmSource.volume = Mathf.MoveTowards(bgmSource.volume, TargetVolume, FadeSpeed * Time.deltaTime);
            if (Mathf.Approximately(bgmSource.volume, TargetVolume))
            {
                fading = false;
            }
        }
       
        
    }
    public void FadeOut()
    {
        TargetVolume = 0f;
        fading = true;
    }

    public void FadeIn(float volume = 1f)
    {
        TargetVolume = Mathf.Clamp01(volume);
        fading = true;
    }

    public void GameOverReset()
    {

        FadeOut();
        gameOverTriggered = true;
    }

}
