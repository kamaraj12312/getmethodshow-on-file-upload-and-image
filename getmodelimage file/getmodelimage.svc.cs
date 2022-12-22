using getmodelimage_file.viewModel;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "getmodelimage" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select getmodelimage.svc or getmodelimage.svc.cs at the Solution Explorer and start debugging.
    public class getmodelimage : Igetmodelimage
    {
        public List<clsViewFile> GetFiles()
        {
            List<clsViewFile> viewLst = new List<clsViewFile>();
            try
            {
                string DocumentFolder;
                string FilePath;
                //if (mode.ToLower().Trim() == "r")
                DocumentFolder =HostingEnvironment.ApplicationPhysicalPath +"fileView";
                //DocumentFolder = HostingEnvironment.ApplicationPhysicalPath+"D:\\wcf\\my project\\mydbcontext\\mydbcontext\fileView\\gif2.gif"+"".ToString();

                //else
                //{
                //    DocumentFolder = HostingEnvironment.ApplicationPhysicalPath + "D:\\wcf\\my project\\mydbcontext\\mydbcontext\fileView\\gif2.gif" /*+ Convert.ToString(invId) + "\\Others"*/;
                //}

                if (Directory.Exists(DocumentFolder))
                {
                    string[] fileEntries = Directory.GetFiles(DocumentFolder);

                    for (int i = 0; i < fileEntries.Length; i++)
                    {
                        clsViewFile vwFile = new clsViewFile();
                        FileInfo file = new FileInfo(fileEntries[i]);
                        FileStream reader = new FileStream(fileEntries[i], FileMode.Open, FileAccess.Read);

                        FilePath = fileEntries[i].Replace(HostingEnvironment.ApplicationPhysicalPath, "");
                        FilePath = FilePath.Replace("\\", "/");
                        byte[] buffer = new byte[reader.Length];
                        reader.Read(buffer, 0, (int)reader.Length);
                        reader.ReadByte();
                        var b = Convert.ToBase64String(buffer);
                        vwFile.FileSource = b;
                        vwFile.FileUrl = FilePath;

                        vwFile.FileName = Path.GetFileName(fileEntries[i]);
                        vwFile.FileSize = Convert.ToString(file.Length / 1024) + " KB";
                        viewLst.Add(vwFile);

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return viewLst;
        }
    }
}

