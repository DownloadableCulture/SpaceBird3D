using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    private UIDocument _document;
    private Button _startButton;
    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _startButton = _document.rootVisualElement.Q("StartButton") as Button;
        _startButton.RegisterCallback<ClickEvent>(OnStartClick);
    }

    private void OnStartClick(ClickEvent evt)
    {
        Debug.Log("Start");
    }
}
