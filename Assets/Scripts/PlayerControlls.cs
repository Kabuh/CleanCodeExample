using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour, IMove, IRotate
{
    [SerializeField]
    private float speed = 0.1f;
    Vector3 moveVector;

    [SerializeField]
    private Weapon Gun;
    

    private void Update()
    {
        if (Input.GetKey("w")) {
            Move(Vector3.up);
        }
        if (Input.GetKey("s"))
        {
            Move(Vector3.down);
        }
        if (Input.GetKey("d"))
        {
            Move(Vector3.right);
        }
        if (Input.GetKey("a"))
        {
            Move(Vector3.left);
        }

        CursorRotation();

        if (Input.GetMouseButton(0)) {
            Gun.StartShooting();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Gun.StopShooting();
        }
    }

    public void Move(Vector3 moveVector)
    {
        this.transform.position += moveVector * speed * Time.deltaTime;
    }

    public void RotateTo(Vector3 lookPoint) {
        
        this.transform.rotation = Quaternion.LookRotation(lookPoint-this.transform.position, Vector3.back);
    }

    private void CursorRotation(){
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0.0f;
        RotateTo(mousePos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ExploderAI>() != null) {
            WaveManager.GameOver();
        }
    }
}
