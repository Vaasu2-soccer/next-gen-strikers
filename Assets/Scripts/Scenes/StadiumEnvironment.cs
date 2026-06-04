using UnityEngine;
using System.Collections.Generic;

public class StadiumEnvironment : MonoBehaviour
{
    [SerializeField] private AudioClip crowdCheerSound;
    [SerializeField] private AudioClip crowdBooSound;
    [SerializeField] private AudioClip crowdAmbientSound;
    [SerializeField] private List<ParticleSystem> crowdReactionVFX;
    [SerializeField] private Light stadiumLighting;
    [SerializeField] private Material fieldMaterial;

    private AudioSource crowdAudioSource;
    private float crowdEnergyLevel = 0.5f; // 0-1 range

    private void Start()
    {
        crowdAudioSource = gameObject.AddComponent<AudioSource>();
        PlayCrowdAmbient();
    }

    public void PlayCrowdCheer()
    {
        crowdAudioSource.PlayOneShot(crowdCheerSound);
        TriggerCrowdVFX();
        crowdEnergyLevel = Mathf.Min(crowdEnergyLevel + 0.1f, 1f);
    }

    public void PlayCrowdBoo()
    {
        crowdAudioSource.PlayOneShot(crowdBooSound);
        crowdEnergyLevel = Mathf.Max(crowdEnergyLevel - 0.1f, 0f);
    }

    private void PlayCrowdAmbient()
    {
        crowdAudioSource.clip = crowdAmbientSound;
        crowdAudioSource.loop = true;
        crowdAudioSource.volume = crowdEnergyLevel;
        crowdAudioSource.Play();
    }

    private void TriggerCrowdVFX()
    {
        foreach (var vfx in crowdReactionVFX)
        {
            if (Random.value > 0.5f)
                vfx.Play();
        }
    }

    public void UpdateStadiumAtmosphere(float matchIntensity)
    {
        crowdEnergyLevel = Mathf.Clamp01(matchIntensity);
        crowdAudioSource.volume = crowdEnergyLevel;
    }
}
