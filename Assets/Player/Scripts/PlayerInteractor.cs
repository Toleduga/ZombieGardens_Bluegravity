using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private TopDownCharacterController topDownCharacterController;

    public GameObject button1;

    public GameObject shop;
    public GameObject diffuse;
    public int flowers = 0;

    bool interacSeller;
    bool interacFlower;

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
            Destroy(objectInterac);
            flowers += 1;
        }
    }

}
