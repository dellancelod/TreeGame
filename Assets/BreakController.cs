using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakController : MonoBehaviour
{
    PlayerMovement playerMovement;
    Rigidbody rb;

    [SerializeField] 
    float offsetDistance = 1f;
    [SerializeField] 
    float pickupZone = 1f;
    [SerializeField]
    TreeCut tree; 
    [SerializeField]
    float breakSpeed = 1;

    private int breakDistance = 3;
    private bool isTreeBreaking = false;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, tree.transform.position) < breakDistance)
        {
            if (!isTreeBreaking)
            {
                isTreeBreaking = true;
                StartCoroutine("BreakTree");
            }
        }
        else
        {
            isTreeBreaking = false;
            StopCoroutine("BreakTree");
        }
    }

    private IEnumerator BreakTree()
    {
        while (isTreeBreaking)
        {
            yield return new WaitForSeconds(breakSpeed);
            tree.Hit();
        }
    }
}
