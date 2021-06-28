using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private HingeJoint joint;

    private void Start() {
        joint.connectedBody = TargetsGenerationController.GetInstance().GetSceneFloorRigidBody();    
    }
}
