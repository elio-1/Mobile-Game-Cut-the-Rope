using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    public int m_candyEaten = 0;
    [SerializeField] UnityEvent _hasEatACandyEvent;
    [SerializeField] float _candyDetectorRange = 3f;
    [SerializeField] LayerMask _candyDetectorMask;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
       Collider2D detectorCollider =  Physics2D.OverlapCircle(transform.position, _candyDetectorRange, _candyDetectorMask);
        if (detectorCollider != null)
        {
            _animator.SetBool("CandyDetected", true);
            Debug.Log("Blip bloup, Candy, in, range.");
        }
        else
        {
            _animator.SetBool("CandyDetected", false);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Candy"))
        {
            collision.gameObject.SetActive(false);
            m_candyEaten++;
            _animator.SetTrigger("Eating");
            _hasEatACandyEvent.Invoke();
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
        _animator.ResetTrigger("Eating");
           
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _candyDetectorRange);
    }
}
