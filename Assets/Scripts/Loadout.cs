using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour
{
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;
    public Weapon defaultWeapon;
    public Weapon activeWeapon;
    // Start is called before the first frame update
    void Start()
    {
        activeWeapon = primaryWeapon;
        activeWeapon.spawnLocation = GetComponent<Player>().projSpawnLocation;
        primaryWeapon.start(gameObject.GetComponent<Player>());
        secondaryWeapon.start(gameObject.GetComponent<Player>());
    }

    // Update is called once per frame
    void Update()
    {
        activeWeapon.update();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (activeWeapon == primaryWeapon)
                activeWeapon = secondaryWeapon;
            else if (activeWeapon == secondaryWeapon)
                activeWeapon = primaryWeapon;
        }
    }

    public void SwapWeapon(Weapon weapon)
    {
        secondaryWeapon = weapon;
    }
}
