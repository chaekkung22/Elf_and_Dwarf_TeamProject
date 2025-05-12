using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : BaseUI
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private TextMeshProUGUI currentGoldText;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemPriceText;
    //private ItemSO item;
    private int currentPage = 1;
    private int totalPage;


    protected override UIState UIState { get; } = UIState.Shop;

    protected override void Initialize()
    {
        base.Initialize();
        //List<ItemSO> = DataManager.Instance.GetOwnedItems();
        //ItemSO[] allItems = DataManager.Instance.GetAllItems();
        //totalPage = allItems.Length / 3 + 1;
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);
    }

    void ShowCurrentPage()
    {
        //currentGoldText.text = DataManager.Instance.playerGold.ToString();
        //itemNameText.text = item.itemID;
        //itemPriceText.text = $"{item.Price.ToString()} 골드";
    }

    void PurchaseItem()
    {
        //if (DataManager.Instance.playerGold >= item.Price)
        {
        //DataManager.Instance.SpendGold(item.Price);
        //DataManager.Instance.AddItem(itemID);
        }
    }


    void PrevButton()
    {

    }

    void NextButton()
    {

    }
}
