using UnityEngine;
using UnityEngine.UI;

public class FigureTypeProperties : MonoBehaviour
{
    [SerializeField] private Image colorImage;
    [SerializeField] private Image spriteImage;

    //задает цыет фигуре
    public void SetColor(Color color)
    {
        colorImage.color = color;
    }

    //присваивает картинку фигуре
    public void SetAnimalImage(Sprite sprite)
    {
        spriteImage.sprite = sprite;
    }

    //возвращает цвет фигуры
    public Color GetColor()
    {
        return colorImage.color;
    }

    //возвращает картинку фигуры
    public Sprite GetImage()
    {
        return spriteImage.sprite;
    }

}
