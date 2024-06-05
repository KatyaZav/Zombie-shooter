using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SliderShop : MonoBehaviour
{
    [SerializeField] Image[] _sliderParts;
    [SerializeField] Color _color = new Color(14, 202, 0);

    public void SetSlider(int count)
    {
        for (var i = 0; i < _sliderParts.Length; i++)
        {
            if (i < count)
                _sliderParts[i].color = _color;
            else
                _sliderParts[i].color = Color.white;
        }
    }
}
