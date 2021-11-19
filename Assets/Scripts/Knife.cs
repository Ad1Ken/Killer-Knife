using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public int scoreValue = 1;
    public void OnTriggerEnter2D(Collider2D Knife)
    {
        if(Knife.tag == "Border" )
        {
            FindObjectOfType<ScoreScript>().ScoreUpdate(scoreValue);
        }
        
    }
}
