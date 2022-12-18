using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMechanics : MonoBehaviour
{
    [Header("Finshing wating/rating")]
    [SerializeField] float minWating;
    [SerializeField] float maxWating;

    [SerializeField] float minRate;
    [SerializeField] float maxRate;

    int[] fishes = new int[10];


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

    void Start()
    {
        for (int i = 0; i < fishes.Length; i++)
            fishes[i] = 0;
    }

    public void FixedUpdate()
    {
        //tiempo de espera
        float wating = Random.Range(minWating, maxWating);
        //convert to int
        int watingtime = (int)wating;
        System.Threading.Thread.Sleep(watingtime);
        //What a fish!!
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
                float fishRate = Random.Range(minRate, maxRate);

                if (fishRate == 1000)
                    //aparece bobble
                    fishes[0]++;
                else if (fishRate <= 999 && fishRate >= 890)
                    //aparece  rape
                    fishes[1]++;
                else if (fishRate <= 889 && fishRate >= 780)
                    //aparece  pulpo
                    fishes[2]++;
                else if (fishRate <= 779 && fishRate >= 670)
                    //aparece  gamba
                    fishes[3]++;
                else if (fishRate <= 669 && fishRate >= 560)
                    //aparece  bacalo
                    fishes[4]++;
                else if (fishRate <= 559 && fishRate >= 450)
                    //aparece  calamar
                    fishes[5]++;
                else if (fishRate <= 449 && fishRate >= 340)
                    //aparece  pez de roca
                    fishes[6]++;
                else if (fishRate <= 339 && fishRate >= 230)
                    //aparece  trucha
                    fishes[7]++;
                else if (fishRate <= 229 && fishRate >= 120)
                    //aparece  atun
                    fishes[8]++;
                else if (fishRate <= 119 && fishRate >= 10)
                    //aparece  mejillon
                    fishes[9]++;
                else
                    //aparece  almeha
                    fishes[10]++;
            }
        }
        else
        {
            catchProgress -= progressBarDecay * Time.deltaTime;
            if (catchProgress <= 0)
                Debug.Log("para la pesca");
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
