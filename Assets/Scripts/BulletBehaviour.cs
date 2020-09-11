using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    float Speed  = 0.1f;
    [SerializeField]
    float maxFlightTime;

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void Update()
    {
        this.transform.position += transform.forward * Speed * Time.deltaTime;
    }

    //has 3d collisions to avoid unity 2d physics artifacts
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IEnemy>()!= null) {
        }
        Damage(other.gameObject);
    }

    //bullet destroys enemy and dissapears
    private void Damage(GameObject target) {
        WaveManager.EnemyList.Remove(target);
        Destroy(target);
        WaveManager.EnemyDeathCaptured();
        Destroy(this.gameObject);
    }
    
    //a way to prohibited unlimited bullets
    IEnumerator SelfDestruct() {
        yield return new WaitForSeconds(maxFlightTime);
        Destroy(this.gameObject);
    }

}
