using UnityEngine;
using System.Collections;

// $CTK this works only if the xform isn't touched by any other components
public class groundPoundAttack : MonoBehaviour {

	public float jumpSpeed=3.5f;
	public float jumpSize=10f;
    public float secondsPerJump = 5f;
    public float secondsBetweenJumps = 20f;
	private float startingY=0f;
    private float nextJumpTime = 0f;
	private ctkWobble wobbler;
	void Start () {
		startingY=transform.localPosition.y;
        nextJumpTime = Time.time + secondsBetweenJumps;
        wobbler = GetComponent<ctkWobble>();
	}
	
	void Update () {
		if (Time.time > nextJumpTime && Time.time < (nextJumpTime+secondsPerJump)) {
            if (wobbler.enabled) {
                Debug.Log("ground pounding!");
                startingY=transform.localPosition.y;
            }
            wobbler.enabled = false;
            float y=startingY+jumpSize*Mathf.Sin(jumpSpeed*Time.time-nextJumpTime); // $CTK
            transform.localPosition=new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }
        if (Time.time > (nextJumpTime+secondsPerJump)) {
            wobbler.enabled = true;
            Debug.Log("getting ready to ground pound!");
            nextJumpTime = Time.time + secondsBetweenJumps;
        }
	}
}
