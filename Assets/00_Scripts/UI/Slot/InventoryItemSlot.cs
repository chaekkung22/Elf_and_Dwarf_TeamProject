using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI equipButtonText;
    [SerializeField] Button equipButton;


    public void ItemSet(ItemSO item, bool isPurchaseable)
    {
        if (item == null)
        {
            gameObject.SetActive(false);
            return;
        }

        if (DataManager.Instance.GetEquipedItem() == null || DataManager.Instance.GetEquipedItem() != item)
        {
            equipButtonText.text = "장착하기";
        }
        else if (DataManager.Instance.GetEquipedItem() == item)
        {
            equipButtonText.text = "해제하기";
        }
        
        itemImage.sprite = item.image;
        itemNameText.text = item.itemName;
        equipButton.onClick.RemoveAllListeners();
        equipButton.onClick.AddListener(() => ChangeEquipButton(item));
    }

    void ChangeEquipButton(ItemSO item)
    {
        if (DataManager.Instance.GetEquipedItem() == null)
        {
            DataManager.Instance.EquipItem(item);
        }
        else
        {
            //지금 장착한 아이템을 해제하고 선택한 아이템 장착하기
        }

    }
}
