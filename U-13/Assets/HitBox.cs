using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public bool HitPlayer = false;
    public LayerMask PlayerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Hit Player!" + collision.gameObject.layer);
            HitPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HitPlayer = false;
    }
}
