using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new recipe", menuName = "New Recipe")]
public class RecipeSO : ScriptableObject
{
    public itemSO[] item;
    public itemSO craftedItem;
}
