using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 ballPos;            
    public GameObject prefabObj;        
    private GameObject obj;             
    private Vector3 startPos;           
    private bool oneCall;               
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ballPos = GameObject.FindWithTag("Ball").transform.position;
        lineRenderer.SetPosition(0, ballPos);
        lineRenderer.startWidth = 0.1f;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && GameManager.instance.ballStart)
        {
            if (oneCall)
            {
                oneCall = false;
                startPos = Input.mousePosition;
                startPos.z = 10f;
                startPos = Camera.main.ScreenToWorldPoint(startPos);
                obj = Instantiate(prefabObj, startPos, Quaternion.identity);
                obj.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            Vector3 endPos = Input.mousePosition;
            endPos.z = 10f;
            endPos = Camera.main.ScreenToWorldPoint(endPos);
            lineRenderer.SetPosition(1, (startPos - endPos) * 1.2f + ballPos);
        }
        else
        {
            oneCall = true;
            Destroy(obj);
            lineRenderer.SetPosition(1, ballPos);
        }
    }
}
