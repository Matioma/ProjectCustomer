using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingNumber : MonoBehaviour
{
    [SerializeField]
    public Vector3 Direction {get; set; }



    [SerializeField]
    float velocity = 100.0f;
    [SerializeField]
    float lifeTime =5;
    public float Velocity { get { return velocity; } }


    float Timer;



    void Start()
    {
        //Invoke("DestroyIndicator", lifeTime);
        Timer = lifeTime;
    }





    private void Update()
    {
        transform.localPosition += transform.localPosition.normalized * velocity * GlobalTimer.Instance.DeltaTime;

        lifeTime -= GlobalTimer.Instance.DeltaTime;
        if (lifeTime <= 0) {
            DestroyIndicator();
        }
    }

    void DestroyIndicator() {
        Destroy(this.gameObject);
    }
}
