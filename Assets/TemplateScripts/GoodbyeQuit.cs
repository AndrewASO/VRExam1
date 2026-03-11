using UnityEngine;
using System.Collections;

public class GoodbyeQuit : MonoBehaviour {

    public bool end;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        //Text already displaying the game is closing in a few seconds 
        if (end) {
            StartCoroutine(QuitAfterDelay() );
        }
    }

    //Quits application after 5 seconds have elapsed since scene was loaded in
    IEnumerator QuitAfterDelay() {
        yield return new
        WaitForSeconds(5f);
        Application.Quit();
    }
}
