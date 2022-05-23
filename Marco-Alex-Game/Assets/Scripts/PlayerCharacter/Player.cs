using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static Player instance;
    private float mp = 100;
    private float stamina = 100;
    private Animator animator;

    public static Player Instance { get => instance; set => instance = value; }
    public float Stamina { get => stamina; set => stamina = value; }
    public Animator Animator { get => animator; set => animator = value; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
