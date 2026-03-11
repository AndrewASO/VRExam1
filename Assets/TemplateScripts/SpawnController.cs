using UnityEngine;
using TMPro;

public class SpawnController : MonoBehaviour {

    //How to get numbers from all of the other planets and how to update them as well ? 
    public SpawnPlanets[] planetSpawners;
    private int totalDupe = 0;
    public TMP_Text pointText;


    public void UpdatePlanets(){
        for(int i = 0; i < planetSpawners.Length; i++){
            planetSpawners[i].UpdateTotalDupe(totalDupe);
        }
        pointText.text = "Score: " + totalDupe;
    }

    public void AddDupe(){
        totalDupe++;
        UpdatePlanets();
    }
}
