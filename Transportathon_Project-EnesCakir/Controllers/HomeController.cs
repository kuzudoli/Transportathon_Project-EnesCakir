using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Transportathon_Project_EnesCakir.Models;
using Transportathon_Project_EnesCakir.Services.Interfaces;

namespace Transportathon_Project_EnesCakir.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public HomeController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _companyService.GetCompaniesForHomePage();
            return View(companies);
        }
    }
}