using Unity.VisualScripting;
using UnityEngine;

public class TopPartsGenerator : MonoBehaviour
{
    [Header("Player Number")]
    [SerializeField, Range(1,2)]
    private int playerNumber = 1;

    [Header("Part Objects")]
    [SerializeField] private GameObject[] tops;
    [SerializeField] private GameObject[] mids;
    [SerializeField] private GameObject[] tips;

    private void Start()
    {
        ApplySelection();
    }

    private void ApplySelection()
    {
        int topIndex, midIndex, tipIndex;

        if (playerNumber == 1)
        {
            topIndex = SelectionData.P1Top;
            midIndex = SelectionData.P1Mid;
            tipIndex = SelectionData.P1Tip;
        }
        else
        {
            topIndex = SelectionData.P2Top;
            midIndex = SelectionData.P2Mid;
            tipIndex = SelectionData.P2Tip;
        }

        SetSelectedPart(tops, topIndex);
        SetSelectedPart(mids, midIndex);
        SetSelectedPart(tips, tipIndex);
    }

    private void SetSelectedPart(GameObject[] parts, int selectedIndex)
    {
          if (parts == null || parts.Length == 0)
        {
            Debug.LogError("No parts assigned on " + gameObject.name);
            return;
        }

        if (selectedIndex < 0 || selectedIndex >= parts.Length)
        {
            Debug.LogError("Invalid selection on " + gameObject.name);
            return;
        }

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i] != null)
                parts[i].SetActive(i == selectedIndex);
        }
    }

}
