using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class RayYellow : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] UnityEvent OnEnter;
    [SerializeField] UnityEvent OnExit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            image.color = Color.yellow;
            OnEnter.Invoke();
            image.enabled = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnExit.Invoke();
            image.enabled = false;
        }
    }
}
