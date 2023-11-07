using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class itemSO : ScriptableObject
{
        public string itemName;
        public Sprite icon;
        public string description;
        public GameObject prefab;
}