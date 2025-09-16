
using UnityEngine;
using UnityEngine.UIElements;

public class UpdateInterface : MonoBehaviour
{
    public UIDocument gameInterface;
    private Label checkpoints;
    private ProgressBar hitPoints;
    void Awake()
    {
        var root = gameInterface.rootVisualElement;
        checkpoints = root.Q<Label>("Checkpoints");
        hitPoints = root.Q<ProgressBar>("lives");
        
    }

    public void UpdateCheckpoints(int remaining)
    {
        checkpoints.text = "Checkpoints Remaining:" + remaining;
    }

    public void UpdateHP(float value)
    {
        hitPoints.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
