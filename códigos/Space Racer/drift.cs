using UnityEngine;

public class drift : MonoBehaviour
{
    public ParticleSystem derrapagemE;
    public ParticleSystem derrapagemD;
    public ParticleSystem chuvaestelar;
    public float driftParticleStart;
    public float carroParticleStart;

    public Rigidbody rb;
    float driftVal;
    float carroVal;

    void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            driftVal += Time.fixedDeltaTime;
            if (driftVal > driftParticleStart){
                derrapagemE.Play();
                derrapagemD.Play();
            }
        } else 
        {
            driftVal = 0;
            derrapagemD.Stop();
            derrapagemE.Stop();
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            carroVal += Time.fixedDeltaTime;
            if (carroVal > carroParticleStart)
            {
                chuvaestelar.Play();
                
            }
        }
        else
        {
            carroVal = 0;
            chuvaestelar.Stop();
        }
    }

}
