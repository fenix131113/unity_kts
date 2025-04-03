namespace ServiceLocator
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly SoundPlayerSetup _settings;
        
        public SoundPlayer(SoundPlayerSetup setup)
        {
            _settings = setup;
        }

        public void PlayOpenSound() => _settings.AudioSource.PlayOneShot(_settings.OpenPanelSound);

        public void PlayCloseSound() => _settings.AudioSource.PlayOneShot(_settings.ClosePanelSound);
    }
}