using UnityEngine;

public class Floating : MonoBehaviour {

    public float distance = 10f;
    public float movSpd = 1f;
    private Vector3 originalPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        //Used sin here instead of Lerp because it'll return values between -1 & 1 
        //If it was in one direction or 2 different directions of varying lengths then Lerp would probably be used ? Or maybe a scalar
        //alongside the Sin for one direction but since its moving equally in both directions then this works for the floating portion
        float offset = Mathf.Sin(Time.time * movSpd) * distance;
        transform.position = originalPos + new Vector3(offset, 0f, 0f);
    }
}
