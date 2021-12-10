using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    public AudioClip backgroundMusic;
    public AudioClip mainMenuMusic;

    [Header("Menus")]
    public AudioClip pauseMenu;
    public AudioClip gameOver;

    [Header("Rounds")]
    public AudioClip roundStarted;
    public AudioClip roundWon;

    [Header("Enemies")]
    public AudioClip enemyDies;
    public AudioClip enemyHit;
    public AudioClip playerHit;

    [Header("PlayerLines")]
    public AudioClip[] santaLines;

    [Header("Weapons")]
    public AudioClip coalGrenade;
    public AudioClip throwGrenade;
    public AudioClip dash;
    public AudioClip shootCarrots;

}
