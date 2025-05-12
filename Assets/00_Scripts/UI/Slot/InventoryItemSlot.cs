using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] Button equipButton;


    public void ItemSet(ItemSO item)
    {
        if (item == null)
        {
            gameObject.SetActive(false);
            return;
        }

        
        itemImage.sprite = item.image;
        itemNameText.text = item.itemName;
        equipButton.onClick.RemoveAllListeners();
        equipButton.onClick.AddListener(() => DataManager.Instance.EquipItem(item));
    }
}
