using UnityEngine;

public class ScrollViewFix : MonoBehaviour
{
    private RectTransform _transform;
    private const float _scrollPositionX = -4.5f;

    void Start()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        transform.position = new Vector2(_scrollPositionX, transform.position.y);
    }


}
