using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public bool destroyOnContact;
    public bool explosive;
    public float explosionRadius;
    public float timer;
    private float _currentTime;

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = timer;
    }
    void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0)
        {
            if (explosive)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
                foreach (Collider c in colliders)
                {
                    Enemies enemy = c.GetComponent<Enemies>();
                    if (enemy != null)
                    {
                        enemy.PlayDeathEffect();
                        Destroy(enemy.gameObject);
                        Destroy(gameObject);
                    }

                }
            }

        }
    }
}
