using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private TopDownCharacterController topDownCharacterController;

    public GameObject button1;
    public GameObject popUpDeath;
    public GameObject popUpFinish;

    public GameObject shop;
    public GameObject inventory;
    public GameObject diffuse;

    public AudioSource audioFlower;

    public Animator animatorUI;
    public int flowers = 1;

    public Clothe[] cloths;

    bool interacSeller;
    bool interacFlower;
    bool interacInventory;

    GameObject objectInterac;
    void Start()
    {
        topDownCharacterController = FindObjectOfType<TopDownCharacterController>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.gameObject.CompareTag("Seller"))
        {
            //Debug.Log("Collider Seller");
            interacSeller = true;
            button1.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Flower"))
        {
            objectInterac = collision.gameObject;
            interacFlower = true;
            button1.SetActive(true);
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Collider");
        if (collision.gameObject.CompareTag("Seller"))
        {
            //Debug.Log("Collider Seller");
            interacSeller = false;
            button1.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Flower"))
        {
            interacFlower = false;
            button1.SetActive(false);
        }

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && interacSeller)
        {
            shop.SetActive(true);
            diffuse.SetActive(true);
            topDownCharacterController.PlayerModeUI(true);
        }
        if (Input.GetKey(KeyCode.F) && interacFlower)
        {
            interacFlower = false;
            button1.SetActive(false);
            audioFlower.Play();
            Destroy(objectInterac);
            flowers += 1;
        }
        if (Input.GetKey(KeyCode.B) && (!interacSeller))
        {
            if (CheckFinsh())
            {
                topDownCharacterController.UImode = true;
                popUpFinish.SetActive(true);
            }
            else {
                inventory.SetActive(true);
                diffuse.SetActive(true);
                topDownCharacterController.PlayerModeUI(true);
            }
            
        }
    }

    public void AnimLess()
    {
        animatorUI.SetTrigger("Less");
    }

    public void DeathPlayer()
    {
        topDownCharacterController.UImode = true;
        popUpDeath.SetActive(true);
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
