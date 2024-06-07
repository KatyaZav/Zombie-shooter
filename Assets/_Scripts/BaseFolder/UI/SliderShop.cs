using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SliderShop : MonoBehaviour
{
    [SerializeField] Image[] _sliderParts;
    [SerializeField] Color _color = new Color(13, 202, 0);
    
    private int _current;

    public virtual bool IsGettedMaxValue() => _current == _sliderParts.Length;
    public virtual int GetMaxSliderValue() => _sliderParts.Length;

    public virtual void SetSlider(int count)
    {
        _current = count;

        for (var i = 0; i < _sliderParts.Length; i++)
        {
            if (i < count)
                _sliderParts[i].color = _color;
            else
                _sliderParts[i].color = Color.white;
        }
    }
}
