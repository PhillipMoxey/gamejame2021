using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Weapon powerWeapon;
    public float lifeSpan;
    private float _currentLifeSpan;
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            player.loadout.activeWeapon = powerWeapon;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentLifeSpan = lifeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        _currentLifeSpan -= Time.deltaTime;

    }
}
