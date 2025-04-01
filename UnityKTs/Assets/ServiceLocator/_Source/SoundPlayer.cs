using UnityEngine;

namespace ServiceLocator
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly AudioSource _source;
        private readonly AudioClip _openSound;
        private readonly AudioClip _closeSound;
        
        public SoundPlayer(AudioSource source, AudioClip openSound, AudioClip closeSound)
        {
            _source = source;
            _openSound = openSound;
            _closeSound = closeSound;
        }

        public void PlayOpenSound() => _source.PlayOneShot(_openSound);

        public void PlayCloseSound() => _source.PlayOneShot(_closeSound);
    }
}