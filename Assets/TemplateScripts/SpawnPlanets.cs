using UnityEngine;
using TMPro;

public class SpawnPlanets : MonoBehaviour {

    public Transform planetPos;
    public GameObject prefab;
    public SpawnController spawnController;
    private int dupeNumber = 0;
    public int totalDupe = 0;
    public TMP_Text worldText;
    public TextMeshProUGUI closedText;
    public string orientation;              //Orientation of the offsets if they'll go in the x or z direction

    public void SpawnDupe(){
        if(dupeNumber == 0) {
            worldText.gameObject.SetActive(true);
            //worldText = "You are on the top of the world";
        }

        if(dupeNumber < 3 && totalDupe < 6){
            Vector3 currentPosition = planetPos.position;
            Vector3 newPos = currentPosition;
            if(orientation == "x") {
                float newXPos = currentPosition.x + ( 1 * (dupeNumber + 1) );
                newPos = new Vector3(newXPos, currentPosition.y, currentPosition.z);
            }
            //Simply leaving the else if in case there needs to be an else{} for saying to input the right one
            else if(orientation == "z") {
                float newZPos = currentPosition.z + ( 1 * (dupeNumber + 1) );
                newPos = new Vector3(currentPosition.x, currentPosition.y, newZPos);
            }
            Instantiate(prefab, newPos, planetPos.rotation );
            dupeNumber++;
            spawnController.AddDupe();
        }
    }

    public void UpdateTotalDupe(int newTotal){
        totalDupe = newTotal;
        //Was thinking about optimizing this by making it into a TextMeshProUGUI[] that'll iterate through all of the index's
        //until everything was set active but skipped it for now. Might be more efficient ? Uhh, 18 checks through sending it to
        //3 planets or 3n, versus n for just having it in SpawnController for every check. So marginally better so it might
        //add up over time but not worth it for this but a bottleneck for the future potentially. 
        if(totalDupe == 6) {
            closedText.gameObject.SetActive(true);
        }
        Debug.Log(totalDupe);
    }
}