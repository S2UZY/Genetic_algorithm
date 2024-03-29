﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grade : MonoBehaviour
{
    public int checkPoint = 0;
    public float dist1;
    public float dist2;

    private void Update() {
        DistCal();
    }

    void DistCal( ) {
        Vector2 pos          = Utils.S.Vector3ToVector2(transform.position);
        Vector2 nowCheck = Utils.S.Vector3ToVector2(GradeMgr.S.positions[(int)Mathf.Repeat(checkPoint, GradeMgr.S.positions.Length)]);
        Vector2 nextCheck = Utils.S.Vector3ToVector2(GradeMgr.S.positions[(int)Mathf.Repeat(checkPoint + 1, GradeMgr.S.positions.Length)]);

        dist1 = (pos - nowCheck).sqrMagnitude;
        dist2 = (pos - nextCheck).sqrMagnitude;

        float dist3 = (nowCheck - nextCheck).sqrMagnitude;

        if (dist2 < dist1) {
            CheckPointUp();
        }
    }

    void CheckPointUp() {
        checkPoint++;
        GradeMgr.S.GradeChanged(checkPoint, this);
    }
}
