using DAL;
using Model;


namespace BLL
{
    public class SimulationService
    {
        SimulationDao simulationDao = new SimulationDao();

        public bool add触诊人设置(触诊模拟人 _触诊模拟人, string username)
        {
            return simulationDao.add触诊人设置(_触诊模拟人, username);
        }


        public bool add听诊人设置(听诊模拟人 _听诊模拟人, string username)
        {
            return simulationDao.add听诊人设置(_听诊模拟人, username);
        }
    }
}
