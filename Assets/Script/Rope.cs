using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rope : MonoBehaviour
{
    public bool m_isCut = false;
    [SerializeField] UnityEvent m_ropeIsCut;
    private SpriteRenderer[] _ropesPart;
    private void Awake()
    {
        _ropesPart = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isCut)
        {
            foreach (SpriteRenderer rope in _ropesPart)
            {
                m_ropeIsCut.Invoke();
                Color tmp = rope.color;
                if (tmp.a > 0)
                {
                tmp.a -= Time.deltaTime;

                }
                rope.color = tmp;
            }
        }
    }
}
