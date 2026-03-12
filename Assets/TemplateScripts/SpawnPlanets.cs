using UnityEngine;
using TMPro;
using System.Collections;

public class SpawnPlanets : MonoBehaviour {

    public Transform planetPos;             //Position of the planet
    public GameObject prefab;               //Prefab of the planet to be spawned
    public SpawnController spawnController; //Spawn controller so total dupe can be retrieved from it
    private int dupeNumber = 0;             //Local duplications made from this obj
    public int totalDupe = 0;               //Overall duplication made from all objs
    public TMP_Text worldText;              //Text for saying you're on top of the world
    public TextMeshProUGUI closedText;      //Text for displaying Shop is closed
    public enum Orientation {X, Z};         //Orientation of the offsets if they'll go in the x or z direction
    public Orientation orientation;         //Made into enum instead of string so there's less mistakes and only 2 options
    public float moveDur = 2.5f;              //How long it'll take the duped planet to move to its designated location
    private bool canSpawn = true;
    public int maxSpawns = 3;

    public void SpawnDupe(){
        if(dupeNumber == 0) {
            worldText.gameObject.SetActive(true);
            //worldText = "You are on the top of the world";
        }

        if(dupeNumber < maxSpawns && totalDupe < maxSpawns && canSpawn){
            Vector3 currentPosition = planetPos.position;
            Vector3 newPos = currentPosition;
            if(orientation == Orientation.X) {
                float newXPos = currentPosition.x + ( 1 * (dupeNumber + 1) );
                newPos = new Vector3(newXPos, currentPosition.y, currentPosition.z);
            }
            //Simply leaving the else if in case there needs to be an else{} for saying to input the right one
            else if(orientation == Orientation.Z) {
                float newZPos = currentPosition.z + ( 1 * (dupeNumber + 1) );
                newPos = new Vector3(currentPosition.x, currentPosition.y, newZPos);
            }

            //Creates the new planet as a game object then puts it into the coroutine MovePlanet to move it to its new location
            GameObject newPlanet = Instantiate(prefab, currentPosition, planetPos.rotation );
            canSpawn = false;
            StartCoroutine( UpdateCanSpawn() );
            StartCoroutine(MovePlanet(newPlanet.transform, newPos) );
            dupeNumber++;
            spawnController.AddDupe();
        }
    }

    IEnumerator UpdateCanSpawn() {
        yield return new
        WaitForSeconds(2f);
        this.canSpawn = true;
    }

    //Gets the transform of the initial planet and then the location set for the new planet
    IEnumerator MovePlanet(Transform planet, Vector3 targetPos) {
        Vector3 startPos = planet.position;
        float time = 0;
        while(time < moveDur) {
            //Lerp(Linear interpolation) to smoothly move the planet from its initial location to the final location
            planet.position = Vector3.Lerp(startPos, targetPos, time / moveDur);
            time += Time.deltaTime;
            yield return null;
        }

        planet.position = targetPos;
    }
    

    public void UpdateTotalDupe(int newTotal){
        totalDupe = newTotal;
        //Was thinking about optimizing this by making it into a TextMeshProUGUI[] that'll iterate through all of the index's
        //until everything was set active but skipped it for now. Might be more efficient ? Uhh, 18 checks through sending it to
        //3 planets or 3n, versus n for just having it in SpawnController for every check. So marginally better so it might
        //add up over time but not worth it for this but a bottleneck for the future potentially. 
        if(totalDupe == maxSpawns) {
            closedText.gameObject.SetActive(true);
        }
        Debug.Log(totalDupe);
    }
}