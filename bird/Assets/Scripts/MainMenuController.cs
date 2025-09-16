using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance { get; private set; }
    public InputActionReference Pause;
    public InputActionReference Submit;
    public InputActionReference Navigate;

    public bool MenuVisible { get; private set; } = true;

    private UIDocument _document;

    private Label _menuLabel;
    private Button _startButton;
    private Button _quitButton;
    private Button[] _buttons;
    private int _currentButton;
    private bool canNavigate = true;

    public float timeLerpSpeed = 5f;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        _document = GetComponent<UIDocument>();

        _menuLabel = _document.rootVisualElement.Q<Label>("MenuLabel");
        _startButton = _document.rootVisualElement.Q("StartButton") as Button;
        _quitButton = _document.rootVisualElement.Q("QuitButton") as Button;

        _startButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);
        _quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClicked);

        _startButton.focusable = true;
        _quitButton.focusable = true;

        _buttons = new Button[] { _startButton, _quitButton };
        _buttons[_currentButton].Focus();

    }

    private void Update()
    {
        //show or hide the menu
        if (Pause.action.WasPerformedThisFrame())
        { 
            if (MenuVisible)
                HideMenu();
            else
                ShowMenu();
                
        }
        if (!MenuVisible) return;

        //button navigation with controller/keyboard
        Vector2 nav = Navigate.action.ReadValue<Vector2>();

        if (canNavigate)
        {
            if (nav.y > 0.5f)
            {
                ButtonSelect(-1);
                canNavigate = false;
            }
            else if (nav.y < -0.5f)
            {
                ButtonSelect(1);
                canNavigate = false;
            }
        }
        if(Mathf.Abs(nav.y) < 0.2f)
            { 
            canNavigate = true;
            }


        if (Submit.action.WasPerformedThisFrame())
            {
                if (_currentButton == 0) OnStartButtonClicked(null);
                else if (_currentButton == 1) OnQuitButtonClicked(null);
            }
        

    }

    private void ButtonSelect(int direction)
    {
        _currentButton += direction;
        if (_currentButton < 0) _currentButton = _buttons.Length - 1;
        if (_currentButton >= _buttons.Length) _currentButton = 0;

        _buttons[_currentButton].Focus();
    }



    private void OnEnable()
    {
        Pause.action.Enable();
        Submit.action.Enable();
        Navigate.action.Enable();
    }

    private void OnDisable()
    {
        Pause.action.Disable(); 
        Submit.action.Disable();
        Navigate.action.Disable();
    }

    public void ShowMenu(string message = "Space Bird 3D", string startButtonText = "Start")
    {
        MenuVisible = true;

        if (_menuLabel != null)
            _menuLabel.text = message;

        if (_startButton != null)
        {
            _startButton.style.display = DisplayStyle.Flex;
            _startButton.text = startButtonText;
        }

        _document.rootVisualElement.style.display = DisplayStyle.Flex;
        StopAllCoroutines();
        StartCoroutine(LerpTimeScale(Time.timeScale, 0f));

        _currentButton = 0;
        _buttons[_currentButton].Focus();
    }

    private void HideMenu()
    {
        MenuVisible = false;
        _document.rootVisualElement.style.display = DisplayStyle.None;
        StopAllCoroutines();
        StartCoroutine(LerpTimeScale(Time.timeScale, 1f));
    }

    private System.Collections.IEnumerator LerpTimeScale(float start, float end)
    {
        float t = 0f;
        while (!Mathf.Approximately(Time.timeScale, end))
        {
            t += Time.unscaledDeltaTime * timeLerpSpeed;
            Time.timeScale = Mathf.Lerp(start, end, t);
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            if (Mathf.Abs(Time.timeScale - end) < 0.001f)
            { Time.timeScale = end;
            }
            yield return null;
        }
        Time.timeScale = end;
    }

    private void OnStartButtonClicked(ClickEvent evt)
    {
        if (_startButton.text == "Try Again?")
        {
            PlayerData player = FindFirstObjectByType<PlayerData>();
            if (player != null)
                player.ResetPlayer();
            HideMenu();
        }
        else
        {
            HideMenu();
        }
            
    }

    private void OnQuitButtonClicked(ClickEvent evt)
    {
        QuitGame();
    }


    private void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
