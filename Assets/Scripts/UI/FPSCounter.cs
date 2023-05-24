using TMPro;
using UnityEngine;

namespace UI
{
    public class FPSCounter : MonoBehaviour
    {
        public TMP_Text fpsText;
        public float updateInterval = 0.5f;

        private float fpsAccumulator = 0f;
        private int fpsFrames = 0;
        private float fpsTime = 0f;

        private void Start()
        {
            if (fpsText == null)
            {
                Debug.LogError("FPSCounter: TextMeshPro Text component not assigned!");
                enabled = false;
                return;
            }

            fpsTime = updateInterval;
        }

        private void Update()
        {
            fpsTime += Time.unscaledDeltaTime;
            fpsFrames++;

            if (fpsTime >= updateInterval)
            {
                float currentFPS = fpsFrames / fpsTime;
                fpsAccumulator += currentFPS;
                fpsFrames = 0;
                fpsTime = 0f;

                float averageFPS = fpsAccumulator / updateInterval;
                fpsAccumulator = 0f;

                UpdateFPSDisplay(averageFPS);
            }
        }

        private void UpdateFPSDisplay(float fps)
        {
            fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";
        }
    }
}