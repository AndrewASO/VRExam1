using UnityEngine;
using TMPro;

public class ExitObjectSpawner : MonoBehaviour {

    public GameObject exitObjectPrefab;
    public Transform spawnLocation;
    //Need this for the donut spawn point tracker
    public TMP_Text pointText;

    void Start() {
        if (GlobalTimer.Instance != null) {
            GlobalTimer.Instance.OnTimeReached += SpawnExitObject;
        }
    }

    void OnDisable() {
        if (GlobalTimer.Instance != null) {
            GlobalTimer.Instance.OnTimeReached -= SpawnExitObject;
        }
    }

    void SpawnExitObject() {
        Debug.Log("Exit object was attempted to be spawned");
        GameObject obj = Instantiate(exitObjectPrefab, spawnLocation.position, spawnLocation.rotation);
        //Increase donut count as well just for the task in exam 1
        DonutTracker.donutsSpawned++;
        pointText.text = "Score: " + (DonutTracker.donutsSpawned + DonutTracker.dupesSpawned);
    }
}
