using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SeeDog : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 3f;

    bool chasing = false;

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);

        if (chasing)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Dog see Player");
            chasing = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}

