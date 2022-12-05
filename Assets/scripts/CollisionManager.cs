using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{   
    AudioSource audiosource;
    [SerializeField] float crashdelaytime = 0.5f;
    [SerializeField] float newleveldelaytime = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    bool isTransitioning = false;
    void Start() {
        {
            audiosource = GetComponent<AudioSource>();
        }
    }
    
    void Update()
    {
        DebugKeyActions();
    }
    void DebugKeyActions()
    {
      if(Input.GetKeyDown(KeyCode.L))
      {
        LoadNextLevel();
      }
      
    }

     void OnCollisionEnter(Collision other) {
        if(isTransitioning){return;}

        switch (other.gameObject.tag)
        {
            case "start":
                break;
            
            case "Finish":
                LoadNextLevelDelay();
                break;

            case "obstacle":
                Debug.Log("Avoid crashing into obstacles");
                CrashDelay();
                break;

            case "ground":
                Debug.Log("Avoid crashing into obstacles");
                CrashDelay();
                break;

            default:
                Debug.Log("Fly to the Green Finishing pad to advance!");
                break;
        }
    }

    void CrashDelay()
    {   
        isTransitioning = true;
        audiosource.Stop();
        audiosource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", crashdelaytime);
    }

    void LoadNextLevelDelay()
    {
        isTransitioning = true;
        audiosource.Stop();
        audiosource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", newleveldelaytime);
    }
    void ReloadLevel()
    { 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

}

