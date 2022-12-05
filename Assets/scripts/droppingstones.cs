using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droppingstones : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidbody;
    [SerializeField]float droppingtime = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

        
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("StoneDropping",2);    
    }
    void StoneDropping()
    {
        if (Time.time > droppingtime)
            {
                rigidbody.useGravity = true;
                renderer.enabled = true;
            }  
    }
}