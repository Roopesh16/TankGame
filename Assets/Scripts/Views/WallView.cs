using System.Collections;
using System.Collections.Generic;
using TankGame.Controllers;
using UnityEngine;

public class WallView : MonoBehaviour
{
    [SerializeField] private GunController gunController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            gunController.canFire = false;
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
