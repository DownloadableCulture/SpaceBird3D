using UnityEngine;

public class MenuBGMFader : MonoBehaviour
{
    public AudioSource MenubgmSource;
    public AudioSource GamebgmSource;
    public float FadeSpeed = 1f;
    public float TargetVolume = 1f;

    private bool fadingMenu = false;
    private bool fadingGame = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenuController.Instance.MenuVisible)
        {
            fadingMenu = true;
            fadingGame = false;
        }
        else
        {
            fadingMenu = false;
            fadingGame = true;
        }


        if (fadingMenu && MenubgmSource != null)
        {
            MenubgmSource.volume = Mathf.MoveTowards(MenubgmSource.volume, TargetVolume, FadeSpeed * Time.unscaledDeltaTime);
            GamebgmSource.volume = Mathf.MoveTowards(GamebgmSource.volume, 0f, FadeSpeed * Time.unscaledDeltaTime);

            if (MenubgmSource.volume >= 1f)
                fadingMenu = false;
        }

  

        if (fadingGame && GamebgmSource != null)
        {
            GamebgmSource.volume = Mathf.MoveTowards(GamebgmSource.volume, TargetVolume, FadeSpeed * Time.unscaledDeltaTime);
            MenubgmSource.volume = Mathf.MoveTowards(MenubgmSource.volume, 0f, FadeSpeed * Time.unscaledDeltaTime);

            if (GamebgmSource.volume >= 1f)
                fadingGame = false;
        }
    }
    

}
