using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float minWating;
    public float maxWating;

    public float minRate;
    public float maxRate;

    int almehea;
    int mejillon;
    int atun;
    int trucha;
    int pezDeRoca;
    int calamar;
    int bacalao;
    int rape;
    int pulpo;
    int gamba;
    bool bobblecat;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //tiempo de espera
            float wating = Random.Range(minWating, maxWating);
            //convert to int
            int watingtime = (int)wating;
            System.Threading.Thread.Sleep(watingtime);
            //What a fish!!
            float fishRate = Random.Range(minRate, maxRate);

            if (fishRate == 1000)
                //aparece bobble
                if (!bobblecat )
                bobblecat = true;
            else if (fishRate <= 999 && fishRate >= 890)
                //aparece  rape
                rape ++;
            else if (fishRate <= 889 && fishRate >= 780)
                //aparece  pulpo
                pulpo ++;
            else if (fishRate <= 779 && fishRate >= 670)
                //aparece  gamba
                gamba ++;
            else if (fishRate <= 669 && fishRate >= 560)
                //aparece  bacalo
                bacalao ++;
            else if (fishRate <= 559 && fishRate >= 450)
                //aparece  calamar
                calamar++;
            else if (fishRate <= 449 && fishRate >= 340)
                //aparece  pez de roca
                pezDeRoca++;
            else if (fishRate <= 339 && fishRate >= 230)
                //aparece  trucha
                trucha++;
            else if (fishRate <= 229 && fishRate >= 120)
                //aparece  atun
                atun++;
            else if (fishRate <= 119 && fishRate >= 10)
                //aparece  mejillon
                mejillon++;
            else 
                //aparece  almeha
                almehea++;
        }
    }
}
