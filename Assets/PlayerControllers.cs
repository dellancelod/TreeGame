using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    [SerializeField]
    private AnimatorController animatorController; 
    [SerializeField]
    private BreakController breakController;
    [SerializeField]
    private PlayerMovement playerMovement; 
    [SerializeField]
    private PickupItemController pickupItemController;

    public AnimatorController GetAnimatorController()
    {
        return animatorController;
    }

    public BreakController GetBreakController()
    {
        return breakController;
    }

    public PlayerMovement GetPlayerMovement()
    {
        return playerMovement;
    }

    public PickupItemController GetPickupItemController()
    {
        return pickupItemController;
    }
}
