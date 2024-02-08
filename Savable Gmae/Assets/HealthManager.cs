using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p")){
            AddHealth(5);
        }
        if(Input.GetKeyDown("o")){
            RemoveHealth(5);
        }
    }
    public void AddHealth(float amount){
        health += amount;
    }
    public void RemoveHealth(float amount){
        health -= amount;
    }
}
