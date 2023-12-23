using UnityEngine;

public class ShowRecipe : MonoBehaviour
{
    public RecipeSO recipe;
    public Transform craftSlotHolder;

    CraftSlot[] craftSlots;

    private void Start()
    {
        craftSlots = craftSlotHolder.GetComponentsInChildren<CraftSlot>();

    }


    public void UpdateCraftUI()
    {

        for (int i = 0; i < craftSlots.Length; i++)
        {
            if (i < recipe.item.Length)
            {
                craftSlots[i].AddItemToCraftUI(recipe.item[i],1);
            }
            else
            {
                craftSlots[i].ClearItemFromCraftUI();
            }
        }
    }
}
