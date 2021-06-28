using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellsPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] shellsPrefabs;

    private List<ShellStateController> shellsPool;
    private int shellsCount = 15;

    private static ShellsPoolManager Instance;

    private ShellsPoolManager() { }

    private void Awake() {
        Instance = this;
        FillPool();
    }

    public static ShellsPoolManager GetInstance() {
        return Instance;
    }

    public void ReturnObjToPool(ShellStateController shell) {
        shellsPool.Add(shell);
        shell.gameObject.SetActive(false);
    }

    public ShellStateController GetRandomShellFromPool() {
        int rndNumber = Random.Range(0, shellsPool.Count);
        ShellStateController shell = shellsPool[rndNumber];
        shellsPool.RemoveAt(rndNumber);
        shell.gameObject.SetActive(true);
        return shell;
    }

    private void FillPool() {
        int poolSize = shellsCount * shellsPrefabs.Length;
        shellsPool = new List<ShellStateController>(poolSize);
        for(int i = 0;i < shellsPrefabs.Length;i++) {
            for(int k = 0;k < shellsCount;k++) {
                GameObject shell = Instantiate(shellsPrefabs[i], transform);
                ShellStateController shellStateController = shell.GetComponent<ShellStateController>();
                shellsPool.Add(shellStateController);
                shell.SetActive(false);
            }
        }
    }
}
