using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject flowers;
    public GameObject flowersFloor1;
    public GameObject zombies;

    private void SeekPlayer(bool _seek)
    {
        int count = zombies.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            var _zombie = zombies.transform.GetChild(i).GetComponent<ZombieController>();
            _zombie.seek = _seek;
            if (!_seek)
            {
                _zombie.Stop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zombies.GetComponent<TombController>().SpawnZombies();
            zombies.GetComponent<TombController>().canSpawn = true;
            SeekPlayer(true);
            //Debug.LogFormat("number child {0}", flowers.transform.GetChild(0).gameObject.transform.childCount);
            if (flowers.transform.GetChild(0).gameObject.transform.childCount < 1)
            {
                
                var _flowers = Instantiate(flowersFloor1, flowers.transform.GetChild(0).gameObject.transform);
                Destroy(flowers.transform.GetChild(0).gameObject);
                _flowers.transform.parent = flowers.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zombies.GetComponent<TombController>().StopSpawnZombies();
            zombies.GetComponent<TombController>().canSpawn = false;
            SeekPlayer(false);
        }
            
    }
}
