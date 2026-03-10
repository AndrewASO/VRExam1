using UnityEngine;

public class ExitObjectSpawner : MonoBehaviour {

    public GameObject exitObjectPrefab;
    public Transform spawnLocation;

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
    }
}
