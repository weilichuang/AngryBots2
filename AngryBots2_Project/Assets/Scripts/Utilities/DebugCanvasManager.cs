using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DebugCanvasManager : MonoBehaviour
{
    [Header("General References")] public Canvas debugWindow;
    public GameObject fpsDisplay;
    public GameObject postProcessingVolumes;

    [SerializeField] public GameObject globalLight;


    [System.Serializable]
    public struct UniversalAssetSettings
    {
        public string qualityName;
        public UniversalRenderPipelineAsset qualityRenderPipelineAsset;
        public GameObject qualitySelectedDisplay;
    }

    [Header("URP Asset Switch Settings")] public UniversalAssetSettings[] urpAssetSettings;
    private int currentURPAssetID = 2; // High
    public Text currentURPAssetInfo;

    void Start()
    {
        HideUI();
    }

    void HideUI()
    {
        debugWindow.enabled = false;
        fpsDisplay.SetActive(false);
    }

    public void ToggleDebugWindow(bool newState)
    {
        debugWindow.enabled = newState;
    }

    public void ToggleFPSDisplay(bool newState)
    {
        fpsDisplay.SetActive(newState);
    }

    public void TogglePostProcessing(bool newState)
    {
        postProcessingVolumes.SetActive(newState);
    }

    public void SwitchURPAsset(int newAssetID)
    {
        GraphicsSettings.renderPipelineAsset = urpAssetSettings[newAssetID].qualityRenderPipelineAsset;
        UpdateURPAssetUI(newAssetID);
    }

    void UpdateURPAssetUI(int newAssetID)
    {
        urpAssetSettings[currentURPAssetID].qualitySelectedDisplay.SetActive(false);
        currentURPAssetID = newAssetID;
        urpAssetSettings[currentURPAssetID].qualitySelectedDisplay.SetActive(true);

        if (currentURPAssetID == 0)
        {
            globalLight.GetComponent<Light>().intensity = 2.0f;
        }
        else
        {
            globalLight.GetComponent<Light>().intensity = 0.5f;
        }

        UniversalRenderPipelineAsset asset = UniversalRenderPipeline.asset;

        string assetInfoString = "HDR: " + asset.supportsHDR;

        currentURPAssetInfo.text = assetInfoString;
    }
}