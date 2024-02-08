using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    [SerializeField] GameObject engine;
    [SerializeField] float screenWidthInUnits = 0f;
    [SerializeField] float mouseOffset;
    [SerializeField] float padding = 1f;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip catchSound;
    
    float xMin;
    float xMax;

    float yMin;
    float yMax;

    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        int score = 1; // TODO: Dynamic score
        engine.GetComponent<Engine>().score += score;
        engine.GetComponent<Engine>().LiveAdderForScore += score; 
        audioSource.PlayOneShot(catchSound);
        Destroy(collision.gameObject);
        engine.GetComponent<Spawner>().velocity -= 0.1f;
        var spawnPeriod = engine.GetComponent<Spawner>().spawnPeriod;
        engine.GetComponent<Spawner>().spawnPeriod = spawnPeriod - 2 / 50;
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0f, 0.2f, 0f)).y;
    }
    private void Move()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * (screenWidthInUnits * 2) - mouseOffset;
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(paddlePos.x, -7.87f, 7.87f);
        if (!engine.GetComponent<Engine>().isPaused)
        {
            transform.position = paddlePos;
        }
    }
}
