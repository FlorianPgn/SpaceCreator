﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour, IClickableObj {

    public Carryable.SeedType[] Seeds;
    public Carryable SeedPrefab;
    public Color SelectedColor;
    public Renderer DespenserSeedRenderer;
    public Animator Animator;

    private Material[] _materials;
    private Material _materialHover;
    private Color _originalColor;
    private int _currentIndex = 0;
    private Player _player;

	// Use this for initialization
	void Start () {
        _materialHover = GetComponent<Renderer>().materials[0];
        _materials = GetComponent<Renderer>().materials;
        _originalColor = _materialHover.color;
        _player = FindObjectOfType<Player>();
        UpdateColor();
    }

    public void NextSeed()
    {
        _currentIndex = (_currentIndex + 1) % Seeds.Length;
        Animator.SetTrigger("Play");
        UpdateColor();
    }

    private void UpdateColor()
    {
        _materials[3] = Seeds[_currentIndex].material;
        GetComponent<Renderer>().materials = _materials;
        DespenserSeedRenderer.material = Seeds[_currentIndex].material;
    }

    public void Enter()
    {
        _materials[0].color = SelectedColor;
        //GetComponent<Renderer>().materials = _materials;
    }

    public void Select()
    {
        SeedPrefab.Type = Seeds[_currentIndex];
        SeedPrefab.IsSeed = true;
        if (_player.Give(SeedPrefab))
        {
        }
    }

    public void Exit()
    {
        _materials[0].color = _originalColor;
    }
}
