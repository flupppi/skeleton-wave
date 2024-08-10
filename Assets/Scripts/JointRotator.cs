using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointRotator : MonoBehaviour
{
    private Transform selectedJoint;
    private Vector3 initialMousePosition;
    private Quaternion initialRotation;
    [SerializeField] private GameObject hightlightPrefab;
    public GameObject highlight;



    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // On mouse click
        {
            SelectJoint();
        }

        if (selectedJoint != null)
        {
            RotateJoint();
        }

        if (Input.GetMouseButtonUp(0)) // On mouse release
        {
            if(highlight!=null) 
                Destroy(highlight);
            selectedJoint = null;
        }
    }

    void SelectJoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.transform.CompareTag("Joint"))
        {
            selectedJoint = hit.transform;
            initialMousePosition = Input.mousePosition;
            initialRotation = selectedJoint.rotation;
            highlight = Instantiate(hightlightPrefab, selectedJoint.transform);
        }
    }

    void RotateJoint()
    {
        Vector3 mouseDelta = Input.mousePosition - initialMousePosition;
        float angle = mouseDelta.x; // Modify this to control rotation sensitivity

        selectedJoint.rotation = initialRotation * Quaternion.Euler(0, 0, angle);
    }
}
