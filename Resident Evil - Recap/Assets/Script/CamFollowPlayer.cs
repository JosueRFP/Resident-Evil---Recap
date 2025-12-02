using UnityEngine;


public class CamFollowPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;


    [Header("Settings")]
    [SerializeField] private LayerMask obstacleMask; // layers que bloqueiam a câmera
    [SerializeField] private float rotationSpeed = 5f; // velocidade da rotação
    [SerializeField] private float moveSpeed = 3f; // velocidade de movimento da câmera
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -6); // posição relativa ao player
    [SerializeField] private bool ignoreVertical = true; // ignora altura do player // ignora altura do player



    void LateUpdate()
    {




        {
            if (player == null) return;


            // verifica se o player está visível pela câmera
            Renderer rend = player.GetComponentInChildren<Renderer>();
            bool playerVisible = rend && GeometryUtility.TestPlanesAABB(
            GeometryUtility.CalculateFrustumPlanes(GetComponent<Camera>()),
            rend.bounds
            );


            // checa se há obstáculo entre câmera e player (raycast)
            bool blocked = false;
            Vector3 origin = transform.position;
            Vector3 dirToPlayer = (player.position - origin).normalized;
            float dist = Vector3.Distance(origin, player.position);


            if (Physics.Raycast(origin, dirToPlayer, out RaycastHit hit, dist, obstacleMask))
            {
                if (!hit.transform.IsChildOf(player))
                    blocked = true;
            }


            // se NÃO está visível OU está bloqueado por objeto, a câmera sobe e segue
            if (!playerVisible)
            {
                Vector3 targetPos = player.position + offset;
                transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
            }

            {
                if (player == null) return;


                // se o player estiver visível, a câmera NÃO se move
                // apenas gira para olhar


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
    }
}
    





   



