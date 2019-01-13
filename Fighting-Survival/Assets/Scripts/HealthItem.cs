using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private int Value;
    // Start is called before the first frame update
    void Start()
    {
        Value = Random.Range(10, 60);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.SetHealth(Value);
        }
    }
    
}
