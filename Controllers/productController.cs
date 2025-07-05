using AutoMapper;
using MCV_Empity.Models;
using MCV_Empity.Services.Implementations;
using MCV_Empity.Services.InterFaces;
using MCV_Empity.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Reflection;

namespace MCV_Empity.Controllers
{
    public class productController : Controller
	{
		private readonly IProductService _IproductService;
		private IFileServiece _IFileServiece;
		private ICategoryServices _categoryServices;
		private readonly IMapper _mapper;
		public productController(IProductService productService,IFileServiece fileServiece, ICategoryServices categoryServices ,IMapper mapper)
		{
			_IproductService = productService;
			_IFileServiece = fileServiece;
			_categoryServices = categoryServices;
			_mapper=mapper;
		}
		[HttpGet]
		public async Task<ActionResult> Index(string? search)
		{

			//var cook=Request.Cookies["UserName"];
			//var ses = HttpContext.Session.GetString("UserName");
			
			//ViewBag.Cook = ses;

			var products = _IproductService.GetProductsAsQerayable(search);

			var result =await _mapper.ProjectTo<GetProductListViewModel>(products).ToListAsync();

			return View(result);
		}

		[HttpGet]
		public async Task<ActionResult> SearchProductList(string? searchtext)
		{

			//var cook=Request.Cookies["UserName"];
			//var ses = HttpContext.Session.GetString("UserName");

			//ViewBag.Cook = ses;

			var products = _IproductService.GetProductsAsQerayable(searchtext);

			var result = await _mapper.ProjectTo<GetProductListViewModel>(products).ToListAsync();

			return PartialView("_ProductList",result);


		}
		public async Task<IActionResult> Create()
		{
			ViewBag.Category= new SelectList(await	_categoryServices.GetCategories(),"Id", "NameAr");
			return View();
		}

		[HttpPost]
		public async Task <IActionResult> Create(AddProductViewModels model)
		{
            try
            {

				
                if (ModelState.IsValid)
                {
					var product = _mapper.Map<product>(model);
					var result=await _IproductService.AddProduct(product,model.Files);
					if (result != "Success")
					{

						ViewBag.Category = new SelectList(await _categoryServices.GetCategories(), "Id", "Name");
						TempData["Failed"]=result;

						return View(model);
					}


					//var product = new product()
					//{
					//	Name = model.Name,
					//	Price = model.Price
					//	,
					//	CategoryId = model.CategoryId
					//};
					TempData["Success"] = "Create Successfully ";
					return RedirectToAction(nameof(Index));
				}
				TempData["Failed"] = "valid data";
				ViewBag.Category = new SelectList(await _categoryServices.GetCategories(), "Id", "Name");
				return View(model);
		
			

			}
			catch(Exception ex)
			{
				TempData["Failed"] = ex.Message +"--"+ex.InnerException;
				ViewBag.Category = new SelectList(await _categoryServices.GetCategories(), "Id", "Name");
				return View();

			}
		
		}

		public  async Task< IActionResult> Details(int Id)
		{
			var products =await _IproductService.GetProductById(Id);
			return View(products);
		}

		public async Task<IActionResult> UpdateAsync(int Id) {
			var pro = await _IproductService.GetProductById(Id);

			var result = _mapper.Map<UpdateProductViewModel>(pro);

			ViewBag.Category = new SelectList(await _categoryServices.GetCategories(), "Id", "NameAr");
			return View(result);
		}
		[HttpPost]
		public async Task< IActionResult> Update(UpdateProductViewModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var product = await _IproductService.GetProductByIdWithOutInclude(model.Id);
					if(product == null)
					{
						return NotFound();
					}
					product = _mapper.Map<product>(model);
	
					await _IproductService.UpdateProduct(product,model.Files);


					return RedirectToAction(nameof(Index));
				}
				else
				{
					return View(model);
				}



			}
			catch (Exception)
			{
				return View(model.Id);

			}



		}

		public async Task<IActionResult> Delete(int Id)
		{
			var pro = await _IproductService.GetProductByIdWithOutInclude(Id);
			return View(pro);
		}
		[HttpPost]
		public async Task< IActionResult> IDelete(int Id)
		{
			try
			{
				var productR = await _IproductService.GetProductById(Id);
				if (productR == null)
				{
					return NotFound();
				}
				await _IproductService.DeleteProduct(productR);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
				
			}

		}

		[HttpPost]
		public async Task< IActionResult >IsProductNameArExist(string name)
		{
			var result =await _IproductService.IsProductNameArExist(name);
			
			return Json(!result);
		}
		[HttpPost]
		public async Task< IActionResult >IsProductNameEnExist(string name)
		{
			var result =await _IproductService.IsProductNameEnExist(name);
			
			return Json(!result);
		}
	}
}
