using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FatData", menuName = "Fat/Create new fat")]
public class FatBase : MonoBehaviour

{
    [SerializeField]string Name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] FatBase type1;
    [SerializeField] FatBase type2;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spdefense;
    [SerializeField] int speed;
}

public enum FatType
{
    Normal,
    Fire,
    Water,
    Ground,
    Electric,
    Grass,
    Light,
    Darkness,
    
}
