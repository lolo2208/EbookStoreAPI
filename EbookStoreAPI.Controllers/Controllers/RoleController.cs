using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbookStoreAPI.Controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            try
            {
                var roles = await _roleService.GetAllRolesAsync();
                return Ok(roles);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{idRole}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoleById(int idRole)
        {
            try
            {
                var findedRole = await _roleService.FindById(idRole);
                return Ok(findedRole);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> CreateRole(RoleDTO role)
        {
            try
            {
                var addedRole = await _roleService.CreateRole(role);
                return Ok(addedRole);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("{idRole}")]
        public async Task<ActionResult<RoleDTO>> UpdateRole(RoleDTO role, int idRole)
        {
            try
            {
                if (idRole == role.IdRole)
                {
                    var updatedRole = await _roleService.UpdateRole(role);
                    return Ok(updatedRole);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{idRole}")]
        public async Task<ActionResult<RoleDTO>> DeleteRole(int idRole)
        {
            try
            {
                {
                    var findedRole = await _roleService.FindById(idRole);
                    if (findedRole != null)
                    {
                        var deletedRole = await _roleService.DeleteRole(findedRole.IdRole);
                        return Ok(deletedRole);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
