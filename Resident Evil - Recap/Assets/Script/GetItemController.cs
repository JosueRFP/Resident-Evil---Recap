using UnityEngine;
using UnityEngine.Events;

public class GetItemController : MonoBehaviour
{
    [Header("Hold Points (Front, Back, Left, Right)")]
    [SerializeField] private Transform[] holdPoints;

    private int currentHoldIndex = 0;

    private GameObject carriedTrash;
    private GameObject itemDetected;
    private GameObject depositDetected;

    [SerializeField] UnityEvent OnGetTrashSound;

    public bool IsCarryingTrash { get; private set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemDetected != null && carriedTrash == null)
            {
                PickUpItem(itemDetected);
                OnGetTrashSound.Invoke();
            }
            else if (depositDetected != null && carriedTrash != null)
            {
                DeliverItem();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && carriedTrash != null)
            CycleHoldPoint();

        if (Input.GetKeyDown(KeyCode.Q) && carriedTrash != null)
            DropItem();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Item"))
            itemDetected = hit.gameObject;

        if (hit.gameObject.CompareTag("Deposit"))
            depositDetected = hit.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == itemDetected)
            itemDetected = null;

        if (other.gameObject == depositDetected)
            depositDetected = null;
    }

    void PickUpItem(GameObject trash)
    {
        carriedTrash = trash;

        carriedTrash.transform.SetParent(holdPoints[currentHoldIndex]);
        carriedTrash.transform.localPosition = Vector3.zero;
        carriedTrash.transform.localRotation = Quaternion.identity;

        Rigidbody rb = carriedTrash.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        Collider col = carriedTrash.GetComponent<Collider>();
        if (col != null) col.isTrigger = true;

        IsCarryingTrash = true;
    }

    void DropItem()
    {
        carriedTrash.transform.SetParent(null);

        Rigidbody rb = carriedTrash.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = false;

        Collider col = carriedTrash.GetComponent<Collider>();
        if (col != null) col.isTrigger = false;

        carriedTrash = null;
        IsCarryingTrash = false;
    }

    void DeliverItem()
    {
        Destroy(carriedTrash);
        carriedTrash = null;
        IsCarryingTrash = false;

        print("Passou!");
    }

    void CycleHoldPoint()
    {
        currentHoldIndex = (currentHoldIndex + 1) % holdPoints.Length;
        carriedTrash.transform.SetParent(holdPoints[currentHoldIndex]);
        carriedTrash.transform.localPosition = Vector3.zero;
        carriedTrash.transform.localRotation = Quaternion.identity;
    }
}
