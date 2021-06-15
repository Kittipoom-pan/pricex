using System;

namespace Api.Pricex.ViewModels
{
    public class ResponseViewModel
    {
        public Object data { get; set; }
        public ResponseViewModel(Object data)
        {
            this.data = data;
        }
    }
}
