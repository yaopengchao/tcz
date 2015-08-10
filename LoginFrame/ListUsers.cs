using System.Collections;
using System.DirectoryServices;
using System.Net;

namespace LoginFrame
{
    class ListUsers
    {
        public static ArrayList GetComputerList()
        {
            ArrayList list = new ArrayList();
            DirectoryEntry root = new DirectoryEntry("WinNT:");
            DirectoryEntries domains = root.Children;
            domains.SchemaFilter.Add("domain");
            foreach (DirectoryEntry domain in domains)
            {
                DirectoryEntries computers = domain.Children;
                computers.SchemaFilter.Add("computer");
                foreach (DirectoryEntry computer in computers)
                {
                    string[] arr = new string[3];
                    IPHostEntry iphe = null;
                    try
                    {
                        iphe = Dns.GetHostByName(computer.Name);
                    }
                    catch
                    {
                        continue;
                    }
                    arr[0] = domain.Name;
                    arr[1] = computer.Name;
                    if (iphe != null && iphe.AddressList.Length > 0)
                    {
                        arr[2] += iphe.AddressList[0].ToString();
                    }
                    else
                        arr[2] = "";
                    list.Add(arr);
                }
            }
            return list;
        }
    }
}
