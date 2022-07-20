using Microsoft.AspNetCore.Mvc;

namespace ProjectPass2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]

    public class GenericController : ControllerBase
    {

        private readonly ILogger<GenericController> _logger;

        public GenericController(ILogger<GenericController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// /Основной метод генерации данных: принимает целое значение длинны пароля и длинны соли
        ///  для дальнейшего использования в программе, для получения 
        ///  сгенерированного пароля соли и хеша 
        ///  
        ///
        /// </summary>
        /// 
        /// 
        /// <param name="ls">Параметр для длинны соли</param>
        /// 
        /// <param name="lp">Параметр для длинны пароля</param>
        /// <returns></returns>
       ///
        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public Optimal Get(int ls, int lp)
        {
            Optimal _class = ClassPHS.Rezerv(ls, lp);
            return _class;
        }
    }
}