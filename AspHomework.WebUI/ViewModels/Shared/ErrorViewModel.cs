namespace AspHomework.WebUI.ViewModels.Shared
{
    public class ErrorViewModel: BaseViewModel
    {
        public ErrorViewModel()
        {
            this.PageTitle = "Error";
        }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}