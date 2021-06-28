using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsGenerationController : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private Rigidbody sceneFloorRB;
    [SerializeField] private Transform spawnYPoint;
    [SerializeField] private Transform player;
    [SerializeField] private int radius;
    [Range(1,10)]
    [SerializeField] private int targetsCount;

    private static TargetsGenerationController Instance;

    private TargetsGenerationController() { }

    private void Awake() {
        Instance = this;
        for(int i = 0; i < targetsCount;i++) {
            GameObject target = Instantiate(targets[Random.Range(0, targets.Length)], transform);
            int angle = 360 / targetsCount * (i + 1);
            Vector3 baseSpawnPoint = new Vector3(player.position.x, spawnYPoint.position.y, player.position.z);
            target.transform.position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius + baseSpawnPoint;
        }
    }

    public static TargetsGenerationController GetInstance() {
        return Instance;
    }

    public Rigidbody GetSceneFloorRigidBody() {
        return sceneFloorRB;
    }
}
