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
        activeWeapon.weaponImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        activeWeapon.update();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            activeWeapon.weaponImage.gameObject.SetActive(false);
            if (activeWeapon == primaryWeapon)
                activeWeapon = secondaryWeapon;
            else if (activeWeapon == secondaryWeapon)
                activeWeapon = primaryWeapon;
            activeWeapon.weaponImage.gameObject.SetActive(true);
            UpdateUI();
        }
    }

    public void SwapWeapon(Weapon weapon)
    {
        secondaryWeapon = weapon;
    }

    public void UpdateUI()
    {
        UIManager.instance.ammoCount.text = activeWeapon.ammoCount.ToString();
        if (!activeWeapon.unlimitedAmmo)
            UIManager.instance.totalAmmo.text = activeWeapon.totalAmmo.ToString();
        else
            UIManager.instance.totalAmmo.text = "999";
    }
}
