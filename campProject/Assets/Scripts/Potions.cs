using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D x)
    {
        if (x.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            
        }
    }
    }
