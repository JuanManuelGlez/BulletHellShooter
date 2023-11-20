using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesMovement : MonoBehaviour
{
    
    public GameObject SpawnArea;
    public GameObject Enemy;

    private Vector3 initialSpawnPosition;
    private float enemyRate1 = 0.15f;
    private float enemyRate2 = 0.2f;
    private float enemyRate3 = 0.5f;
    private float timer = 30.0f;
    private float fireRate = 1.0f;
    private int numEnemies;

    private int moveSpeed = 10;
    private float oscilationRate = 3.0f;
    private float oscilationTimer = 3.0f;
    private int dir1 = -1;
    private int dir2 = -1;

    private bool done = false;
    private bool done2 = false;
    
    private int angleEnemies = 45;
    private int angleCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        initialSpawnPosition = SpawnArea.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 20)
        {
            if (fireRate <= 0)
            {
                //spawnEnemy1();
                experiment1();
            }
        }
        else if (timer <= 20 && timer > 10)
        {
            if (!done)
            {
                SpawnArea.transform.position = new Vector3(-120.0f, 1.0f, 80.0f);
                done = !done;
            }
            if (fireRate <= 0)
            {
                spawnEnemy2();
            }
            if (oscilationTimer <= 0)
            {
                dir2 *= -1;
                oscilationTimer = oscilationRate;
            }
            SpawnArea.transform.Translate(new Vector3((10.0f * dir2 * moveSpeed * Time.deltaTime), 0f, 0f));
            oscilationTimer -= Time.deltaTime;
        }
        else if (timer <= 10 && timer > 0)
        {
            if (!done2)
            {
                SpawnArea.transform.position = new Vector3(0.0f, 1.0f, 80.0f);
                done2 = !done2;
            }
            numEnemies = 10;
            if (fireRate <= 0)
            {
                experiment2();
            }
        }
        timer -= Time.deltaTime;
        fireRate -= Time.deltaTime;
    }

    void spawnEnemy1()
    {
        GameObject enemyClone;
        enemyClone = Instantiate(Enemy, SpawnArea.transform.position, SpawnArea.transform.rotation);
        fireRate = enemyRate1;
    }
    
    void spawnEnemy2()
    {
        GameObject enemyClone;
        enemyClone = Instantiate(Enemy, SpawnArea.transform.position, SpawnArea.transform.rotation);
        fireRate = enemyRate2;
    }

    void experiment1()
    {
        GameObject enemyClone;
        enemyClone = Instantiate(Enemy, SpawnArea.transform.position, Quaternion.Euler(0,(90 + (angleEnemies)), 0));
        if (angleCount % 5 == 0){
            dir1 = dir1 * -1;
        }
        angleEnemies += (dir1 * 18);
        angleCount += 1;
        fireRate = enemyRate1;
    }

    void experiment2()
    {
        angleEnemies = 360 / numEnemies;
        for (int i = 0; i < numEnemies; i++){
            GameObject enemyClone;
            enemyClone = Instantiate(Enemy, SpawnArea.transform.position, Quaternion.Euler(0, (i * angleEnemies), 0));
        }
        fireRate = enemyRate3;
    }
}
