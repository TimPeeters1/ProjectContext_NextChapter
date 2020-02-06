using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] StuffArray;
    GameObject StuffsParent;
    [SerializeField] float XFrom;
    [SerializeField] float XTo;
    [SerializeField] float ZFrom;
    [SerializeField] float ZTo;

    // Start is called before the first frame update

    private void Awake()
    {
    }

    void Start()
    {
        
        StuffsParent = GameObject.Find("Stuffs");
        for (int i = 0; i < StuffArray.Length; i++)
        {
            Instantiate(StuffArray[i],new Vector3(Random.Range(XFrom, XTo),-5, Random.Range(ZFrom, ZTo)),new Quaternion(0,0,Random.Range(0,180),0),StuffsParent.transform);
        }
    }
}
