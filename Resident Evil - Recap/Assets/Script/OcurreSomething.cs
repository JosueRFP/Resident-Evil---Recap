using UnityEngine;
using UnityEngine.Events;

public class OcurreSomething : MonoBehaviour
{
    [SerializeField] UnityEvent OnOcurreSomething, OnUnOcurreSomething;
    
    private void OnTriggerEnter(Collider col)
    {        
        
      if (col.gameObject.CompareTag("Player"))
      {
        OnOcurreSomething.Invoke();
      }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        OnUnOcurreSomething.Invoke();
    }
}
