using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject weapon1; // e.g., pistol
    public GameObject weapon2; // e.g., machine gun

    private GameObject currentWeapon;

    void Start()
    {
        weapon1.SetActive(true);
        weapon2.SetActive(false);
        currentWeapon = weapon1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchTo(weapon1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchTo(weapon2);
        }
    }

    void SwitchTo(GameObject newWeapon)
    {
        currentWeapon.SetActive(false);
        newWeapon.SetActive(true);
        currentWeapon = newWeapon;
    }
}

