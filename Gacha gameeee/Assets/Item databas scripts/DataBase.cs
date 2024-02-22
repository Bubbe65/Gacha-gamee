using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Collection")]

public class DataBase : ScriptableObject
{
    public string itemID;
    public string itemName;
    [TextArea]
    public string itemDescription;
    public int itemCost;
    public Sprite itemSprite;
    public string ItemRarity;
}
