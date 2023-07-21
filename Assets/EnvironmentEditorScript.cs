using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public class EnvironmentEditorScript : MonoBehaviour
{
    [SerializeField] private bool applyLayers;

    [Space(12)] 
    [SerializeField] private SingleUnityLayer ShownLayer;
    [SerializeField] private SingleUnityLayer HiddenLayer;
    [SerializeField] private SingleUnityLayer ViewBlockLayer;
    [SerializeField] private Transform Shown;
    [SerializeField] private Transform Hidden;
    [SerializeField] private Transform ViewBlockers;
    
    
    
    private void OnValidate()
    {
        if (applyLayers)
        {
            applyLayers = false;
            UpdateLayers();
        }
    }

    private void RecursivelyApplyLayer(Transform transform, SingleUnityLayer layer)
    {
        var child_count = transform.childCount;
        for (int i = 0; i < child_count; i++)
        {
            transform.GetChild(i).gameObject.layer = layer.LayerIndex;
            RecursivelyApplyLayer(transform.GetChild(i), layer);
        }
    }
    
    private void UpdateLayers()
    {
        RecursivelyApplyLayer(Shown, ShownLayer);
        RecursivelyApplyLayer(Hidden, HiddenLayer);
        RecursivelyApplyLayer(ViewBlockers, ViewBlockLayer);

        Debug.Log("Layers applied!");
    }
}
#endif