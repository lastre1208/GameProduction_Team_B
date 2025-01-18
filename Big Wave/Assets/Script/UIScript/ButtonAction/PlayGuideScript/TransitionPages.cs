using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionPages : MonoBehaviour
{
    private List<Image> images;
    private int currentIndex;

    public void SetImages(List<Image> imagesList, int index)//画像のセット
    {
        images = imagesList;
        currentIndex = index;
    }

    public void ShowImage(int index)//画像の表示
    {
        if (images == null || index < 0 || index >= images.Count) return;
        images[index].gameObject.SetActive(true);
    }

    public void HideImage(int index)//画像を隠す
    {
        if (images == null || index < 0 || index >= images.Count) return;
        images[index].gameObject.SetActive(false);
    }

    public void SetNextImage()//リスト内の次の画像を見せる
    {
        if (images == null || images.Count == 0) return;

        images[currentIndex].gameObject.SetActive(false);
        currentIndex = (currentIndex + 1) % images.Count;
        images[currentIndex].gameObject.SetActive(true);
    }

    public void SetPreviousImage()//リスト内の前の画像を見せる
    {
        if (images == null || images.Count == 0) return;

        images[currentIndex].gameObject.SetActive(false);
        currentIndex = (currentIndex - 1 + images.Count) % images.Count;
        images[currentIndex].gameObject.SetActive(true);
    }
}
