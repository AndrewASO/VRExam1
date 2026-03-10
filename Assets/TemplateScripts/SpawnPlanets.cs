using UnityEngine;

public class SpawnPlanets : MonoBehaviour {

    public Transform planetPos;
    public GameObject prefab;
    public SpawnController spawnController;
    private int dupeNumber = 0;
    public int totalDupe = 0;

    public void SpawnDupe(){
        if(dupeNumber < 3 && totalDupe < 6){
            Vector3 currentPosition = planetPos.position;
            float newYPos = currentPosition.y + ( 1 * (dupeNumber + 1) );
            Vector3 newPos = new Vector3(currentPosition.x, newYPos, currentPosition.z);
            Instantiate(prefab, newPos, planetPos.rotation );
            dupeNumber++;
            spawnController.AddDupe();
        }
    }

    public void UpdateTotalDupe(int newTotal){
        totalDupe = newTotal;
        Debug.Log(totalDupe);
    }
}
