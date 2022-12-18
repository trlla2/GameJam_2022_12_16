using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMechanics : MonoBehaviour
{
    //fishing move
    [Header("Fishing area")]
    [SerializeField] Transform topbound;
    [SerializeField] Transform bottombound;


    [Header("Fish setings")]
    [SerializeField] Transform siluetapez;
    [SerializeField] float smoothMotion = 3f; //k se muve suabecito
    [SerializeField] float fishTimeRandomizer = 3f; //how often the fish move
    float fishPosition;
    float fishSpeed;
    float fishTimer;
    float fishTargetPosition;


    [Header("Hook setting")]
    [SerializeField] Transform hook;
    [SerializeField] float hookSize = .18f;
    [SerializeField] float hookSpeed = .1f;
    [SerializeField] float hookGravity;
    float hookPosition;
    float hookPullVelocity;


    [Header("Progres bar setings")]
    [SerializeField] Transform progressBarContiner;
    [SerializeField] float hookPower;
    [SerializeField] float progressBarDecay;
    float catchProgress;


    private void FixedUpdate()
    {
        MoveFish();
        MoveHook();
        CheckProgress();
    }
    private void CheckProgress()
    {
        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;  
        
        if(min < fishPosition && fishPosition < max)
        {
            catchProgress += hookPower * Time.deltaTime;
            if(catchProgress >= 1)
            {
                Debug.Log("has pescado un pescado");
            }
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
        }
        catchProgress = Mathf.Clamp(catchProgress, 0, 1);

        Vector3 progressBarScale = progressBarContiner.localScale;
        progressBarScale.y = catchProgress;
        progressBarContiner.localScale = progressBarScale; //updatea la posicion de y del objecto
    }
    private void MoveHook()
    {
        if (Input.GetMouseButton(0))
        {
            //augmentar la velocidad de estirar?¿
            hookPullVelocity += hookSpeed * Time.deltaTime;//levantar el gancho
        }
        else
        {
            hookPullVelocity += hookGravity * Time.deltaTime;
        }

        //solucion bug velocidad negativa
        if(hookPosition -hookSize/2 <= 0 && hookPullVelocity < 0)
        {
            hookPullVelocity = 0;
        }
        
        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        {
            hookPullVelocity = 0;
        }

        hookPosition += hookPullVelocity;

        hookPosition = Mathf.Clamp(hookPosition, hookSize/2, 1 - hookSize / 2); //Manten el gancho entre los bounds
        
        hook.position = Vector3.Lerp(bottombound.position, topbound.position, hookPosition);

    }

    private void MoveFish()
    {
        //bassado en el tiempo, pilla una posision ramndom
        //y mover el pez suabecito a ese sitio
        fishTimer -= Time.deltaTime;
        if(fishTimer < 0)
        {
            //pillar otra posicion
            //y resetear timer
            fishTimer = Random.value * fishTimeRandomizer;
            fishTargetPosition = Random.value;
        }
        fishPosition = Mathf.SmoothDamp(fishPosition, fishTargetPosition, ref fishSpeed, smoothMotion);
        siluetapez.position = Vector3.Lerp(bottombound.position, topbound.position, fishPosition);



    }

}
