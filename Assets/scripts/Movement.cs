using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    Rigidbody rb;
    AudioSource audiosource;
    [SerializeField]float thrust = 800f;
    [SerializeField]float rotationthrust = 100f;
    [SerializeField] AudioClip rocketboost;
    [SerializeField] ParticleSystem mainboostParticles;
    [SerializeField] ParticleSystem rightboostParticles;
    [SerializeField] ParticleSystem leftboostParticles;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        Debug.Log("Reach the Green Area to Advance to next level");
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
          StartThrusting();

        }
        else
        {
          StopThrusting();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
          RotatingRight();

        }
        else if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
          RotatingLeft();
        }

        else
        {
          StopRotating();
        }
    }
     void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(rocketboost);
            mainboostParticles.Play();
        }
        if (!mainboostParticles.isPlaying)
        {
            mainboostParticles.Play();
        }
    }

    void StopThrusting()
    {
        audiosource.Stop();
        mainboostParticles.Stop();
    }
    void RotatingRight()
    {
        ApplyRotation(rotationthrust);
        if (!rightboostParticles.isPlaying)
        {
            rightboostParticles.Play();
        }
    }
     void RotatingLeft()
    {
        ApplyRotation(-rotationthrust);
        if (!leftboostParticles.isPlaying)
        {
            leftboostParticles.Play();
        }
    }
    void StopRotating()
    {
        rightboostParticles.Stop();
        leftboostParticles.Stop();
    }

    void ApplyRotation(float rotatethisframe)
    {
        rb.freezeRotation = true; //Frezzing the rotation
        transform.Rotate(Vector3.forward * rotatethisframe * Time.deltaTime);
        rb.freezeRotation = false; //Unfreeze the rotation 
    }
}
