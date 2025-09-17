using UnityEngine;

public class EngineGlow : MonoBehaviour
{
    
    public Renderer sphereRenderer;

    
    [Range(0f, 1f)] public float lowG = 0f;
    [Range(0f, 1f)] public float highG = 0.784f;
    [Range(0f, 3f)]public float fadeSpeed = 2f;               

    private float targetG;                        
    private Material mat;                       

    private void Awake()
    {

        if (sphereRenderer == null)
            sphereRenderer = GetComponent<Renderer>();


        mat = sphereRenderer.material;
        targetG = highG;


        Color c = mat.color;
        c.g = targetG;
        mat.color = c;
    }

    private void Update()
    {

        Color c = mat.color;
        c.g = Mathf.MoveTowards(c.g, targetG, fadeSpeed * Time.deltaTime);
        mat.color = c;
    }

    public void BoostTrigger()
    {
        targetG = lowG;

   
        CancelInvoke(nameof(ResetColor));
        Invoke(nameof(ResetColor), 1f);
    }

    private void ResetColor()
    {
        targetG = highG;
    }
}
