using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Vector3 Movement_Speed;
    public Vector3 Rotation_Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Movement_Speed * Time.deltaTime);
        transform.Rotate(Rotation_Speed * Time.deltaTime);
    }
}
