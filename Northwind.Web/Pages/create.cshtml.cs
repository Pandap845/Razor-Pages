using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorkingWithEFCore;

namespace Web.Create
{
  public class CreateModel : PageModel  //Hereda de PageMode. PageModel es una clase que contiene propiedades y métodos que se pueden usar para administrar la solicitud HTTP para una página Razor y para seleccionar la página Razor que se va a ejecutar.
  { 
   [BindProperty (SupportsGet=true)]
    public string? Name { get; set; }  //Propiedad Name de la categoria

    [BindProperty (SupportsGet=true)]
    public string? Description_t { get; set; }  //Propiedad Description de la categoria
    


   public void OnGet() //Método que se ejecuta cuando se carga la página.
   {
        if(Name is not null && Description_t is not null)
       {
          using(Northwind db = new())
             {
              Category category = new()              {
                     CategoryName = Name,
                     Description = Description_t
                 };  //Crear un objeto con los datos mandados por el formulario
              
                 db.Categories.Add(category); //Agregar el objeto a la base de datos
                 db.SaveChanges(); //Guardar los cambios en la base de datos
                
           }

          

    }
   }

  //Método que se ejecuta cuando se envía el formulario.
 
   
  /*  public IActionResult OnPost() //Método que se ejecuta cuando se envía el formulario.
   {
        if(Name is not null && Description_t is not null)
       {
          using(Northwind db = new())
             {
              Category category = new()
              {
                     CategoryName = Name,
                     Description = Description_t
                 };  //Crear un objeto con los datos mandados por el formulario
              
                 db.Categories.Add(category); //Agregar el objeto a la base de datos
                 db.SaveChanges(); //Guardar los cambios en la base de datos
                
           }

 
         }
      return Page();
      }
       */

       
    }
  
}