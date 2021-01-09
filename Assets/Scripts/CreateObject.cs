using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class CreateObject : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    private int count;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // タッチ時
        if (Input.GetMouseButton(0) && count % 4 == 0)
        {
            Debug.Log("タッチした");
            // レイと平面が交差した時
            if (raycastManager.Raycast(Input.GetTouch(0).position, hitResults, TrackableType.PlaneWithinPolygon))
            {
                int num = Random.Range(0, objectPrefabs.Length);
                Instantiate(objectPrefabs[num], hitResults[0].pose.position, Quaternion.identity);
            }
        }
        count++;
    }
}
