using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, _layerMask);

        transform.position = mousePos;

        if (hit.collider != null)
        {
            GameObject collision =  hit.collider.gameObject;
            collision.GetComponentInParent<Rope>().m_isCut = true;
            collision.SetActive(false);
        }
    }
}
