using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.DAL;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;
using UTN.Winform.AppAirBnB.Layers.Interface;

namespace UTN.Winform.AppAirBnB.Layers.BLL
{
    class BLLSysUserRolDTO : IBLLSysUserRolDTO
    {

        public bool DeleteSysUser(string pId)
        {
            IDALSysUserRolDTO _IDALSysUserRolDTO = new DALSysUserRolDTO();
            return _IDALSysUserRolDTO.DeleteSysUser(pId);
        }

        public List<SysUserRolDTO> GetAllSysUser()
        {
            IDALSysUserRolDTO _IDALSysUserRolDTO = new DALSysUserRolDTO();
            return _IDALSysUserRolDTO.GetAllSysUser();

        }

        public List<SysUser> GetSysUserByFilter(string pDescripcion)
        {
            IDALSysUserRolDTO _IDALSysUserRolDTO = new DALSysUserRolDTO();
            return _IDALSysUserRolDTO.GetSysUserByFilter(pDescripcion);
        }

        public SysUser GetSysUserById(double pId)
        {
            IDALSysUserRolDTO _IDALSysUserRolDTO = new DALSysUserRolDTO();
            return _IDALSysUserRolDTO.GetSysUserById(pId);
        }

        public SysUser SaveSysUser(SysUser pSysUser)
        {
            IDALSysUserRolDTO _IDALSysUserRolDTO = new DALSysUserRolDTO();
            SysUser oSysUser = null;
            if (_IDALSysUserRolDTO.GetSysUserById(pSysUser.IDUser) == null)
                oSysUser = _IDALSysUserRolDTO.SaveSysUser(pSysUser);
            else
                oSysUser = _IDALSysUserRolDTO.UpdateSysUser(pSysUser);

            return oSysUser;
        }

    }
}
