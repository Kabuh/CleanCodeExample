using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ExploderAI : MonoBehaviour, IMove, IRotate, IEnemy
{
    private GameObject Player;

    [SerializeField]
    private float speed = 0.1f;

    [SerializeField]
    EnemyType myEnemyType;

    void Start()
    {
        Player = WaveManager.player.gameObject;
    }
    
    void Update()
    {
        RotateTo(Player.transform.position);
        Move(Player.transform.position);
    }

    public EnemyType ReturnEnemyType()
    {
        return myEnemyType;
    }

    //always look at player
    public void RotateTo(Vector3 lookPoint)
    {
        this.transform.rotation = Quaternion.LookRotation(lookPoint - this.transform.position, Vector3.back);
    }

    //rush onto player
    public void Move(Vector3 moveVector)
    {
        this.transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void ReportToEnemyList()
    {
        WaveManager.EnemyList.Add(this.gameObject);
    }
}
