using UnityEngine;
public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_effectPrefab;

    public enum EffectType
    {
        SubEmitterDeath
    }

    public void OnPlayEffect(Vector3 position, EffectType effectType)
    {
        GameObject effect = Instantiate(m_effectPrefab[(int)effectType], position, Quaternion.identity);

        EffectPlayer effectPlayer = effect.GetComponent<EffectPlayer>();

        effectPlayer.OnPlay();
    }
}
