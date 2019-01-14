using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        int value = Random.Range(1, 100);
        PlayerHealth.instance.SetHealth(value);
        GetComponent<TextMeshPro>().text = value + "+";
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
