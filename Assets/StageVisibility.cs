using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageVisibility : MonoBehaviour
{

    Color[] originalColor;
    public MeshRenderer[] meshRenderer;
    private Transform[] children;
    public bool isVisible = false;
    private List<Transform> childTransforms;

    /*private void AddDescendantsWithTag(Transform parent, string tag, List<Transform> list)
    {
        Debug.Log("1");
        foreach (Transform child in parent)
        {
            Debug.Log("2");
            if (child.gameObject.CompareTag (tag))
            {
                Debug.Log("3");
                list.Add(child.gameObject.transform);
            }
            Debug.Log("4");
            AddDescendantsWithTag(child, tag, list);
        }
    }*/
    void Start()
    {
        //AddDescendantsWithTag(transform, "StageObject", childTransforms);
        //originalColor = new Color[childTransforms.Count];
        //children = new Transform[childTransforms.Count];
        childTransforms = new List<Transform>();
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            childTransforms.Add(child.transform);
        }
        originalColor = new Color[childTransforms.Count];
        children = new Transform[childTransforms.Count];
            

        Debug.Log(childTransforms.Count);
        for (int i = 0; i < childTransforms.Count; i++)
        {
            //children[i] = transform.GetChild(i);
            if (childTransforms[i].GetComponent<MeshRenderer>() != null && childTransforms[i].GetComponent<MeshRenderer>().material.HasProperty("_Color"))
            {
                originalColor[i] = childTransforms[i].GetComponent<MeshRenderer>().material.color;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GameIsPaused)
        {
            return;
        }
        else
        {
            if (!isVisible)
            {
                for (int i = 0; i < childTransforms.Count; i++)
                {

                    if (childTransforms[i].GetComponent<MeshRenderer>() != null)
                    {
                        Debug.Log("Visible");
                        childTransforms[i].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.clear);
                    }
                }
            }
            else
            {
                for (int i = 0; i < childTransforms.Count; i++)
                {

                    if (childTransforms[i].GetComponent<MeshRenderer>() != null)
                    {
                        Debug.Log("Not Visible");
                        childTransforms[i].GetComponent<MeshRenderer>().material.color = originalColor[i];
                    }
                }
            }
        }
    }
}
