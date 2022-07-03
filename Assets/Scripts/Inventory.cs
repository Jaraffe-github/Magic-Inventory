using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode] // 에디터 테스트용.
public class Inventory : MonoBehaviour
{
    public int columnMaxCount = 8;
    public Vector2 slotSize = new Vector2(50, 50);

    public RectTransform bag;
    public RectTransform slotsParent;
    private Slot[] itemSlots;

    private void OnValidate()
    {
        // 처음 셋팅된 slot들이 해당 인벤토리의 최대 크기.
        itemSlots = slotsParent.GetComponentsInChildren<Slot>(true);
    }

    private void Update()
    {
        // 최소, 최대값을 구해서 bag의 위치와 크기를 활성화되 slot에 맞춘다.
        Vector2 min = new Vector2(float.MaxValue, float.MaxValue);
        Vector2 max = new Vector2(-float.MaxValue, -float.MaxValue);

        for (int i = 0; i < itemSlots.Length; ++i)
        {
            float x = (i % columnMaxCount) * slotSize.x;
            float y = (i / columnMaxCount) * slotSize.y;

            // 슬롯들을 배치한다.
            var rt = itemSlots[i].GetComponent<RectTransform>();
            rt.sizeDelta = slotSize;
            rt.anchoredPosition = new Vector2(x, -y);

            // 활성화 되어 있는 경우만, bag의 위치, 크기에 영향을 준다.
            if (itemSlots[i].isActiveAndEnabled)
            {
                min.x = Mathf.Min(min.x, x);
                min.y = Mathf.Min(min.y, y);

                max.x = Mathf.Max(max.x, x + slotSize.x);
                max.y = Mathf.Max(max.y, y + slotSize.y);
            }
        }

        // slot들이 모여있는 slots의 위치를 기준으로 bag의 위치, 크기를 조절한다.
        // 현재는 bag, slots가 left top 일때만 워킹함.
        bag.localPosition = slotsParent.localPosition;
        bag.anchoredPosition += new Vector2(min.x, -min.y);
        bag.sizeDelta = max - min;
    }

}
