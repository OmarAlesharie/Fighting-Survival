using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDropper : MonoBehaviour
{
    public GameObject[] Items;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropItem", 10.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropItem()
    {
        GameObject Item = Instantiate(Items[Random.Range(0, Items.Length)], transform.position, Quaternion.identity);
    }
}
