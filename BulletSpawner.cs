using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnrateMin = 2f;
    public float spawnrateMax = 3f;

    private Transform target; // public으로도 되나 확인 부탁 V 된다고 한다.
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnrateMin, spawnrateMax);

        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnrateMin, spawnrateMax);
        }
    }
}
