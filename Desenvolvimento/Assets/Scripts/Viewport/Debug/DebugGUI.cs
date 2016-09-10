using ProjectFeudo.Domain.Creatures;
using ProjectFeudo.Managers;
using UnityEngine;

public class DebugGUI : MonoBehaviour {

    public GameObject playerObject;
    public PlayerManager playerManager;
    public AttackManager attackManager;
    public Human playerAvatar;
    public AnimationManager animationManager;
    public string animationCategory;
    public InventoryManager inventoryManager;
    public LootPanelManager lootPanelManager;


    void Start() {
        playerManager = playerObject.GetComponent<PlayerManager>();
        attackManager = playerObject.GetComponent<AttackManager>();
        animationManager = playerObject.GetComponent<AnimationManager>();
        inventoryManager = playerObject.GetComponent<InventoryManager>();
        playerAvatar = playerManager.GetAvatar();
    }

    void OnGUI() {
        GUI.Box(new Rect(0, 0, 135, Screen.height), "Top-left");

        GUI.Label(new Rect(5, 25, 90, 30), "Strength:" + playerAvatar.Strength);
        GUI.Label(new Rect(5, 40, 90, 30), "Dexterity:" + playerAvatar.Dexterity);
        GUI.Label(new Rect(5, 55, 90, 30), "Intelligence:" + playerAvatar.Intelligence);

        GUI.Label(new Rect(5, 70, 90, 30), "Stamina:" + playerAvatar.Stamina);
        GUI.Label(new Rect(5, 85, 135, 30), "Is Attacking?:" + attackManager.GetIsAttacking());
        GUI.Label(new Rect(5, 100, 135, 30), "Attack Delay:" + playerAvatar.GetAttackDelay());
        GUI.Label(new Rect(5, 115, 135, 30), "Attack Sequence:" + attackManager.GetAttackSequence());

        if (GUI.Button(new Rect((Screen.width / 2) + 150, (Screen.height / 2 - 50), 120, 50), "Open Loot"))
            lootPanelManager.InstantiateLootItems("loot00000001");
    }
}
