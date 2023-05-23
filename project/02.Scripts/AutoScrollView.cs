using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoScrollView : MonoBehaviour
{
    public ScrollRect scrollView;
    public float scrollSpeed = 1f;
    public float scrollDelay = 2f;

    private bool isScrolling = false;

    private void Start()
    {
        InvokeRepeating("ScrollDown", scrollDelay, scrollDelay);
    }

    private void ScrollDown()
    {
        if (!isScrolling)
        {
            isScrolling = true;
            StartCoroutine(ScrollCoroutine());
        }
    }

    private IEnumerator ScrollCoroutine()
    {
        float scrollY = 0f;
        while (scrollY < 1f)
        {
            scrollY -= Time.deltaTime * scrollSpeed;
            scrollView.verticalNormalizedPosition = scrollY;
            yield return null;
        }

        isScrolling = false;
    }
}
