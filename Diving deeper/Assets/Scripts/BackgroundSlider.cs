using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSlider : MonoBehaviour
{
    public GameObject background;
    public GameObject backgroundPrefab;
    private Transform backgroundTransform;
    private Transform instantiatedBGTransform;
    private Vector3 startingPos;
    private BoxCollider2D bc;
    private GameObject instantiatedBG;
    // Start is called before the first frame update
    void Awake()
    {
        InitiateBackGround();
    }

    // Update is called once per frame
    void Update()
    {
        //backgroundTransform = instantiatedBG.GetComponent<Transform>();
        if(instantiatedBGTransform.position.y >= startingPos.y)
        {
            Destroy(background);
            InitiateBackGround();
        }
    }

    void InitiateBackGround()
    {
        background = FindObjectOfType<BackgroundMove>().gameObject;
        backgroundTransform = background.GetComponent<Transform>();
        startingPos = backgroundTransform.position;
        bc = background.GetComponent<BoxCollider2D>();
        float y = bc.size.y;
        Vector3 pos = new Vector3(backgroundTransform.position.x, backgroundTransform.position.y - y, backgroundTransform.position.z);
        instantiatedBG = Instantiate(backgroundPrefab, pos, Quaternion.identity);
        instantiatedBGTransform = instantiatedBG.transform;
    }

    public GameObject getBackground()
    {
        return instantiatedBG;
    }
}
