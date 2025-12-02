using UnityEngine;

public class RotationCam : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;


    [Header("Settings")]
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private bool ignoreVertical = true; 


    void LateUpdate()
    {
        if (player == null) return;


        // direção da câmera para o player
        Vector3 dir = player.position - transform.position;


        // remove o Y para girar só no eixo horizontal
        if (ignoreVertical)
            dir.y = 0f;


        if (dir.sqrMagnitude < 0.001f) return;


        // rotação alvo
        Quaternion target = Quaternion.LookRotation(dir);


        // suaviza rotação
        transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
    }
}
