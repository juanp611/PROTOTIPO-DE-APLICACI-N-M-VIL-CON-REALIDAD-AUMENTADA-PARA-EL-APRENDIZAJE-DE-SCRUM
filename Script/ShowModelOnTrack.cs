using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShowModelOnTrack : MonoBehaviour
{
    private ObserverBehaviour mObserverBehaviour;
    public GameObject model3D;

    private void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour != null)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        
        model3D.SetActive(false); 
    }

    private void OnDestroy()
    {
        if (mObserverBehaviour != null)
        {
            mObserverBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            model3D.SetActive(true); 
        }
        else
        {
            model3D.SetActive(false); 
        }
    }
}

