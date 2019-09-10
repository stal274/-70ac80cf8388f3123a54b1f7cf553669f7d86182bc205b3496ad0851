using System.Collections;
using StudyGameScene;
using UnityEngine;

public class VisualisingObjectContract : MonoBehaviour
{
    private GameObject obj;
    
    public void ObjectVisibleAfter1Second(GameObject obj)
    {
        this.obj = obj;
        this.obj.SetActive(false);
    
        StartCoroutine(CheckingAnimations());


    }
    private IEnumerator CheckingAnimations()
    {
        if (FindObjectOfType<GameplayStepsControl>().StopGame)
        {
            yield return null;
           
        }
      var  basket = GameObject.FindObjectOfType<Basket>();
        yield return StartCoroutine(basket.StonesInBasketGenerate());
        
        yield return new WaitForSeconds(2f);
        obj.SetActive(true);

    }
}
