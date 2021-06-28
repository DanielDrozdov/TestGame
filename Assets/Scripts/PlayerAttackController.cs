using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private ShellsPoolManager ShellsPoolManager;
    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    private void Start() {
        ShellsPoolManager = ShellsPoolManager.GetInstance();
    }

    public void OnClickButton_Shoot() {
        ShellsPoolManager.GetRandomShellFromPool().SetDirection(mainCamera.transform.position, mainCamera.transform.forward);
    }
}
