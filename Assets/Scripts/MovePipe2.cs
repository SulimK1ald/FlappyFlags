using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe2 : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
    }
}
