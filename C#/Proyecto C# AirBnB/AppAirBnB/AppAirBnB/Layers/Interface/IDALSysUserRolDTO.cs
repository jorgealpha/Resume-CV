using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.AppAirBnB.Layers.Entities;
using UTN.Winform.AppAirBnB.Layers.Entities.DTO;

namespace UTN.Winform.AppAirBnB.Layers.Interface
{
    interface IDALSysUserRolDTO
    {
        SysUser SaveSysUser(SysUser pSysUser);
        SysUser GetSysUserById(double pId);
        List<SysUser> GetSysUserByFilter(string pDescripcion);
        List<SysUserRolDTO> GetAllSysUser();
        bool DeleteSysUser(string pId);
        SysUser UpdateSysUser(SysUser pSysUser);

    }
}
