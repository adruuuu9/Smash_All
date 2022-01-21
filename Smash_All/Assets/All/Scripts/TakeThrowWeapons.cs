using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TakeThrowWeapons : MonoBehaviour
{
    //Variables
    public float distance = 10f;
    public Transform equipPosition;
    [SerializeField] private GameObject currentWeapon;

    [SerializeField] private bool canGrab;
    [SerializeField] private bool weaponTaked;

    public float dropForwardForce;
    public float dropUpwardForce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrab();
        DropWeapon();
        KeepWeaponStatic();
    }

    private void CheckGrab()
    {
        if (weaponTaked)
        {
            canGrab = false;
        }
        else if (!weaponTaked)
        {
            canGrab = true;
        }
    }

    private void KeepWeaponStatic()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanGrab") && !weaponTaked)
        {
            currentWeapon = other.gameObject;
            currentWeapon.transform.position = equipPosition.position;
            currentWeapon.transform.parent = equipPosition;
            currentWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            currentWeapon.GetComponent<Rigidbody>().useGravity = false;
            currentWeapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            weaponTaked = true;
        }
    }

    private void DropWeapon()
    {
        if (Input.GetKeyDown(KeyCode.G) && weaponTaked)
        {
            currentWeapon.transform.parent = null;
            currentWeapon.GetComponent<Rigidbody>().useGravity = true;
            currentWeapon.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            currentWeapon.GetComponent<Rigidbody>().AddForce(equipPosition.forward * dropForwardForce, ForceMode.Impulse);
            currentWeapon.GetComponent<Rigidbody>().AddForce(equipPosition.up * dropUpwardForce, ForceMode.Impulse);
            float random = Random.Range(-1f, 1f);
            currentWeapon.GetComponent<Rigidbody>().AddTorque(new Vector3(random, random, random) * 10);

            currentWeapon = null;
            
            

            weaponTaked = false;
        }
    }
}
