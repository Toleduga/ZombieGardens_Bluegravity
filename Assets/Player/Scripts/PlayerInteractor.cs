using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    public GameObject button1;
 
    void Start()
    {
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.gameObject.CompareTag("Seller"))
        {
            Debug.Log("Collider Seller");
            button1.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collider");
        if (collision.gameObject.CompareTag("Seller"))
        {
            Debug.Log("Collider Seller");
            button1.SetActive(false);
        }
    }


}
