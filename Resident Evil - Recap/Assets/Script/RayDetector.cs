using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RayDetector : MonoBehaviour
{
    [SerializeField] GameObject image;
    [SerializeField] UnityEvent OnEnter;
    [SerializeField] UnityEvent OnExit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       image.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Colidiu com o jogador");
            OnEnter.Invoke();
            image.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Saiu da colisao com o jogador");
            OnExit.Invoke();
            image.SetActive(false);
        }
    }
}
