using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/New Weapon")]
public class Weapon : ScriptableObject
{

    public enum SPAWNLOCATION
    {
        REINDEER,
        PLAYER
    }

    public enum WEAPONTYPE
    {
        BULLET,
        THROWN
    }

    public enum WEAPON
    {
        SNOWBALL,
        CARROT,
        COAL
    }

    public WEAPON weapon;
    public WEAPONTYPE weaponType;
    public SPAWNLOCATION spawnEnum;
    public GameObject spawnLocation;
    private GameObject _projectileSpawn;
    public GameObject objectPrefab;
    public Image weaponImage;
    private Player _user;

    public float forwardProjectileForce;
    public float upwardProjectileForce;
    public float reloadTime;
    private float _currentReloadTime;
    public bool unlimitedAmmo;
    public int totalAmmo = 0;
    public int ammoCount;
    public int clipSize;


    // Start is called before the first frame update
    public void start(Player player)
    {       
        switch (weapon)
        {
            case WEAPON.CARROT:
                weaponImage = UIManager.instance.carrotImage;
                break;
            case WEAPON.COAL:
                weaponImage = UIManager.instance.coalImage;
                break;
            case WEAPON.SNOWBALL:
                weaponImage = UIManager.instance.snowballImage;
                break;
        }
        _projectileSpawn = spawnLocation;
        _user = player;
        ammoCount = clipSize;
        _currentReloadTime = reloadTime;
        switch (spawnEnum)
        {
            case SPAWNLOCATION.REINDEER:
                _projectileSpawn = _user.projSpawnLocation;
                break;
            case SPAWNLOCATION.PLAYER:
                _projectileSpawn = _user.gameObject;
                break;
            default:
                break;
        }
        if (unlimitedAmmo)
        {
            totalAmmo = 999;
            ammoCount = 999;
        }
        UpdateUI();
    }

    // Update is called once per frame
    public void update()
    {
        if (ammoCount <= 0)
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {   
            if (ammoCount > 0 || unlimitedAmmo)
            {
                if (!unlimitedAmmo)
                    ammoCount--;
                //_user.anim.SetTrigger("Shoot");

                GameObject _bullet = Instantiate(objectPrefab, _projectileSpawn.transform.position, Quaternion.identity);
                switch (weaponType)
                {
                    case WEAPONTYPE.BULLET:
                        _bullet.GetComponent<Rigidbody>().AddForce(_projectileSpawn.transform.forward * forwardProjectileForce, ForceMode.Impulse);
                        break;
                    case WEAPONTYPE.THROWN:
                        _bullet.GetComponent<Rigidbody>().AddForce(_projectileSpawn.transform.forward * forwardProjectileForce, ForceMode.Impulse);
                        _bullet.GetComponent<Rigidbody>().AddForce(Vector3.up * forwardProjectileForce, ForceMode.Impulse);
                        break;
                }
                UpdateUI();
            }
        }
    }
    void Reload()
    {
        _user.anim.SetTrigger("Reload");
        if (_currentReloadTime > 0)
        {
            _currentReloadTime -= Time.deltaTime;
        }
        else
        {
            if (totalAmmo > clipSize)
            {
                ammoCount += clipSize;
                totalAmmo -= clipSize;
            }
            else
            {
                ammoCount += totalAmmo;
                totalAmmo = 0;
            }
            _currentReloadTime = reloadTime;
        }
    }

    void UpdateUI()
    {
        UIManager.instance.ammoCount.text = ammoCount.ToString();
        if (!unlimitedAmmo)
            UIManager.instance.totalAmmo.text = totalAmmo.ToString();
        else
            UIManager.instance.totalAmmo.text = "999";
    }
}
