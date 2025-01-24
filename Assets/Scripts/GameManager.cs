using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Inventory playerInventory;
    public ObjectiveManager objectiveManager;
    public QuestInfo objectiveInfo;
    public Objective objective;

    private void Awake()
    {
        objectiveInfo = Resources.Load<QuestInfo>("ScriptableObjects/MakeOneHealthPotion");
        objective = new Objective(objectiveInfo.EventTrigger, objectiveInfo.StatusText, objectiveInfo.MaxValue);
    }

    private void Start()
    {
        objectiveManager.AddObjective(objective);
    }
}
