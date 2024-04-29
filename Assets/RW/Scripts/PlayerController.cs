using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float horizontalBoundary = 22;
    public GameObject hayBalePrefab; //Reference to the Hay Bale prefab.
    public float shootInterval; //The smallest amount of time between shots
    private float shootTimer; //A timer that to keep track whether the machine can shoot 

    public Transform modelParent; // 1

    // 2
    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;


    // Start is called before the first frame update
    void Start()
    {
        LoadModel();

    }
    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject); // 1

        switch (GameSettings.hayMachineColor) // 2
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }

    void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 1
        {
            transform.Translate(transform.right * - speed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 2
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        
    }

    void ShootHay()
    {

        if (shootTimer < 0 && Input.GetKeyUp(KeyCode.Space))
        {

            shootTimer = shootInterval; 
            Instantiate(hayBalePrefab, transform.position + new Vector3(0, 2f, 4f), Quaternion.identity);
            SoundManager.Instance.PlayShootClip();

        }
        shootTimer += -Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();

        ShootHay(); 
    }
}
