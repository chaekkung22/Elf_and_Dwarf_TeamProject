using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemPriceText;
    [SerializeField] Button purchaseButton;


    public void ItemSet(ItemSO item, bool isPurchaseable)
    {
        if(item == null)
        {
            gameObject.SetActive(false);
            return;
        }
        itemImage.sprite = item.image;
        itemNameText.text = item.itemName;
        itemPriceText.text = $"{item.price.ToString()} 골드";
        purchaseButton.gameObject.SetActive(isPurchaseable);
        purchaseButton.onClick.RemoveAllListeners();
        purchaseButton.onClick.AddListener(()=>PurchaseItemButton(item));
    }

    void PurchaseItemButton(ItemSO item)
    {
        if(DataManager.Instance.SpendGold(item.price))
        {
            DataManager.Instance.AddItem(item);
        }
        else
        {
            //TODO : 구매실패 메시지 띄우기
        }

    }
}
