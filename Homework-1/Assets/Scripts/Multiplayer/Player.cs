using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Player : NetworkBehaviour
{
    public NetworkVariableString nickname = new NetworkVariableString(new NetworkVariableSettings 
                                            {WritePermission = NetworkVariablePermission.OwnerOnly, 
                                             ReadPermission = NetworkVariablePermission.Everyone});
    public NetworkVariableColor tint = new NetworkVariableColor(new NetworkVariableSettings 
                                            {WritePermission = NetworkVariablePermission.OwnerOnly, 
                                             ReadPermission = NetworkVariablePermission.Everyone});

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform textPoint;
    [SerializeField] private TMP_Text nameText;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        nickname.OnValueChanged += UpdateNickname;
        tint.OnValueChanged += UpdateColor;
    }

    private void OnDisable()
    {
        nickname.OnValueChanged -= UpdateNickname;
        tint.OnValueChanged -= UpdateColor;
    }

    private void Start()
    {
        if(IsHost)
        {
            tint.Value = GameObject.FindGameObjectWithTag("MultiplayerManager").GetComponent<MultiplayerManager>().GetUniqueColor();
        }
        if(IsOwner)
        {
            nickname.Value = PlayerPrefs.GetString("name");
            Camera.main.GetComponent<Follow>().FollowObject(gameObject);
        }
        else
        {
            GetComponent<CharacterMovement>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());
            foreach(Collider2D collider in GetComponents<Collider2D>())
            {
                collider.enabled = false;
            }
        }
    }

    private void Update()
    {
        ChangeNamePosition();
    }

    private void ChangeNamePosition()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(textPoint.position);
        nameText.transform.position = pos;
    }

    private void UpdateColor(Color prev, Color curr)
    {
        spriteRenderer.color = curr;
        nameText.color = curr;
    }

    private void UpdateNickname(string prev, string curr)
    {
        nameText.text = curr;
    }

}
