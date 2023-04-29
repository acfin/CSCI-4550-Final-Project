using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    AudioSource menuMusic;
    AudioSource gameplayMusic;
    [SerializeField] Transform cameraPos;
    void Start()
    {
        menuMusic = gameObject.GetComponent<AudioSource>();
        gameObject.transform.position = cameraPos.position;
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position != cameraPos.position)
        {
            gameObject.transform.position = cameraPos.position;
        }
    }
}
