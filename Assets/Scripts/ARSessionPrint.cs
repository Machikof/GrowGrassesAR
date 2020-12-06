using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionPrint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ARSession.state == ARSessionState.CheckingAvailability)
        {
            print("session>>>CheckingAvailability");
        }
        else if (ARSession.state == ARSessionState.Ready)
        {
            print("session>>>Ready");
        }
        else if (ARSession.state == ARSessionState.SessionInitializing)
        {
            print("session>>>SessionInitializing");
        }
        else if (ARSession.state == ARSessionState.SessionTracking)
        {
            print("session>>>SessionTracking");
        }
        else if (ARSession.state == ARSessionState.Installing)
        {
            print("session>>>Installing");
        }
        else if (ARSession.state == ARSessionState.NeedsInstall)
        {
            print("session>>>NeedsInstall");
        }
        else if (ARSession.state == ARSessionState.Unsupported)
        {
            print("session>>>Unsupported");
        }
        else if (ARSession.state == ARSessionState.None)
        {
            print("session>>>None");
        }
    }
}
