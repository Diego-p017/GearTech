namespace WebApiUser.Model.ViewModels
{
    public class ViewModelResponse<TObject>
    {
        public bool Error { get; set; }
        public string Response { get; set; }
        public TObject Object { get; set; }
        public object Token { get; set; }
        public string Status { get; set; }
    }
}
