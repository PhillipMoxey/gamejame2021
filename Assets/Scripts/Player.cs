using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Loadout loadout;

    //Spawning projectiles
    public GameObject projSpawnLocation;

    //Variable for looking around
    public Vector3 lookVector;
    public Animator anim;

    //Variables for dash
    public KeyCode dashButton;
    public float dashTime;
    public float dashSpeed;
    public float dashCooldownTime;
    public GameObject dashEffect;
    private bool _dashing;

    public float defaultMoveSpeed;
    private float _moveSpeed;

    public Vector3 _playerInput;
    private CharacterController _characterController;

    private Rigidbody _rb; 
    // Start is called before the first frame update
    void Start()
    {
        _dashing = false;
        _moveSpeed = defaultMoveSpeed;
        _characterController = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dashButton) && !_dashing)
        {
            StartCoroutine(Dash());
        }
        ReadInput();
        LookAtMouse();
    }

    private void FixedUpdate()
    {

        _rb.MovePosition(transform.position + (_playerInput * _moveSpeed * Time.deltaTime));

        //_characterController.Move(_playerInput * _moveSpeed * Time.deltaTime);
    }

    void ReadInput()
    {    
        _playerInput.x = Input.GetAxisRaw("Horizontal");
        _playerInput.z = Input.GetAxisRaw("Vertical");
    }

    void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            lookVector = hit.point;
            lookVector.y = 0;
            transform.LookAt(lookVector);
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }
    }

    IEnumerator Dash()
    {
        ReadInput();
        _dashing = true;
        _moveSpeed = dashSpeed;
        StartCoroutine(dashCooldown(dashCooldownTime));
        yield return new WaitForSeconds(dashTime);
        _moveSpeed = defaultMoveSpeed;
    }

    IEnumerator dashCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        _dashing = false;
    }
}
