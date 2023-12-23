using UnityEngine;

[CreateAssetMenu(fileName = "new recipe", menuName = "New Recipe")]
public class RecipeSO : ScriptableObject
{
    public ItemSO[] item;
    public ItemSO craftedItem;
}
