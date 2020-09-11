using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvoice
{
    private List<EnemyType> unitsOrdered = new List<EnemyType>();

    public void Add(EnemyType enemyType, int Count) {
        for (int i = 0; i < Count; i++) {
            unitsOrdered.Add(enemyType);
        }
    }

    public List<EnemyType> ReadList() {
        return unitsOrdered;
    }

}
