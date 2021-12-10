using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Vector3 force;
    private Rigidbody _rb; 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(force,ForceMode.Impulse); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
