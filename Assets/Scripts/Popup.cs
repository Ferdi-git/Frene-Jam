using DG.Tweening;
using DG.Tweening.Core.Easing;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] float popupDuration = 1f;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Initialise(int points)
    {
        text.text = points.ToString();
        text.fontSize = 0.70f;
        text.DOFontSize(1, popupDuration).SetEase(Ease.InOutBack).OnComplete(() => text.DOFontSize(0.70f, popupDuration/2).SetEase(Ease.InOutBack).OnComplete(()=> Destroy(this.gameObject)));
    }


}
