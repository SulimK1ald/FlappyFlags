using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject Pipes;
    void Start()
    {
        StartCoroutine(PipeSpawn());
    }

    void Update()
    {

    }

    IEnumerator PipeSpawn()
    {
        while(true)
        {
            float spawnTime = Random.Range(2.5f, 2.5f);
            float randY = Random.Range(-2.3f, 1.5f);
            yield return new WaitForSeconds(spawnTime);
            GameObject newPipes = Instantiate(Pipes, new Vector3(13, randY, 0), Quaternion.identity);
            Destroy(newPipes, 6.7f);
        }
    }
}
