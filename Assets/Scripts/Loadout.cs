using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour
{
    public Weapon defaultWeapon;
    public Weapon activeWeapon;
    // Start is called before the first frame update
    void Start()
    {
        activeWeapon = defaultWeapon;
        defaultWeapon.unlimitedAmmo = true;
        activeWeapon.spawnLocation = GetComponent<Player>().projSpawnLocation;
        if (activeWeapon.weaponImage)
            activeWeapon.weaponImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        activeWeapon.update();
    }

    public void UpdateUI()
    {

        if (!activeWeapon.unlimitedAmmo)
        {
            UIManager.instance.ammoCount.text = activeWeapon.ammoCount.ToString();
            UIManager.instance.totalAmmo.text = activeWeapon.totalAmmo.ToString();
        }
        else
        {
            UIManager.instance.ammoCount.text = "999";
            UIManager.instance.totalAmmo.text = "999";
        }
    }
}
