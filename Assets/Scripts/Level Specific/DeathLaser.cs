using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLaser : MonoBehaviour
{
    public ParticleSystem myLaser;

    private float effectiveRange = 15.0f;
    private float effectiveAngle = 45.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = PlayerController.instance.transform.position;
        float distance = Vector3.Distance(transform.position, playerPos);

        if (distance < effectiveRange)
        {
            float angleOffset = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;

            float tiltOffset = Mathf.Atan2(transform.forward.y, transform.forward.x) * Mathf.Rad2Deg;
            float angDif = Mathf.Abs(angleOffset - tiltOffset);
            //Debug.Log(angDif);
            if(angDif < effectiveAngle)
            {
                if(myLaser)
                {
                    myLaser.Emit(1000);
                    myLaser.transform.rotation = Quaternion.AngleAxis(angleOffset, Vector3.forward);
                    PlayerPos ppScript = PlayerController.instance.GetComponent<PlayerPos>();
                    ppScript.ResetPlayer();
                }
            }
        }
    }

}
