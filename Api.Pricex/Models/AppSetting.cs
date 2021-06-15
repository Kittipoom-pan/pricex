namespace Api.Pricex.Models
{
    public class AppSetting
    {
        public EmailAccount EmailAccount { get; set; }
    }

    public class EmailAccount
    {
        public string Accounting { get; set; }
        public string Hotel { get; set; }
        public string Customer { get; set; }
    }
}
