using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_JS : MonoBehaviour
{
    public static GameManager_JS instance { get; private set; }

    public GameObject playerPrefab;
    public Transform spawn;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Instantiate(playerPrefab, spawn.position, spawn.rotation);
    }

    public void RespawnPlayer(GameObject player)
    {
        var controller = player.GetComponent<CharacterController>();
        if (controller != null)
            controller.enabled = false;

        // ���� ������ ����Ʈ�� �̵�
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;

        if (controller != null)
            controller.enabled = true;

        // ���� �ʱ�ȭ
        player.GetComponent<Status>()?.ResetStatus();
        Debug.Log("�÷��̾� ���2");
    }
}
