using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public enum CutsceneTrigger
    {
        Playing,
        Ending
    }

    public class CutsceneHandler : MonoBehaviour
    {
        [SerializeField] private Animator CutsceneAnimator;
        [Header("Fade In/Out Info")] [SerializeField]
        private Image FadePanel;

        [Header("Fade In Info")] [SerializeField]
        private float FadeInDuration;

        [Header("Fade Out Info")] [SerializeField]
        private float FadeOutDuration;

        private Sequence enterCutsceneTween;
        private Sequence exitCutsceneTween;

        private void Awake()
        {
            DOTween.Init();
        }

        private void Start()
        {
            enterCutsceneTween = DOTween.Sequence();
            exitCutsceneTween = DOTween.Sequence();

            InitializeTweenAnimation();

            PlayCutscene();
        }

        private void OnDestroy()
        {
            enterCutsceneTween.Kill();
            exitCutsceneTween.Kill();
        }

        private void InitializeTweenAnimation()
        {
            enterCutsceneTween.Append(FadePanel.DOFade(0, FadeInDuration));

            exitCutsceneTween.Append(FadePanel.DOFade(255, FadeOutDuration)
                                              .OnComplete(ExecuteOnEndCutsceneEvent));
        }

        public void PlayCutscene()
        {
            Debug.Log("Play Cutscene!");

            // Forced to take in account fade in transition?
            CutsceneAnimator.SetTrigger(CutsceneTrigger.Playing.ToString());
            ExecuteFadeInTransition();
        }

        public void SkipCutscene()
        {
            Debug.Log("Skip Cutscene!");
            EndCutscene();
        }

        public void EndCutscene()
        {
            Debug.Log("End Cutscene!");
            CutsceneAnimator.SetTrigger(CutsceneTrigger.Ending.ToString());
            ExecuteFadeOutTransition();
        }

        private void ExecuteOnEndCutsceneEvent()
        {
        }

        private void ExecuteFadeInTransition()
        {
            enterCutsceneTween.Restart();
            enterCutsceneTween.Play();
        }

        private void ExecuteFadeOutTransition()
        {
            exitCutsceneTween.Restart();
            exitCutsceneTween.Play();
        }
    }
}

