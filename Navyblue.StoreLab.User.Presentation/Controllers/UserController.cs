using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Navyblue.StoreLab.User.Application.Commands.UserRegister;
using Navyblue.StoreLab.User.Presentation.Requests;

namespace Navyblue.StoreLab.User.Presentation.Controllers
{
    /// <summary>
    /// 需要注意的是，每个request需要映射成command，通过消息进一步进行数据处理，此处需要考虑的是，如何抽象一层，使得request可以更加便捷而又轻量的映射成command
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _iMapper;

        public UsersController(IMediator mediator, IMapper iMapper)
        {
            this._mediator = mediator;
            this._iMapper = iMapper;
        }

        /// <summary>
        /// Users the register.
        /// </summary>
        /// <param name="registerRequest">The register request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> UserRegister(UserRegisterRequest registerRequest)
        {
            UserRegisterCommand? command = this._iMapper.Map<UserRegisterRequest, UserRegisterCommand>(registerRequest);

            int result = await this._mediator.Send(command);

            return await Task.FromResult(result);
        }
    }
}
