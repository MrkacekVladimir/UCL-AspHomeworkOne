namespace AspHomework.WebUI.ViewModels.Shared
{
    public abstract class BaseViewModel
    {
        public string PageTitle { get; set; } = "Unknown";
        public bool ShowSuccess { get; set; } = false;
    }
}
