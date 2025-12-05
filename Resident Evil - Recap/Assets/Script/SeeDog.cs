using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SeeDog : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 3f;
    [SerializeField] Image image;

    bool chasing = false;

    void Update()
    {
        transform.Rotate(0, 50  * Time.deltaTime, 0);

        if (chasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position,speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Dog see Player");
            image.color = Color.red;
            chasing = true;
        }
    }

   
}

