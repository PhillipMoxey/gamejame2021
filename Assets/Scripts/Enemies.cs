using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public float health = 50f;

    //Reference of AI movement
    Player player;
    public Vector3 target;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float MinDist = 1;
    public float magnitude;

    private bool _deathTime; 
    public float deathTimer; 

    //AI attacking player
    public float attackInterval;
    private float _attackIntervalTimer;

    public int damage;

    //Reference to Nav-mesh for movement
    public NavMeshAgent _agent;
    public GameObject Death_Effect;
    public GameObject propPrefab; 

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(player.transform.position);

        if(_deathTime && deathTimer > 0)
        {
            deathTimer -= Time.deltaTime; 
        }
        else if (_deathTime)
        {
            Die(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //TEMP SCRIPT - just kills enemy on collision
        if(other.CompareTag("Bullet"))
        {
            health -= other.GetComponent<Projectile>().damage; 
            if(health <= 0)
            {
                //_agent.enabled = false;
                GameObject _deathProp = Instantiate(propPrefab, transform.position, Quaternion.identity);
                Die();
                _deathTime = true; 
                PlayDeathEffect();
            }
            else
            {
                MoveSpeed = 2f; 
            }
            
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void PlayDeathEffect()
    {
        Instantiate(Death_Effect, transform.position, transform.rotation);
    }

    public void SetTarget(Vector3 targetToSet)
    {
        target = targetToSet;
    }
    void Die()
    {
        PlayDeathEffect();
        Destroy(gameObject);
    }
}

