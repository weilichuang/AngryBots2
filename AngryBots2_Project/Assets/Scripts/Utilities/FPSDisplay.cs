using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public Text fpsText;

    private float deltaTime;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        SetFPS();
    }

    void SetFPS()
    {
        fpsText.text = string.Format("FPS: {0:00.} ({1:00.0} ms)", 1.0f / deltaTime, deltaTime * 1000.0f);
    }
}