using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    // Start is called before the first frame update
    private string path = @"Assets\save.txt";
    private HealthManager healthManager;


    void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            Debug.Log("Test ett");
            SaveGame();
        }
        if(Input.GetKeyDown("f")){
            LoadGame();
        }
    }
    void SaveGame(){
        //Sapara spelet
        Debug.Log("F har tryckts; ");
        Vector2 position = transform.position;

        StreamWriter sw = new StreamWriter(path);
        sw.WriteLine(position.x + " " + position.y);
        sw.WriteLine(healthManager.health);
        sw.Close();
    }
    void LoadGame()
    {
        StreamReader sr = new StreamReader(path);
        string output = sr.ReadLine();
        string healthOutput = sr.ReadLine();
        string[] outputArray = output.Split(' ');
        Vector2 position = Vector2.zero;

        try
        {
            position = new Vector2(float.Parse(outputArray[0]), float.Parse(outputArray[1]));
        }
        catch{
            Debug.Log("Parsen misslyckades");
        }
        float Health = float.Parse(healthOutput);


        sr.Close();

        transform.position = position;
        healthManager.health = Health;
    }

}
