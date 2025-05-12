using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopUI : BaseUI
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI currentGoldText;
    [SerializeField] private ItemSlot[] itemSetting;
    private ItemSO selectedItem;
    private int currentPage = 1;
    private int itemsPerPage = 3;
    private int totalPage;
    Dictionary<string, ItemSO> ownedItems;
    List<ItemSO> allItems;



    protected override UIState UIState { get; } = UIState.Shop;

    protected override void Initialize()
    {
        base.Initialize();

        allItems = DataManager.Instance.GetAllItems();
        ownedItems = DataManager.Instance.GetOwnedItems();
        totalPage = allItems.Count / 3 + 1;
        prevButton.onClick.AddListener(PrevButton);
        nextButton.onClick.AddListener(NextButton);
        exitButton.onClick.AddListener(UIManager.Instance.CloseUI);
        DataManager.Instance.AddChangeOwnedItemsEvent(UpdateOwnedItems);
    }

    public override void SetUIActive(bool isActive)
    {
        base.SetUIActive(isActive);
        currentPage = 1;
        nextButton.gameObject.SetActive(true);
        UpdateOwnedItems();
    }

    void UpdateOwnedItems()
    {
        currentGoldText.text = $"골드 : {DataManager.Instance.GetGold()}";
        int start = (currentPage * itemsPerPage) - itemsPerPage;
        int end = currentPage * itemsPerPage;
        int idx = 0;


        for (int i = start; i < end; i++)
        {
            if (i < allItems.Count)
            {

                if (ownedItems.ContainsKey(allItems[i].id))
                    itemSetting[idx].ItemSet(allItems[i], false);
                else
                    itemSetting[idx].ItemSet(allItems[i], true);

                itemSetting[idx++].gameObject.SetActive(true);
            }
            else
            {
                itemSetting[idx++].gameObject.SetActive(false);
            }
        }

        if (currentPage == 1)
            prevButton.gameObject.SetActive(false);
        else if (currentPage == totalPage)
            nextButton.gameObject.SetActive(false);
        else
        {
            prevButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
    }


    void PrevButton()
    {
        if (!(currentPage == 1))
        {
            currentPage--;
            UpdateOwnedItems();
        }
    }

    void NextButton()
    {
        if (!(currentPage == totalPage))
        {
            currentPage++;
            UpdateOwnedItems();
        }
    }
}
