using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public WEAPONTYPE weaponType;
    public SPAWNLOCATION spawnEnum;
    public GameObject spawnLocation;
    private GameObject _projectileSpawn;
    public GameObject objectPrefab;
    private Player _user;

    public float forwardProjectileForce;
    public float upwardProjectileForce;
    public float reloadTime;
    private float _currentReloadTime;
    public int ammoCap = 0;
    public int _ammoCount;


    // Start is called before the first frame update
    public void start(Player player)
    {
        _projectileSpawn = spawnLocation;
        _user = player;
        _ammoCount = ammoCap;
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
    }

    // Update is called once per frame
    public void update()
    {
        if (_ammoCount <= 0)
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {   
            if (_ammoCount > 0)
            {
                _ammoCount--;
                _user.anim.SetTrigger("Shoot");

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
            _ammoCount = ammoCap;
            _currentReloadTime = reloadTime;
        }
    }
}
