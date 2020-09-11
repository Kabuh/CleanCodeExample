using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public static PlayerControlls player;

    [SerializeField]
    private PlayerControlls playerPrefab;

    [SerializeField]
    List<GameObject> EnemyTypesList;
    public static Dictionary<EnemyType, GameObject> EnemyGameObjectLib = new Dictionary<EnemyType,GameObject>();

    public static Spawner currentSpawner;
    private static SpawnInvoice mySpawnInvoice;

    private static int enemyCnt = 0;

    //if we run out of enemies - spawn more without constant checking on update
    private static int enemyCount { get {
            return enemyCnt;
        } set {
            enemyCnt = value;
            if (enemyCnt == 0) {
                DeployEnemies();
            }
        } }

    public static List<GameObject> EnemyList = new List<GameObject>();

    private void Start()
    {
        Time.timeScale = 1.0f;
        mySpawnInvoice = new SpawnInvoice();

        PopulateEnemyLib();
        SpawnPlayer();
        

        //ad-hoc ordering instead of j-son, which can be done now
        mySpawnInvoice.Add(EnemyType.Exploder, 10);

        DeployEnemies();
    }

    public static void DeployEnemies() {
        foreach (EnemyType type in mySpawnInvoice.ReadList()) {
            currentSpawner.Spawn(EnemyGameObjectLib[type]);
            enemyCount++;
        }
    }

    public static void EnemyDeathCaptured() {
        enemyCount--;
    }

    public static void GameOver() {
        Time.timeScale = 0.0f;
        player.gameObject.SetActive(false);


        //restartbuttonSpawn
        EnemyGameObjectLib.Clear();
        mySpawnInvoice = null;
        //foreach (GameObject item in EnemyList) {
        //    if (item != null) {
        //        Destroy(item);
        //    }
        //}

        SceneManager.LoadScene(0);
    }

    private void SpawnPlayer() {
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void PopulateEnemyLib() {
        foreach (GameObject item in EnemyTypesList)
        {
            EnemyGameObjectLib.Add(item.GetComponent<IEnemy>().ReturnEnemyType(), item);
        }
    }
}
