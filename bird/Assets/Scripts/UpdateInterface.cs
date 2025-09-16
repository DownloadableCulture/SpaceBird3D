
using UnityEngine;
using UnityEngine.UIElements;

public class UpdateInterface : MonoBehaviour
{
    public UIDocument gameInterface;
    private Label checkpoints;
    void Awake()
    {
        var root = gameInterface.rootVisualElement;
        checkpoints = root.Q<Label>("Checkpoints");
        
    }

    public void UpdateCheckpoints(int remaining)
    {
        checkpoints.text = "Checkpoints Remaining:" + remaining;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
