using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
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
        [SerializeField] private Animator CutsceneToPlay;
        [SerializeField] private UnityEvent OnEndCutscene;

        [SerializeField] private Image FadeOutPanel;
        [SerializeField] private float FadeOutDuration;

        private void Start()
        {
            DOTween.Init();
        }

        public void Play()
        {
            CutsceneToPlay.SetTrigger(CutsceneTrigger.Playing.ToString());
        }
        
        public void Skip()
        {
            CutsceneToPlay.SetTrigger(CutsceneTrigger.Ending.ToString());

            FadeOutPanel.DOFade(255, FadeOutDuration)
                        .OnComplete(EndCutscene)
                        .Play();
        }

        private void EndCutscene()
        {
            OnEndCutscene?.Invoke();
        }
    }    
}

