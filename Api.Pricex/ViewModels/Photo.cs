using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Pricex.ViewModels
{
    public class PhotoViewModel
    {
        public string FileName { get; set; }
        public int? ReferenceId { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public List<PhotoFileName> photoFileNames { get; set; }
        //public string Type { get; set; }

        //public PhotoViewModels()
        //{
        //    Path = Path + Filename;
        //}
    }
    public class PhotoFileName
    {
        public string FileNames { get; set; }
        public string Paths { get; set; }
        public string ContentType { get; set; }
    }
}
