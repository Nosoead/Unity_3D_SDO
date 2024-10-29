using UnityEngine;

public class EquipTool : ItemEquip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;
    public float useStamina;

    [Header("Resource Gathering")]
    public bool doesGatherResources;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;
    private Camera camera;

    void Start()
    {
        animator = GetComponent<Animator>();
        camera = Camera.main;
    }

    // Update is called once per frame
    public override void OnAttackInput()
    {
        if (!attacking)
        {
            if (CharacterManager.Instance.Player.conditionController.staminaHandler.CurrentValue >= useStamina)
            {
                CharacterManager.Instance.Player.conditionController.staminaHandler.ApplyExternalEffect(useStamina);
                attacking = true;
                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    private void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, attackDistance))
        //{
        //    if (doesGatherResources && hit.collider.TryGetComponent(out Resource resource))
        //    {
        //        resource.Gather(hit.point, hit.normal);
        //    }
        //    if (doesDealDamage && hit.collider.TryGetComponent(out NPC npc))
        //    {
        //        npc.TakePhysicalDamage(damage);
        //    }
        //}
    }
}