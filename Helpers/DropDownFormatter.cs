using BlockBuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlockBuster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace BlockBuster.WebApp.Helpers
{
    public class DropDownFormatter
    {
        public static SelectList FormatDirectors()
        {
           return new SelectList(BasicFunctions.GetAllDirectors()
                .OrderBy(d => d.LastName)
                .ToDictionary(d => d.DirectorId, d => d.LastName + ", " + d.FirstName), "Key", "Value");
        }

        public static SelectList FormatGenres()
        {
            return new SelectList(BasicFunctions.GetAllGenres()
                 .OrderBy(g => g.GenreDescr)
                 .ToDictionary(g => g.GenreId, g => g.GenreDescr), "Key", "Value");
        }
    }

}
