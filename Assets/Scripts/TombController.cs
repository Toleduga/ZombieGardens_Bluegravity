using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombController : MonoBehaviour
{
    public GameObject zombie;
    public Transform parentZombie;
    public bool canSpawn;
    public float time = 5;
    public void SpawnZombies()
    {
        StartCoroutine(Spawn());
    }

    public void StopSpawnZombies()
    {
        StopCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(time);

        if (canSpawn)
        {
            var _zombie = Instantiate(zombie, parentZombie.transform);
            _zombie.transform.parent = parentZombie;
            StartCoroutine(Spawn());
        }
    }
    
}
