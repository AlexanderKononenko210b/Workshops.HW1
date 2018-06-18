using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Rocket.BL.Common.Services;
using Rocket.BL.Services.UserServices;
using Swashbuckle.Swagger.Annotations;

namespace Rocket.Web.Controllers.UserRole
{
    [RoutePrefix("user")]
    public class RoleManagerController : ApiController
    {
        private readonly UserRoleManager _roleManager;

        public RoleManagerController(UserRoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("{userId:length(36)}/role/add")]//{roleId:string:min(1)}
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NotFound, "Data is not valid", typeof(string))]
        [SwaggerResponse(HttpStatusCode.OK, "Role added to user")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid")]
        public async Task<IHttpActionResult> AddToRole(string userId, string roleId)
        {
            if (userId == null || roleId == null)
                return BadRequest();
            var result = await _roleManager.AddToRole(userId, roleId);
            return result.Succeeded ? (IHttpActionResult)NotFound() : Ok();
        }

        [HttpDelete]
        [Route("{userId:length(36)}/role/{roleId}/remove")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NotFound, "Data is not valid", typeof(string))]
        [SwaggerResponse(HttpStatusCode.OK, "Role removed from user")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid")]
        public async Task<IHttpActionResult> RemoveFromRole(string userId, string roleId)
        {
            if (userId == null || roleId == null)
                return BadRequest();
            var removeResult = await _roleManager.RemoveFromRole(userId, roleId);
            return removeResult.Succeeded ?  Ok() : (IHttpActionResult)NotFound();
        }

        [HttpGet]
        [Route("{userId:length(36)}/roles")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NotFound, "Data is not valid", typeof(string))]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid")]
        public IHttpActionResult GetRoles(string userId)
        {
            if (userId == null)
                return BadRequest();
            return _roleManager.GetRoles(userId) == null ? (IHttpActionResult)NotFound() : Ok();
        }

        [HttpGet]
        [Route("{userId:length(36)}/role/{roleId}/has")]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.NotFound, "Data is not valid", typeof(string))]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Data is not valid")]
        public async Task<IHttpActionResult> IsInRole(string userId, string roleId)
        {
            if (userId == null || roleId == null)
                return BadRequest();

            var isInRoleResult = await _roleManager.IsInRole(userId, roleId);

            return isInRoleResult ? Ok() : (IHttpActionResult)NotFound();
        }
    }
}