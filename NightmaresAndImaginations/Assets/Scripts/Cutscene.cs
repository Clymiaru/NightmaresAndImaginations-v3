using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
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

    [Serializable]
    public class Dialogue
    {
        [Multiline] public string Text;
    }

    public class Cutscene : MonoBehaviour
    {
        [SerializeField] private KeyCode SkipCutsceneHotkey = KeyCode.Escape;
        
        [SerializeField] private Animator CutsceneAnimator;

        [SerializeField] private UnityEvent OnEndCutscene;
        
        [Header("Fade In/Out Info")] [SerializeField]
        private Image FadePanel;

        [Header("Fade In Info")] [SerializeField]
        private float FadeInDuration;

        [Header("Fade Out Info")] [SerializeField]
        private float FadeOutDuration;

        [Header("Dialogue")] 
        [SerializeField] private TMP_Text DialogueText;
        [SerializeField] private List<Dialogue> Script;

        private Sequence enterCutsceneTween;
        private Sequence exitCutsceneTween;

        private int currentDialogue = -1;

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

        private void Update()
        {
            if (!Input.GetKeyDown(SkipCutsceneHotkey))
            {
                return;
            }
            
            SkipCutscene();
        }

        private void OnDestroy()
        {
            enterCutsceneTween.Kill();
            exitCutsceneTween.Kill();
        }

        private void InitializeTweenAnimation()
        {
            enterCutsceneTween.Append(FadePanel.DOFade(0, FadeInDuration)
                                               .OnComplete(Play));

            exitCutsceneTween.Append(FadePanel.DOFade(255, FadeOutDuration)
                                              .OnComplete(Exit));
        }

        public void PlayCutscene()
        {
            Debug.Log("Play Cutscene!");
            DialogueText.text = " ";
            // Forced to take in account fade in transition?
            ExecuteFadeInTransition();
            
        }

        public void SkipCutscene()
        {
            Debug.Log("Skip Cutscene!");
            EndCutscene();
        }

        public void NextDialogue()
        {
            currentDialogue = Mathf.Min(currentDialogue + 1, Script.Count - 1);
            Debug.Log(currentDialogue);

            if (Script[currentDialogue].Text == " ")
            {
                DialogueText.text = " ";
            }
            else
            {
                DialogueText.text = Script[currentDialogue].Text;
            }
            
        }

        public void EndCutscene()
        {
            Debug.Log("End Cutscene!");
            DialogueText.text = " ";
            ExecuteFadeOutTransition();
        }

        private void Play()
        {
            CutsceneAnimator.SetTrigger(CutsceneTrigger.Playing.ToString());
        }

        private void Exit()
        {
            
            CutsceneAnimator.SetTrigger(CutsceneTrigger.Ending.ToString());
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
    }
}

