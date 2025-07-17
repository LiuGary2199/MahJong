using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using Mkey;
public class ScamExplain : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("gameBoard")]    public GameBoard CrabDeity;
    static public ScamExplain Instance;
    private Tween LoveDose;
    private float Lethargy= 15;
[UnityEngine.Serialization.FormerlySerializedAs("m_isCommbo")]    public bool m_OfGossip;
[UnityEngine.Serialization.FormerlySerializedAs("m_ComboCount")]    public int m_PeartCrack= 0;
[UnityEngine.Serialization.FormerlySerializedAs("eventSystem")]    public EventSystem PatchWorthy;

    public void EnglishTruck()
    {
        PatchWorthy.enabled = false;
    }
    public void LotusTruck()
    {
        PatchWorthy.enabled = true;
    }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SeepageGrassy.MayMsgPrestige(CStatus.So_AnPeartCosmic, OnComboUpdate);
    }

    public void OnstageScam()
    {
        CrabDeity.RestartLevel();
        m_PeartCrack = 0;
    }
    public void HandScam()
    {
        CrabDeity.CompleteAndLoadNextLevel();
        m_PeartCrack = 0;
    }
    private void OnComboUpdate(KeyValuesUpdate kv)
    {
        m_PeartCrack += 1;
        LoveDose?.Kill();
        LoveDose = DOVirtual.DelayedCall(Lethargy, () =>
        {
            m_PeartCrack = 0;
            m_OfGossip = false;
        });
        if (m_PeartCrack>=3)
        {
            m_OfGossip = true;
            FastFive sendData = new FastFive();
            sendData.PeartCrack = m_PeartCrack;
            sendData.Heater3Nut = (Vector3) kv.Borrow;
            KeyValuesUpdate keyfly = new KeyValuesUpdate(CStatus.So_AnPeartHale, sendData);
            SeepageGrassy.FastSeepage(CStatus.So_AnPeartHale, keyfly);
        }
       /* int goldMul = PinBeadEka.instance.GameData.combogold;
        if (m_ComboCount > 0 && m_ComboCount % goldMul == 0 && m_ComboCount != goldMul)
        {
            gameBoard.ChangeGold();
        }

        if (m_ComboCount >= goldMul)
        {

        }*/
    }
}
