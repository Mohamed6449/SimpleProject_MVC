using AutoMapper;
using MCV_Empity.Models;
using MCV_Empity.Services.Implementations;
using MCV_Empity.Services.InterFaces;
using MCV_Empity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		public async Task< ActionResult> Index()
		{

			var products =await _IproductService.GetProducts();

			return View(products);

		}
		public async Task<IActionResult> Create()
		{
			ViewBag.Category= new SelectList(await	_categoryServices.GetCategories(),"Id","Name");
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
					//var product = new product()
					//{
					//	Name = model.Name,
					//	Price = model.Price
					//	,
					//	CategoryId = model.CategoryId
					//};
				await _IproductService.AddProduct(product,model.Files);
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.Category = new SelectList(await _categoryServices.GetCategories(), "Id", "Name");
					return View(model);
				}
		
			

			}
			catch(Exception)
			{
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
			return View(pro);
		}
		[HttpPost]
		public async Task< IActionResult> IUpdate(product model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var product = await _IproductService.GetProductById(model.Id);
					if(product == null)
					{
						return NotFound();
					}
					/*var path = model.path;
					if (model.File?.Length > 0)
					{
						_IFileServiece.DeleteSource(path);
						path = await _IFileServiece.Upload(model.File, "/image/");
						if (path == "Not saved")
						{
							return BadRequest();
						}
					}

					model.path = path;*/
					await _IproductService.UpdateProduct(model);
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
			var pro = await _IproductService.GetProductById(Id);
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
		public async Task< IActionResult >IsProductNameExist(string name)
		{
			var result =await _IproductService.IsProductNameExist(name);
			
			return Json(!result);
		}
	}
}
