using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderShopWithBlock : SliderShop
{
    [Space(20)]
    [SerializeField] GameObject _blockImage;

    public override void SetSlider(int count)
    {
        ActivateBlock(count == 0);

        base.SetSlider(count);
    }

    private void ActivateBlock(bool isTrue)
    {
        _blockImage.SetActive(isTrue);
    }
}
