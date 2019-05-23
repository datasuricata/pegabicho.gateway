using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Arguments.Core.Surveys;
using pegabicho.domain.Interfaces.Services.Core;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : CoreController {
        private readonly IServiceSurvey serviceSurvey;
        public SurveyController(IServiceSurvey serviceSurvey) {
            this.serviceSurvey = serviceSurvey;
        }

        [HttpGet("getById")]
        public IActionResult GetById(string id) {
            return Result((SurveyResponse)serviceSurvey.GetById(id));
        }

        [HttpGet("listSurveys")]
        public IActionResult ListSurveys() {
            return Result(serviceSurvey.ListSurveys().ConvertAll(e => (SurveyResponse)e));
        }

        [HttpGet("listSurveysByType")]
        public IActionResult ListSurveysByType(SurveyType type) {
            return Result(serviceSurvey.ListSurveysByType(type).ConvertAll(e => (SurveyResponse)e));
        }

        [HttpPost("addSurvey")]
        public IActionResult AddSurvey([FromBody] SurveyRequest request) {
            serviceSurvey.AddSurvey(request);
            return Result(new ResponseBase("Vistoria criada com sucesso."));
        }

        [HttpDelete("softDelete")]
        public IActionResult softDelete(string id) {
            serviceSurvey.SoftDelete(id);
            return Result(new ResponseBase("Registro desativado com sucesso."));
        }
    }
}
