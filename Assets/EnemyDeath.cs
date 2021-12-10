using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public float deathTimer;

    public float exposionForce;

    public float explosionRadius;



    private Rigidbody _rb; 
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        float _Xrand = Random.Range(-20f, 20f); 
        float _Yrand = Random.Range(0f, 20f);
        float _Zrand = Random.Range(-20f, 20f);

        _rb.AddForce(_Xrand, _Yrand, _Zrand, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
