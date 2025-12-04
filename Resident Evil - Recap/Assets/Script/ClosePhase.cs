using System.Collections;
using UnityEngine;

public class ClosePhase : MonoBehaviour
{
    [SerializeField] GameObject winPainel;

    void Start()
    {
        winPainel.SetActive(false);
    }


    public void StartEndPhase()
    {
        winPainel.SetActive(true);
        StartCoroutine(EndPhase());
    }


   public IEnumerator EndPhase()
   {
        yield return new WaitForSeconds(.2f);
        Application.Quit();
        print("End of Game");
   }
}
