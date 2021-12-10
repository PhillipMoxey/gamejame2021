using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Script : MonoBehaviour
{
    public Weapon Ammo_script;
    public Loadout SwapWeapon_Script;

    public bool pickedUp;

    public GameObject Press_E;
    public GameObject Effect_Star;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        Press_E.SetActive(pickedUp);
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pickedUp = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(Effect_Star, transform.position, transform.rotation);
                Ammo_script.ammoCount++; // here tom
                SwapWeapon_Script.SwapWeapon(weapon);
                Effect_Star.SetActive(pickedUp);
             
                print("Active");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickedUp = false;
        }
    }
}
