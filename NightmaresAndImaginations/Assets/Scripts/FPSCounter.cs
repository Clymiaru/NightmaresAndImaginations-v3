using UnityEngine;
using TMPro;

namespace TDS
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private float timer;
        private readonly float refresh = 1.0f;
        private float avgFramerate;
        private const string DisplayFormat = "{0} FPS";

        private void Update()
        {
            var timelapse = Time.deltaTime;
            
            timer = timer <= 0 ? refresh : timer -= timelapse;

            if (timer <= 0)
            {
                avgFramerate = (int) (1f / timelapse);
            }
            
            text.text = string.Format(DisplayFormat, avgFramerate.ToString());
        }
    }
}
