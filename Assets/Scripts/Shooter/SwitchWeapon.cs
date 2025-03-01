using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private const KeyCode SwitchKeyAuto = KeyCode.Alpha1, 
        SwitchKeyShotgun = KeyCode.Alpha2, 
        SwitchKeyLaser = KeyCode.Alpha3;
    
    [SerializeField] private FullAuto _automat;
    [SerializeField] private Shotgun _shotgun;
    [SerializeField] private Laser _laser;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeapon(SwitchKeyAuto);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapon(SwitchKeyShotgun);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeapon(SwitchKeyLaser);
    }

    private void ChangeWeapon(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case SwitchKeyAuto:
                _automat.enabled = true;
                _shotgun.enabled = false;
                _laser.enabled = false;
                break;
            
            case SwitchKeyShotgun:
                _automat.enabled = false;
                _shotgun.enabled = true;
                _laser.enabled = false;
                break;
            
            case SwitchKeyLaser:
                _automat.enabled = false;
                _shotgun.enabled = false;
                _laser.enabled = true;
                break;
            
            default:
                
                break;
        }
    }
}