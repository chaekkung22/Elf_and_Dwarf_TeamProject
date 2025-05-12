using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSetting : MonoBehaviour
{
    [SerializeField] private SpriteRenderer itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemPriceText;


    public void ItemSet(/*ItemSO item*/)
    {
        //itemImage.sprite = item.sprite;
        //itemNameText.text = item.name;
        //itemPriceText.text = $"{item.value.ToString()} 골드";
    }
}
