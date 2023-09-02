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

    private TopDownCharacterController topDownCharacterController;
    public Clothe[] cloths;
    public GameObject popUpFinish;
    public GameObject difuse;

    public void OnEnable()
    {
        topDownCharacterController = FindObjectOfType<TopDownCharacterController>();
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

    public void CloseShop()
    {
        if (CheckFinsh())
        {
            topDownCharacterController.UImode = true;
            difuse.SetActive(false);
            this.gameObject.SetActive(false);
            popUpFinish.SetActive(true);
        }
        else
        {
            topDownCharacterController.UImode = false;
            difuse.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    public bool CheckFinsh()
    {
        bool finish = true;
        foreach (Clothe _clothe in cloths)
        {
            finish = finish && _clothe.acquired;
        }

        return finish;
    }

}
