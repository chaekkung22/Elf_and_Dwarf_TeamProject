using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO_", menuName = "Scriptable Object/Item")]
public class ItemSO : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite image;
    public int price;
}
