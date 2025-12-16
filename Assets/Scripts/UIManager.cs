using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider;

    public void UpdateSlider(float value)
    {
        slider.value = value;
    }
}
