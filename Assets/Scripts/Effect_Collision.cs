using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Collision : MonoBehaviour
{
    public GameObject Snowy_Explosion;




    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Present"))
        {
            Instantiate(Snowy_Explosion, transform.position, transform.rotation);
            Destroy(gameObject); 
        }
        if (other.CompareTag("Enemy"))
        {
            Instantiate(Snowy_Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
