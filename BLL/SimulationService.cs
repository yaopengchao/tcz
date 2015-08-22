using DAL;
using Model;


namespace BLL
{
    public class SimulationService
    {
        SimulationDao simulationDao = new SimulationDao();

        public bool add触诊人设置(触诊模拟人 _触诊模拟人, string user_name)
        {
            return simulationDao.add触诊人设置(_触诊模拟人, user_name);
        }

        public 触诊模拟人 get触诊人设置(string user_name)
        {
            return simulationDao.get触诊人设置(user_name);
        }


        public bool add听诊人设置(听诊模拟人 _听诊模拟人, string user_name)
        {
            return simulationDao.add听诊人设置(_听诊模拟人, user_name);
        }

        public 听诊模拟人 get听诊人设置(string user_name)
        {
            return simulationDao.get听诊人设置(user_name);
        }
    }
}
