using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkingWithEFCore;

namespace Web.index
{
  public class IndexModel : PageModel  //Hereda de PageMode. PageModel es una clase que contiene propiedades y métodos que se pueden usar para administrar la solicitud HTTP para una página Razor y para seleccionar la página Razor que se va a ejecutar.
  {  //IndexModel actuá como el modelo de datos para la página Razor.
    public List<Category> categories { get; set; } //Lista que almacena las categorías de la base de datos.

    [BindProperty (SupportsGet = true)]
    public int? CategoryId { get; set; }


    public void OnGet() //Método que se ejecuta cuando se carga la página.
    {
      using (Northwind db = new()) //Se crea una instancia de la base de datos.
      {
        categories = db.Categories.ToList(); //Se obtienen las categorías de la base de datos y se almacenan en la lista.
      }

      
      if(CategoryId is not null)
      {
            if( CategoryId>0)
        {
            
        using(Northwind db = new()) //conexión con la base de datos
        {
           
            Category categories = db.Categories.FirstOrDefault(cat => cat.CategoryId == CategoryId);
            if(categories is not  null )
            {
        
                db.Categories.Remove(categories); //remover la categoría de la base de datos
                db.SaveChanges(true); //guardar los cambios en la base de datos
            }
            
            
        }

        }
      

        
      }



    }

 


    
    
    
  }
}