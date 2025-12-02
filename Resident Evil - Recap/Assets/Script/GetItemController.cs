using UnityEngine;

public class GetItemController : MonoBehaviour
{
    [SerializeField] private float pickUpDistance;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private Transform holdPoint;

    Transform currentItem;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(currentItem == null)
            TryPickUpObj();
        }
    }

    public void TryPickUpObj()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawLine(ray.origin, ray.direction * pickUpDistance, Color.green, 1f);
        if (Physics.Raycast(ray, out hit, pickUpDistance, itemLayer))
        {
            PickUp(hit.transform);
            
        }
           
    }

    void PickUp(Transform item)
    {
        currentItem = item;
        item.SetParent(currentItem);

        item.localPosition = Vector3.zero;
        item.localRotation = Quaternion.identity;

        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb) rb.isKinematic = true;

        Collider collider = item.GetComponent<Collider>();
        if(collider) collider.enabled = false;

        print("Item"); 
    }

}
