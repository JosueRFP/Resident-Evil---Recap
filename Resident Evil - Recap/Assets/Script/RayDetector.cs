using UnityEngine;
using UnityEngine.UI;

public class RayDetector : MonoBehaviour
{
    [SerializeField] Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image.enabled = false;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            image.enabled = true;
        }
    }
}
