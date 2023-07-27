using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakController : MonoBehaviour
{
    AnimatorController animatorController;
    Rigidbody rb;

    [SerializeField]
    TreeCut tree; 
    [SerializeField]
    float breakSpeed = 1;

    private int breakDistance = 3;
    private bool isTreeBreaking = false;

    private void Awake()
    {
        animatorController = GetComponent<PlayerControllers>().GetAnimatorController();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, tree.transform.position) < breakDistance 
            && !tree.GetBrokenState())
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
            animatorController.PlayBreak();
            yield return new WaitForSeconds(breakSpeed);
            tree.Hit();
        }
    }

    public bool GetBreakingState()
    {
        return isTreeBreaking;
    }
}
