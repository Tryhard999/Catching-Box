using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] public float spawnPeriod = 2f;
    [SerializeField] public float velocity = 0f;
    [SerializeField] public float periodAdder = 0.1f;

    [SerializeField] Sprite[] sprites;

    float xMin;
    float xMax;
    void Start()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;
        StartCoroutine(SpawnContinuously());
        StartCoroutine(PeriodAddEverySec());

    }

    void Update()
    {
    }

    IEnumerator SpawnContinuously()
    {
        while (true)
        {
            var spawnPosX = Random.Range(xMin, xMax);
            GameObject food = Instantiate(foodPrefab, new Vector2(spawnPosX, 7f), Quaternion.identity);
            food.GetComponent<SpriteRenderer>().sprite = sprites[0];
            food.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity);
            yield return new WaitForSeconds(spawnPeriod);
        }
    }

    IEnumerator PeriodAddEverySec()
    {
        while (true)
        {
            if (spawnPeriod > 0.5f)
            {
                spawnPeriod = spawnPeriod - spawnPeriod / 50;
            }
            else
            {
                velocity -= 0.1f;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
