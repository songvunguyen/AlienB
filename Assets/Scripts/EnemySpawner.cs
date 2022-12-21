using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum Directions{
        NORTH,
        SOUTH,
        EAST,
        WEST
    }
    [SerializeField]
    private GameObject fighterEnemy;

    [SerializeField]
    private float spawnInterval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, fighterEnemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy (float interval, GameObject enemy){
        yield return new WaitForSeconds(spawnInterval);
        Directions dir = (Directions) Random.Range(0,3);
        GameObject newEnemy;
        switch(dir){
            case Directions.NORTH:
                newEnemy = Instantiate(enemy, new Vector3(Random.Range(-8,8), 7.5f), Quaternion.identity );
                newEnemy.GetComponent<EnemyController>().faceDir = new Vector2(0,-1);
                break;
            case Directions.SOUTH:
                newEnemy = Instantiate(enemy, new Vector3(Random.Range(-8,8), -7.5f), Quaternion.Euler(new Vector3(0, 0, 180)));
                newEnemy.GetComponent<EnemyController>().faceDir = new Vector2(0,1);
                break;
            case Directions.EAST:
                newEnemy = Instantiate(enemy, new Vector3(14f,Random.Range(-3.5f,3.5f)), Quaternion.Euler(new Vector3(0, 0,-90)));
                newEnemy.GetComponent<EnemyController>().faceDir = new Vector2(-1,0);
                break;
            case Directions.WEST:
                newEnemy = Instantiate(enemy, new Vector3(-14f,Random.Range(-3.5f,3.5f)), Quaternion.Euler(new Vector3(0, 0, 90)));
                newEnemy.GetComponent<EnemyController>().faceDir = new Vector2(1,0);
                break;
            default:
                break;
        }

        StartCoroutine(spawnEnemy(interval,enemy));
        

    }
}
