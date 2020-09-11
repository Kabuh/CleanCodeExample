using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IShoot

{
    [SerializeField]
    private float shootEveryXSeconds;
    [SerializeField]
    private GameObject Bullet;
    private GameObject Gun;
    [SerializeField]
    private GameObject GunBarrel;

    public float ShootEveryXseconds {
        get {
            return shootEveryXSeconds;
        } set {
            shootEveryXSeconds = value;
        } }

    private bool bulletInChamber = true;

    private IEnumerator shootingInstance;

    private void Start()
    {
        Gun = this.gameObject;
    }

    public void StartShooting() {
        if (shootingInstance != null) {
            StopCoroutine(shootingInstance);
            shootingInstance = null;
        }
            if (bulletInChamber) {
                shootingInstance = Shooting(ShootEveryXseconds);
                StartCoroutine(shootingInstance);
            }
    }

    public void StopShooting() {
        if (shootingInstance != null) {
            StopCoroutine(shootingInstance);
        }
    }

    IEnumerator Shooting(float fireRate) {
        while (bulletInChamber) {
            Instantiate(Bullet, GunBarrel.transform.position, transform.rotation);
            bulletInChamber = false;
            StartCoroutine(Reloading(fireRate));
            yield return new WaitForSeconds(fireRate);
            yield return null;
        }
    }

    IEnumerator Reloading(float fireRate) {
        yield return new WaitForSeconds(fireRate);
        bulletInChamber = true;
    }
}
