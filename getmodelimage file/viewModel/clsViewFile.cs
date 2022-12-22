using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace getmodelimage_file.viewModel
{
    public class clsViewFile
    {
        [DataMember]
        public string FileName;

        [DataMember]
        public string FileUrl;

        [DataMember]
        public string FileSize;

        [DataMember]
        public bool isDeleted;

        [DataMember]
        public string FileSource;
    }
}