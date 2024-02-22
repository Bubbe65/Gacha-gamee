using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectionsData", menuName = "Databases/DataBaseCollections")]
public class Collections : ScriptableObject
{
    public List<DataBase> allCollections;

}
