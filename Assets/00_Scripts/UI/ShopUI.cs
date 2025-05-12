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
    [SerializeField] private GameObject[] ItemSlots;
    //private ItemSO item0, item1, item2, selectedItem;
    private int currentPage = 0;
    private int itemsPerPage = 3;
    private int totalPage;
    //Dictionary<string,ItemSO> ownedItems;
    //List<ItemSO> allItems;



    protected override UIState UIState { get; } = UIState.Shop;

    protected override void Initialize()
    {
        base.Initialize();

        //allItems = DataManager.Instance.GetAllItems();
        //totalPage = allItems.Count / 3 + 1;
        prevButton.onClick.AddListener(PrevButton);
        nextButton.onClick.AddListener(NextButton);
        purchaseButton.onClick.AddListener(PurchaseItemButton);
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);
    }

    void UpdateOwnedItems()
    {
        //ownedItems = DataManager.Instance.GetOwnedItems();
        //foreach(ItemSO item in all
    }

    void ShowPage(int currentPage)
    {

    }

    void PurchaseItemButton()
    {
        //if (DataManager.Instance.playerGold < item.Price) return;
        //if (
        
        //DataManager.Instance.SpendGold(item.Price);
        //DataManager.Instance.AddItem(itemID);
        //
        
    }


    void PrevButton()
    {
        if (!(currentPage == 1))
        currentPage--;

        if(currentPage == 1)
            prevButton.gameObject.SetActive(false);
        else
            prevButton.gameObject.SetActive(true);
    }

    void NextButton()
    {
        if(!(currentPage == totalPage))
        currentPage++;

        if(currentPage == totalPage)
            nextButton.gameObject.SetActive(false);
        else
            nextButton.gameObject.SetActive(true);
    }
}
