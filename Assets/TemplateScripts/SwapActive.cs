using UnityEngine;

public class SwapActive : MonoBehaviour {

    public GameObject obj1;
    public GameObject obj2;
    public int swapCounter = 0;

    public void SwapOnce(){
        if(swapCounter == 0){
            swapCounter++;
            obj1.SetActive(!obj1.activeSelf);
            obj2.SetActive(!obj2.activeSelf);
        }
    }
}
