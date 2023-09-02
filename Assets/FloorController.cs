using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject flowers;
    public GameObject flowersFloor1;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogFormat("number child {0}", flowers.transform.GetChild(0).gameObject.transform.childCount);
            if (flowers.transform.GetChild(0).gameObject.transform.childCount < 1)
            {
                
                var _flowers = Instantiate(flowersFloor1, flowers.transform.GetChild(0).gameObject.transform);
                Destroy(flowers.transform.GetChild(0).gameObject);
                _flowers.transform.parent = flowers.transform;
            }
        }
    }
}
