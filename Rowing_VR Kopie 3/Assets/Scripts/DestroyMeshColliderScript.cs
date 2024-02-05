using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeshColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisableMeshColliders(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisableMeshColliders(Transform parent)
    {
        foreach (Transform child in parent)
        {
            MeshCollider meshCollider = child.GetComponent<MeshCollider>();
            if (meshCollider != null)
            {
                meshCollider.enabled = false;
            }
            DisableMeshColliders(child);
        }
    }
}

