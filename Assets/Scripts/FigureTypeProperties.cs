using UnityEngine;
using UnityEngine.UI;

public class FigureTypeProperties : MonoBehaviour
{
    [SerializeField] private Image colorImage;
    [SerializeField] private Image spriteImage;

    //������ ���� ������
    public void SetColor(Color color)
    {
        colorImage.color = color;
    }

    //����������� �������� ������
    public void SetAnimalImage(Sprite sprite)
    {
        spriteImage.sprite = sprite;
    }

    //���������� ���� ������
    public Color GetColor()
    {
        return colorImage.color;
    }

    //���������� �������� ������
    public Sprite GetImage()
    {
        return spriteImage.sprite;
    }

}
