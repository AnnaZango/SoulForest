using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : Action
{
    public SharedTransform foodTransform;
    public float eatDuration = 3;
    private Animator animator;


    private AnimalBehavior animalBehavior;
    private float timeStartedEating;
    private FoodElement foodElement;
    private GameObject targetGO;
    public AudioSource soundEatFood;

    public override void OnAwake()
    {
        animalBehavior = GetComponent<AnimalBehavior>();
        animator = GetComponent<Animator>();
    }

    public override void OnStart()
    {
        if(foodTransform != null)
        {
            targetGO = foodTransform.Value.gameObject;
            timeStartedEating = Time.time;
            foodElement = foodTransform.Value.transform.gameObject.GetComponent<FoodElement>();
                        
            animator.SetInteger("state", 1);            
        }
    }

    public override TaskStatus OnUpdate()
    {
        if(targetGO == null) //if another animal eats it before this one, failure
        {
            return TaskStatus.Failure;
        }

        if(Time.time >= timeStartedEating + eatDuration) //enough time has passed
        {
            animalBehavior.TrustLevel += foodElement.trustValueIncrease;
            foodElement.SelfDestroy();
            soundEatFood.Play();
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }
}
