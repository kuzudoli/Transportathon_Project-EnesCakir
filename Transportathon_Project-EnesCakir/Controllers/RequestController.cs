using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Models.ViewModels;
using Transportathon_Project_EnesCakir.Services.Interfaces;

namespace Transportathon_Project_EnesCakir.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CancelRequest(int requestId)
        {
            var request = await _requestService.FirstOrDefaultAsync(x => x.Id == requestId);
            if (request == null)
                return RedirectToAction("Index", "Client");

            await _requestService.RemoveAsync(request);

            return RedirectToAction("MyRequests", "Client");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bir hata ile karşılaşıldı!");
                return RedirectToAction("CreateRequest", "Client", new { companyId = request.CompanyId });
            }

            var model = _mapper.Map<Request>(request);
            var result = await _requestService.AddAsync(model);
            if (result == null)
                return RedirectToAction("CreateRequest", "Client", new { companyId = request.CompanyId });

            return RedirectToAction("Index", "Client");
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest(EditRequestViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bir hata ile karşılaşıldı!");
                return RedirectToAction("MyRequests", "Client");
            }

            var updateModel = await _requestService.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (updateModel == null)
                return RedirectToAction("MyRequests", "Client");

            updateModel.FromAdress = request.FromAdress;
            updateModel.FromFloor = request.FromFloor;
            updateModel.ToAdress = request.ToAdress;
            updateModel.ToFloor = request.ToFloor;
            updateModel.RequestTypeId = request.RequestTypeId;
            updateModel.ExtraMessage = request.ExtraMessage;
            updateModel.TransportDate = request.TransportDate;

            await _requestService.UpdateAsync(updateModel);

            return RedirectToAction("EditRequest", "Client", new { requestId = request.Id });
        }
    }
}
