using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCrear : MonoBehaviour
{
    public GameObject prefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InstantiateOnPosition(Input.mousePosition);
        }
    }
   void InstantiateOnPosition (Vector3 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit info))
        {
            Debug.Log("Choca en " + info.collider.name);
            Vector3 instantiationPoint = info.point;
            GameObject newGo = Instantiate(prefab, instantiationPoint, Quaternion.identity);

            Rigidbody rb = newGo.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = newGo.AddComponent<Rigidbody>();

            }
            rb.mass = 10f;
        }

    }
}
