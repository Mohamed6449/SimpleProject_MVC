using MCV_Empity.Models;
using MCV_Empity.Services.Implementations;
using MCV_Empity.Services.InterFaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MCV_Empity.Controllers
{
	public class productController : Controller
	{
		private readonly IProductService _IproductService;
		private IFileServiece _IFileServiece;
		public productController(IProductService productService,IFileServiece fileServiece)
		{
			_IproductService = productService;
			_IFileServiece = fileServiece;
		}
		public ActionResult Index()
		{

			var products = _IproductService.GetProducts();

			return View(products);

		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task <IActionResult> Create(product model)
		{
            try
            {


                if (ModelState.IsValid)
                {
					var path = "";
					if (model.File?.Length > 0)
					{

                       path = await _IFileServiece.Upload(model.File,"/image/");
                        if (path == "Not saved")
                        {
                            return BadRequest();
                        }
                    }

					model.path = path;


				_IproductService.AddProduct(model);
                return RedirectToAction(nameof(Index));
				}
				else
				{
					return View(model);
				}
		
			

			}
			catch(Exception)
			{
				return View();

			}
		
		}

		public IActionResult Details(int Id)
		{
			var products = _IproductService.GetProductById(Id);
			return View(products);
		}

		public IActionResult Update(int Id) {
			var pro = _IproductService.GetProductById(Id);
			return View(pro);
		}
		[HttpPost]
		public async Task< IActionResult> IUpdate(product model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var path = model.path;
					if (model.File?.Length > 0)
					{
						_IFileServiece.DeleteSource(path);
						path = await _IFileServiece.Upload(model.File, "/image/");
						if (path == "Not saved")
						{
							return BadRequest();
						}
					}

					model.path = path;
					_IproductService.UpdateProduct(model);
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

		public IActionResult Delete(int Id)
		{
			var pro = _IproductService.GetProductById(Id);
			return View(pro);
		}
		[HttpPost]
		public IActionResult IDelete(int Id)
		{
			_IproductService.DeleteProduct(Id);

			return RedirectToAction(nameof(Index));
		}
	}
}
