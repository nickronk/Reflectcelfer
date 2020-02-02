using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelScript : MonoBehaviour
{ 
    public int level=1;
    public GameObject player,respA;
    Camera viewer;
    public FMODUnity.StudioEventEmitter emitter;
    FMOD.Studio.Bus Maestro;
    public float vol;

    void OnEnable()
    {
        //emitter.SetParameter("Level", level);
        emitter.SetParameter("Level", level);
        var target = GameObject.Find("EMTR");
        emitter.SetParameter("Level", level);

    }

    void Awake()
    {
        Maestro = FMODUnity.RuntimeManager.GetBus("bus:/");
        
    }

    void Start()
    {
        viewer = GetComponent<Camera>();

        transform.position = new Vector3(-73.25f, 21.71f, -10f);
        player.transform.position = new Vector3(-81.5f, 17.6f);
        respA.transform.position = new Vector3(-81.5f, 17.6f);
        viewer.orthographicSize = 5;
    }

    void Update()
    {
        Maestro.setVolume(vol);
    }



    public void newLevel()
    {
        level++;
        
        emitter.SetParameter("Level", level);
        if (level == 2)
        {
            transform.position = new Vector3(-117.11f, 15.9f, -10f);
            respA.transform.position = new Vector3(-124.1f, 13.4f);
            player.transform.position = respA.transform.position;
        }
        else if (level == 3)
        {
            viewer.orthographicSize = 10;

            transform.position = new Vector3(-75,-12.5f, -10f);
            respA.transform.position = new Vector3(-90,-17.5f);
            player.transform.position = respA.transform.position;
        }
        else if (level == 4)
        {
            transform.position = new Vector3();
            respA.transform.position = new Vector3();
            player.transform.position = respA.transform.position;
        }
        else if (level == 5)
        {
            transform.position = new Vector3();
            respA.transform.position = new Vector3();
            player.transform.position = respA.transform.position;
        }
        else if (level == 6)
        
        {
            transform.position = new Vector3();
            respA.transform.position = new Vector3();
            player.transform.position = respA.transform.position;
        }


    }
}
