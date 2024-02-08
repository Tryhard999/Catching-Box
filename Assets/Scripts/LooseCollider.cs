using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour
{
    [SerializeField] GameObject engine;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        engine.GetComponent<Engine>().lifes--;
        Destroy(collision.gameObject);
    }
}
