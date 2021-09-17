using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

namespace TDS
{
    [RequireComponent(typeof(VideoPlayer))]
    public class CutscenePlayer : MonoBehaviour
    {
        [SerializeField] private KeyCode SkipCutsceneHotkey = KeyCode.Escape;

        [SerializeField] private VideoClip CutsceneClip;
        [SerializeField] private RawImage Screen;
        
        [SerializeField] private UnityEvent OnEndCutscene;
        
        [Header("Fade Out Info")] [SerializeField]
        private float FadeOutDuration;

        private Sequence skipCutsceneTween;

        private VideoPlayer videoPlayer;

        private void Awake()
        {
            DOTween.Init();
            videoPlayer = GetComponent<VideoPlayer>();

            videoPlayer.clip = CutsceneClip;
            videoPlayer.loopPointReached += EndCutscene;
        }

        private void Start()
        {
            skipCutsceneTween = DOTween.Sequence();

            InitializeTweenAnimation();

            Play();
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
            skipCutsceneTween.Kill();
        }

        private void InitializeTweenAnimation()
        {
            skipCutsceneTween.Append(Screen.DOColor(Color.black, FadeOutDuration)
                                           .OnComplete(Exit));
        }

        public void SkipCutscene()
        {
            videoPlayer.Pause();
            ExecuteFadeOutTransition();
        }

        private void EndCutscene(VideoPlayer player)
        {
            player.Pause();
            ExecuteFadeOutTransition();
        }

        private void Play()
        {
            videoPlayer.Play();
        }

        private void Exit()
        {
            Debug.Log("End Cutscene!");
            videoPlayer.Stop();
            OnEndCutscene?.Invoke();
        }

        private void ExecuteFadeOutTransition()
        {
            skipCutsceneTween.Restart();
            skipCutsceneTween.Play();
        }
    }
}

