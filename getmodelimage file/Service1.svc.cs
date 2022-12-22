using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Hosting;

namespace getmodelimage_file
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
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

        }


        public List<clsViewFile> GetFiles(string invId, string mode)
        {
            List<clsViewFile> viewLst = new List<clsViewFile>();
            try
            {
                string DocumentFolder;
                string FilePath;
                if (mode.ToLower().Trim() == "r")
                {
                    DocumentFolder = HostingEnvironment.ApplicationPhysicalPath + "Documents\\" + Convert.ToString(invId) + "\\Required";
                }
                else
                {
                    DocumentFolder = HostingEnvironment.ApplicationPhysicalPath + "Documents\\" + Convert.ToString(invId) + "\\Others";
                }

                if (Directory.Exists(DocumentFolder))
                {
                    string[] fileEntries = Directory.GetFiles(DocumentFolder);

                    for (int i = 0; i < fileEntries.Length; i++)
                    {
                        clsViewFile vwFile = new clsViewFile();
                        FileInfo file = new FileInfo(fileEntries[i]);

                        FilePath = fileEntries[i].Replace(HostingEnvironment.ApplicationPhysicalPath, "");
                        FilePath = FilePath.Replace("\\", "/");

                        vwFile.FileUrl = FilePath;
                        vwFile.FileName = Path.GetFileName(fileEntries[i]);
                        vwFile.FileSize = Convert.ToString(file.Length / 1024) + " KB";
                        viewLst.Add(vwFile);
                    }
                }
            }
            catch (Exception ex)
            {
                InsertErrorLog("Invoice.svc", "Get Uploaded File Details for View  ", ex.Message);
            }
            return viewLst;
        }

    }


     <system.serviceModel> //IMAGE UPLOAD ON CONFIG FILE UING IS FILE UPLOAD SERVICE MODEL
	   <bindings>  
      <basicHttpBinding>  
        <binding name = "ExampleBinding" transferMode="Streamed"/>  
      </basicHttpBinding>  
    </bindings>  












}
