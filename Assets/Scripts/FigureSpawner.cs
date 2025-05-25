using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class FigureSpawner : MonoBehaviour
{
    public List<GameObject> figurePool = new List<GameObject>();
    private List<GameObject> respawnBuffer = new List<GameObject>();

    [SerializeField] private int spawnDelayMs = 150;


    public async void SpawnFigure()
    {
        //���������� ����� ��� �������� �����
        respawnBuffer.Clear();
        respawnBuffer.AddRange(figurePool);

        //����������� ���� ����� � �����
        foreach (var item in respawnBuffer)
        {
            item.SetActive(false);
        }

        // �������� ��������
        int[] indices = new int[respawnBuffer.Count];
        for (int i = 0; i < respawnBuffer.Count; i++) indices[i] = i;

        // �������������
        for (int i = 0; i < respawnBuffer.Count; i++)
        {
            int temp = indices[i];
            int randomIndex = Random.Range(0, respawnBuffer.Count);
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }
        //��������� ����� �����
        foreach (var item in indices)
        {
            respawnBuffer[item].gameObject.SetActive(true);
            respawnBuffer[item].transform.localPosition = Vector3.zero;
            await Task.Delay(spawnDelayMs);
        }
    }


}
