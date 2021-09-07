using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

namespace TDS
{
    public enum CutsceneTrigger
    {
        Playing,
        Ending
    }

    [Serializable]
    public struct CutsceneMeta
    {
        public string SceneName;
        public AnimationClip Cutscene;
    }
    
    public class CutsceneHandler : MonoBehaviour
    {
        [SerializeField] private List<CutsceneMeta> CutsceneInfoList;
        
        [SerializeField] private UnityEvent OnEndCutscene;

        [Header("Fade In/Out Info")]
        [SerializeField] private Image FadePanel;

        [Header("Fade In Info")] 
        [SerializeField] private Color FadeInColor;
        [SerializeField] private float FadeInDuration;
        
        [Header("Fade Out Info")]
        [SerializeField] private Color FadeOutColor;
        [SerializeField] private float FadeOutDuration;

        private Sequence enterCutsceneTween;
        private Sequence exitCutsceneTween;
        
        private string currentSceneName = "Test";
        private Animator cutsceneAnimator;
        private AnimatorOverrideController cutsceneAnimatorOverride;
        
        private const string BaseCutsceneAnimTag = "BaseCutsceneAnim";

        private void Awake()
        {
            DOTween.Init();
            
            // Idea is that when we load a save file, we obtain current chapter information.
            // Based on that current chapter information, we load the appropriate animation clip
            // Since, the cutscene will only be played at the beginning of each level.
            // Except at the last level where it will also be played at the end.
            
            // ASK: How will the cutscene be played?
            // Example: 
            // There will be a fade in transition at the beginning
            // Main cutscene will play
            // Then, fade out transition at the end (which will also occur when skipped)

            cutsceneAnimator = gameObject.GetComponent<Animator>();
            cutsceneAnimatorOverride = new AnimatorOverrideController(cutsceneAnimator.runtimeAnimatorController);
            cutsceneAnimator.runtimeAnimatorController = cutsceneAnimatorOverride;
            
            
        }

        private void Start()
        {
            // TODO: Add get chapter information from the save file
            InitializeCutscene();

            enterCutsceneTween = DOTween.Sequence();
            exitCutsceneTween = DOTween.Sequence();
            
            InitializeTweenAnimation();
        }
        
        private void OnDestroy()
        {
            enterCutsceneTween.Kill();
            exitCutsceneTween.Kill();
        }

        private void InitializeCutscene()
        {
            cutsceneAnimatorOverride[BaseCutsceneAnimTag] = GetCutsceneOfSceneName(currentSceneName);
        }

        private void InitializeTweenAnimation()
        {
            enterCutsceneTween.Append(FadePanel.DOColor(FadeInColor, FadeInDuration)
                                               .OnComplete(StartCutscene));

            exitCutsceneTween.Append(FadePanel.DOColor(FadeOutColor, FadeOutDuration)
                                              .OnComplete(ExecuteOnEndCutsceneEvent));
        }
        
        public void PlayCutscene()
        {
            Debug.Log("Play Cutscene!");
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
            cutsceneAnimator.SetTrigger(CutsceneTrigger.Ending.ToString());
            ExecuteFadeOutTransition();
        }
        
        private void ExecuteOnEndCutsceneEvent()
        {
            OnEndCutscene?.Invoke();
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

        private void StartCutscene()
        {
            cutsceneAnimator.SetTrigger(CutsceneTrigger.Playing.ToString());
        }

        private AnimationClip GetCutsceneOfSceneName(string sceneName)
        {
            for (var i = 0; i < CutsceneInfoList.Count; i++)
            {
                if (CutsceneInfoList[i].SceneName != sceneName)
                {
                    continue;
                }
                
                return CutsceneInfoList[i].Cutscene;
            }

            return null;
        }
        
    }    
}

