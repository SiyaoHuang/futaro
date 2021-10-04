using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class SampleScript : MonoBehaviour
{
    public RuntimeAnimatorController SampleAnimatorController;

    Vector3 defaultPosition = new Vector3(0, 0, 0);
    Quaternion defaultRotation = Quaternion.Euler(0, 180, 0);


    // Start is called before the first frame update
    async void Start()
    {
        string stream = Application.streamingAssetsPath;
        string humanPath = stream+"/AliciaMMD/Alicia_solid.pmx";
        //string humanPath = "AliciaMMD/Alicia_solid.pmx";
        //var hp = FileLoader.unpackFile(humanPath);
        //var source = new WWW(humanPath);
        //source.
        //Debug.Log(humanPath);
        Transform alicia = await PMXModelLoader.LoadPMXModel(humanPath, SampleAnimatorController);
        // Transform alicia = await PMXModelLoader.LoadPMXModel(humanPath, null);
        var left = GameObject.Find("右武器");
        alicia.position = defaultPosition;
        alicia.rotation = defaultRotation;
        string objPath =stream+ "/AliciaMMD/Alicia_blade.pmx";
        //string objPath = "AliciaMMD/Alicia_blade.pmx";
        //var op = FileLoader.unpackFile(objPath);

        Transform sword = await PMXModelLoader.LoadPMXModel(objPath, null, left.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
