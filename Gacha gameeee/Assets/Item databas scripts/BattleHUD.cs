using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public void SetHUD(FatUnit unit)
    {
        nameText.text = unit.FatName;
        levelText.text = "Lvl " + unit.FatLevel;
        hpSlider.maxValue = unit.maxHp;
        hpSlider.value = unit.currentHp;

    }


    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }

}
