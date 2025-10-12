using System.Runtime.InteropServices;

namespace WebClient.Client.App.Layouts
{
    public partial class MainLayout
    {
        #region UI Fields

        private bool _isLoaded = false;
        private bool _isClientSide = false;

        #endregion

        #region LC Methods

        protected override void OnInitialized()
        {
            CheckPlatform();
            ConfirmClientLoadAsync();
        }

        #endregion

        #region Private Methods

        private void CheckPlatform()
            => _isClientSide = RuntimeInformation.IsOSPlatform(OSPlatform.Create("Browser"));

        private void ConfirmClientLoadAsync()
        {
            if (_isClientSide)
                _isLoaded = true;
        }

        #endregion
    }
}