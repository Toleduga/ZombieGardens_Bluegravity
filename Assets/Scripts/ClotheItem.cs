using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClotheItem : MonoBehaviour
{   
    public Clothe clothe;
    public Toggle toggle;
    private Image image;
    private ShopController shopcontroller;
    public bool ShopInventory;

    void Start()
    {
        shopcontroller = FindObjectOfType<ShopController>();
        image = gameObject.GetComponent<Image>();
 
    }

    private void Update()
    {
        if ((ShopInventory) && (clothe.acquired))
        {
            toggle.interactable = false;
        }
    }

    public void ButtonPress()
    {
        shopcontroller.SetPrice(clothe.price);
        shopcontroller.clotheSelected = clothe;
    }



    

    
}
