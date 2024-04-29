using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1

    [HideInInspector]
    public int sheepSaved; // 2

    [HideInInspector]
    public int sheepDropped = 0; // 3

    public int sheepDroppedBeforeGameOver; // 4
    public SheepSpawner sheepSpawner; // 5

    private bool hardMode = false;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }

        if (sheepSaved >= 10 && !hardMode)
        {
            hardMode = true;

            // Find all GameObjects with the specified tag
            GameObject[] wheels = GameObject.FindGameObjectsWithTag("Wheel");

            // Loop through each wheel object
            foreach (GameObject wheel in wheels)
            {
                // Access the Rotate script attached to the wheel object
                Rotate rotateScript = wheel.GetComponent<Rotate>();
                               
                // Modify the speed variable
                rotateScript.speed = 1000f;         
            }

            // More Sheeps
            GameObject spawner = GameObject.Find("Sheep Spawner");
            SheepSpawner spawnerScript = spawner.GetComponent<SheepSpawner>();
            spawnerScript.timeBetweenSpawns = 0.8f;

            // More Player Speed and Rate of Fire
            GameObject hayMachine = GameObject.Find("Hay Machine");
            PlayerController playerControllerScript = hayMachine.GetComponent<PlayerController>();
            playerControllerScript.speed *= 2;
            playerControllerScript.shootInterval = 0.25f;

            // Different Light
            GameObject light = GameObject.Find("Directional Light");
            Light Light = light.GetComponent<Light>();
            Light.color = new Color(214f / 255f, 174f / 255f, 76f / 255f);
       
            // Different Light
            GameObject camera = GameObject.Find("Main Camera");
            Camera Camera = camera.GetComponent<Camera>();
            Camera.backgroundColor = new Color(180 / 255f, 142 / 255f, 99 / 255f);
        }
        if (hardMode)
        {
            GameObject spawner = GameObject.Find("Sheep Spawner");
            SheepSpawner spawnerScript = spawner.GetComponent<SheepSpawner>();
            
            foreach (GameObject sheep in spawnerScript.sheepList)
            {
                Sheep sheepScript = sheep.GetComponent<Sheep>(); // Get the Sheep script component
                sheepScript.runSpeed = 20; // Modify the runSpeed variable
                
            }
        }
        

    }
    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();

    }
    private void GameOver()
    {
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
        UIManager.Instance.ShowGameOverWindow();

    }
    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();


        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }
    }

}
