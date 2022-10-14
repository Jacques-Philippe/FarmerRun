using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    /// <summary>
    /// The list of all prefabs to use as obstacle paths
    /// </summary>
    public List<GameObject> obstacleTunnelPrefabs;

    [Tooltip("The amount of time obstacles should be kept alive for")]
    public float ObstacleLife;

    private GameManager gameManager;

    private void Start()
    {
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        
        StartCoroutine(ManageObstacleSpawning());
    }

    private IEnumerator ManageObstacleSpawning()
    {
        if (!gameManager.IsGameOver)
        {
            float randomDelay = Random.Range(3, 4);
            yield return new WaitForSeconds(randomDelay);
            if (!gameManager.IsGameOver)
            {
                this.SpawnObstacles();
                yield return ManageObstacleSpawning();
            }
        }
        else
        {
            yield return null;
        }
    }

    private void SpawnObstacles()
    {
        int randomIndex = Random.Range(0, this.obstacleTunnelPrefabs.Count - 1);
        var prefab = this.obstacleTunnelPrefabs[randomIndex];
        var obj = GameObject.Instantiate(original: prefab);
        var destroyCoroutine = DestroyAfterSeconds(obj, this.ObstacleLife);
        StartCoroutine(destroyCoroutine);
    }

    private IEnumerator DestroyAfterSeconds(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (!this.gameManager.IsGameOver)
        {
            GameObject.Destroy(obj);
        }
    }

}
