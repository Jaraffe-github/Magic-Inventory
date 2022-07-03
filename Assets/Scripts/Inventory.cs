using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode] // ������ �׽�Ʈ��.
public class Inventory : MonoBehaviour
{
    public int columnMaxCount = 8;
    public Vector2 slotSize = new Vector2(50, 50);

    public RectTransform bag;
    public RectTransform slotsParent;
    private Slot[] itemSlots;

    private void OnValidate()
    {
        // ó�� ���õ� slot���� �ش� �κ��丮�� �ִ� ũ��.
        itemSlots = slotsParent.GetComponentsInChildren<Slot>(true);
    }

    private void Update()
    {
        // �ּ�, �ִ밪�� ���ؼ� bag�� ��ġ�� ũ�⸦ Ȱ��ȭ�� slot�� �����.
        Vector2 min = new Vector2(float.MaxValue, float.MaxValue);
        Vector2 max = new Vector2(-float.MaxValue, -float.MaxValue);

        for (int i = 0; i < itemSlots.Length; ++i)
        {
            float x = (i % columnMaxCount) * slotSize.x;
            float y = (i / columnMaxCount) * slotSize.y;

            // ���Ե��� ��ġ�Ѵ�.
            var rt = itemSlots[i].GetComponent<RectTransform>();
            rt.sizeDelta = slotSize;
            rt.anchoredPosition = new Vector2(x, -y);

            // Ȱ��ȭ �Ǿ� �ִ� ��츸, bag�� ��ġ, ũ�⿡ ������ �ش�.
            if (itemSlots[i].isActiveAndEnabled && itemSlots[i].state == Slot.State.Available)
            {
                min.x = Mathf.Min(min.x, x);
                min.y = Mathf.Min(min.y, y);

                max.x = Mathf.Max(max.x, x + slotSize.x);
                max.y = Mathf.Max(max.y, y + slotSize.y);
            }
        }

        // slot���� ���ִ� slots�� ��ġ�� �������� bag�� ��ġ, ũ�⸦ �����Ѵ�.
        // ����� bag, slots�� left top �϶��� ��ŷ��.
        bag.localPosition = slotsParent.localPosition;
        bag.anchoredPosition += new Vector2(min.x, -min.y);
        bag.sizeDelta = max - min;
    }

}
