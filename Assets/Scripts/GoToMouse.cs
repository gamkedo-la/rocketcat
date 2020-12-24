using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPT = mouseRay.GetPoint(10f / Mathf.Cos(mouseRay.direction.x));
        worldPT.z = 0.0f;
        transform.position = worldPT;
       /* RaycastHit2D rcHit = Physics2D.Raycast(;
        if (rcHit.collider != null)
        {
            transform.position = rcHit.collider.transform.position;
            Debug.Log("words");
        }*/
    }
}
