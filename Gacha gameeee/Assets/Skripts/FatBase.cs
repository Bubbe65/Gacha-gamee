using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBase : MonoBehaviour

{
    [SerializeField]string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

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
