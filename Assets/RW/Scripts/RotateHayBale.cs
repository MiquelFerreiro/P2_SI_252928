using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHayBale : MonoBehaviour
{

    public Vector3 movementSpeed;
    public Space space;

    public float RotSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
        transform.Rotate(RotSpeed*Time.deltaTime, 0, 0);
    }
}
