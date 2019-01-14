using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMeshLookAtCamera : MonoBehaviour
{
    private Transform MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(MainCamera);
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
