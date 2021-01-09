using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.ARFoundation;

public class LightEstimation : MonoBehaviour
{
    public ARCameraManager cameraManager;
    [SerializeField]
    private float lightBrightness;
    private Light light;

    // 起動時に呼ばれる
    void Awake()
    {
        light = GetComponent<Light>();
    }

    // 有効時に呼ばれる
    void OnEnable()
    {
        if (cameraManager != null)
        {
            cameraManager.frameReceived += FrameChanged;
        }
    }

    // 無効時に呼ばれる
    void OnDisable()
    {
        if (cameraManager != null)
        {
            cameraManager.frameReceived -= FrameChanged;
        }
    }

    // フレーム変更時に呼ばれる
    void FrameChanged(ARCameraFrameEventArgs args)
    {
        // ライトの輝度
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            float? averageBrightness = args.lightEstimation.averageBrightness.Value;
            light.intensity = averageBrightness.Value * lightBrightness;
            //print("averageBrightness>>>" + averageBrightness);
        }
        // ライトの色温度
        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            float? averageColorTemperature = args.lightEstimation.averageColorTemperature.Value;
            light.colorTemperature = averageColorTemperature.Value;
            //print("averageColorTemperature>>>" + averageColorTemperature);
        }

        // ライトの色
        if (args.lightEstimation.colorCorrection.HasValue)
        {
            Color? colorCorrection = args.lightEstimation.colorCorrection.Value;
            light.color = colorCorrection.Value;
            //print("colorCorrection>>>" + colorCorrection);
        }

        // アンビエントの球面調和関数
        if (args.lightEstimation.ambientSphericalHarmonics.HasValue)
        {
            SphericalHarmonicsL2? sphericalHarmonics = args.lightEstimation.ambientSphericalHarmonics;
            RenderSettings.ambientMode = AmbientMode.Skybox;
            RenderSettings.ambientProbe = sphericalHarmonics.Value;
            //print("ambientSphericalHarmonics>>" + sphericalHarmonics);
        }

        // メインライトの方向
        if (args.lightEstimation.mainLightDirection.HasValue)
        {
            Vector3? mainLightDirection = args.lightEstimation.mainLightDirection;
            light.transform.rotation = Quaternion.LookRotation(mainLightDirection.Value);
            //print("mainLightDirection>>>" + mainLightDirection);
        }

        // メインライトの色
        if (args.lightEstimation.mainLightColor.HasValue)
        {
            Color? mainLightColor = args.lightEstimation.mainLightColor;
            light.color = mainLightColor.Value;
            //print("mainLightColor>>>" + mainLightColor);
        }

        // メインライトの輝度
        if (args.lightEstimation.averageMainLightBrightness.HasValue)
        {
            float? averageMainLightBrightness = args.lightEstimation.averageMainLightBrightness;
            light.intensity = averageMainLightBrightness.Value;
            //print("averageMainLightBrightness>>>" + averageMainLightBrightness);
        }
    }
}
