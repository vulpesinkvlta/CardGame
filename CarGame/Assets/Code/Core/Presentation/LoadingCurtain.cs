using System.Collections;
using UnityEngine;
using Zenject;

namespace Core.Presentation
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
        }

        public void Hide()
        {
           StartCoroutine(HideCurtain());

        }

        IEnumerator HideCurtain()
        {
            _canvasGroup.alpha -= 0.025f;
            yield return new WaitForSeconds(3f);
            _canvasGroup.blocksRaycasts = false;
            gameObject.SetActive(false);
        }
    }
}
