using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.Design;
using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Models.ViewModels;
using Transportathon_Project_EnesCakir.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Transportathon_Project_EnesCakir.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;
        private readonly IEmployeeService _employeeService;
        private readonly IRequestTypeService _requestTypeService;
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public ClientController(ICompanyService companyService, IEmployeeService employeeService, UserManager<AppUser> userManager, IRequestTypeService requestTypeService, IMapper mapper, IRequestService requestService)
        {
            _companyService = companyService;
            _employeeService = employeeService;
            _userManager = userManager;
            _requestTypeService = requestTypeService;
            _mapper = mapper;
            _requestService = requestService;
        }

        public async Task<IActionResult> Index()
        {
            var companyList = new List<CompanyViewModel>();

            var companies = await _companyService.GetAllAsync();
            var employees = await _employeeService.GetAllAsync();

            companyList.AddRange(companies.Select(x => new CompanyViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                EstablishmentDate = x.EstablishmentDate,
                EmployeeCount = employees.Where(e => e.CompanyId == x.Id).Count()
            }));

            return View(companyList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRequest(int companyId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            if (user == null)
                return RedirectToAction(nameof(Index));

            var company = await _companyService.FirstOrDefaultAsync(x => x.Id == companyId);
            if (company == null)
                return RedirectToAction(nameof(Index));

            ViewBag.UserId = user.Id;
            ViewBag.CompanyDetails = _mapper.Map<CompanyViewModel>(company);

            var reqTypes = await _requestTypeService.GetAllAsync();
            ViewBag.RequestTypes = new SelectList(reqTypes, "Id", "Name");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyRequests()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            if (user == null)
                return RedirectToAction(nameof(Index));

            var requests = await _requestService.GetRequestListWithCompanyName(user.Id);
            return View(requests);
        }

        [HttpGet]
        public async Task<IActionResult> EditRequest(int requestId)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            if (user == null)
                return RedirectToAction(nameof(Index));

            var requestModel = await _requestService.FirstOrDefaultAsync(x => x.Id == requestId);
            if (requestModel == null || requestModel.UserId != user.Id)
                return RedirectToAction(nameof(Index));
            var requestViewModel = _mapper.Map<EditRequestViewModel>(requestModel);

            var company = await _companyService.FirstOrDefaultAsync(x => x.Id == requestModel.CompanyId);
            if (company == null)
                return RedirectToAction(nameof(Index));
            ViewBag.CompanyName = company.Name;

            var reqTypes = await _requestTypeService.GetAllAsync();
            ViewBag.RequestTypes = new SelectList(reqTypes, "Id", "Name");

            return View(requestViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
                throw new Exception("Bir hata oluştu!");

            var userViewModel = _mapper.Map<EditUserViewModel>(user);

            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CompanyDetails(int companyId)
        {
            var company = await _companyService.FirstOrDefaultAsync(x => x.Id == companyId);
            var employees = await 
            if (company == null)
                return RedirectToAction(nameof(Index));


        }
    }
}