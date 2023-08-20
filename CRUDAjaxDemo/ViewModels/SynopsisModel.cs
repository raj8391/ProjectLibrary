using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CRUDAjaxDemo.ViewModels
{
    public class SynopsisModel
    {
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public int? CollegeId { get; set; }
        public string SynaopsisHeader { get; set; }
        public string SynaopsisDescription { get; set; }

        public List<FilesViewModel> Files { get; set; }
    }

    public class FilesListModel
    {
        public int LoginUserId { get; set; }
       
        public List<SynopsisModel> SynopsysList { get; set; }
    }
}
