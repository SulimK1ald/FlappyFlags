using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe2 : MonoBehaviour
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
        while (true)
        {
            float spawnTime = Random.Range(1.0f, 1.7f);
            float randY = Random.Range(-1.7f, 1f);
            yield return new WaitForSeconds(spawnTime);
            GameObject newPipes = Instantiate(Pipes, new Vector3(13, randY, 0), Quaternion.identity);
            Destroy(newPipes, 6.7f);
        }
    }
}
