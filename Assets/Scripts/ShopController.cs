using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public GameObject[] clothesGroup;
    public TMP_Text priceText;
    private PlayerInteractor playerInteractor;
    public Clothe clotheSelected;

    public void OnEnable()
    {
        playerInteractor = FindObjectOfType<PlayerInteractor>();
    }
    public void SetGroup(int indexGroup)
    {
        CleanGroup();
        CleanPrice();
        clothesGroup[indexGroup].SetActive(true);
    }

    private void CleanGroup()
    {
        foreach (GameObject _group in clothesGroup)
        {
            _group.SetActive(false);
        }
    }

    private void CleanPrice()
    {
        priceText.text = "0";
    }

    public void SetPrice(int price)
    {
        priceText.text = price.ToString();
    }

    public void BuyItem()
    {
        if (playerInteractor.flowers >= clotheSelected.price)
        {
            playerInteractor.flowers -= clotheSelected.price;
            clotheSelected.acquired = true;
            CleanPrice();
        }
        
    }
}
