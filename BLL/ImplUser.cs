using System.Data;
using DAL;


namespace BLL
{
    public class ImplUser
    {
        DAOUser daoUser = new DAOUser();


        public string getServerIp()
        {
            return daoUser.getServerIp();
        }
        /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int ExistsName(string username)
        {
            return daoUser.ExistsName(username);
        }

        /// <summary>
        /// 查询用户名和密码是否存在
        /// </summary>
        /// <param name="U_Id"></param>
        /// <returns></returns>
        public DataSet ExistsPwd(string username, string pwd)
        {
            return daoUser.ExistsPwd(username, pwd);
        }

        public DataSet getUsersFromChatroom()
        {
            return daoUser.getUsersFromChatroom();
        }


        public bool logLogin(string username, string loginip)
        {
            return daoUser.logLogin(username, loginip);
        }


        public bool inChatroom(string username, string loginip)
        {
            return daoUser.inChatroom(username, loginip);
        }


        public bool outChatroom(string username)
        {
            return daoUser.outChatroom(username);
        }




    }
}
